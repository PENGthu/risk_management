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
    public partial class Form_DT_Delay : Form
    {
        private DataTable _dt = new DataTable();
        int n, m;
        string variable_name;

        public Form_DT_Delay()
        {
            InitializeComponent();
            this.Text = "数据实用工具-滞后";
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
        }

        private void Form_DT_Delay_Load(object sender, EventArgs e)
        {


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void btn_confirm_Click(object sender, EventArgs e)
        {



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //选择数据表
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void select_all_CheckedChanged(object sender, EventArgs e)
        //全选
        {
            if (select_all.Checked)
                for (int i = 0; i < n; i++)
                    dataGridView1[0, i].Value = true;
            else
                for (int i = 0; i < n; i++)
                    dataGridView1[0, i].Value = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_confirm_Click_2(object sender, EventArgs e)
        {
            if (comboBox1.Text == "") return;
            Excel.Worksheet ws = Globals.ThisAddIn.GetActiveWorksheet();
            int col = ws.UsedRange.Columns.Count;
            if (textBox_outputposition.Text != "")
                col = Dataset.Transfer_int(textBox_outputposition.Text.ToList(), true) - 1;
            int count = 0, d = 1;
            if (textBox1.Text != "")
            {
                d = int.Parse(textBox1.Text);
            }


            for (int i = 0; i < n; i++)
            {
                if (dataGridView1[0, i].Value.ToString().Length == 5) continue; //对应未勾选，直接跳过该列数据
                string name = "滞后(" + d.ToString() + ")(" + _dt.Columns[i].ColumnName + ")";
                if (_dt.Columns.Contains(name)) continue; //对应已经实现过同样的滞后的数据，跳过

                count++;
                DataColumn column = new DataColumn(name, Type.GetType("System.Double"));
                _dt.Columns.Add(column); //向数据表中加入新列
                for (int j = 0; j < d; j++)
                {
                    _dt.Rows[j][name] = 0;
                }
                for (int j = d; j < m; j++)
                {
                    _dt.Rows[j][name] = _dt.Rows[j - d][i];
                }
                ws.Range[Dataset.Transfer_string(col + count) + "1"].Value2 = name; //向Worksheet中加入新列
                for (int j = 0; j < m; j++)
                {
                    ws.Range[Dataset.Transfer_string(col + count) + (j + 2).ToString()].Value2 = ((double)_dt.Rows[j][name] == Dataset_Manager.Dataset.INF? "N/A" : _dt.Rows[j][name]);
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
            textBox1.Text = "";

        }

        private void textBox_outputposition_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form_DT_Delay_Load_1(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox_outputposition_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
