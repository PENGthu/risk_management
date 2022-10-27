using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Chart = System.Windows.Forms.DataVisualization.Charting.Chart;
using Label = System.Windows.Forms.Label;
using Series = System.Windows.Forms.DataVisualization.Charting.Series;

namespace Dataset_Manager
{
    public partial class Form2Pearson_SingleImage : Form
    {
        /*定义以下全局变量*/
        static List<double> source0; //存放原始数据列
        static List<double> source; //存放最终读入图表的数据
        static List<double> para;
        static int num; //项数
        
        static string dataname;
        static int striplineselcet = 2; //=0时第一条stripline被选中，=1时第二条被选中，其他值则都没选中
        static double xv;  //移动strpline时实时的x轴坐标
        static StripLine sl1; //第一条stripline
        static StripLine sl2; //第二条stripline
        static TextAnnotation txt1; //文字批注，表示百分比
        static TextAnnotation txt2;
        static TextAnnotation txt3;
        static double temp1;
        static double temp2;

        public Form2Pearson_SingleImage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 判断是否标准化，输出判断后处理的结果，同时输出匹配的各参数（按定义的顺序放在数组result中）
        /// 选择标准化时，可调用Form2Pearson中的计算结果，避免重复计算
        /// </summary>
        /// <param name="check"></param>选择是否标准化
        /// <param name="input"></param>输入的数组
        /// <param name="source"></param>选择是/否标准化后输出的作为数据源的数组
        /// <param name="result"></param>参数数组，共10项，依次：最小值，最大值，平均值，中位数，标准差，5%，25%，75%，95%，计数
        private void GetParameter(bool check, List<double> input, out List<double> source, out List<double> result)
        {
            source = new List<double>();
            result = new List<double>();
            if (check == false) //标准化：否
            {
                /*弹出框为查看单个数据列时*/
                //字典Form2Pearson.dtSingle_P的值为参数序列，直接查找第j个元素即可
                if (Form2Pearson.sign == 1)
                {
                    for (int i = 0; i <= input.Count - 1; i++)
                        source.Add(input[i]);
                    for (int j = 0; j <= 9; j++)
                        result.Add(Form2Pearson.dtSingle_P[Form2Pearson.dt_Pcol][j]);
                }
                /*弹出框为查看多个数据列时*/
                //字典Form2Pearson.dtMulti_P的值为参数矩阵，此时应先获取对应的列号index，查找矩阵对应的列的第j个元素
                else if (Form2Pearson.sign == 2)
                {
                    for (int i = 1; i <= input.Count - 1; i++)
                        source.Add(input[i]);
                    int index = (int)(input[0]); //index可通过MutiImage中存储在数组的第一个值获得
                    for (int j = 0; j <= 9; j++)
                        result.Add(Form2Pearson.dtMulti_P[Form2Pearson.dt_P][index][j]);
                }
            }
            else //标准化：是
            {
                if(Form2Pearson.sign == 1) //查看单个数据列时，直接对source进行标准化
                    source = Dataset.Stantardize(input);
                else if(Form2Pearson.sign == 2) //否则先取出source的除去第一个元素的其他元素，再进行标准化
                {
                    List<double> temp = new List<double>();
                    for(int i = 1; i <= input.Count - 1; i++)
                        temp.Add(input[i]);
                    source = Dataset.Stantardize(temp);
                }
                for(int j = 0; j <= 9; j++)
                    result.Add(Dataset.Parameter(source)[j]);
            }
        }

        private void Chart1Draw(string type)
        {
            if(type == "column")
            {
                chart1.Series.Clear(); //清空原有图形
                chart1.Annotations.Clear();
                chart1.ChartAreas[0].AxisX.StripLines.Clear();
                dataGridView1.Columns.Clear();
                temp1 = 5.0;
                temp2 = 5.0;
                label4.Visible = true; //修改使标签可见
                label5.Visible = true;
                label6.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                dataGridView1.Visible = true;
                ChartDraw.ColumnChart_SeriesAdd(dataname, source);
                ChartDraw.ColumnChart_StatementAdd(dataname, dataGridView1, para);
                ChartDraw.ColumnChart_AnnotationAdd(source, 0.885 * chart1.ChartAreas[0].AxisY.Maximum, out sl1, out sl2, out txt1, out txt2, out txt3, textBox1, textBox2);
            }
            else if(type == "box")
            {
                chart1.Series.Clear(); //清空原有图形
                chart1.Annotations.Clear();
                chart1.ChartAreas[0].AxisX.StripLines.Clear();
                dataGridView1.Columns.Clear();
                label4.Visible = false; //对于stripline的注释在箱形图中不存在
                label5.Visible = false;
                label6.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                dataGridView1.Visible = false; //数据列表在箱形图中不存在
                ChartDraw.BoxChart_SeriesAdd(dataname, source);
            }
        }

        /// <summary>
        /// 返回input中小于或大于value的元素个数
        /// </summary>
        /// <param name="sign"></param>为true时返回小于value的值的个数，反之返回大于的个数
        /// <param name="input"></param>输入的数据列
        /// <param name="value"></param>插值的大小
        /// <returns></returns>
        private int Interpolation(bool sign, List<double> input, double value)
        {
            int res = 0;
            int i ;
            List<double> temp = new List<double>(); //建立input的副本temp，对temp排序便于计算，同时又不改变input
            input.ForEach(j => temp.Add(j));
            temp.Sort();
            if (sign == true) //返回小于value的值的个数
            {
                i = 0;
                while (value > temp[i])
                {
                    res++;
                    i++;
                }
            }
            else //返回大于value的值的个数
            {
                i = input.Count - 1;
                while (value < temp[i])
                {
                    res++;
                    i--;
                }
            }
            return res;
        }

        /// <summary>
        /// 初始化，传递图表所需数据源
        /// 如果是单个数据列查看，则直接将dt_Pcol的数据传入
        /// 如果是多个数据列的查看，则将doubles中的数据传入，在GetParameter函数中去除第一个元素作为数据源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2Pearson_SingleImage_Load(object sender, EventArgs e)
        {
            ChartDraw.chart = chart1;
            /*得到原始数据列参数*/
            source0 = new List<double>();
            if (Form2Pearson.sign == 1)
            {
                ArrayList temp0 = Dataset.GetColumn(Form2Pearson.dt_Pcol, 0);
                for (int i = 0; i < temp0.Count; i++)
                    source0.Add(Convert.ToDouble(temp0[i]));
                num = source0.Count;
                dataname = Form2Pearson.dt_Pcol.Columns[0].ColumnName;
            }
            else if (Form2Pearson.sign == 2)
            {
                Form2Pearson_MultiImage.doubles.ForEach(j => source0.Add(j));
                num = source0.Count - 1;
                dataname = Form2Pearson_MultiImage.seriesname;
            }
            source = new List<double>();
            GetParameter(false, source0, out source, out para);
            Chart1Draw("column");
        }

        private void Bar_CheckedChanged(object sender, EventArgs e)
        {
            source = new List<double>();
            if (No.Checked) //判断是否标准化
                GetParameter(false, source0, out source, out para);
            else
                GetParameter(true, source0, out source, out para);

            Chart1Draw("column"); //柱状图 
        }

        private void Box_CheckedChanged(object sender, EventArgs e)
        {
            source = new List<double>();
            if (No.Checked) //判断是否标准化
                GetParameter(false, source0, out source, out para);
            else
                GetParameter(true, source0, out source, out para);
            Chart1Draw("box"); //箱形图
        }

        private void Yes_CheckedChanged(object sender, EventArgs e)
        {
            GetParameter(true, source0, out source, out para); //标准化

            if (Bar.Checked) //判断图形类型
                Chart1Draw("column");
            else if (Box.Checked)
                Chart1Draw("box");
        }

        private void No_CheckedChanged(object sender, EventArgs e)
        {
            GetParameter(false, source0, out source, out para); //非标准化

            if (Bar.Checked) //判断图形类型
                Chart1Draw("column");
            else if (Box.Checked)
                Chart1Draw("box");
        }

        private void chart1_MouseDown_1(object sender, MouseEventArgs e) //鼠标按键按下时
        {
            if (e.Button == MouseButtons.Right) return;//右键忽略        
            HitTestResult hit = chart1.HitTest(e.X, e.Y);

            if (hit.Object.Equals(sl1))
            {
                this.Cursor = Cursors.SizeWE;//鼠标变成左右有箭头的形式                
                striplineselcet = 0; //标识：第一条线被选中
                this.chart1.MouseMove += new MouseEventHandler(chart1_MouseMove_1);
            }
            else if (hit.Object.Equals(sl2))
            {
                this.Cursor = Cursors.SizeWE;
                striplineselcet = 1; //标识：第二条线被选中
                this.chart1.MouseMove += new MouseEventHandler(chart1_MouseMove_1);
            }
        }

        private void chart1_MouseMove_1(object sender, MouseEventArgs e) //鼠标移动时
        {
            var area = chart1.ChartAreas[0];
            
            HitTestResult hit = chart1.HitTest(e.X, e.Y);
            //需先判断鼠标在绘图区，否则PixelPositionToValue会超出范围
            if (hit.ChartElementType == ChartElementType.PlottingArea)
            {
                xv = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);//xv是定义好的全局变量，x轴的坐标
                if (striplineselcet == 0)
                {
                    sl1.IntervalOffset = xv;
                    temp1 = 100 * Convert.ToDouble(Interpolation(true, source, xv)) / Convert.ToDouble(num);
                    txt2.Text = $"{temp1:F1}%";
                    txt1.X = sl1.IntervalOffset + 0.5 * (sl2.IntervalOffset - sl1.IntervalOffset - txt1.Width); //txt1的批注位置发生变化
                    txt1.Text = $"{(100 - temp1 - temp2):F1}%";
                    chart1.Invalidate();
                }
                if (striplineselcet == 1)
                {
                    sl2.IntervalOffset = xv;
                    temp2 = 100 * Convert.ToDouble(Interpolation(false, source, xv)) / Convert.ToDouble(num);
                    txt3.Text = $"{temp2:F1}%";
                    txt1.X = sl1.IntervalOffset + 0.5 * (sl2.IntervalOffset - sl1.IntervalOffset - txt1.Width); //txt1的批注位置发生变化
                    txt1.Text = $"{(100 - temp1 - temp2):F1}%";
                    chart1.Invalidate();
                }
                //以下为测试鼠标移动时x轴的坐标变动，xv的值显示在label5和6里
                if (striplineselcet == 0) //如果是第一条线被选中。$"..."是字符串插值表示，F3：3位有效数字
                    textBox1.Text = $"{xv:F3}";
                if (striplineselcet == 1) //如果是第二条线被选中
                    textBox2.Text = $"{xv:F3}";
            }
        }

        private void chart1_MouseUp_1(object sender, MouseEventArgs e) //鼠标按键释放时
        {
            if (striplineselcet == 0)
                sl1.IntervalOffset = xv;
            else if (striplineselcet == 1)
                sl2.IntervalOffset = xv;

            chart1.Invalidate(); //相当于refresh, 根据sl1/sl2的新位置重新绘制chart1

            striplineselcet = 2; //改变标识，表示没有线被选中
            this.Cursor = Cursors.Default;//鼠标变回默认形态
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
                sl1.IntervalOffset = Convert.ToDouble(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
                sl2.IntervalOffset = Convert.ToDouble(textBox2.Text);
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Form2Pearson.sign = 0;
            this.Dispose();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
