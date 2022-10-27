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
    public partial class Form1Repeat : Form
    {
        public bool choice = false;

        public Form1Repeat()
        {
            InitializeComponent();
        }

        private void Form1Repeat_Load(object sender, EventArgs e)
        {
            this.Text = "数据集名称重复";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Yes_Click(object sender, EventArgs e)
        {
            choice = true;
            this.Close();
        }

        private void No_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
