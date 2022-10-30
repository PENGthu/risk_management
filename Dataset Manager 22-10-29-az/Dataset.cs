using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
namespace Dataset_Manager
{
    internal static class Dataset  //自定义数据结构Dataset，其属性包含数据集类DataSet
    {
        public const int INF = 2000000000;

        public static DataSet DS = new DataSet();

        public static Excel.Application app = Globals.ThisAddIn.GetActiveApplication();
        public static Excel.Worksheet ws = Globals.ThisAddIn.GetActiveWorksheet();


        public static void RangeToDT(ref DataTable dt, Excel.Range range, int FirstRowNumber)
        /*把一个Excel.Range转存到DataSet.DS的datatable中，Datatable的名字为TableName*/
        {
            /*如果excel只选了一个格或什么也没选*/
            if (range.Count <= 1) 
            {
                MessageBox.Show("必须选择多于1个cell区域!");
                return;
            }

            /*先建一个datatable dt，名称是输入参数TableName*/
            object[,] values = range.Value2;
            int row_length = values.GetLength(0); //行数
            int column_length = values.GetLength(1); //列数
            if(FirstRowNumber == range.Row) //如果数据第一行作为表头：此range必须至少两行，第一行是数据项的名称
            {
                if(row_length < 2) //必须至少两行数据
                {
                    MessageBox.Show("无数据！");
                    return;
                }
                for(int i = 1; i <= column_length; i++) //把第一行表头放入dt中作为column
                {
                    DataColumn col = new DataColumn(values[1, i].ToString(), values[2, i].GetType());
                    dt.Columns.Add(col);
                }
                for(int i = 2; i <= row_length; i++) //从第二行起，逐行把数据放入dt中
                {
                    DataRow row = dt.NewRow();
                    for (int j = 1; j <= column_length; j++)
                        row[j - 1] = values[i, j];
                    dt.Rows.Add(row);
                }
            }
            else //如果数据第一行不作为表头
            {
                for (int i = 1; i <= column_length; i++) //把ws中表头放入dt中作为column
                {                   
                    DataColumn col = new DataColumn(ws.Cells[FirstRowNumber, range.Column+i-1].Value.ToString(), values[1, i].GetType());          

                    dt.Columns.Add(col);
                }
                for (int i = 1; i <= row_length; i++) //逐行把数据放入dt中
                {
                    DataRow row = dt.NewRow();
                    for (int j = 1; j <= column_length; j++)
                        row[j - 1] = values[i, j];
                    dt.Rows.Add(row);
                }
            }
        }

        public static ArrayList GetRow(string tableName, int rowIndex)
        /*返回某表（TableName)的某行(rowIndex,从0开始)的数到一个ArrayList*/
        {
            ArrayList al = new ArrayList();
            if (DS.Tables.Contains(tableName))
            {
                for (int i = 0; i < DS.Tables[tableName].Columns.Count; i++)
                    al.Add(DS.Tables[tableName].Rows[rowIndex][i]);
            }
            return al;
        }

        public static ArrayList GetColumn(string tableName, int colIndex)
        /*返回某表（tableName)的某列(rowIndex,从0开始)的数 到一个ArrayList*/
        {
            ArrayList al = new ArrayList();
            if (DS.Tables.Contains(tableName))
            {
                for (int i = 0; i < DS.Tables[tableName].Rows.Count; i++)
                    al.Add(DS.Tables[tableName].Rows[i][colIndex]);
            }
            return al;
        }

        public static string ColumnTransfer_str(int column)
        /*读取数字，将列数转换为列地址*/
        {
            int remainder = column;
            List<int> result0 = new List<int>();
            string result = "";
            while (remainder - 26 > 0)
            {
                int temp1, temp2;
                temp1 = remainder / 26;
                temp2 = remainder % 26;
                remainder = temp1;
                result0.Add(temp2);
            }
            result0.Add(remainder);
            result0.Reverse();
            for (int i = 0; i < result0.Count; i++)
                result += (char)(result0[i]+64);
            return result;
        }

        public static int Transfer_int(List<char> Char, bool type)
        /*读取字符，将行、列字符地址转换为行号、列号*/
        {
            int result = 0;
            if (type == true) //对列转换时type为true
            {
                for (int i = 0; i < Char.Count; i++)
                {
                    int t = Char[i] - 64;
                    result += t * (int)Math.Pow(26, Char.Count - 1 - i);
                }
            }
            else //对行时为false
            {
                for (int i = 0; i < Char.Count; i++)
                {
                    int t = Char[i] - 48;
                    result += t * (int)Math.Pow(10, Char.Count - 1 - i);
                }
            }
            return result;
        }

        public static List<int> GetDisplayInfo(string str)
        /*对于字符串形式的数据范围，获取行号、列号信息*/
        {
            int ColumnStart, RowStart, ColumnLength, RowLength;
            List<int> result = new List<int>();
            char[] temp = str.ToCharArray();
            List<char> alph1 = new List<char>();
            List<char> alph2 = new List<char>();
            List<char> num1 = new List<char>();
            List<char> num2 = new List<char>();
            for (int i = 0; temp[i] != 58; i++)
            {
                if (temp[i] >= 65 && temp[i] <= 90)
                    alph1.Add(temp[i]);
                else
                    num1.Add(temp[i]);
            }
            for (int j = temp.Length - 1; temp[j] != 58; j--)
            {
                if (temp[j] >= 65 && temp[j] <= 90)
                {
                    alph2.Add(temp[j]);
                    alph2.Reverse();
                }
                else
                {
                    num2.Add(temp[j]);
                    num2.Reverse();
                }
            }
            RowStart = Dataset.Transfer_int(num1, false);
            result.Add(RowStart);
            RowLength = Dataset.Transfer_int(num2, false) - RowStart + 1;
            result.Add(RowLength);
            ColumnStart = Dataset.Transfer_int(alph1, true);
            result.Add(ColumnStart);
            ColumnLength = Dataset.Transfer_int(alph2, true) - ColumnStart + 1;
            result.Add(ColumnLength);
            return result;
        }

        public static string Transfer_string(int k)
        /*读取列号，转换为字母 新加入！！*/
        {
            string s = "";
            while (k > 0)
            {
                s = ((char)((k % 26) + (int)'A' - 1)).ToString() + s;
                k /= 26;
            }
            return s;
        }
        //记录最近使用的数据表，新加入！！！
        public static string RecentDT = "";

    }
}
