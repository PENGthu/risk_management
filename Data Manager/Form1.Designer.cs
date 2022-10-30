namespace Dataset_Manager
{
    partial class Form1
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
            this.Open = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.textBox_Head = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.maskedTextBox_Range = new System.Windows.Forms.MaskedTextBox();
            this.Create = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton_Row = new System.Windows.Forms.RadioButton();
            this.radioButton_Column = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.Display = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Excel_Range = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Variable_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Range_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Output_Format = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.Confirm = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_Opt = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Open
            // 
            this.Open.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Open.Location = new System.Drawing.Point(963, 272);
            this.Open.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(112, 37);
            this.Open.TabIndex = 1;
            this.Open.Text = "打开";
            this.Open.UseVisualStyleBackColor = true;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // Delete
            // 
            this.Delete.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Delete.Location = new System.Drawing.Point(1084, 272);
            this.Delete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(112, 37);
            this.Delete.TabIndex = 4;
            this.Delete.Text = "删除";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(18, 230);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "选择已有项：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBox_Name);
            this.groupBox1.Controls.Add(this.textBox_Head);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.maskedTextBox_Range);
            this.groupBox1.Controls.Add(this.Create);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(177, 19);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1020, 197);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据";
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(170, 35);
            this.textBox_Name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(840, 39);
            this.textBox_Name.TabIndex = 16;
            // 
            // textBox_Head
            // 
            this.textBox_Head.Location = new System.Drawing.Point(170, 141);
            this.textBox_Head.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_Head.Name = "textBox_Head";
            this.textBox_Head.Size = new System.Drawing.Size(148, 39);
            this.textBox_Head.TabIndex = 15;
            this.textBox_Head.Text = "1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 150);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(158, 31);
            this.label8.TabIndex = 14;
            this.label8.Text = "表头所在行：";
            // 
            // maskedTextBox_Range
            // 
            this.maskedTextBox_Range.Location = new System.Drawing.Point(170, 86);
            this.maskedTextBox_Range.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.maskedTextBox_Range.Name = "maskedTextBox_Range";
            this.maskedTextBox_Range.Size = new System.Drawing.Size(840, 39);
            this.maskedTextBox_Range.TabIndex = 7;
            this.maskedTextBox_Range.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox_Range_MaskInputRejected);
            // 
            // Create
            // 
            this.Create.Location = new System.Drawing.Point(898, 144);
            this.Create.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(112, 37);
            this.Create.TabIndex = 5;
            this.Create.Text = "创建";
            this.Create.UseVisualStyleBackColor = true;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 31);
            this.label3.TabIndex = 1;
            this.label3.Text = "Excel范围(E)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "名称(N)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton_Row);
            this.groupBox2.Controls.Add(this.radioButton_Column);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.Display);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(18, 309);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(1179, 670);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "变量";
            // 
            // radioButton_Row
            // 
            this.radioButton_Row.AutoSize = true;
            this.radioButton_Row.Location = new System.Drawing.Point(257, 28);
            this.radioButton_Row.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton_Row.Name = "radioButton_Row";
            this.radioButton_Row.Size = new System.Drawing.Size(69, 35);
            this.radioButton_Row.TabIndex = 20;
            this.radioButton_Row.TabStop = true;
            this.radioButton_Row.Text = "行";
            this.radioButton_Row.UseVisualStyleBackColor = true;
            // 
            // radioButton_Column
            // 
            this.radioButton_Column.AutoSize = true;
            this.radioButton_Column.Checked = true;
            this.radioButton_Column.Location = new System.Drawing.Point(159, 26);
            this.radioButton_Column.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton_Column.Name = "radioButton_Column";
            this.radioButton_Column.Size = new System.Drawing.Size(69, 35);
            this.radioButton_Column.TabIndex = 19;
            this.radioButton_Column.TabStop = true;
            this.radioButton_Column.Text = "列";
            this.radioButton_Column.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 377);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 31);
            this.label6.TabIndex = 18;
            this.label6.Text = "数据源";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(9, 413);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 27;
            this.dataGridView2.Size = new System.Drawing.Size(1118, 230);
            this.dataGridView2.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(654, 30);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 31);
            this.label5.TabIndex = 16;
            this.label5.Text = "label5";
            this.label5.Visible = false;
            // 
            // Display
            // 
            this.Display.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Display.Location = new System.Drawing.Point(1136, 320);
            this.Display.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Display.Name = "Display";
            this.Display.Size = new System.Drawing.Size(34, 120);
            this.Display.TabIndex = 8;
            this.Display.Text = "确认显示";
            this.Display.UseVisualStyleBackColor = true;
            this.Display.Click += new System.EventHandler(this.Display_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Excel_Range,
            this.Variable_Name,
            this.Range_Name,
            this.Output_Format});
            this.dataGridView1.Location = new System.Drawing.Point(6, 73);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1120, 291);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Excel_Range
            // 
            this.Excel_Range.HeaderText = "Excel数据范围";
            this.Excel_Range.MinimumWidth = 6;
            this.Excel_Range.Name = "Excel_Range";
            // 
            // Variable_Name
            // 
            this.Variable_Name.HeaderText = "变量名";
            this.Variable_Name.MinimumWidth = 6;
            this.Variable_Name.Name = "Variable_Name";
            // 
            // Range_Name
            // 
            this.Range_Name.HeaderText = "Excel范围名称";
            this.Range_Name.MinimumWidth = 6;
            this.Range_Name.Name = "Range_Name";
            // 
            // Output_Format
            // 
            this.Output_Format.HeaderText = "输出格式";
            this.Output_Format.MinimumWidth = 6;
            this.Output_Format.Name = "Output_Format";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 31);
            this.label4.TabIndex = 0;
            this.label4.Text = "布局：";
            // 
            // Confirm
            // 
            this.Confirm.Font = new System.Drawing.Font("黑体", 9F);
            this.Confirm.Location = new System.Drawing.Point(963, 989);
            this.Confirm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(112, 37);
            this.Confirm.TabIndex = 8;
            this.Confirm.Text = "确定";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // Cancel
            // 
            this.Cancel.Font = new System.Drawing.Font("黑体", 9F);
            this.Cancel.Location = new System.Drawing.Point(1084, 989);
            this.Cancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(112, 37);
            this.Cancel.TabIndex = 9;
            this.Cancel.Text = "取消";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(18, 31);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 31);
            this.label7.TabIndex = 11;
            this.label7.Text = "新建数据集：";
            // 
            // comboBox_Opt
            // 
            this.comboBox_Opt.FormattingEnabled = true;
            this.comboBox_Opt.Location = new System.Drawing.Point(177, 226);
            this.comboBox_Opt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox_Opt.Name = "comboBox_Opt";
            this.comboBox_Opt.Size = new System.Drawing.Size(1018, 32);
            this.comboBox_Opt.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(618, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 31);
            this.label9.TabIndex = 17;
            this.label9.Text = "label9";
            this.label9.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 1045);
            this.Controls.Add(this.comboBox_Opt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Open);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "StatTools - 数据集管理器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Open;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Range;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Display;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Excel_Range;
        private System.Windows.Forms.DataGridViewTextBoxColumn Variable_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Range_Name;
        private System.Windows.Forms.DataGridViewComboBoxColumn Output_Format;
        private System.Windows.Forms.TextBox textBox_Head;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox_Opt;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.RadioButton radioButton_Column;
        private System.Windows.Forms.RadioButton radioButton_Row;
        private System.Windows.Forms.Label label9;
    }
}