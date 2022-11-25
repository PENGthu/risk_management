using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelAddIn1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("欢迎来未央书院！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 Form = new Form2();
            Form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("准备好了");
            Worksheet sheet = Globals.ThisAddIn.GetActiveWorkSheet();
            sheet.Range["A1"].Value2 = "1145141919810";
        }
    }
}
