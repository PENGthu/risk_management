namespace Dataset_Manager
{
    partial class Form2Pearson
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CheckIm = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Dataname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Minimum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Maximum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Average = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Standard_Deviation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Five_Percent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ninty_Five_Percent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Close = new System.Windows.Forms.Button();
            this.Check = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.CheckIm,
            this.Dataname,
            this.Minimum,
            this.Maximum,
            this.Average,
            this.Standard_Deviation,
            this.Five_Percent,
            this.Ninty_Five_Percent,
            this.Count});
            this.dataGridView1.Location = new System.Drawing.Point(18, 19);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1164, 635);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "选择";
            this.Column1.MinimumWidth = 10;
            this.Column1.Name = "Column1";
            // 
            // CheckIm
            // 
            this.CheckIm.HeaderText = "查看图像";
            this.CheckIm.MinimumWidth = 6;
            this.CheckIm.Name = "CheckIm";
            this.CheckIm.Text = "查看";
            // 
            // Dataname
            // 
            this.Dataname.HeaderText = "数据列名称";
            this.Dataname.MinimumWidth = 6;
            this.Dataname.Name = "Dataname";
            // 
            // Minimum
            // 
            this.Minimum.HeaderText = "最小值";
            this.Minimum.MinimumWidth = 6;
            this.Minimum.Name = "Minimum";
            // 
            // Maximum
            // 
            this.Maximum.HeaderText = "最大值";
            this.Maximum.MinimumWidth = 6;
            this.Maximum.Name = "Maximum";
            // 
            // Average
            // 
            this.Average.HeaderText = "平均值";
            this.Average.MinimumWidth = 6;
            this.Average.Name = "Average";
            // 
            // Standard_Deviation
            // 
            this.Standard_Deviation.HeaderText = "标准差";
            this.Standard_Deviation.MinimumWidth = 6;
            this.Standard_Deviation.Name = "Standard_Deviation";
            // 
            // Five_Percent
            // 
            this.Five_Percent.HeaderText = "5%";
            this.Five_Percent.MinimumWidth = 6;
            this.Five_Percent.Name = "Five_Percent";
            // 
            // Ninty_Five_Percent
            // 
            this.Ninty_Five_Percent.HeaderText = "95%";
            this.Ninty_Five_Percent.MinimumWidth = 6;
            this.Ninty_Five_Percent.Name = "Ninty_Five_Percent";
            // 
            // Count
            // 
            this.Count.HeaderText = "计数";
            this.Count.MinimumWidth = 6;
            this.Count.Name = "Count";
            // 
            // Close
            // 
            this.Close.Font = new System.Drawing.Font("黑体", 9F);
            this.Close.Location = new System.Drawing.Point(1070, 664);
            this.Close.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(112, 37);
            this.Close.TabIndex = 1;
            this.Close.Text = "关闭";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // Check
            // 
            this.Check.Font = new System.Drawing.Font("黑体", 9F);
            this.Check.Location = new System.Drawing.Point(918, 664);
            this.Check.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Check.Name = "Check";
            this.Check.Size = new System.Drawing.Size(142, 37);
            this.Check.TabIndex = 2;
            this.Check.Text = "查看相关性";
            this.Check.UseVisualStyleBackColor = true;
            this.Check.Click += new System.EventHandler(this.Check_Click);
            // 
            // Form2Pearson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.Check);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form2Pearson";
            this.Text = "Pearson相关性查看";
            this.Load += new System.EventHandler(this.Form2Pearson_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button Check;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewButtonColumn CheckIm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dataname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Minimum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Maximum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Average;
        private System.Windows.Forms.DataGridViewTextBoxColumn Standard_Deviation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Five_Percent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ninty_Five_Percent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
    }
}