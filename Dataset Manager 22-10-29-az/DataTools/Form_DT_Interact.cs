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
    public partial class Form_DT_Interact : Form
    {
        private DataTable _dt = new DataTable();
        int n, m;
        public Form_DT_Interact()
        {
            InitializeComponent();
            this.Text = "数据实用工具-交互作用";
            foreach (DataTable table in Dataset.DS.Tables) //读取所有DS的datatable名称,放入combobox
                comboBox1.Items.Add(table.TableName);
            if (Dataset.RecentDT != "")
            {
                comboBox1.Text = Dataset.RecentDT;
                _dt = Dataset.DS.Tables[Dataset.RecentDT];
                n = _dt.Columns.Count;
                m = _dt.Rows.Count;
                comboBox2.Items.Clear();
                comboBox4.Items.Clear();
                for (int i = 0; i < n; i++)
                {
                    comboBox2.Items.Add(_dt.Columns[i].ColumnName);
                    comboBox4.Items.Add(_dt.Columns[i].ColumnName);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "") return;
            Excel.Worksheet ws = Globals.ThisAddIn.GetActiveWorksheet();
            int col = ws.UsedRange.Columns.Count;
            if (textBox_outputposition.Text != "")
                col = Dataset.Transfer_int(textBox_outputposition.Text.ToList(), true) - 1;
            int count = 0;

                string name1 = comboBox2.Text, name2 = comboBox4.Text, d = comboBox3.Text;
                string name = "(" + name1 + ")" + d + "(" + name2 + ")";
                if (_dt.Columns.Contains(name)) return; //对应已经实现过同样的运算的数据，跳过
                if (_dt.Columns.Contains(name1) == false || _dt.Columns.Contains(name2) == false)
                {
                    MessageBox.Show("找不到数据，请从下拉菜单中选择数据名！");
                    return;
                }

                bool b_zero = false;

                if (d == "+")
                {
                    {
                        count++;
                        DataColumn column = new DataColumn(name, Type.GetType("System.Double"));
                        _dt.Columns.Add(column); //向数据表中加入新列
                        for (int j = 0; j < m; j++)
                        {
                            if ((double)_dt.Rows[j][name1] == Dataset_Manager.Dataset.INF || (double)_dt.Rows[j][name2] == Dataset_Manager.Dataset.INF)
                                _dt.Rows[j][name] = Dataset_Manager.Dataset.INF;
                            else
                                _dt.Rows[j][name] = (double)_dt.Rows[j][name1] + (double)_dt.Rows[j][name2];
                        }
                    }
                }

                if (d == "-")
                {
                    {
                        count++;
                        DataColumn column = new DataColumn(name, Type.GetType("System.Double"));
                        _dt.Columns.Add(column); //向数据表中加入新列
                        for (int j = 0; j < m; j++)
                        {
                            if ((double)_dt.Rows[j][name1] == Dataset_Manager.Dataset.INF || (double)_dt.Rows[j][name2] == Dataset_Manager.Dataset.INF)
                                _dt.Rows[j][name] = Dataset_Manager.Dataset.INF;
                            else
                                _dt.Rows[j][name] = (double)_dt.Rows[j][name1] - (double)_dt.Rows[j][name2];
                        }
                    }
                }

                if (d == "*")
                {
                    {
                        count++;
                        DataColumn column = new DataColumn(name, Type.GetType("System.Double"));
                        _dt.Columns.Add(column); //向数据表中加入新列
                        for (int j = 0; j < m; j++)
                        {
                            if ((double)_dt.Rows[j][name1] == Dataset_Manager.Dataset.INF || (double)_dt.Rows[j][name2] == Dataset_Manager.Dataset.INF)
                                _dt.Rows[j][name] = Dataset_Manager.Dataset.INF;
                            else
                                _dt.Rows[j][name] = (double)_dt.Rows[j][name1] * (double)_dt.Rows[j][name2];
                        }
                    }
                }

                if (d == "/")
                {
                    for (int j = 0; j < m; j++)
                        if ((double)_dt.Rows[j][name2] == 0) b_zero = true;
                    if (b_zero)
                    {
                        MessageBox.Show(_dt.Columns[name2].ColumnName + "列含有零值，不能进行除法运算！");
                    }
                    //else
                    {
                        count++;
                        DataColumn column = new DataColumn(name, Type.GetType("System.Double"));
                        _dt.Columns.Add(column); //向数据表中加入新列
                        for (int j = 0; j < m; j++)
                        {
                            if ((double)_dt.Rows[j][name1] == Dataset_Manager.Dataset.INF || (double)_dt.Rows[j][name2] == Dataset_Manager.Dataset.INF || (double)_dt.Rows[j][name2] == 0)
                                _dt.Rows[j][name] = Dataset_Manager.Dataset.INF;
                            else
                                _dt.Rows[j][name] = (double)_dt.Rows[j][name1] / (double)_dt.Rows[j][name2];
                        }
                    }
                }

            if (b_zero) return;
            ws.Range[Dataset.Transfer_string(col + count) + "1"].Value2 = name; //向Worksheet中加入新列
            for (int j = 0; j < m; j++)
            {
                ws.Range[Dataset.Transfer_string(col + count) + (j + 2).ToString()].Value2 = ((double)_dt.Rows[j][name] == Dataset_Manager.Dataset.INF ? "N/A" : _dt.Rows[j][name]);
            }
            ws.Range[Dataset.Transfer_string(col + count) + "1"].EntireColumn.AutoFit();
            //重置相关参数
            n = _dt.Columns.Count;
            m = _dt.Rows.Count;
            comboBox2.Items.Clear(); comboBox4.Items.Clear();
            for (int i = 0; i < n; i++)
            {
                comboBox2.Items.Add(_dt.Columns[i].ColumnName);
                comboBox4.Items.Add(_dt.Columns[i].ColumnName);
            }
            textBox_outputposition.Text = "";
        }

        private void textBox_outputposition_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form_DT_Interact_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                if (comboBox1.Text != "")
                {
                    _dt = Dataset.DS.Tables[comboBox1.Text];
                    Dataset.RecentDT = comboBox1.Text;
                }

                n = _dt.Columns.Count;
                m = _dt.Rows.Count;

                for (int i = 0; i < n; i++)
                {
                    comboBox2.Items.Add(_dt.Columns[i].ColumnName);
                    comboBox4.Items.Add(_dt.Columns[i].ColumnName);
                }
            }
        }
    }
}
