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
        public static DataSet DS = new DataSet(); //数据集管理器中作为存放所有数据表的集合
        public static Dictionary<DataTable, string> DC = new Dictionary<DataTable, string>(); //方便查找，键为数据表，值为数据表对应区域

        public static Excel.Application app; //当前应用程序
        public static Excel.Worksheet ws; //当前工作表

        /// <summary>
        /// 把一个Excel.Range转存到DataSet.DS的datatable中，Range的地址为Address
        /// </summary>
        /// <param name="dt">将选中区域存入数据表</param>
        /// <param name="range">当前excel选中的区域</param>
        /// <param name="FirstRowNumber">选中区域的第一行行号</param>
        public static void RangeToDT(ref DataTable dt, Excel.Range range, int FirstRowNumber)
        {
            /*如果excel只选了一个格或什么也没选，则弹出提示*/
            if (range.Count <= 1) 
            {
                MessageBox.Show("必须选择多于1个cell区域!");
                return;
            }

            /*先建一个datatable dt，名称是输入参数TableName*/
            object[,] values = range.Value2; //获取当前选中区域，注意value的行列都是从1开始
            int row_length = values.GetLength(0); //行数
            int column_length = values.GetLength(1); //列数
            if(FirstRowNumber == range.Row) //如果数据第一行作为表头：此range必须至少两行，第一行是数据项的名称
            {
                if(row_length < 2) //若range少于两行则弹出提示
                {
                    MessageBox.Show("无数据！");
                    return;
                }
                /*range大于等于两行时*/
                for (int i = 1; i <= column_length; i++) //把第一行表头放入dt中作为column
                {
                    for (int j = 2; j <= row_length; j++) //此循环作用：数据列的数据类型为表头下一行元素的类型；若下一行为空则依次向下寻找不为空的元素，获取其类型作为该数据列类型
                    {
                        if (values[j, i] != null)
                        {
                            dt.Columns.Add(values[1, i].ToString(), values[j, i].GetType());
                            break;
                        }
                    }
                }
                for(int i = 2; i <= row_length; i++) //从第二行起，逐行把数据放入dt中
                {
                    DataRow row = dt.NewRow(); //新建数据表行
                    for (int j = 1; j <= column_length; j++) //每一行中，依次将各列数据放入数据表行
                    {
                        if (values[i, j] == null) //若数据为空则放入数据表空元素DBNull
                            row[j - 1] = DBNull.Value;
                        else
                        row[j - 1] = values[i, j];
                    }
                    dt.Rows.Add(row); //将数据表行加入dt
                }
            }
            else //如果数据第一行不作为表头
            {
                for (int i = 1; i <= column_length; i++) //逐列把ws中表头放入dt中作为column
                {
                    for (int j = 1; j <= row_length; j++) //此循环作用：在工作表中从第一行依次寻找不为空的行，默认其为表头
                    {
                        if (values[j, i] != null)
                        {
                            dt.Columns.Add(ws.Cells[FirstRowNumber, range.Column + i - 1].Value.ToString(), values[j, i].GetType());
                            break;
                        }
                    }
                }
                for (int i = 1; i <= row_length; i++) //逐行把数据放入dt中，方法同上
                {
                    DataRow row = dt.NewRow();
                    for (int j = 1; j <= column_length; j++)
                    {
                        if (values[i, j] == null)
                            row[j - 1] = DBNull.Value;
                        else
                            row[j - 1] = values[i, j];
                    }
                    dt.Rows.Add(row);
                }
            }
        }

        public static  ArrayList GetRow(DataTable dt, int rowIndex)
        /*返回某表（dt)的某行(rowIndex,从0开始)的数到一个ArrayList*/
        {
            ArrayList al = new ArrayList();
            if (dt != null)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                    al.Add(dt.Rows[rowIndex][i]);
            }
            return al;
        }

        /// <summary>
        /// 返回某表（dt)的某列(colIndex)的数 到一个ArrayList
        /// </summary>
        /// <param name="dt">目标列所在的数据表</param>
        /// <param name="colIndex">列号（从0开始）</param>
        /// <returns></returns>
        public static ArrayList GetColumn(DataTable dt, int colIndex)
        {
            ArrayList al = new ArrayList();
            if (dt!=null) //当数据表不为空时执行
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if(dt.Rows[i][colIndex] != DBNull.Value)
                        al.Add(dt.Rows[i][colIndex]);
                    else //若某一元素为空，则加入null
                        al.Add(null);
                }
            }
            return al;
        }

        /// <summary>
        /// 读取数字，将列数（1,2,3,……）转换为列地址（A,B,C,……）
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public static string ColumnTransfer_str(int column)
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

        /// <summary>
        /// 读取字符，将行、列字符地址转换为行号、列号
        /// </summary>
        /// <param name="Char">行列地址的字符串形式，对于行为"1""2"……，对于列为"A""B"……</param>
        /// <param name="type">判断是对行还是对列做转换，true为列，false为行</param>
        /// <returns></returns>
        public static int Transfer_int(List<char> Char, bool type)
        {
            int result = 0;
            if (type == true) //对列转换时
            {
                for (int i = 0; i < Char.Count; i++)
                {
                    int t = Char[i] - 64;
                    result += t * (int)Math.Pow(26, Char.Count - 1 - i);
                }
            }
            else //对行时
            {
                for (int i = 0; i < Char.Count; i++)
                {
                    int t = Char[i] - 48;
                    result += t * (int)Math.Pow(10, Char.Count - 1 - i);
                }
            }
            return result;
        }

        /// <summary>
        /// 对于字符串形式的数据范围，获取行号、列号信息
        /// </summary>
        /// <param name="str">用户输入或选择的数据范围，如"A3:D10"</param>
        /// <returns></returns>
        public static List<int> GetDisplayInfo(string str)
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

        /// <summary>
        /// 对数据进行标准化处理
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<double> Stantardize(List<double> source)
        {
            List<double> result = new List<double>();
            int num = source.Count; //项数
            double average = source.Sum() / num; //平均值
            double devi0 = 0;
            for (int i = 0; i < num; i++)
                devi0 += Math.Pow((source[i] - average), 2); //方差
            double std_devi0 = System.Math.Sqrt(devi0 / (num - 1)); //标准差
            for (int j = 0; j < num; j++)
                result.Add((source[j] - average) / std_devi0);
            return result;
        }

        /// <summary>
        /// 获取数据列参数，依次为：最小值,最大值,平均值，中位数，标准差，5%，25%，75%，95%，计数
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<double> Parameter(List<double> source)
        {
            List<double> result = new List<double>();
            source.Sort(); //将source中的数据从小到大排列
            int num = source.Count; //项数
            double min = source[0]; //最小值
            double max = source[num - 1]; //最大值
            double average = source.Sum() / num; //平均值
            double middle;
            if (num % 2 == 0)
                middle = (source[num / 2 - 1] + source[num / 2]) / 2;
            else
                middle = source[(int)(num / 2)]; //中位数
            double devi = 0;
            for (int i = 0; i < num; i++)
                devi += Math.Pow((source[i] - average), 2); //方差
            double std_devi = System.Math.Sqrt(devi / num); //标准差
            int mark1, mark2;
            if (num % 20 == 0)
                mark1 = (int)(0.05 * num);
            else
                mark1 = (int)(0.05 * num) + 1;
            if (num % 4 == 0)
                mark2 = (int)(0.25 * num);
            else
                mark2 = (int)(0.25 * num) + 1;
            double five_percent = source[mark1 - 1]; //5%
            double nintyfive_percent = source[num - mark1 - 1]; //95%
            double twentyfive_percent = source[mark2 - 1]; //25%
            double seventyfive_percent = source[num - mark2 - 1]; //75%

            result.Add(min); //向参数序列中添加各个参数
            result.Add(max);
            result.Add(average);
            result.Add(middle);
            result.Add(std_devi);
            result.Add(five_percent);
            result.Add(twentyfive_percent);
            result.Add(seventyfive_percent);
            result.Add(nintyfive_percent);
            result.Add(Convert.ToDouble(num));
            
            return result;
        }

        /// <summary>
        /// 超过三位的数用科学计数法保留两位小数
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string SciNotation(double input)
        {
            if ((input >= 1000) || ((1000 * input - Convert.ToInt32(1000 * input) != 0)))
                return (input.ToString("e2"));
            else
                return (Convert.ToString(input));
        }
 
    }
}
