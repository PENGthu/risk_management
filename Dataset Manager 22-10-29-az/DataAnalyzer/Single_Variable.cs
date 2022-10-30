using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Dataset_Manager.DataAnalyzer
{
    public partial class Single_Variable : Form
    {
        static int form_count = 0;
        private DataTable _dt = new DataTable();
        int n, m;
        string variable_name;
        public Single_Variable()
        {
            InitializeComponent();
            this.Text = "数据分析器-单变量分析";
        }
        private void Single_Variable_Load(object sender, EventArgs e)
        {

            foreach (DataTable table in Dataset.DS.Tables) //读取所有DS的datatable名称,放入combobox
                comboBox1.Items.Add(table.TableName);
            if (Dataset.RecentDT != "")
            {
                _dt = Dataset.DS.Tables[Dataset.RecentDT];
                comboBox1.Text = Dataset.RecentDT;
                n = _dt.Columns.Count;
                m = _dt.Rows.Count;
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add(n);
                for (int i = 0; i < n; i++)
                {
                    variable_name = _dt.Columns[i].ColumnName;
                    dataGridView1[0, i].Value = false;
                    dataGridView1[1, i].Value = variable_name;
                }
            }

            checkBox1.Checked = true;
            checkBox2.Checked = true;
            checkBox3.Checked = true;
        }
        private void select_all_CheckedChanged(object sender, EventArgs e)
        {
            if (select_all.Checked)
                for (int i = 0; i < n; i++)
                    dataGridView1[0, i].Value = true;
            else
                for (int i = 0; i < n; i++)
                    dataGridView1[0, i].Value = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "") return;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1[0, i].Value.ToString().Length == 5) continue;
                Excel.Worksheet sheet = Dataset.app.Worksheets.Add();

                #region 基本信息
                double[] datalist = new double[m];//临时数据表
                int datacount = 0;//临时计数器
                for (int j = 0; j < m; j++)
                {
                    datalist[j] = (double)_dt.Rows[j][i];
                    if (datalist[j] != Dataset.INF) datacount++;
                }
                Array.Sort(datalist);
                double sum = 0.0;//求和
                for (int j = 0; j < datacount; j++) sum += datalist[j];

                sheet.Range["A2"].Value2 = "数据名称";
                sheet.Range["B2"].Value2 = _dt.Columns[i].ColumnName;
                sheet.Range["C2"].Value2 = "有效数据总数";
                sheet.Range["D2"].Value2 = datacount;
                int usedrows = 2;//记录使用过的行数
                #endregion

                #region 频率分布
                if (checkBox1.Checked)
                {
                    usedrows++;
                    sheet.Range["A" + usedrows.ToString()].Value2 = "5%";
                    sheet.Range["B" + usedrows.ToString()].Value2 = datalist[datacount / 20];
                    sheet.Range["C" + usedrows.ToString()].Value2 = "95%";
                    sheet.Range["D" + usedrows.ToString()].Value2 = datalist[(datacount * 19) / 20];

                }
                #endregion

                #region 集中趋势分布
                if (checkBox2.Checked)
                {
                    usedrows++;
                    sheet.Range["A" + usedrows.ToString()].Value2 = "平均数";
                    sheet.Range["B" + usedrows.ToString()].Value2 = sum / (double)datacount;
                    sheet.Range["C" + usedrows.ToString()].Value2 = "中位数";
                    sheet.Range["D" + usedrows.ToString()].Value2 = (datacount % 2 == 0 ? ((datalist[datacount / 2] + datalist[datacount / 2 - 1]) / 2.0) : datalist[(datacount - 1) / 2]);
                }
                #endregion

                #region 离散趋势分布
                if (checkBox3.Checked)
                {
                    usedrows++;
                    sheet.Range["A" + usedrows.ToString()].Value2 = "极差";
                    sheet.Range["B" + usedrows.ToString()].Value2 = datalist[datacount-1] - datalist[0];
                    double aver = sum / (double)datacount;
                    double sigma = 0.0;//标准差
                    for (int j = 0; j < datacount; j++)
                    {
                        sigma += (datalist[j] - aver) * (datalist[j] - aver);
                    }
                    sigma /= (double)datacount;
                    sigma = Math.Sqrt(sigma);
                    sheet.Range["C" + usedrows.ToString()].Value2 = "标准差";
                    sheet.Range["D" + usedrows.ToString()].Value2 = sigma;
                    usedrows++;
                    sheet.Range["A" + usedrows.ToString()].Value2 = "离散系数";
                    sheet.Range["B" + usedrows.ToString()].Value2 = sigma / aver;
                }
                #endregion

                sheet.Name = "单变量分析" + (++form_count).ToString();
                sheet.Range["A1:D1"].Merge();
                Excel.Range range = sheet.Range["A1"];
                range.Value2 = "单变量分析";
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                range.Interior.ColorIndex = 39;
                range.Font.Size = 16;

                range = sheet.Range["A1:D" + usedrows.ToString()];
                range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                sheet.Range["A2:D" + usedrows].BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);
                range.BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                sheet.Range["A1"].EntireColumn.AutoFit();
                sheet.Range["B1"].EntireColumn.AutoFit();
                sheet.Range["C1"].EntireColumn.AutoFit();
                sheet.Range["D1"].EntireColumn.AutoFit();
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                _dt = Dataset.DS.Tables[comboBox1.Text];
                Dataset.RecentDT = comboBox1.Text;
            }

            n = _dt.Columns.Count;
            m = _dt.Rows.Count;
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add(n);
            for (int i = 0; i < n; i++)
            {
                variable_name = _dt.Columns[i].ColumnName;
                dataGridView1[0, i].Value = false;
                dataGridView1[1, i].Value = variable_name;
            }
        }
    }
}
