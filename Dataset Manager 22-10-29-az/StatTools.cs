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
            Form_DataViewer form1 = new Form_DataViewer();
            form1.Show();
        }

        private void btn_Difference_Click(object sender, RibbonControlEventArgs e)
        {
            DataTools.Form_DT_Difference form2 = new DataTools.Form_DT_Difference();
            form2.Show();
        }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
            DataTools.Form_DT_Delay form2 = new DataTools.Form_DT_Delay();
            form2.Show();
        }

        private void btn_calc_Click(object sender, RibbonControlEventArgs e)
        {
            DataTools.Form_DT_Calc form2 = new DataTools.Form_DT_Calc();
            form2.Show();
        }

        private void btn_Interact_Click(object sender, RibbonControlEventArgs e)
        {
            DataTools.Form_DT_Interact form2 = new DataTools.Form_DT_Interact();
            form2.Show();
        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            DataAnalyzer.Single_Variable form2 = new DataAnalyzer.Single_Variable();
            form2.Show();
        }

        private void button1_Click_1(object sender, RibbonControlEventArgs e)
        {
            DataAnalyzer.Hypothesis_Testing form2 = new DataAnalyzer.Hypothesis_Testing();
            form2.Show();
        }
    }
}
