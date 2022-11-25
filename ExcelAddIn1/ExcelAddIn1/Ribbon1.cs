using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Worksheet = Microsoft.Office.Interop.Excel.Worksheet;
using System.Drawing;

namespace ExcelAddIn1
{
    public partial class Ribbon1
    {
        public Excel.Application Excelapp;
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            Excelapp = Globals.ThisAddIn.Application;
        }

        private void checkBox1_Click(object sender, RibbonControlEventArgs e)
        {
            Excelapp.ActiveCell.Value = 114514;
        }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
            Excelapp.ActiveCell.Value = 1919810;
        }

        private void group2_DialogLauncherClick(object sender, RibbonControlEventArgs e)
        {
            //dialog launcher的单击事件
            Excelapp.ActiveCell.Value = 48;
            MessageBox.Show("dialog");

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            Form1 Form = new Form1();
            Form.Show();
        }

        private void button3_Click(object sender, RibbonControlEventArgs e)
        {
            //当前活动工作表
            Worksheet sheet = Globals.ThisAddIn.GetActiveWorkSheet();

            int sRow = sheet.UsedRange.Rows.Count;
            Range datarange = sheet.Range["B2:B"+sRow];
            //object
            object[,] dataRangeArray = datarange.Value2;
            List<double> dataValue = new List<double> { };

            for(int i=1;i<=dataRangeArray.Length;i++)
            {
                dataValue.Add(Convert.ToDouble(dataRangeArray[i,1]));
            }

            double sum = 0;
            double avg = 0;
            for(int i=0;i<dataValue.Count;i++)
            {
                sum = sum + dataValue[i];
            }
            avg=sum/dataValue.Count;
            string info = "B2:B" + sRow + "的和是:" + sum+"\n"+
               "B2:B" + sRow + "的平均值是:"+avg;

            MessageBox.Show(info);
        }
    }
}
