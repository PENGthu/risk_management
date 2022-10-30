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

namespace Dataset_Manager
{
    public partial class Form1 : Form
    {
        private DataTable _dt; 
        bool new_create = false;
        bool new_open = false;
        int head;
        public Form1()
        {
            InitializeComponent();
        }

        private void Display()
        {
            if (new_create == true)
            {
                int ColumnStart, RowStart, ColumnLength, RowLength;
                List<int> DisplayInfo = new List<int>();
                DisplayInfo = Dataset.GetDisplayInfo(maskedTextBox_Range.Text);
                RowStart = DisplayInfo[0];
                RowLength = DisplayInfo[1];
                ColumnStart = DisplayInfo[2];
                ColumnLength = DisplayInfo[3];

                /*选择数据呈现方式（行/列）*/
                int n;
                string range, variable_name, range_name, output_format;
                if (radioButton_Column.Checked == true)
                {
                    n = _dt.Columns.Count;
                    dataGridView1.Rows.Clear();
                    dataGridView1.Rows.Add(n);
                    for (int i = 0; i < n; i++)
                    {
                        range = Dataset.ColumnTransfer_str(ColumnStart + i) + Convert.ToString(RowStart) + ":" + Dataset.ColumnTransfer_str(ColumnStart + i) + Convert.ToString(RowStart + RowLength - 1);
                        variable_name = Dataset.ws.Cells[head, ColumnStart + i].Value;
                        range_name = "ST_" + Dataset.ws.Cells[head, ColumnStart + i].Value;
                        output_format = "自动";

                        dataGridView1[0, i].Value = range;
                        dataGridView1[1, i].Value = variable_name;
                        dataGridView1[2, i].Value = range_name;
                        dataGridView1[3, i].Value = output_format;
                        ((DataGridViewComboBoxCell)dataGridView1[3, i]).Items.Add("自动");
                        ((DataGridViewComboBoxCell)dataGridView1[3, i]).Items.Add("常规");
                        ((DataGridViewComboBoxCell)dataGridView1[3, i]).Items.Add("固定");
                        ((DataGridViewComboBoxCell)dataGridView1[3, i]).Items.Add("币种");
                    }
                    label5.Visible = true;
                    label5.Text = Convert.ToString(n) + "个变量，每个变量" + Convert.ToString(RowLength) + "个数据单元";
                }
                else
                {
                    n = _dt.Rows.Count;
                    dataGridView1.Rows.Clear();
                    dataGridView1.Rows.Add(n);
                    for (int i = 0; i < n; i++)
                    {
                        range = Dataset.ColumnTransfer_str(ColumnStart) + Convert.ToString(RowStart + i) + ":" + Dataset.ColumnTransfer_str(ColumnStart + ColumnLength - 1) + Convert.ToString(RowStart + i);
                        variable_name = Convert.ToString(RowStart + i);
                        range_name = "ST_" + Convert.ToString(RowStart + i);
                        output_format = "自动";

                        dataGridView1[0, i].Value = range;
                        dataGridView1[1, i].Value = variable_name;
                        dataGridView1[2, i].Value = range_name;
                        dataGridView1[3, i].Value = output_format;
                        ((DataGridViewComboBoxCell)dataGridView1[3, i]).Items.Add("自动");
                        ((DataGridViewComboBoxCell)dataGridView1[3, i]).Items.Add("货币");
                        ((DataGridViewComboBoxCell)dataGridView1[3, i]).Items.Add("时间");
                    }
                    label5.Visible = true;
                    label5.Text = Convert.ToString(n) + "个变量，每个变量" + Convert.ToString(ColumnLength) + "个数据单元";
                }
            }
            dataGridView2.DataSource = _dt;
            dataGridView2.Refresh(); //dataGridView2刷新显示
        }

        /// <summary>
        /// 读取所有DS的datatable名称,放入combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
             Dataset.app = Globals.ThisAddIn.GetActiveApplication();
             Dataset.ws = Globals.ThisAddIn.GetActiveWorksheet();
             foreach (DataTable table in Dataset.DS.Tables) 
                comboBox_Opt.Items.Add(table.TableName);
        }

        private void maskedTextBox_Range_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        /// <summary>
        /// 点击“创建”
        /// 创建临时数据集_dt，待确认后再放入DS
        /// 在信息栏中显示数据表信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Create_Click(object sender, EventArgs e)
        {
            new_create = true;
            if (textBox_Name.Text == "") //datatable名称不能为空
            {
                MessageBox.Show("名称不能为空！");
                return;
            }

            if (maskedTextBox_Range.Text == "") //显示选中单元格范围
            {
                var Data = (Excel.Range)Dataset.app.Selection;
                maskedTextBox_Range.Text = Data.Address[false, false];
            }

            if (maskedTextBox_Range.Text != "") //将区域内数据作为一个datatable加入到临时的_dt中
            {
                var Data = Dataset.ws.Range[maskedTextBox_Range.Text];
                head = 0; //判断表头是否在Excel的第一行，以此确定表头的显示
                char[] temp = textBox_Head.Text.ToCharArray();
                for (int i = 0; i < temp.Length; i++)
                {
                    int t = temp[i] - 48;
                    head += t * (int)Math.Pow(10, temp.Length - 1 - i);
                }
                _dt = new DataTable(textBox_Name.Text);
                Dataset.RangeToDT(ref _dt, Data, head);
            }

            label9.Visible = true;
            label9.Text = "数据集创建成功！";
        }

        private void Open_Click(object sender, EventArgs e)
        {
            if (comboBox_Opt.Text != "")
                _dt = Dataset.DS.Tables[comboBox_Opt.Text];
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (comboBox_Opt.Text != "")
            {
                Form1Delete form3 = new Form1Delete();
                form3.ShowDialog();
                if (form3.choice == true)
                {
                    Dataset.DS.Tables.Remove(Dataset.DS.Tables[comboBox_Opt.Text]); //删除相应的datatable,并更新combo_Box
                    comboBox_Opt.Items.Remove(comboBox_Opt.Text);
                    comboBox_Opt.Text = "";
                    comboBox_Opt.Refresh();
                }
                else
                    return;
            }
        }

        private void Display_Click(object sender, EventArgs e)
        {
            if (new_create == true)
            {
                int ColumnStart, RowStart, ColumnLength, RowLength;
                List<int> DisplayInfo = new List<int>();
                DisplayInfo = Dataset.GetDisplayInfo(maskedTextBox_Range.Text);
                RowStart = DisplayInfo[0];
                RowLength = DisplayInfo[1];
                ColumnStart = DisplayInfo[2];
                ColumnLength = DisplayInfo[3];

                /*选择数据呈现方式（行/列）*/
                int n;
                string range, variable_name, range_name, output_format;
                if (radioButton_Column.Checked == true)
                {
                    n = _dt.Columns.Count;
                    dataGridView1.Rows.Clear();
                    dataGridView1.Rows.Add(n);
                    for (int i = 0; i < n; i++)
                    {
                        range = Dataset.ColumnTransfer_str(ColumnStart + i) + Convert.ToString(RowStart) + ":" + Dataset.ColumnTransfer_str(ColumnStart + i) + Convert.ToString(RowStart + RowLength - 1);
                        variable_name = Dataset.ws.Cells[head, ColumnStart + i].Value;
                        range_name = "ST_" + Dataset.ws.Cells[head, ColumnStart + i].Value;
                        output_format = "自动";

                        dataGridView1[0, i].Value = range;
                        dataGridView1[1, i].Value = variable_name;
                        dataGridView1[2, i].Value = range_name;
                        dataGridView1[3, i].Value = output_format;
                        ((DataGridViewComboBoxCell)dataGridView1[3, i]).Items.Add("自动");
                        ((DataGridViewComboBoxCell)dataGridView1[3, i]).Items.Add("常规");
                        ((DataGridViewComboBoxCell)dataGridView1[3, i]).Items.Add("固定");
                        ((DataGridViewComboBoxCell)dataGridView1[3, i]).Items.Add("币种");
                    }
                    label5.Visible = true;
                    label5.Text = Convert.ToString(n) + "个变量，每个变量" + Convert.ToString(RowLength) + "个数据单元";
                }
                else
                {
                    n = _dt.Rows.Count;
                    dataGridView1.Rows.Clear();
                    dataGridView1.Rows.Add(n);
                    for (int i = 0; i < n; i++)
                    {
                        range = Dataset.ColumnTransfer_str(ColumnStart) + Convert.ToString(RowStart + i) + ":" + Dataset.ColumnTransfer_str(ColumnStart + ColumnLength - 1) + Convert.ToString(RowStart + i);
                        variable_name = Convert.ToString(RowStart + i);
                        range_name = "ST_" + Convert.ToString(RowStart + i);
                        output_format = "自动";

                        dataGridView1[0, i].Value = range;
                        dataGridView1[1, i].Value = variable_name;
                        dataGridView1[2, i].Value = range_name;
                        dataGridView1[3, i].Value = output_format;
                        ((DataGridViewComboBoxCell)dataGridView1[3, i]).Items.Add("自动");
                        ((DataGridViewComboBoxCell)dataGridView1[3, i]).Items.Add("货币");
                        ((DataGridViewComboBoxCell)dataGridView1[3, i]).Items.Add("时间");
                    }
                    label5.Visible = true;
                    label5.Text = Convert.ToString(n) + "个变量，每个变量" + Convert.ToString(ColumnLength) + "个数据单元";
                }
            }
            dataGridView2.DataSource = _dt;
            dataGridView2.Refresh(); //dataGridView2刷新显示
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if(_dt == null)
            {
                this.Dispose();
                return;
            }
            /*如果DS中已包含同名的datatable,判断是否替换*/
            if (Dataset.DS.Tables.Contains(_dt.TableName))
            {
                Form1Repeat form2 = new Form1Repeat();
                form2.ShowDialog();
                if (form2.choice == true)
                    Dataset.DS.Tables.Remove(_dt.TableName);
                else
                    return;
            }
            Dataset.DS.Tables.Add(_dt);
            Dataset.DC.Add(_dt, maskedTextBox_Range.Text); //Hash Table将数据表、数据表名、数据表范围存在一起
            this.Dispose();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        
    }
}
