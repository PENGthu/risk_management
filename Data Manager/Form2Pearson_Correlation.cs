using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Dataset_Manager
{
    public partial class Form2Pearson_Correlation : Form
    {
        DataTable dt_Cor;
        List<double> source1;
        List<double> source2;
        static int num; //元素个数
        static StripLine sl1; //第一条stripline
        static StripLine sl2; //第二条stripline
        static double xv;  //移动strpline时实时的x轴坐标
        static double yv; //移动stripline时实时的y轴坐标
        //static double temp1;
        //static double temp2;
        //static double temp3;
        //static double temp4;
        static int striplineselcet = 2; //=0时第一条stripline被选中，=1时第二条被选中，其他值则都没选中

        public Form2Pearson_Correlation()
        {
            InitializeComponent();
        }

        private void Form2Pearson_Correlation_Load(object sender, EventArgs e)
        {
            /*操作combobox*/
            comboBox1.Items.Add("数据");
            comboBox1.Items.Add("统计量");

            /*处理数据源*/
            source1 = new List<double>();
            num = Form2Pearson_MultiImage.doubles1.Count; //由于在建立doubles1,doubles2的时候判断两列数据皆不为空，因此doubles1和doubles2项数是相等的
            for (int i = 1; i < num; i++)
                source1.Add(Form2Pearson_MultiImage.doubles1[i]);
            source2 = new List<double>();
            for (int i = 1; i < num; i++)
                source2.Add(Form2Pearson_MultiImage.doubles2[i]);
            double d1 = source1.Max() - source1.Min();
            double d2 = source2.Max() - source2.Min();
            //MessageBox.Show(source1[0].ToString() + "\r\n" + source2[0].ToString() + "\r\n");

            /*画图*/
            chart1.Series.Clear();
            chart1.Series.Add(Form2Pearson_MultiImage.seriesname);
            chart1.Series[Form2Pearson_MultiImage.seriesname].ChartType = SeriesChartType.Point;
            chart1.Series[Form2Pearson_MultiImage.seriesname].Points.DataBindXY(source2, source1);
            chart1.ChartAreas[0].AxisX.Minimum = source2.Min() - 0.1 * d2;
            chart1.ChartAreas[0].AxisX.Maximum = source2.Max() + 0.1 * d2;
            chart1.ChartAreas[0].AxisY.Minimum = source1.Min() - 0.1 * d1;
            chart1.Refresh();
            
            chart1.ChartAreas[0].AxisX.StripLines.Clear(); //先清除原先的striplines
            sl1 = new StripLine(); //新建第一条stripline -sl1
            sl1.BackImage = $@"{System.AppDomain.CurrentDomain.BaseDirectory}指示线2.png";
            sl1.BackImageWrapMode = ChartImageWrapMode.Scaled; //设置线的绘制模式
            sl1.BackImageAlignment = ChartImageAlignmentStyle.Center; //设置线对齐方式
            sl1.IntervalOffset = source2.Min();// 设置线的位置        
            sl1.StripWidth = 0.05 * d2;//设置线的宽度
            sl1.TextAlignment = StringAlignment.Near;
            sl1.TextOrientation = TextOrientation.Horizontal; //lable的文字的方向
            chart1.ChartAreas[0].AxisX.StripLines.Add(sl1);//在chart1中插入垂直于X轴的StripLine sl1 

            sl2 = new StripLine(); //新建第二条stripline -sl2
            sl2.BackImage = $@"{System.AppDomain.CurrentDomain.BaseDirectory}指示线4.png";
            sl2.BackImageWrapMode = ChartImageWrapMode.Scaled;
            sl2.BackImageAlignment = ChartImageAlignmentStyle.Center;
            sl2.IntervalOffset = source1.Min();
            sl2.StripWidth = 0.05 * d1;
            sl2.TextAlignment = StringAlignment.Near;
            sl2.TextOrientation = TextOrientation.Rotated90;
            chart1.ChartAreas[0].AxisY.StripLines.Add(sl2);//在chart1中插入垂直于Y轴的StripLine sl2

            /*将数据传入数据表dt_Cor中*/
            dt_Cor = new DataTable();
            DataColumn column1 = new DataColumn(); //新建两个数据表列，将两个数据列添加进去
            DataColumn column2 = new DataColumn();
            column1 = Form2Pearson.dt_P.Columns[(int)(Form2Pearson_MultiImage.doubles1[0])];
            column2 = Form2Pearson.dt_P.Columns[(int)(Form2Pearson_MultiImage.doubles2[0])];
            dt_Cor.Columns.Add(column1.ColumnName, column1.DataType);
            dt_Cor.Columns.Add(column2.ColumnName, column2.DataType);
            for (int i = 0; i < Form2Pearson_MultiImage.doubles1.Count - 1; i++) //逐行添加数据，doubles1.Count = doubles2.Count
            {
                DataRow row = dt_Cor.NewRow();
                row[0] = Form2Pearson.dt_P.Rows[i][(int)(Form2Pearson_MultiImage.doubles1[0])];
                row[1] = Form2Pearson.dt_P.Rows[i][(int)(Form2Pearson_MultiImage.doubles2[0])];
                dt_Cor.Rows.Add(row);
            }

            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
        }

        /// <summary>
        /// 统计每个象限分布的数据点个数
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="xv"></param>
        /// <param name="yv"></param>
        /// <param name="quadrant1"></param>
        /// <param name="quadrant2"></param>
        /// <param name="quadrant3"></param>
        /// <param name="quadrant4"></param>
        private void Interpolation(DataTable dt, double xv, double yv, out int quadrant1, out int quadrant2, out int quadrant3, out int quadrant4)
        {
            int n = dt.Rows.Count;
            quadrant1 = 0;
            quadrant2 = 0;
            quadrant3 = 0;
            quadrant4 = 0;
            for(int i = 0; i < n; i++)
            {
                if (Convert.ToDouble(dt.Rows[i][0]) > yv && Convert.ToDouble(dt.Rows[i][1]) > xv)
                    quadrant1++;
                if (Convert.ToDouble(dt.Rows[i][0]) <= yv && Convert.ToDouble(dt.Rows[i][1]) > xv)
                    quadrant4++;
                if (Convert.ToDouble(dt.Rows[i][0]) <= yv && Convert.ToDouble(dt.Rows[i][1]) <= xv)
                    quadrant3++;
                if (Convert.ToDouble(dt.Rows[i][0]) > yv && Convert.ToDouble(dt.Rows[i][1]) <= xv)
                    quadrant2++;
            }
        }

         /// <summary>
         /// 计算Pearson相关系数，前提是x.Count = y.Count
         /// </summary>
         /// <param name="x"></param>
         /// <param name="y"></param>
         /// <returns></returns>
        private double Pearson(List<double> x, List<double> y)
        {
            List<double> para_x = new List<double>();
            List<double> para_y = new List<double>();
            para_x = Dataset.Parameter(x);
            para_y = Dataset.Parameter(y);
            int n = x.Count;
            double average_x = para_x[2];
            double average_y = para_y[2];
            double devi_x = para_x[4];
            double devi_y = para_y[4];
            double cov = 0;
            for(int i = 0; i < n;i++)
                cov += (x[i]- average_x) * (y[i] - average_y) / n;
            double P = cov / (devi_x * devi_y);
            return P;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            if (comboBox1.Text == "数据")
            {
                dataGridView1.Visible = true;
                dataGridView2.Visible = false;
                dataGridView1.DataSource = null; //初始化表格
                dataGridView1.DataSource = dt_Cor;
            }
            else if(comboBox1.Text == "统计量")
            {
                dataGridView1.Visible = false;
                dataGridView2.Visible = true;
                dataGridView2.Rows.Clear();
                dataGridView2.Columns.Clear(); //初始化表格
                dataGridView2.Columns.Add("属性", null);
                dataGridView2.Columns.Add("数值", null);
                dataGridView2.Rows.Add(12);
                dataGridView2[0, 0].Value = "X平均值";
                dataGridView2[1, 0].Value = Dataset.Parameter(source2)[2].ToString();
                dataGridView2[0, 1].Value = "X标准差";
                dataGridView2[1, 1].Value = Dataset.Parameter(source2)[4].ToString();
                dataGridView2[0, 2].Value = "Y平均值";
                dataGridView2[1, 2].Value = Dataset.Parameter(source1)[2].ToString();
                dataGridView2[0, 3].Value = "Y标准差";
                dataGridView2[1, 3].Value = Dataset.Parameter(source1)[4].ToString();
                dataGridView2[0, 4].Value = "相关（皮尔逊）";
                dataGridView2[1, 4].Value = Pearson(source1, source2);
                dataGridView2[0, 5].Value = "相关（等级）";
                dataGridView2[0, 6].Value = "定界符X";
                dataGridView2[1, 6].Value = sl1.IntervalOffset.ToString();
                dataGridView2[0, 7].Value = "定界符Y";
                dataGridView2[1, 7].Value = sl2.IntervalOffset.ToString();
                dataGridView2[0, 8].Value = "象限I";
                dataGridView2[0, 9].Value = "象限II"; 
                dataGridView2[0, 10].Value = "象限III";
                dataGridView2[0, 11].Value = "象限IV";

                int quadrant1, quadrant2, quadrant3, quadrant4;
                double temp1, temp2, temp3, temp4;
                Interpolation(dt_Cor, sl1.IntervalOffset, sl2.IntervalOffset, out quadrant1, out quadrant2, out quadrant3, out quadrant4);
                temp1 = 100 * Convert.ToDouble(quadrant1) / Convert.ToDouble(num -1);
                temp2 = 100 * Convert.ToDouble(quadrant2) / Convert.ToDouble(num -1);
                temp3 = 100 * Convert.ToDouble(quadrant3) / Convert.ToDouble(num -1);
                temp4 = 100 * Convert.ToDouble(quadrant4) / Convert.ToDouble(num - 1);
                MessageBox.Show(sl1.IntervalOffset.ToString()+"\r\n"+sl2.IntervalOffset.ToString()+"\r\n"+quadrant1.ToString() + "\r\n" + quadrant2.ToString() + "\r\n" + quadrant3.ToString() + "\r\n" + quadrant4.ToString() + "\r\n");
                dataGridView2[1, 8].Value = $"{temp1:F1}%";
                dataGridView2[1, 9].Value = $"{temp2:F1}%";
                dataGridView2[1, 10].Value = $"{temp3:F1}%";
                dataGridView2[1, 11].Value = $"{temp4:F1}%";
            }
        }

        private void Form2Pearson_Correlation_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void Form2Pearson_Correlation_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void chart1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;//右键忽略        
            HitTestResult hit = chart1.HitTest(e.X, e.Y);

            if (hit.Object.Equals(sl1))
            {
                this.Cursor = Cursors.SizeWE; //鼠标变成左右有箭头的形式                
                striplineselcet = 0; //标识：第一条线被选中
                this.chart1.MouseMove += new MouseEventHandler(chart1_MouseMove);
            }
            else if (hit.Object.Equals(sl2))
            {
                this.Cursor = Cursors.SizeNS; //鼠标变成上下箭头的形式
                striplineselcet = 1; //标识：第二条线被选中
                this.chart1.MouseMove += new MouseEventHandler(chart1_MouseMove);
            }
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            var area = chart1.ChartAreas[0];

            HitTestResult hit = chart1.HitTest(e.X, e.Y);
            //需先判断鼠标在绘图区，否则PixelPositionToValue会超出范围
            if (hit.ChartElementType == ChartElementType.PlottingArea)
            {
                xv = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);//xv是定义好的全局变量，x轴的坐标
                yv = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);//yv是定义好的全局变量，y轴的坐标
                if (striplineselcet == 0)
                {
                    sl1.IntervalOffset = xv;
                    sl1.Text = $"{xv:F3}";
                    chart1.Invalidate();

                    if(comboBox1.Text == "统计量")
                    {
                        dataGridView2[1, 6].Value = sl1.IntervalOffset.ToString();
                        int quadrant1, quadrant2, quadrant3, quadrant4;
                        double temp1, temp2, temp3, temp4;
                        Interpolation(dt_Cor, sl1.IntervalOffset, sl2.IntervalOffset, out quadrant1, out quadrant2, out quadrant3, out quadrant4);
                        temp1 = 100 * Convert.ToDouble(quadrant1) / Convert.ToDouble(num - 1);
                        temp2 = 100 * Convert.ToDouble(quadrant2) / Convert.ToDouble(num - 1);
                        temp3 = 100 * Convert.ToDouble(quadrant3) / Convert.ToDouble(num - 1);
                        temp4 = 100 * Convert.ToDouble(quadrant4) / Convert.ToDouble(num - 1);
                        dataGridView2[1, 8].Value = $"{temp1:F1}%";
                        dataGridView2[1, 9].Value = $"{temp2:F1}%";
                        dataGridView2[1, 10].Value = $"{temp3:F1}%";
                        dataGridView2[1, 11].Value = $"{temp4:F1}%";
                    }
                }
                if (striplineselcet == 1)
                {
                    sl2.IntervalOffset = yv;
                    sl2.Text = $"{yv:F3}";
                    chart1.Invalidate();

                    if (comboBox1.Text == "统计量")
                    {
                        dataGridView2[1, 7].Value = sl2.IntervalOffset.ToString();
                        int quadrant1, quadrant2, quadrant3, quadrant4;
                        double temp1, temp2, temp3, temp4;
                        Interpolation(dt_Cor, sl1.IntervalOffset, sl2.IntervalOffset, out quadrant1, out quadrant2, out quadrant3, out quadrant4);
                        temp1 = 100 * Convert.ToDouble(quadrant1) / Convert.ToDouble(num - 1);
                        temp2 = 100 * Convert.ToDouble(quadrant2) / Convert.ToDouble(num - 1);
                        temp3 = 100 * Convert.ToDouble(quadrant3) / Convert.ToDouble(num - 1);
                        temp4 = 100 * Convert.ToDouble(quadrant4) / Convert.ToDouble(num - 1);
                        dataGridView2[1, 8].Value = $"{temp1:F1}%";
                        dataGridView2[1, 9].Value = $"{temp2:F1}%";
                        dataGridView2[1, 10].Value = $"{temp3:F1}%";
                        dataGridView2[1, 11].Value = $"{temp4:F1}%";
                    }
                }
                //以下为测试鼠标移动时x轴的坐标变动，xv的值显示在label5和6里
                //if (striplineselcet == 0)
                //{
                //    label5.Text = "line1 x:";//如果是第一条线被选中。$"..."是字符串插值表示，F3：3位有效数字
                //    textBox1.Text = $"{xv:F3}";
                //}
                //if (striplineselcet == 1)
                //{
                //    label6.Text = "line2 x:";//如果是第二条线被选中
                //    textBox2.Text = $"{xv:F3}";
                //}
            }
        }

        private void chart1_MouseUp(object sender, MouseEventArgs e)
        {
            if (striplineselcet == 0)
                sl1.IntervalOffset = xv;
            else if (striplineselcet == 1)
                sl2.IntervalOffset = yv;

            chart1.Invalidate(); //相当于refresh, 根据sl1/sl2的新位置重新绘制chart1

            striplineselcet = 2; //改变标识，表示没有线被选中
            this.Cursor = Cursors.Default;//鼠标变回默认形态
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
