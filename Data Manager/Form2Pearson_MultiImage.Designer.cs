namespace Dataset_Manager
{
    partial class Form2Pearson_MultiImage
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Close = new System.Windows.Forms.Button();
            this.Confidence = new System.Windows.Forms.RadioButton();
            this.Column = new System.Windows.Forms.RadioButton();
            this.DataGridViewShow = new System.Windows.Forms.RadioButton();
            this.optional_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Yes = new System.Windows.Forms.RadioButton();
            this.No = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Box = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optional_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridView1.Location = new System.Drawing.Point(13, 14);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1174, 630);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column1.HeaderText = "数据列";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 127;
            // 
            // Close
            // 
            this.Close.Font = new System.Drawing.Font("黑体", 9F);
            this.Close.Location = new System.Drawing.Point(1075, 669);
            this.Close.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(112, 37);
            this.Close.TabIndex = 1;
            this.Close.Text = "关闭";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // Confidence
            // 
            this.Confidence.Appearance = System.Windows.Forms.Appearance.Button;
            this.Confidence.AutoSize = true;
            this.Confidence.Image = global::Dataset_Manager.Properties.Resources.堆积图1;
            this.Confidence.Location = new System.Drawing.Point(200, 652);
            this.Confidence.Name = "Confidence";
            this.Confidence.Size = new System.Drawing.Size(56, 56);
            this.Confidence.TabIndex = 4;
            this.Confidence.UseVisualStyleBackColor = true;
            this.Confidence.Click += new System.EventHandler(this.Confidence_Click);
            // 
            // Column
            // 
            this.Column.Appearance = System.Windows.Forms.Appearance.Button;
            this.Column.AutoSize = true;
            this.Column.Image = global::Dataset_Manager.Properties.Resources.柱状图11;
            this.Column.Location = new System.Drawing.Point(75, 652);
            this.Column.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Column.Name = "Column";
            this.Column.Size = new System.Drawing.Size(56, 56);
            this.Column.TabIndex = 2;
            this.Column.UseVisualStyleBackColor = true;
            this.Column.Click += new System.EventHandler(this.Column_Click);
            // 
            // DataGridViewShow
            // 
            this.DataGridViewShow.Appearance = System.Windows.Forms.Appearance.Button;
            this.DataGridViewShow.AutoSize = true;
            this.DataGridViewShow.Image = global::Dataset_Manager.Properties.Resources.表格;
            this.DataGridViewShow.Location = new System.Drawing.Point(12, 652);
            this.DataGridViewShow.Name = "DataGridViewShow";
            this.DataGridViewShow.Size = new System.Drawing.Size(56, 56);
            this.DataGridViewShow.TabIndex = 5;
            this.DataGridViewShow.UseVisualStyleBackColor = true;
            this.DataGridViewShow.CheckedChanged += new System.EventHandler(this.DataGridViewShow_CheckedChanged);
            // 
            // optional_chart
            // 
            chartArea3.Name = "ChartArea1";
            this.optional_chart.ChartAreas.Add(chartArea3);
            legend3.Enabled = false;
            legend3.Name = "Legend1";
            this.optional_chart.Legends.Add(legend3);
            this.optional_chart.Location = new System.Drawing.Point(13, 14);
            this.optional_chart.Name = "optional_chart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.optional_chart.Series.Add(series3);
            this.optional_chart.Size = new System.Drawing.Size(906, 630);
            this.optional_chart.TabIndex = 6;
            this.optional_chart.Text = "chart3";
            this.optional_chart.Visible = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(925, 14);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidth = 82;
            this.dataGridView2.RowTemplate.Height = 37;
            this.dataGridView2.Size = new System.Drawing.Size(262, 450);
            this.dataGridView2.TabIndex = 7;
            this.dataGridView2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 9F);
            this.label1.Location = new System.Drawing.Point(528, 675);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "是否标准化：";
            this.label1.Visible = false;
            // 
            // Yes
            // 
            this.Yes.AutoSize = true;
            this.Yes.Font = new System.Drawing.Font("黑体", 9F);
            this.Yes.Location = new System.Drawing.Point(3, 4);
            this.Yes.Name = "Yes";
            this.Yes.Size = new System.Drawing.Size(65, 28);
            this.Yes.TabIndex = 9;
            this.Yes.Text = "是";
            this.Yes.UseVisualStyleBackColor = true;
            this.Yes.Visible = false;
            this.Yes.Click += new System.EventHandler(this.Yes_Click);
            // 
            // No
            // 
            this.No.AutoSize = true;
            this.No.Checked = true;
            this.No.Font = new System.Drawing.Font("黑体", 9F);
            this.No.Location = new System.Drawing.Point(149, 4);
            this.No.Name = "No";
            this.No.Size = new System.Drawing.Size(65, 28);
            this.No.TabIndex = 10;
            this.No.TabStop = true;
            this.No.Text = "否";
            this.No.UseVisualStyleBackColor = true;
            this.No.Visible = false;
            this.No.Click += new System.EventHandler(this.No_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Yes);
            this.panel1.Controls.Add(this.No);
            this.panel1.Location = new System.Drawing.Point(688, 669);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 37);
            this.panel1.TabIndex = 11;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1013, 568);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(174, 35);
            this.textBox1.TabIndex = 12;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1013, 609);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(174, 35);
            this.textBox2.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("黑体", 9F);
            this.label2.Location = new System.Drawing.Point(925, 571);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 14;
            this.label2.Text = "line1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("黑体", 9F);
            this.label3.Location = new System.Drawing.Point(925, 612);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 15;
            this.label3.Text = "line2:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("黑体", 9F);
            this.label4.Location = new System.Drawing.Point(925, 527);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 24);
            this.label4.TabIndex = 16;
            this.label4.Text = "横坐标值";
            // 
            // Box
            // 
            this.Box.Appearance = System.Windows.Forms.Appearance.Button;
            this.Box.AutoSize = true;
            this.Box.Image = global::Dataset_Manager.Properties.Resources.基础箱型图22;
            this.Box.Location = new System.Drawing.Point(138, 652);
            this.Box.Name = "Box";
            this.Box.Size = new System.Drawing.Size(56, 56);
            this.Box.TabIndex = 17;
            this.Box.TabStop = true;
            this.Box.UseVisualStyleBackColor = true;
            this.Box.Click += new System.EventHandler(this.Box_Click);
            // 
            // Form2Pearson_MultiImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.Box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.optional_chart);
            this.Controls.Add(this.DataGridViewShow);
            this.Controls.Add(this.Confidence);
            this.Controls.Add(this.Column);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form2Pearson_MultiImage";
            this.Text = "Form2Pearson_MultiImage";
            this.Load += new System.EventHandler(this.Form2Pearson_MultiImage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optional_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.RadioButton Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.RadioButton Confidence;
        private System.Windows.Forms.RadioButton DataGridViewShow;
        private System.Windows.Forms.DataVisualization.Charting.Chart optional_chart;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton Yes;
        private System.Windows.Forms.RadioButton No;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton Box;
    }
}