using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dataset_Manager
{
    public partial class StatTools
    {
        private void StatTools_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void DataManager_Click(object sender, RibbonControlEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void DataView_Click(object sender, RibbonControlEventArgs e)
        {
            Form2 form4 = new Form2();
            form4.Show();
        }
    }
}
