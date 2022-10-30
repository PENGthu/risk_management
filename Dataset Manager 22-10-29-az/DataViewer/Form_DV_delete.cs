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
    public partial class Form_DV_delete : Form
    {
        public bool choice = false;

        public Form_DV_delete()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Text = "是否确认删除文件";
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
