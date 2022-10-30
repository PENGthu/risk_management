namespace Dataset_Manager
{
    partial class Form_DataViewer
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
            this.textBox_Head = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.maskedTextBox_Range = new System.Windows.Forms.MaskedTextBox();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.Save = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox_Name = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.Display = new System.Windows.Forms.Button();
            this.radioButton_Row = new System.Windows.Forms.RadioButton();
            this.radioButton_Column = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Excel_Range = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Variable_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Range_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Output_Format = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.Confirm = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.comboBox_Opt = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Open
            // 
            this.Open.Font = new System.Drawing.Font("黑体", 9F);
            this.Open.Location = new System.Drawing.Point(642, 157);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(75, 23);
            this.Open.TabIndex = 1;
            this.Open.Text = "打开";
            this.Open.UseVisualStyleBackColor = true;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // Delete
            // 
            this.Delete.Font = new System.Drawing.Font("黑体", 9F);
            this.Delete.Location = new System.Drawing.Point(723, 157);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 4;
            this.Delete.Text = "删除";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "选择已有项：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_Head);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.maskedTextBox_Range);
            this.groupBox1.Controls.Add(this.textBox_Name);
            this.groupBox1.Controls.Add(this.Save);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.checkBox_Name);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("黑体", 9F);
            this.groupBox1.Location = new System.Drawing.Point(118, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(680, 110);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据";
            // 
            // textBox_Head
            // 
            this.textBox_Head.Location = new System.Drawing.Point(460, 82);
            this.textBox_Head.Name = "textBox_Head";
            this.textBox_Head.Size = new System.Drawing.Size(100, 25);
            this.textBox_Head.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(303, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "请输入表头所在行：";
            // 
            // maskedTextBox_Range
            // 
            this.maskedTextBox_Range.Location = new System.Drawing.Point(113, 54);
            this.maskedTextBox_Range.Name = "maskedTextBox_Range";
            this.maskedTextBox_Range.Size = new System.Drawing.Size(561, 25);
            this.maskedTextBox_Range.TabIndex = 7;
            this.maskedTextBox_Range.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox_Range_MaskInputRejected);
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(113, 22);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(561, 25);
            this.textBox_Name.TabIndex = 6;
            this.textBox_Name.TextChanged += new System.EventHandler(this.textBox_Name_TextChanged);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(599, 82);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 5;
            this.Save.Text = "创建";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Excel范围(E)";
            // 
            // checkBox_Name
            // 
            this.checkBox_Name.AutoSize = true;
            this.checkBox_Name.Checked = true;
            this.checkBox_Name.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Name.Location = new System.Drawing.Point(113, 85);
            this.checkBox_Name.Name = "checkBox_Name";
            this.checkBox_Name.Size = new System.Drawing.Size(173, 19);
            this.checkBox_Name.TabIndex = 13;
            this.checkBox_Name.Text = "名称在表格第一行中";
            this.checkBox_Name.UseVisualStyleBackColor = true;
            this.checkBox_Name.CheckedChanged += new System.EventHandler(this.checkBox_Name_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "名称(N)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.Display);
            this.groupBox2.Controls.Add(this.radioButton_Row);
            this.groupBox2.Controls.Add(this.radioButton_Column);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("黑体", 9F);
            this.groupBox2.Location = new System.Drawing.Point(12, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(786, 405);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "变量";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = "数据源";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 247);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 27;
            this.dataGridView2.Size = new System.Drawing.Size(745, 152);
            this.dataGridView2.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(437, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "label5";
            // 
            // Display
            // 
            this.Display.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Display.Location = new System.Drawing.Point(757, 169);
            this.Display.Name = "Display";
            this.Display.Size = new System.Drawing.Size(23, 75);
            this.Display.TabIndex = 8;
            this.Display.Text = "确认显示";
            this.Display.UseVisualStyleBackColor = true;
            this.Display.Click += new System.EventHandler(this.Display_Click);
            // 
            // radioButton_Row
            // 
            this.radioButton_Row.AutoSize = true;
            this.radioButton_Row.Location = new System.Drawing.Point(184, 15);
            this.radioButton_Row.Name = "radioButton_Row";
            this.radioButton_Row.Size = new System.Drawing.Size(44, 19);
            this.radioButton_Row.TabIndex = 15;
            this.radioButton_Row.Text = "行";
            this.radioButton_Row.UseVisualStyleBackColor = true;
            this.radioButton_Row.CheckedChanged += new System.EventHandler(this.radioButton_Row_CheckedChanged);
            // 
            // radioButton_Column
            // 
            this.radioButton_Column.AutoSize = true;
            this.radioButton_Column.Checked = true;
            this.radioButton_Column.Location = new System.Drawing.Point(106, 15);
            this.radioButton_Column.Name = "radioButton_Column";
            this.radioButton_Column.Size = new System.Drawing.Size(44, 19);
            this.radioButton_Column.TabIndex = 14;
            this.radioButton_Column.TabStop = true;
            this.radioButton_Column.Text = "列";
            this.radioButton_Column.UseVisualStyleBackColor = true;
            this.radioButton_Column.CheckedChanged += new System.EventHandler(this.radioButton_Column_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Excel_Range,
            this.Variable_Name,
            this.Range_Name,
            this.Output_Format});
            this.dataGridView1.Location = new System.Drawing.Point(4, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(747, 187);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Excel_Range
            // 
            this.Excel_Range.HeaderText = "Excel数据范围";
            this.Excel_Range.MinimumWidth = 6;
            this.Excel_Range.Name = "Excel_Range";
            this.Excel_Range.Width = 174;
            // 
            // Variable_Name
            // 
            this.Variable_Name.HeaderText = "变量名";
            this.Variable_Name.MinimumWidth = 6;
            this.Variable_Name.Name = "Variable_Name";
            this.Variable_Name.Width = 174;
            // 
            // Range_Name
            // 
            this.Range_Name.HeaderText = "Excel范围名称";
            this.Range_Name.MinimumWidth = 6;
            this.Range_Name.Name = "Range_Name";
            this.Range_Name.Width = 174;
            // 
            // Output_Format
            // 
            this.Output_Format.HeaderText = "输出格式";
            this.Output_Format.MinimumWidth = 6;
            this.Output_Format.Name = "Output_Format";
            this.Output_Format.Width = 174;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "布局：";
            // 
            // Confirm
            // 
            this.Confirm.Font = new System.Drawing.Font("黑体", 9F);
            this.Confirm.Location = new System.Drawing.Point(642, 590);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(75, 23);
            this.Confirm.TabIndex = 8;
            this.Confirm.Text = "确定";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // Cancel
            // 
            this.Cancel.Font = new System.Drawing.Font("黑体", 9F);
            this.Cancel.Location = new System.Drawing.Point(723, 590);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 9;
            this.Cancel.Text = "取消";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // comboBox_Opt
            // 
            this.comboBox_Opt.FormattingEnabled = true;
            this.comboBox_Opt.Location = new System.Drawing.Point(118, 128);
            this.comboBox_Opt.Name = "comboBox_Opt";
            this.comboBox_Opt.Size = new System.Drawing.Size(680, 23);
            this.comboBox_Opt.TabIndex = 10;
            this.comboBox_Opt.SelectedIndexChanged += new System.EventHandler(this.comboBox_Opt_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("黑体", 9F);
            this.label7.Location = new System.Drawing.Point(12, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "新建数据集：";
            // 
            // Form_DataViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 625);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox_Opt);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Open);
            this.Name = "Form_DataViewer";
            this.Text = "Form1";
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
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.ComboBox comboBox_Opt;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Range;
        private System.Windows.Forms.CheckBox checkBox_Name;
        private System.Windows.Forms.RadioButton radioButton_Column;
        private System.Windows.Forms.RadioButton radioButton_Row;
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
    }
}