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
    public partial class Hypothesis_Testing : Form
    {
        private DataTable _dt = new DataTable();
        int n, m;
        string variable_name;
        public Hypothesis_Testing()
        {
            InitializeComponent();
            this.Text = "数据分析器-假设检验";
        }


        private void Hypothesis_Testing_Load(object sender, EventArgs e)
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
            comboBox2.Text = "新工作表";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "总体均值...")
            {
                textBox1.Clear();
                textBox1.ForeColor = Color.Black;
            }
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "总体均值...";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "总体标准差...")
            {
                textBox2.Clear();
                textBox2.ForeColor = Color.Black;
            }
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "总体标准差...";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "可留空...")
            {
                textBox3.Clear();
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "可留空...";
                textBox3.ForeColor = Color.Gray;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "总体均值...") return;
            if (textBox2.Text == "总体标准差...") return;
            if (comboBox1.Text == "") return;
            double haver = double.Parse(textBox1.Text);
            double hsd = double.Parse(textBox2.Text);
            bool haveCustomAlpha = false;
            if (textBox3.Text != "可留空...")
            {
                haveCustomAlpha = true;
            }

            int index = 0;
            if (comboBox2.Text == "从当前单元格开始")
            {
                index = 1;
            }

            int st_row, st_col;
            Excel.Worksheet sheet;
            if (index == 1)
            {
                sheet = Dataset.app.ActiveCell.Worksheet;
                st_row = Dataset.app.ActiveCell.Row;
                st_col = Dataset.app.ActiveCell.Column;
                Dataset.app.ActiveCell.Value2 = Dataset.ColumnTransfer_str(st_col) + st_row.ToString(); 
            }
            else
            {
                sheet = Dataset.app.Worksheets.Add();
                st_row = 1;
                st_col = 1;
            }

            {
                int usedrows = 0;
                int rowstart = 0;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1[0, i].Value.ToString().Length == 5) continue;
                    

                    #region 基本信息
                    double[] datalist = new double[m];//临时数据表
                    int datacount = 0;//临时计数器
                    for (int j = 0; j < m; j++)
                    {
                        datalist[j] = (double)_dt.Rows[j][i];
                        if (datalist[j] != Dataset.INF) datacount++;
                    }
                    //Array.Sort(datalist);
                    double sum = 0.0;//求和
                    for (int j = 0; j < datacount; j++) sum += datalist[j];

                    double aver = sum / datacount;
                    double sd = 0.0;
                    for (int k = 0; k < datacount; k++)
                        sd += (datalist[k] - aver) * (datalist[k] - aver);
                    sd /= datacount;
                    sd = Math.Sqrt(sd);

                    usedrows = 1;
                    sheet.Range[Dataset.ColumnTransfer_str(st_col) + (rowstart + usedrows + st_row - 1).ToString()].Value2 = "数据名称";
                    sheet.Range[Dataset.ColumnTransfer_str(st_col + 1) + (rowstart + usedrows + st_row - 1).ToString()].Value2 = _dt.Columns[i].ColumnName;

                    usedrows++;
                    sheet.Range[Dataset.ColumnTransfer_str(st_col) + (rowstart + usedrows + st_row - 1).ToString()].Value2 = "样本量";
                    sheet.Range[Dataset.ColumnTransfer_str(st_col + 1) + (rowstart + usedrows + st_row - 1).ToString()].Value2 = datacount;

                    usedrows++;
                    sheet.Range[Dataset.ColumnTransfer_str(st_col) + (rowstart + usedrows + st_row - 1).ToString()].Value2 = "样本平均值";
                    sheet.Range[Dataset.ColumnTransfer_str(st_col + 1) + (rowstart + usedrows + st_row - 1).ToString()].Value2 = aver;

                    usedrows++;
                    sheet.Range[Dataset.ColumnTransfer_str(st_col) + (rowstart + usedrows + st_row - 1).ToString()].Value2 = "样本标准差";
                    sheet.Range[Dataset.ColumnTransfer_str(st_col + 1) + (rowstart + usedrows + st_row - 1).ToString()].Value2 = sd;
                    #endregion

                    #region 均值T检验
                    usedrows++;
                    sheet.Range[Dataset.ColumnTransfer_str(st_col) + (rowstart + usedrows + st_row - 1).ToString()].Value2 = "假设平均值";
                    sheet.Range[Dataset.ColumnTransfer_str(st_col + 1) + (rowstart + usedrows + st_row - 1).ToString()].Value2 = haver;

                    usedrows++;
                    sheet.Range[Dataset.ColumnTransfer_str(st_col) + (rowstart + usedrows + st_row - 1).ToString()].Value2 = "备择假设";
                    sheet.Range[Dataset.ColumnTransfer_str(st_col + 1) + (rowstart + usedrows + st_row - 1).ToString()].Value2 = "<>" + haver.ToString();

                    usedrows++;
                    sheet.Range[Dataset.ColumnTransfer_str(st_col) + (rowstart + usedrows + st_row - 1).ToString()].Value2 = "样本标准误差";
                    sheet.Range[Dataset.ColumnTransfer_str(st_col + 1) + (rowstart + usedrows + st_row - 1).ToString()].Value2 = sd / Math.Sqrt(datacount);

                    usedrows++;
                    sheet.Range[Dataset.ColumnTransfer_str(st_col) + (rowstart + usedrows + st_row - 1).ToString()].Value2 = "自由度";
                    sheet.Range[Dataset.ColumnTransfer_str(st_col + 1) + (rowstart + usedrows + st_row - 1).ToString()].Value2 = datacount - 1;

                    usedrows++;
                    sheet.Range[Dataset.ColumnTransfer_str(st_col) + (rowstart + usedrows + st_row - 1).ToString()].Value2 = "t检验统计量";
                    double tvalue = Math.Sqrt(datacount) * (aver - haver) / sd;
                    sheet.Range[Dataset.ColumnTransfer_str(st_col + 1) + (rowstart + usedrows + st_row - 1).ToString()].Value2 = tvalue;

                    usedrows++;
                    sheet.Range[Dataset.ColumnTransfer_str(st_col) + (rowstart + usedrows + st_row - 1).ToString()].Value2 = "P值";
                    sheet.Range[Dataset.ColumnTransfer_str(st_col + 1) + (rowstart + usedrows + st_row - 1).ToString()].Value2 = "=TDIST(" + (Math.Abs(tvalue)).ToString() + "," + (datacount - 1).ToString() + ",2）";
                    double pvalue = (double)sheet.Range[Dataset.ColumnTransfer_str(st_col + 1) + (rowstart + usedrows + st_row - 1).ToString()].Value2;

                    usedrows++;
                    sheet.Range[Dataset.ColumnTransfer_str(st_col) + (rowstart + usedrows + st_row - 1).ToString()].Value2 = "原假设以10%显著性";
                    sheet.Range[Dataset.ColumnTransfer_str(st_col + 1) + (rowstart + usedrows + st_row - 1).ToString()].Value2 = pvalue < 0.1 ? "否定" : "保留";

                    usedrows++;
                    sheet.Range[Dataset.ColumnTransfer_str(st_col) + (rowstart + usedrows + st_row - 1).ToString()].Value2 = "原假设以5%显著性";
                    sheet.Range[Dataset.ColumnTransfer_str(st_col + 1) + (rowstart + usedrows + st_row - 1).ToString()].Value2 = pvalue < 0.05 ? "否定" : "保留";

                    usedrows++;
                    sheet.Range[Dataset.ColumnTransfer_str(st_col) + (rowstart + usedrows + st_row - 1).ToString()].Value2 = "原假设以1%显著性";
                    sheet.Range[Dataset.ColumnTransfer_str(st_col + 1) + (rowstart + usedrows + st_row - 1).ToString()].Value2 = pvalue < 0.01 ? "否定" : "保留";

                    if (haveCustomAlpha) 
                    {
                        usedrows++;
                        double customalpha = double.Parse(textBox3.Text);
                        sheet.Range[Dataset.ColumnTransfer_str(st_col) + (rowstart + usedrows + st_row - 1).ToString()].Value2 = "原假设以" + ((int)(customalpha * 100)).ToString() + "%显著性";
                        sheet.Range[Dataset.ColumnTransfer_str(st_col + 1) + (rowstart + usedrows + st_row - 1).ToString()].Value2 = pvalue < customalpha ? "否定" : "保留";
                    }
                    #endregion
                    
                    Excel.Range range = sheet.Range[Dataset.ColumnTransfer_str(st_col) + (rowstart + st_row).ToString() + ":" + Dataset.ColumnTransfer_str(st_col + 1) + (rowstart + usedrows + st_row - 1).ToString()];
                    range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    range.BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    sheet.Range[Dataset.ColumnTransfer_str(st_col) + (rowstart + 1).ToString()].EntireColumn.AutoFit();
                    sheet.Range[Dataset.ColumnTransfer_str(st_col + 1) + (rowstart + 1).ToString()].EntireColumn.AutoFit();

                    usedrows++;
                    rowstart += usedrows;
                }
            }
        }
    }
}
