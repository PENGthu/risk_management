using System;
using System.Collections;
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
    public partial class Form2Pearson : Form
    {
        public static Dictionary<DataTable, List<double>> dtSingle_P;//单个数据列,键为数据表，值为参数序列
        public static DataTable dt_Pcol; //单个数据列数据表
        private List<List<double>> dt_Pparamatrix1; //单个数据列参数（依次：最小值,最大值,平均值，标准差，5%，25%，75%，95%）组成的矩阵
        public static Dictionary<DataTable, List<List<double>>> dtMulti_P; //两个数据列
        public static DataTable dt_P; //多个数据列数据表
        private List<List<double>> dt_Pparamatrix2; //多个数据列参数
        public static int sign = 0; //由于单个数据列的查看和多个数据列分别查看单个图像时有代码重复，故使用同一个窗体显示图像，sign用来指示，sign=1时表示单个数据列查看，=2时表示多个数据列分别查看

        public Form2Pearson()
        {
            InitializeComponent();
        }

        private void Form2Pearson_Load(object sender, EventArgs e)
        {
            dt_Pparamatrix1 = new List<List<double>>(); //二维数组，存放所有列的参数
            int n = Form2.dt.Columns.Count;
            dataGridView1.Rows.Add(n);
            for (int i = 0; i < n; i++) //对数据集每列做操作
            {
                List<double> dt_Ppara = new List<double>();
                ArrayList temp = Dataset.GetColumn(Form2.dt, i);
                List<double> col = new List<double>();
                for (int j = 0; j < temp.Count; j++)
                    col.Add(Convert.ToDouble(temp[j])); //将选中的Form2的dt中的每列数据存入col
                dt_Ppara = Dataset.Parameter(col); //获取每列的各参数
                
                dataGridView1[1, i].Value = "查看"; //向表格中添加各个参数
                dataGridView1[2, i].Value = Dataset.DS.Tables[Form2.dtName].Columns[i];
                dataGridView1[3, i].Value = Convert.ToString(dt_Ppara[0]); 
                dataGridView1[4, i].Value = Convert.ToString(dt_Ppara[1]);
                dataGridView1[5, i].Value = Dataset.SciNotation(dt_Ppara[2]);
                dataGridView1[6, i].Value = Dataset.SciNotation(dt_Ppara[4]);
                dataGridView1[7, i].Value = Convert.ToString(dt_Ppara[5]);
                dataGridView1[8, i].Value = Convert.ToString(dt_Ppara[8]);
                dataGridView1[9, i].Value = Convert.ToString(dt_Ppara[9]);

                dt_Pparamatrix1.Add(dt_Ppara); //将参数序列加入二位维数组
            }
        }
        /// <summary>
        /// 查看单个数据列的图表
        /// 对于Dictionary,在单列查看的情况下其名字为dtSingle_P
        /// 键为目标数据列dt_Pcol,值为对应于dt_Pcol的参数矩阵的行，即由dt_Pcol各参数组成的数组，数组长度为10
        /// 使用Dictionary的目的是在Form2Pearson中已经计算过各数据列的参数，后续仍然需要用，避免重复计算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {           
            if (e.ColumnIndex == 1) //点击“查看”时
            {
                dtSingle_P = new Dictionary<DataTable, List<double>>();
                dt_Pcol = new DataTable(); //以下三行：新建column1是因为不能将原来Form2.dt中的列直接放到新的dt_Pcol中
                DataColumn column1 = Form2.dt.Columns[e.RowIndex];
                dt_Pcol.Columns.Add(column1.ColumnName, column1.DataType); //为dt_Pcol添加表头
                for (int i = 0; i < Form2.dt.Rows.Count; i++) //将每一行添加到dt_Pcol中
                {
                    DataRow row1 = dt_Pcol.NewRow();
                    row1[0] = Form2.dt.Rows[i][e.RowIndex];
                    dt_Pcol.Rows.Add(row1);
                }
                dtSingle_P.Add(dt_Pcol, dt_Pparamatrix1[e.RowIndex]); //将数据表列和该列的参数序列加入Dictionary dtSingle_P中

                sign = 1;
                Form2Pearson_SingleImage formP_SinImage1 = new Form2Pearson_SingleImage();
                formP_SinImage1.ShowDialog();
            }
        }

        private void Check_Click(object sender, EventArgs e)
        /*选定后查看多个数据列相关性的图表*/
        {
            /*选中的数据列不能少于2列*/
            List<int> num_col = new List<int>(); //用于存放选中的列号（从0开始）
            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value) == true)
                    num_col.Add(i);
            }
            if (num_col.Count < 2)
                MessageBox.Show("至少选择2列数据！"); 
            else
            {
                dtMulti_P = new Dictionary<DataTable, List<List<double>>>();
                dt_P = new DataTable();
                dt_Pparamatrix2 = new List<List<double>>();
                for (int i = 0; i < num_col.Count; i++)
                {
                    DataColumn column2 = new DataColumn(); //以下三行：新建column2是因为不能将原来Form2.dt中的列直接放到新的dt_P中
                    column2 = Form2.dt.Columns[num_col[i]];
                    dt_P.Columns.Add(column2.ColumnName, column2.DataType); //根据选择的几列为dt_P添加表头
                    dt_Pparamatrix2.Add(dt_Pparamatrix1[num_col[i]]); //根据选择的几列将相应列的参数数组存入dt_Pparamatrix2
                }
                for (int i = 0; i < Form2.dt.Rows.Count; i++) //将每一行添加到dt_P中
                {
                    DataRow row2 = dt_P.NewRow();
                    for(int j = 0;j < num_col.Count; j++)
                        row2[j] = Form2.dt.Rows[i][num_col[j]];
                    dt_P.Rows.Add(row2);
                }
                dtMulti_P.Add(dt_P, dt_Pparamatrix2);

                Form2Pearson_MultiImage formP_MultiImage = new Form2Pearson_MultiImage();
                formP_MultiImage.ShowDialog();
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form2.btn_flag = 0;
        }
    }
}
