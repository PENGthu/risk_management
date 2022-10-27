using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Data.Common;
using Microsoft.Office.Interop.Excel;
using Series = System.Windows.Forms.DataVisualization.Charting.Series;
using DataTable = System.Data.DataTable;
using Chart = System.Windows.Forms.DataVisualization.Charting.Chart;
using Rectangle = System.Drawing.Rectangle;

namespace Dataset_Manager
{
    public partial class Form2Pearson_MultiImage : Form
    {
        public Chart chart1, chart2;
        public static string seriesname;
        public static List<double> doubles;
        public static List<double> doubles1;
        public static List<double> doubles2;
        public static int flag; //用于指示下一个窗口打开的是直方图还是相关性图
        public static int type = 0; //用于指示显示的是柱状图(type = 1),箱形图(type = 2),置信区间图(type = 3)
        public static bool std; //用于指示是否标准化

        static StripLine sl1; //第一条stripline
        static StripLine sl2; //第二条stripline
        static TextAnnotation txt1; //文字批注，表示百分比
        static TextAnnotation txt2;
        static TextAnnotation txt3;
        static TextAnnotation txt4;
        static TextAnnotation txt5;
        static TextAnnotation txt6;

        public Form2Pearson_MultiImage()
        {
            InitializeComponent();
        }

        private static void MultiFrequency(List<double> total, List<double> input, int n, out List<double> X, out List<int> Y)
        {
            X = new List<double>();
            Y = new List<int>();

            double d = (total.Max() - total.Min()) / n; //区间长度
            int freq; //频数
            for (int i = 0; i <= n - 2; i++)
            {
                freq = 0;
                for (int j = 0; j < input.Count; j++)
                {
                    if ((input[j] >= total.Min() + i * d) && (input[j] < total.Min() + (i + 1) * d))
                        freq++;
                }
                X.Add(total.Min() + 0.5 * (2 * i + 1) * d);
                Y.Add(freq);
            }

            freq = 0;
            for (int j = 0; j < input.Count; j++)
            {
                if ((input[j] >= total.Min() + (n - 1) * d) && (input[j] <= total.Max()))
                    freq++;
            }
            X.Add(total.Min() + (n - 0.5) * d);
            Y.Add(freq);
        }

        private void ConfidenceDraw(string name, List<double> input, Chart chart)
        {
            Series series = new Series();
            series = chart.Series.Add(name);
            series.ChartType = SeriesChartType.Line;
            series.LegendText = name;

            int xValue = 0;
            foreach(double i in input)
            {
                series.Points.AddXY(xValue, i);
                xValue++;
            }

            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisX.Maximum = input.Count - 1;

            chart.ChartAreas[0].AxisX.Interval = double.NaN;
            chart.ChartAreas[0].AxisY.Minimum = double.NaN;
            chart.ChartAreas[0].AxisY.Maximum = double.NaN;
            chart.ChartAreas[0].AxisX.LabelStyle.Enabled = true;
            chart.ChartAreas[0].AxisX.MajorTickMark.Enabled = true;
        }

        private void OptChartDraw(string type, bool std, DataTable dt, Chart chart)
        {
            dataGridView1.Visible = false;
            optional_chart.Visible = true;
            label1.Visible = true;
            Yes.Visible = true;
            No.Visible = true;

            chart.Series.Clear(); //清空原有图形
            chart.Annotations.Clear();
            dataGridView2.Rows.Clear();
            List<List<double>> source = new List<List<double>>(); //用于保存画入图中的数据

            for (int i = 0; i <= dt.Columns.Count - 1; i++) //对数据表的每列进行操作
            {
                List<double> source0 = new List<double>();
                List<double> source0_ = new List<double>();
                ArrayList temp = Dataset.GetColumn(dt, i);
                for (int j = 0; j < temp.Count; j++) //对数据表的每列存入数组source
                    source0.Add(Convert.ToDouble(temp[j]));
                if (std == false) //非标准化：直接将source0复制到source
                    source0.ForEach(j => source0_.Add(j));
                else //标准化处理
                    source0_ = Dataset.Stantardize(source0);
                source.Add(source0_);
            }

            /*以下两个定义：将所有数据表列的数据放在一起统计，因为横坐标的范围为所有数据的最小到最大值，纵坐标的范围为所有列频数的最大值*/
            List<double> Xscale = new List<double>(); //用于存放所有的数据
            List<int> YMax = new List<int>(); //用于存放频数的最大值
            for (int i = 0; i <= source.Count - 1; i++)
            {
                for(int j = 0; j <= source[i].Count - 1; j++)
                    Xscale.Add(source[i][j]);
                List<double> temp1 = new List<double>();
                List<int> temp2 = new List<int>();
                ChartDraw.GetFrequency(source[i], 10, out temp1, out temp2);
                YMax.Add(temp2.Max());
            }

            if (type == "column") //柱状图
            {
                optional_chart.Visible = true;
                dataGridView2.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;

                chart.Series.Clear(); //清空原有图形
                chart.Annotations.Clear();
                chart.ChartAreas[0].AxisX.StripLines.Clear();
                dataGridView2.Rows.Clear();
                dataGridView2.Columns.Clear();
                dataGridView2.Columns.Add("properties", "属性"); //先添加列，之后才能向表格中添加行
                dataGridView2.Columns.Add("value", "值");
                for (int i = 0; i <= dt.Columns.Count - 1; i++)
                {
                    string name = dt.Columns[i].ColumnName; //数据列名称name
                    List<double> X = new List<double>();
                    List<int> Y = new List<int>();
                    MultiFrequency(Xscale, source[i], 10, out X, out Y); //对X、Y赋值为区间、频数
                    
                    chart.Series.Add(name); //系列名称
                    chart.Series[name].ChartType = SeriesChartType.Column; //定义chart1类型：柱状图
                    chart.Series[name].Points.DataBindXY(X, Y); //将X（区间）、Y（频数）绑定到chart1上
                    chart.Series[name].Label = "#VAL"; //在柱子上显示频数的值
                    chart.Series[name]["PointWidth"] = "1"; //<1: 柱间有间隙；=1：柱间无间隙; >1: 柱子会有重合叠压
                    chart.Series[name].BorderColor = System.Drawing.Color.Black;
                    chart.Series[name].BorderWidth = 1;
                    chart.Refresh();

                    for (int j = 0; j <= 6; j++)
                    {
                        DataGridViewRow row = new DataGridViewRow(); //每次向表格中添加一行，方便后续多个系列重复调用
                        DataGridViewTextBoxCell cell1 = new DataGridViewTextBoxCell(); //向行中添加格
                        DataGridViewTextBoxCell cell2 = new DataGridViewTextBoxCell();
                        row.Cells.Add(cell1);
                        row.Cells.Add(cell2);
                        switch (j)
                        {
                            case 0:
                                row.Cells[0].Value = name;
                                row.Cells[1].Value = null;
                                break;
                            case 1:
                                row.Cells[0].Value = "最小值";
                                row.Cells[1].Value = Dataset.Parameter(source[i])[0];
                                break;
                            case 2:
                                row.Cells[0].Value = "最大值";
                                row.Cells[1].Value = Dataset.Parameter(source[i])[1];
                                break;
                            case 3:
                                row.Cells[0].Value = "平均值";
                                row.Cells[1].Value = Dataset.Parameter(source[i])[2];
                                break;
                            case 4:
                                row.Cells[0].Value = "标准差";
                                row.Cells[1].Value = Dataset.Parameter(source[i])[4];
                                break;
                            case 5:
                                row.Cells[0].Value = "计数";
                                row.Cells[1].Value = Dataset.Parameter(source[i])[9];
                                break;
                            default:
                                row.Cells[0].Value = null;
                                row.Cells[1].Value = null;
                                break;
                        }
                        dataGridView2.Rows.Add(row);
                    }

                    dataGridView2.RowHeadersVisible = false; //设置行表头不可见
                    dataGridView2.AllowUserToAddRows = false; //设置用户不可添加行
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //设置列充满表格
                }

                chart.ChartAreas[0].AxisX.Maximum = double.NaN; //X轴坐标最大值改为自动模式(因为confidence图时改了此值）
                chart.ChartAreas[0].AxisX.Minimum = double.NaN; //X轴坐标最小值改为自动模式(因为confidence图时改了此值）
                chart.ChartAreas[0].AxisX.Interval = (Xscale[1] - Xscale[0]) / 2; //横坐标刻度的差值为1/2柱子宽,这样柱子两边能有刻度值
                chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false; //以下两行：去掉网格线
                chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                chart.ChartAreas[0].AxisX.Maximum = double.NaN;
                chart.ChartAreas[0].AxisX.Minimum = double.NaN;
                chart.ChartAreas[0].AxisY.Minimum = 0; //以下三行：设置Y轴显示区间，频数从0到最大频数的1.5倍（美观）
                chart.ChartAreas[0].AxisY.Maximum = (int)(1.5 * YMax.Max());
                chart.ChartAreas[0].AxisX.LabelStyle.Format = "N2"; //柱图X轴保留两位小数
                chart.ChartAreas[0].AxisY.LabelStyle.Format = "N0"; //柱图Y轴为整数
                chart.ChartAreas[0].AxisX.LabelStyle.Enabled = true; //X轴显示标签
                chart.ChartAreas[0].AxisX.MajorTickMark.Enabled = true; //显示X轴刻度线
                chart.Refresh();

                ChartDraw.chart = chart;
                ChartDraw.ColumnChart_AnnotationAdd(Xscale, 0.885 * chart.ChartAreas[0].AxisY.Maximum, out sl1, out sl2, out txt1, out txt2, out txt3, textBox1, textBox2);
            }
            else if(type == "box") //箱形图
            {
                optional_chart.Visible = true; //调整控件可见性
                dataGridView2.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;

                chart.Series.Clear(); //清空原有图形
                chart.Annotations.Clear();     
                chart.ChartAreas[0].AxisX.StripLines.Clear();
                string totalname = "";
                for (int i = 0; i <= dt.Columns.Count - 1; i++)
                {
                    string name = dt.Columns[i].ColumnName;
                    Series series = chart.Series.Add(name);
                    series.Enabled = false;
                    series.Points.DataBindY(source[i]);
                    if(i == 0)
                        totalname += name;
                    else
                        totalname += ";" + name;
                }
                Series sd = chart.Series.Add("Boxplot");
                sd.ChartType = SeriesChartType.BoxPlot; //定义chart类型：箱形图
                sd["BoxPlotSeries"] = totalname;
                sd["BoxPlotWhiskerPercentile"] = "0"; //定义箱形图盒须，不设为0则比例不对
                chart.ChartAreas[0].AxisX.Maximum = double.NaN;
                chart.ChartAreas[0].AxisX.Minimum = double.NaN;
                chart.ChartAreas[0].AxisY.Minimum = Xscale.Min() - 0.1 * (Xscale.Max() - Xscale.Min());
                chart.ChartAreas[0].AxisY.Maximum = Xscale.Max() - 0.1 * (Xscale.Max() - Xscale.Min());
                chart.ChartAreas[0].AxisY.LabelStyle.Format = "N2"; //箱形图Y轴保留两位小数
                chart.ChartAreas[0].AxisX.LabelStyle.Enabled = false; //箱形图不显示X轴标签
                chart.ChartAreas[0].AxisX.MajorTickMark.Enabled = false; //箱形图不显示X轴刻度线
                chart.Refresh();
            }

            else if(type == "confidence") //置信区间图
            {
                /*初始准备工作*/
                optional_chart.Visible = true; //调整控件可见性
                dataGridView2.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;

                chart.Series.Clear(); //清空原有图形
                chart.Annotations.Clear();
                chart.ChartAreas[0].AxisX.StripLines.Clear();
                 
                /*准备折线数据源*/
                List<double> list_95 = new List<double>();
                List<double> list_5 = new List<double>();
                List<double> list_avg = new List<double>();
                List<double> list_upperstd = new List<double>();
                List<double> list_lowerstd = new List<double>();
                for(int i = 0; i < source.Count; i++)
                {
                    list_5.Add(Dataset.Parameter(source[i])[5]);
                    list_95.Add(Dataset.Parameter(source[i])[8]);
                    list_avg.Add(Dataset.Parameter(source[i])[2]);
                    list_upperstd.Add(Dataset.Parameter(source[i])[2] + Dataset.Parameter(source[i])[4]);
                    list_lowerstd.Add(Dataset.Parameter(source[i])[2] - Dataset.Parameter(source[i])[4]);
                }

                ConfidenceDraw("95%", list_95, chart);
                ConfidenceDraw("5%", list_5, chart);
                ConfidenceDraw("平均值", list_avg, chart);
                ConfidenceDraw("+1标准差", list_upperstd, chart);
                ConfidenceDraw("-1标准差", list_lowerstd, chart);
            }
        }

        /// <summary>
        /// 窗体初始化
        /// 初始状态：显示dataGridView列举各变量间缩略图
        /// 获取数据表dt_P信息，画图并存入dataGridView1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2Pearson_MultiImage_Load(object sender, EventArgs e)
        {
            /*初始只显示表格*/
            dataGridView1.Visible = true;
            optional_chart.Visible = false;
            dataGridView2.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            Yes.Visible = false;
            No.Visible = false;

            /*对于第i行、第i+1列（行、列变量相同）：画直方图*/
            for (int i = 0; i <= Form2Pearson.dt_P.Columns.Count - 1; i++)
            {
                /*数据传递*/
                List<double> source = new List<double>();
                ArrayList temp = Dataset.GetColumn(Form2Pearson.dt_P, i);
                for (int j = 0; j < temp.Count; j++) //对数据表的每列存入数组source
                    source.Add(Convert.ToDouble(temp[j]));

                /*新建表格dataGridView1*/
                string name = Form2Pearson.dt_P.Columns[i].ColumnName; //数据列名称name
                dataGridView1.Rows.Add(name); //添加名称为name的表格行，并将名称填入表格第一列
                dataGridView1[0, i].Value = Form2Pearson.dt_P.Columns[i];
                DataGridViewImageColumn column = new DataGridViewImageColumn(); //新建并添加名称为name的表格列
                column.Name = name;
                column.Width = 1020 / Form2Pearson.dt_P.Columns.Count; //根据列数设置列宽使得恰好充满表格（试出来的）
                column.HeaderText = name;
                dataGridView1.Columns.Add(column);
                
                /*画频率分布图*/
                chart1 = new Chart();
                chart1.Annotations.Clear();
                chart1.ChartAreas.Add(name);
                ChartDraw.chart = chart1;
                ChartDraw.ColumnChart_SeriesAdd(name, source);

                /*将画好的图存到内存里，再根据要显示的尺寸从内存中调用显示到dataGridView1中*/
                MemoryStream ms1 = new MemoryStream();
                chart1.SaveImage(ms1, ChartImageFormat.Bmp);
                Bitmap bmp1 = new Bitmap(ms1);
                Bitmap bmp2 = new Bitmap(column.Width, column.Width);
                Graphics graph = Graphics.FromImage(bmp2);
                graph.DrawImage(bmp1, new Rectangle(0, 0, column.Width, column.Width));
                graph.Dispose();
                dataGridView1[i + 1, i].Value = bmp2;
            }
            
            /*对于其他的行、列（行、列变量不相同）：画相关性图*/
            for(int i = 0; i <= Form2Pearson.dt_P.Columns.Count - 1; i++)
            {
                for(int j = 1; j <= Form2Pearson.dt_P.Columns.Count; j++)
                {
                    List<double> source1 = new List<double>();
                    List<double> source2 = new List<double>();
                    ArrayList temp1 = Dataset.GetColumn(Form2Pearson.dt_P, i);
                    ArrayList temp2 = Dataset.GetColumn(Form2Pearson.dt_P, j-1);
                    for (int n = 0; n < temp1.Count; n++) //对数据表的每列存入数组source1,source2（注意：有temp1.Count = temp2.Count）
                    {
                        if ((temp1[n] != null) && (temp2[n] != null)) //当temp1和temp2在这一位置皆不为空时才添加；如果有一个为空则跳过
                        {
                            source1.Add(Convert.ToDouble(temp1[n]));
                            source2.Add(Convert.ToDouble(temp2[n]));
                        }
                    }

                    string name1 = Form2Pearson.dt_P.Columns[i].ColumnName; //数据列名称name1,name2
                    string name2 = Form2Pearson.dt_P.Columns[j - 1].ColumnName;
                    chart2 = new Chart();
                    chart2.Series.Add(name1 + "-" + name2);
                    chart2.ChartAreas.Add(name1 + "-" + name2);
                    chart2.Series[name1 + "-" + name2].ChartType = SeriesChartType.Point;
                    chart2.Series[name1 + "-" + name2].Points.DataBindXY(source2, source1);
                    chart2.Refresh();

                    MemoryStream ms2 = new MemoryStream();
                    chart2.SaveImage(ms2, ChartImageFormat.Bmp);
                    Bitmap bmp1 = new Bitmap(ms2);
                    Bitmap bmp2 = new Bitmap(628 / Form2Pearson.dt_P.Columns.Count, 628 / Form2Pearson.dt_P.Columns.Count);
                    Graphics graph = Graphics.FromImage(bmp2);
                    graph.DrawImage(bmp1, new Rectangle(0, 0, 628 / Form2Pearson.dt_P.Columns.Count, 628 / Form2Pearson.dt_P.Columns.Count));
                    graph.Dispose();
                    if (j != i + 1)
                        dataGridView1[j, i].Value = bmp2;
                }
            }    
        }

        /// <summary>
        /// 点击表格中的图像可查看放大后的统计图
        /// 若选中的是直方图，则将该数据列存入doubles，其中doubles[0]为该列序号，doubles[1]开始为数据列
        /// 若选中的是相关性图，则将两列存入arr1,arr2，将两列数值存入doubles1,doubles2，其中doubles1和doubles2的第一个元素是两列的列序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == e.RowIndex + 1) //选中的是单个数据列的频率分布时，将数据列存入doubles
            {
                doubles = new List<double>();
                doubles.Add(e.RowIndex); //doubles[0]为选中列在数据表中的列号（从0开始），doubles[1]开始为数据表元素
                ArrayList temp = Dataset.GetColumn(Form2Pearson.dt_P, e.RowIndex);
                for (int i = 0; i < temp.Count; i++)
                    doubles.Add(Convert.ToDouble(temp[i]));
                seriesname = Form2Pearson.dt_P.Columns[e.RowIndex].ColumnName;
                flag = 1;
                Form2Pearson.sign = 2;

                Form2Pearson_SingleImage form2Pearson_SingleImage2 = new Form2Pearson_SingleImage();
                form2Pearson_SingleImage2.Show();
            }
            else //否则选中的是两列相关性图，将两列分别存入doubles1,doubles2
            {
                ArrayList arr1 = new ArrayList();
                ArrayList arr2 = new ArrayList();
                doubles1 = new List<double>();
                doubles2 = new List<double>();
                doubles1.Add(e.RowIndex); //doubles1和doubles2的第一个元素是所代表数据列的序号
                doubles2.Add(e.ColumnIndex - 1);
                arr1 = Dataset.GetColumn(Form2Pearson.dt_P, e.RowIndex);
                arr2 = Dataset.GetColumn(Form2Pearson.dt_P, e.ColumnIndex - 1);
                for (int n = 0; n < arr1.Count; n++) //arr1.Count = arr2.Count
                {
                    if ((arr1[n] != null) && (arr2[n] != null))
                    {
                        doubles1.Add(Convert.ToDouble(arr1[n]));
                        doubles2.Add(Convert.ToDouble(arr2[n]));
                    }
                }
                seriesname = Form2Pearson.dt_P.Columns[e.RowIndex].ColumnName + "-" + Form2Pearson.dt_P.Columns[e.ColumnIndex - 1].ColumnName;
                flag = 2;
                Form2Pearson_Correlation form2Pearson_Correlation = new Form2Pearson_Correlation();
                form2Pearson_Correlation.Show();
            }
        }

        private void DataGridViewShow_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
        }

        private void Column_Click(object sender, EventArgs e)
        {
            Column.Checked = true;
            Box.Checked = false;
            Confidence.Checked = false;
            if (Yes.Checked)
                OptChartDraw("column", true, Form2Pearson.dt_P, optional_chart);
            else if (No.Checked)
                OptChartDraw("column", false, Form2Pearson.dt_P, optional_chart);
        }

        private void Box_Click(object sender, EventArgs e)
        {
            Column.Checked = false;
            Box.Checked = true;
            Confidence.Checked = false;
            if (Yes.Checked)
                OptChartDraw("box", true, Form2Pearson.dt_P, optional_chart);
            else if (No.Checked)
                OptChartDraw("box", false, Form2Pearson.dt_P, optional_chart);
        }

        private void Confidence_Click(object sender, EventArgs e)
        {
            Column.Checked = false;
            Box.Checked = false;
            Confidence.Checked = true;
            if (Yes.Checked)
                OptChartDraw("confidence", true, Form2Pearson.dt_P, optional_chart);
            else if (No.Checked)
                OptChartDraw("confidence", false, Form2Pearson.dt_P, optional_chart);
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            if (Column.Checked == true)
                OptChartDraw("column", true, Form2Pearson.dt_P, optional_chart);
            else if (Box.Checked == true)
                OptChartDraw("box", true, Form2Pearson.dt_P, optional_chart);
            else if (Confidence.Checked == true)
                OptChartDraw("confidence", true, Form2Pearson.dt_P, optional_chart);
        }

        private void No_Click(object sender, EventArgs e)
        {
            if (Column.Checked == true)
                OptChartDraw("column", false, Form2Pearson.dt_P, optional_chart);
            else if (Box.Checked == true)
                OptChartDraw("box", false, Form2Pearson.dt_P, optional_chart);
            else if (Confidence.Checked == true)
                OptChartDraw("confidence", false, Form2Pearson.dt_P, optional_chart);
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
