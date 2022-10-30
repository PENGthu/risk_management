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

namespace Dataset_Manager.DataTools
{
    public partial class Form_DT_Calc : Form
    {

        private DataTable _dt = new DataTable();
        int n, m;
        string variable_name;

        public Form_DT_Calc()
        {
            InitializeComponent();
            this.Text = "数据实用工具-计算";
            textBox1.Visible = false;
            foreach (DataTable table in Dataset.DS.Tables) //读取所有DS的datatable名称,放入combobox
                comboBox1.Items.Add(table.TableName);
            if (Dataset.RecentDT != "")
            {
                comboBox1.Text = Dataset.RecentDT;
                _dt = Dataset.DS.Tables[Dataset.RecentDT];
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

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "") return;
            Excel.Worksheet ws = Globals.ThisAddIn.GetActiveWorksheet();
            int col = ws.UsedRange.Columns.Count;
            if (textBox_outputposition.Text != "")
                col = Dataset.Transfer_int(textBox_outputposition.Text.ToList(), true) - 1;
            int count = 0;
            string d = comboBox2.Text, d1 = "", d2 = "" , formula = "";
            int ind = 0;
            if (d == "") return;
            if (d == "自定义公式")
            {
                formula = textBox1.Text;
                ind = formula.IndexOf("参数");
                if (ind == -1)
                {
                    MessageBox.Show("公式未含有参数！");
                    return;
                }
                else
                {
                    d1 = formula.Substring(0, ind);
                    d2 = formula.Substring(ind + 2);
                }
                //ws.Range["A1"].Value2 = d1 + "xxx" + d2;
                //return;
            }


            for (int i = 0; i < n; i++)
            {
                if (dataGridView1[0, i].Value.ToString().Length == 5) continue; //对应未勾选，直接跳过该列数据
                string name = "";
                if (d != "自定义公式")
                {
                    name = d + "(" + _dt.Columns[i].ColumnName + ")";
                }
                else
                {
                    name = d1 + "(" + _dt.Columns[i].ColumnName + ")" + d2;
                }
                if (_dt.Columns.Contains(name)) continue; //对应已经实现过同样的运算的数据，跳过


                bool b_pos = false, b_zero = false;

                if (d == "log")
                {
                    for (int j = 0; j < m; j++)
                        if ((double)_dt.Rows[j][i] <= 0) b_pos = true;
                    if (b_pos)
                    {
                        MessageBox.Show(_dt.Columns[i].ColumnName + "列含有非正值，部分数据不能进行对数运算！");
                    }
                    //else
                    {
                        count++;
                        DataColumn column = new DataColumn(name, Type.GetType("System.Double"));
                        _dt.Columns.Add(column); //向数据表中加入新列
                        for (int j = 0; j < m; j++)
                        {
                            if (((double)_dt.Rows[j][i] == Dataset_Manager.Dataset.INF) || ((double)_dt.Rows[j][i] <= 0))
                                _dt.Rows[j][name] = Dataset_Manager.Dataset.INF;
                            else 
                                _dt.Rows[j][name] = Math.Log10((double)_dt.Rows[j][i]);
                        }
                           
                    }
                }

                if (d == "ln")
                {
                    for (int j = 0; j < m; j++)
                        if ((double)_dt.Rows[j][i] <= 0) b_pos = true;
                    if (b_pos)
                    {
                        MessageBox.Show(_dt.Columns[i].ColumnName + "列含有非正值，部分数据不能进行对数运算！");
                    }
                    //else
                    {
                        count++;
                        DataColumn column = new DataColumn(name, Type.GetType("System.Double"));
                        _dt.Columns.Add(column); //向数据表中加入新列
                        for (int j = 0; j < m; j++)
                        {
                            if (((double)_dt.Rows[j][i] == Dataset_Manager.Dataset.INF) || ((double)_dt.Rows[j][i] <= 0))
                                _dt.Rows[j][name] = Dataset_Manager.Dataset.INF;
                            else
                                _dt.Rows[j][name] = Math.Log((double)_dt.Rows[j][i]);
                        }
                    }
                }

                if (d == "reciprocal")
                {
                    for (int j = 0; j < m; j++)
                        if ((double)_dt.Rows[j][i] == 0) b_zero = true;
                    if (b_zero)
                    {
                        MessageBox.Show(_dt.Columns[i].ColumnName + "列含有零值，部分数据不能进行倒数运算！");
                    }
                    //else
                    {
                        count++;
                        DataColumn column = new DataColumn(name, Type.GetType("System.Double"));
                        _dt.Columns.Add(column); //向数据表中加入新列
                        for (int j = 0; j < m; j++)
                        {
                            if (((double)_dt.Rows[j][i] == Dataset_Manager.Dataset.INF) || ((double)_dt.Rows[j][i] == 0))
                                _dt.Rows[j][name] = Dataset_Manager.Dataset.INF;
                            else
                                _dt.Rows[j][name] = 1.0 / (double)_dt.Rows[j][i];
                        }
                    }
                }

                if (d == "square")
                {
                    {
                        count++;
                        DataColumn column = new DataColumn(name, Type.GetType("System.Double"));
                        _dt.Columns.Add(column); //向数据表中加入新列
                        for (int j = 0; j < m; j++)
                        {
                            if ((double)_dt.Rows[j][i] == Dataset_Manager.Dataset.INF)
                                _dt.Rows[j][name] = Dataset_Manager.Dataset.INF;
                            else
                                _dt.Rows[j][name] = (double)_dt.Rows[j][i] * (double)_dt.Rows[j][i];
                        }
                    }
                }

                if (d == "sqrt")
                {
                    for (int j = 0; j < m; j++)
                        if ((double)_dt.Rows[j][i] <= 0) b_pos = true;
                    if (b_pos)
                    {
                        MessageBox.Show(_dt.Columns[i].ColumnName + "列含有非正值，部分数据不能进行对数运算！");
                    }
                    //else
                    {
                        count++;
                        DataColumn column = new DataColumn(name, Type.GetType("System.Double"));
                        _dt.Columns.Add(column); //向数据表中加入新列
                        for (int j = 0; j < m; j++)
                        {
                            if (((double)_dt.Rows[j][i] == Dataset_Manager.Dataset.INF) || ((double)_dt.Rows[j][i] <= 0))
                                _dt.Rows[j][name] = Dataset_Manager.Dataset.INF;
                            else
                                _dt.Rows[j][name] = Math.Sqrt((double)_dt.Rows[j][i]);
                        }
                    }
                }

                if (d == "cube")
                {
                    {
                        count++;
                        DataColumn column = new DataColumn(name, Type.GetType("System.Double"));
                        _dt.Columns.Add(column); //向数据表中加入新列
                        for (int j = 0; j < m; j++)
                        {
                            if ((double)_dt.Rows[j][i] == Dataset_Manager.Dataset.INF)
                                _dt.Rows[j][name] = Dataset_Manager.Dataset.INF;
                            else
                                _dt.Rows[j][name] = (double)_dt.Rows[j][i] * (double)_dt.Rows[j][i] * (double)_dt.Rows[j][i];
                        }
                    }
                }

                if (d == "cube root")
                {
                    {
                        count++;
                        DataColumn column = new DataColumn(name, Type.GetType("System.Double"));
                        _dt.Columns.Add(column); //向数据表中加入新列
                        for (int j = 0; j < m; j++)
                        {
                            if ((double)_dt.Rows[j][i] == Dataset_Manager.Dataset.INF)
                                _dt.Rows[j][name] = Dataset_Manager.Dataset.INF;
                            else
                                _dt.Rows[j][name] = Math.Pow((double)_dt.Rows[j][i], 1.0 / 3.0);
                        }
                        
                    }
                }

                if (d == "自定义公式")
                {
                    {
                        count++;
                        DataColumn column = new DataColumn(name, Type.GetType("System.Double"));
                        _dt.Columns.Add(column); //向数据表中加入新列
                        for (int j = 0; j < m; j++)
                        {
                            if ((double)_dt.Rows[j][i] == Dataset_Manager.Dataset.INF)
                                _dt.Rows[j][name] = Dataset_Manager.Dataset.INF;
                            else
                            {
                                ws.Range[Dataset.Transfer_string(col + count) + (j+2).ToString()].Value2 = "=" + d1 + _dt.Rows[j][i].ToString() + d2;
                                double temp = (double)ws.Range[Dataset.Transfer_string(col + count) + (j + 2).ToString()].Value2;
                                if (temp < -Dataset_Manager.Dataset.INF)
                                {
                                    _dt.Rows[j][name] = Dataset_Manager.Dataset.INF;
                                }
                                else
                                {
                                    _dt.Rows[j][name] = temp;
                                }
                            }
                        }
                    }
                }


                //if (b_pos || b_zero) continue;
                ws.Range[Dataset.Transfer_string(col + count) + "1"].Value2 = name; //向Worksheet中加入新列
                for (int j = 0; j < m; j++)
                {
                    ws.Range[Dataset.Transfer_string(col + count) + (j + 2).ToString()].Value2 = ((double)_dt.Rows[j][name] == Dataset_Manager.Dataset.INF ? "N/A" : _dt.Rows[j][name]);
                }
                ws.Range[Dataset.Transfer_string(col + count) + "1"].EntireColumn.AutoFit();
            }
            //重置相关参数
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
            textBox_outputposition.Text = "";
            for (int i = 0; i < n; i++)
                dataGridView1[0, i].Value = false;
            select_all.Checked = false;
            comboBox2.Text = "";
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

        private void select_all_CheckedChanged(object sender, EventArgs e)
        {
            if (select_all.Checked)
                for (int i = 0; i < n; i++)
                    dataGridView1[0, i].Value = true;
            else
                for (int i = 0; i < n; i++)
                    dataGridView1[0, i].Value = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "自定义公式")
            {
                textBox1.Visible = true;
                textBox1.Text = "(参数)";
            }
            else textBox1.Visible = false;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form_DT_Calc_Load(object sender, EventArgs e)
        {

        }
    }
}
