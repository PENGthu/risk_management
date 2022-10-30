namespace Dataset_Manager
{
    partial class Form2Pearson_SingleImage
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Close = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Yes = new System.Windows.Forms.RadioButton();
            this.No = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Box = new System.Windows.Forms.RadioButton();
            this.Bar = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            legend1.TitleSeparator = System.Windows.Forms.DataVisualization.Charting.LegendSeparatorStyle.Line;
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(13, 14);
            this.chart1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chart1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series1.BorderColor = System.Drawing.Color.Black;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(937, 630);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            this.chart1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseDown_1);
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove_1);
            this.chart1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseUp_1);
            // 
            // Close
            // 
            this.Close.Font = new System.Drawing.Font("黑体", 9F);
            this.Close.Location = new System.Drawing.Point(1075, 669);
            this.Close.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(112, 37);
            this.Close.TabIndex = 12;
            this.Close.Text = "关闭";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Yes);
            this.panel1.Controls.Add(this.No);
            this.panel1.Location = new System.Drawing.Point(755, 668);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(201, 38);
            this.panel1.TabIndex = 19;
            // 
            // Yes
            // 
            this.Yes.AutoSize = true;
            this.Yes.Font = new System.Drawing.Font("黑体", 9F);
            this.Yes.Location = new System.Drawing.Point(4, 5);
            this.Yes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Yes.Name = "Yes";
            this.Yes.Size = new System.Drawing.Size(65, 28);
            this.Yes.TabIndex = 2;
            this.Yes.Text = "是";
            this.Yes.UseVisualStyleBackColor = true;
            this.Yes.CheckedChanged += new System.EventHandler(this.Yes_CheckedChanged);
            // 
            // No
            // 
            this.No.AutoSize = true;
            this.No.Checked = true;
            this.No.Font = new System.Drawing.Font("黑体", 9F);
            this.No.Location = new System.Drawing.Point(130, 5);
            this.No.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.No.Name = "No";
            this.No.Size = new System.Drawing.Size(65, 28);
            this.No.TabIndex = 1;
            this.No.TabStop = true;
            this.No.Text = "否";
            this.No.UseVisualStyleBackColor = true;
            this.No.CheckedChanged += new System.EventHandler(this.No_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("黑体", 9F);
            this.label5.Location = new System.Drawing.Point(964, 567);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 24);
            this.label5.TabIndex = 20;
            this.label5.Text = "line1:\r\n";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("黑体", 9F);
            this.label6.Location = new System.Drawing.Point(964, 612);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 24);
            this.label6.TabIndex = 21;
            this.label6.Text = "line2:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 9F);
            this.label1.Location = new System.Drawing.Point(597, 675);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 22;
            this.label1.Text = "是否标准化：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("黑体", 9F);
            this.label4.Location = new System.Drawing.Point(964, 535);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 24);
            this.label4.TabIndex = 23;
            this.label4.Text = "横坐标值";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("黑体", 9F);
            this.textBox1.Location = new System.Drawing.Point(1058, 564);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(129, 35);
            this.textBox1.TabIndex = 26;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("黑体", 9F);
            this.textBox2.Location = new System.Drawing.Point(1058, 609);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(129, 35);
            this.textBox2.TabIndex = 27;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Box
            // 
            this.Box.Appearance = System.Windows.Forms.Appearance.Button;
            this.Box.AutoSize = true;
            this.Box.Font = new System.Drawing.Font("黑体", 9F);
            this.Box.Image = global::Dataset_Manager.Properties.Resources.基础箱型图22;
            this.Box.Location = new System.Drawing.Point(77, 654);
            this.Box.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Box.Name = "Box";
            this.Box.Size = new System.Drawing.Size(56, 56);
            this.Box.TabIndex = 16;
            this.Box.UseVisualStyleBackColor = true;
            this.Box.CheckedChanged += new System.EventHandler(this.Box_CheckedChanged);
            // 
            // Bar
            // 
            this.Bar.Appearance = System.Windows.Forms.Appearance.Button;
            this.Bar.AutoSize = true;
            this.Bar.Checked = true;
            this.Bar.Font = new System.Drawing.Font("黑体", 9F);
            this.Bar.Image = global::Dataset_Manager.Properties.Resources.柱状图11;
            this.Bar.Location = new System.Drawing.Point(13, 654);
            this.Bar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Bar.Name = "Bar";
            this.Bar.Size = new System.Drawing.Size(56, 56);
            this.Bar.TabIndex = 15;
            this.Bar.TabStop = true;
            this.Bar.UseVisualStyleBackColor = true;
            this.Bar.CheckedChanged += new System.EventHandler(this.Bar_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(968, 14);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 37;
            this.dataGridView1.Size = new System.Drawing.Size(219, 450);
            this.dataGridView1.TabIndex = 28;
            // 
            // Form2Pearson_SingleImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Box);
            this.Controls.Add(this.Bar);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.chart1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form2Pearson_SingleImage";
            this.Text = "DataViewer - 一元数据查看";
            this.Load += new System.EventHandler(this.Form2Pearson_SingleImage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.RadioButton Bar;
        private System.Windows.Forms.RadioButton Box;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton No;
        private System.Windows.Forms.RadioButton Yes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}