using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dataset_Manager
{
    public partial class Form2 : Form
    {
        public static DataTable dt = new DataTable(); //要查看的数据集，传递给下一窗体类
        public static string dtName;  //数据集名称，传递给下一窗体类
        public static bool checkclick = false;
        public static int btn_flag;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            foreach (DataTable table in Dataset.DS.Tables)
                comboBox_Data.Items.Add(table.TableName);
        }

        private void button_Check_Click(object sender, EventArgs e)
        /*给要查看的数据集赋名称、范围、数据源*/
        {
            if (comboBox_Data.Text != "")
            {
                checkclick = true;
                dtName = comboBox_Data.Text;
                dt = Dataset.DS.Tables[dtName];
                textBox_Addr.Text = Dataset.DC[dt];
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
            }
        }

        private void Pearson_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void Pearson_Click(object sender, EventArgs e)
        {
            if ((comboBox_Data.Text != "") && (checkclick == true))
            {
                btn_flag = 1;
                Form2Pearson formP = new Form2Pearson();
                formP.Show();
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
