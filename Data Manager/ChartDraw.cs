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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Chart = System.Windows.Forms.DataVisualization.Charting.Chart;
using Label = System.Windows.Forms.Label;
using Series = System.Windows.Forms.DataVisualization.Charting.Series;
using TextBox = System.Windows.Forms.TextBox;

namespace Dataset_Manager
{
    internal class ChartDraw
    {
        public static Chart chart;

        /// <summary>
        /// 对输入的数据列input进行处理，区间分成n段，得到X轴和Y轴（方便将数据绑定到直方图）
        /// </summary>
        /// <param name="input"></param>
        /// <param name="n"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public static void GetFrequency(List<double> input, int n, out List<double> X, out List<int> Y)
        {
            X = new List<double>();
            Y = new List<int>();

            double d = (input.Max() - input.Min()) / n; //区间长度
            int freq; //频数
            for (int i = 0; i <= n - 2; i++)
            {
                freq = 0;
                for (int j = 0; j < input.Count; j++)
                {
                    if ((input[j] >= input.Min() + i * d) && (input[j] < input.Min() + (i + 1) * d))
                        freq++;
                }
                X.Add(input.Min() + 0.5 * (2 * i + 1) * d);
                Y.Add(freq);
            }

            freq = 0;
            for (int j = 0; j < input.Count; j++)
            {
                if ((input[j] >= input.Min() + (n - 1) * d) && (input[j] <= input.Max()))
                    freq++;
            }
            X.Add(input.Min() + (n - 0.5) * d);
            Y.Add(freq);
        }

         /// <summary>
         /// 向柱状图中添加系列
         /// </summary>
         /// <param name="name"></param>系列名称
         /// <param name="source"></param>要分析的原始数据列
         /// <param name="chart"></param>图表
        public static void ColumnChart_SeriesAdd(string name, List<double> source)
        {
            List<double> X = new List<double>();
            List<int> Y = new List<int>();
            ChartDraw.GetFrequency(source, 10, out X, out Y); //对X、Y赋值为区间、频数
            chart.Series.Add(name); //系列名称
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false; //以下两行：去掉网格线
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart.Series[name].ChartType = SeriesChartType.Column; //定义chart1类型：柱状图
            chart.Series[name].Points.DataBindXY(X, Y); //将X（区间）、Y（频数）绑定到chart1上
            chart.Series[name].Label = "#VAL"; //在柱子上显示频数的值
            chart.Series[name]["PointWidth"] = "1"; //<1: 柱间有间隙；=1：柱间无间隙; >1: 柱子会有重合叠压
            chart.ChartAreas[0].AxisX.Interval = (X[1] - X[0]) / 2; //横坐标刻度的差值为1/2柱子宽,这样柱子两边能有刻度值
            chart.Series[name].BorderColor = System.Drawing.Color.Black;
            chart.Series[name].BorderWidth = 1;
            chart.ChartAreas[0].AxisY.Minimum = 0; //以下三行：设置Y轴显示区间，频数从0到最大频数的1.5倍（美观）
            chart.ChartAreas[0].AxisY.Maximum = (int)(1.5 * Y.Max());
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "N2"; //柱图X轴保留两位小数
            chart.ChartAreas[0].AxisY.LabelStyle.Format = "N0"; //柱图Y轴为整数
            chart.ChartAreas[0].AxisX.LabelStyle.Enabled = true; //X轴显示标签
            chart.ChartAreas[0].AxisX.MajorTickMark.Enabled = true; //显示X轴刻度线
            chart.Refresh();
        }

        /// <summary>
        /// 在柱状图旁边添加图注，显示数据参数信息
        /// </summary>
        /// <param name="name"></param>系列名称
        /// <param name="dtgv"></param>显示参数的列表
        /// <param name="parameter"></param>参数组成的序列，依次为：最小值，最大值，平均值，中位数，标准差，5%，25%，75%,95%，计数
        public static void ColumnChart_StatementAdd(string name, DataGridView dtgv, List<double> parameter)
        {
            dtgv.Columns.Add("properties", "属性"); //先添加列，之后才能向表格中添加行
            dtgv.Columns.Add("value", "值");
            for (int i = 0; i <= 6; i++)
            {
                DataGridViewRow row = new DataGridViewRow(); //每次向表格中添加一行，方便后续多个系列重复调用
                DataGridViewTextBoxCell cell1 = new DataGridViewTextBoxCell(); //向行中添加格
                DataGridViewTextBoxCell cell2 = new DataGridViewTextBoxCell();
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                switch (i)
                {
                    case 0:
                        row.Cells[0].Value = name;
                        row.Cells[1].Value = null;
                        break;
                    case 1:
                        row.Cells[0].Value = "最小值";
                        row.Cells[1].Value = parameter[0];
                        break;
                    case 2:
                        row.Cells[0].Value = "最大值";
                        row.Cells[1].Value = parameter[1];
                        break;
                    case 3:
                        row.Cells[0].Value = "平均值";
                        row.Cells[1].Value = parameter[2];
                        break;
                    case 4:
                        row.Cells[0].Value = "标准差";
                        row.Cells[1].Value = parameter[4];
                        break;
                    case 5:
                        row.Cells[0].Value = "计数";
                        row.Cells[1].Value = parameter[9];
                        break;
                    default:
                        row.Cells[0].Value = null;
                        row.Cells[1].Value = null;
                        break;
                }
                dtgv.Rows.Add(row);
            }
            dtgv.RowHeadersVisible = false; //设置行表头不可见
            dtgv.AllowUserToAddRows = false; //设置用户不可添加行
            dtgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //设置列充满表格
        }

        /// <summary>
        /// 向柱状图添加百分比条及百分比数字
        /// </summary>
        /// <param name="source"></param>柱状图的原始数据列
        /// <param name="chart"></param>柱状图图表
        /// <param name="Y"></param>设置百分比条位置高度
        public static void ColumnChart_AnnotationAdd(List<double> source, double Y, out StripLine sl1, out StripLine sl2, out TextAnnotation txt1, out TextAnnotation txt2, out TextAnnotation txt3, TextBox txtbx1, TextBox txtbx2)
        {
            RectangleAnnotation percentbar = new RectangleAnnotation(); //矩形批注，表示百分比条
            percentbar.AxisX = chart.ChartAreas[0].AxisX; //将图的X轴绑定到批注，这样批注的位置才能和X轴联系起来
            percentbar.AxisY = chart.ChartAreas[0].AxisY; //将图的Y轴绑定到批注
            percentbar.IsSizeAlwaysRelative = false; //批注的大小不是相对于图表坐标的
            percentbar.X = source.Min(); //以下两行：设置批注框为从X轴最小值到最大值
            percentbar.Y = Y;
            percentbar.Width = source.Max() - source.Min();
            percentbar.Height = 0.067 * chart.ChartAreas[0].AxisY.Maximum;
            percentbar.BackColor = Color.Transparent; //使批注框为透明，防止覆盖stripline
            chart.Annotations.Add(percentbar);
            chart.Invalidate();

            chart.ChartAreas[0].AxisX.StripLines.Clear(); //先清除原先的striplines
            sl1 = new StripLine(); //新建第一条stripline -sl1
            sl1.BackImage = $@"{System.AppDomain.CurrentDomain.BaseDirectory}指示线2.png";
            sl1.BackImageWrapMode = ChartImageWrapMode.Scaled; //设置线的绘制模式
            sl1.BackImageAlignment = ChartImageAlignmentStyle.Center; //设置线对齐方式
            sl1.IntervalOffset = Dataset.Parameter(source)[5];// 设置线的位置        
            sl1.StripWidth = 0.05 * (source.Max() - source.Min());//设置线的宽度           
            sl1.TextOrientation = TextOrientation.Horizontal; //lable的文字的方向
            chart.ChartAreas[0].AxisX.StripLines.Add(sl1);//在chart1中插入垂直于X轴的StripLine sl1 

            sl2 = new StripLine();//新建第二条stripline -sl2
            sl2.BackImage = $@"{System.AppDomain.CurrentDomain.BaseDirectory}指示线3.png";
            sl2.BackImageWrapMode = ChartImageWrapMode.Scaled;
            sl2.BackImageAlignment = ChartImageAlignmentStyle.Center;
            sl2.IntervalOffset = Dataset.Parameter(source)[8];
            sl2.StripWidth = 0.05 * (source.Max() - source.Min());
            sl2.TextOrientation = TextOrientation.Horizontal;
            chart.ChartAreas[0].AxisX.StripLines.Add(sl2);//在chart1中插入垂直于X轴的StripLine sl2

            txt1 = new TextAnnotation(); //新建文字批注1，用于显示中间部分百分比
            txt1.AxisX = chart.ChartAreas[0].AxisX; //将图的X,Y轴绑定到批注
            txt1.AxisY = chart.ChartAreas[0].AxisY;
            txt1.IsSizeAlwaysRelative = false; //批注的大小不是相对于图表坐标的
            txt1.Width = 0.1 * (source.Max() - source.Min()); //设置批注宽度
            txt1.Height = 0.033 * chart.ChartAreas[0].AxisY.Maximum; //设置批注高度：等于百分比条高度的一半
            txt1.X = sl1.IntervalOffset + 0.5 * (sl2.IntervalOffset - sl1.IntervalOffset - txt1.Width); //使批注在两条线间居中
            txt1.Y = percentbar.Y + 0.017 * chart.ChartAreas[0].AxisY.Maximum; //使批注在百分比条上下居中
            txt1.Text = "90.0%";
            chart.Annotations.Add(txt1);
            chart.Invalidate();

            txt2 = new TextAnnotation(); //新建文字批注2，用于左侧百分比
            txt2.AxisX = chart.ChartAreas[0].AxisX; //将图的X,Y轴绑定到批注
            txt2.AxisY = chart.ChartAreas[0].AxisY;
            txt2.IsSizeAlwaysRelative = false; //批注的大小不是相对于图表坐标的
            txt2.Width = 0.1 * (source.Max() - source.Min()); //设置批注宽度
            txt2.Height = 0.033 * chart.ChartAreas[0].AxisY.Maximum; //设置批注高度：等于百分比条高度的一半
            txt2.X = source.Min() - 1.1 * txt2.Width;
            txt2.Y = txt1.Y;
            txt2.Text = "5.0%";
            chart.Annotations.Add(txt2);
            chart.Invalidate();

            txt3 = new TextAnnotation(); //新建文字批注3，用于显示右侧部分百分比
            txt3.AxisX = chart.ChartAreas[0].AxisX; //将图的X,Y轴绑定到批注
            txt3.AxisY = chart.ChartAreas[0].AxisY;
            txt3.IsSizeAlwaysRelative = false; //批注的大小不是相对于图表坐标的
            txt3.Width = 0.1 * (source.Max() - source.Min()); //设置批注宽度
            txt3.Height = 0.033 * chart.ChartAreas[0].AxisY.Maximum; //设置批注高度：等于百分比条高度的一半
            txt3.X = source.Max() + 0.1 * txt3.Width;
            txt3.Y = txt1.Y;
            txt3.Text = "5.0%";
            chart.Annotations.Add(txt3);
            chart.Invalidate();

            txtbx1.Text = $"{sl1.IntervalOffset:F3}";
            txtbx2.Text = $"{sl2.IntervalOffset:F3}";
        }

        public static void BoxChart_SeriesAdd(string name, List<double> source)
        {
            Series series = chart.Series.Add(name);
            series.Enabled = false;
            series.Points.DataBindY(source); //将source绑定到箱形图数据源
            Series sd = chart.Series.Add("Boxplot");
            sd.ChartType = SeriesChartType.BoxPlot; //定义chart1类型：箱形图
            sd["BoxPlotSeries"] = name;
            sd["BoxPlotWhiskerPercentile"] = "0"; //定义箱形图盒须，不设为0则比例不对
            chart.ChartAreas[0].AxisY.Minimum = source.Min() - 0.1 * (source.Max() - source.Min());
            chart.ChartAreas[0].AxisY.Maximum = source.Max() - 0.1 * (source.Max() - source.Min());
            chart.ChartAreas[0].AxisY.LabelStyle.Format = "N2"; //箱形图Y轴保留两位小数
            chart.ChartAreas[0].AxisX.LabelStyle.Enabled = false; //箱形图不显示X轴标签
            chart.ChartAreas[0].AxisX.MajorTickMark.Enabled = false; //箱形图不显示X轴刻度线
            chart.Refresh();
        }
    }
}
