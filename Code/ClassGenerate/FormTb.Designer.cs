namespace ClassGenerate
{
    partial class FormTb
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpSql = new System.Windows.Forms.TabPage();
            this.textBoxSql = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxReturnType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tpPdr = new System.Windows.Forms.TabPage();
            this.comboBoxReturnTypeProcedure = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPdr = new System.Windows.Forms.TextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGenerateClass = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnGenerateMethod = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tcOutput = new System.Windows.Forms.TabControl();
            this.radioButtonModel = new System.Windows.Forms.RadioButton();
            this.radioButtonDal = new System.Windows.Forms.RadioButton();
            this.tabControl1.SuspendLayout();
            this.tpSql.SuspendLayout();
            this.tpPdr.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(3, 3);
            this.checkedListBox1.MultiColumn = true;
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(423, 164);
            this.checkedListBox1.TabIndex = 0;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 14);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(107, 16);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "自动生成数据集";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpSql);
            this.tabControl1.Controls.Add(this.tpPdr);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(423, 219);
            this.tabControl1.TabIndex = 2;
            // 
            // tpSql
            // 
            this.tpSql.Controls.Add(this.textBoxSql);
            this.tpSql.Controls.Add(this.label4);
            this.tpSql.Controls.Add(this.comboBoxReturnType);
            this.tpSql.Controls.Add(this.label3);
            this.tpSql.Location = new System.Drawing.Point(4, 22);
            this.tpSql.Name = "tpSql";
            this.tpSql.Padding = new System.Windows.Forms.Padding(3);
            this.tpSql.Size = new System.Drawing.Size(415, 193);
            this.tpSql.TabIndex = 0;
            this.tpSql.Text = "SQL语句";
            this.tpSql.UseVisualStyleBackColor = true;
            // 
            // textBoxSql
            // 
            this.textBoxSql.Location = new System.Drawing.Point(66, 34);
            this.textBoxSql.Multiline = true;
            this.textBoxSql.Name = "textBoxSql";
            this.textBoxSql.Size = new System.Drawing.Size(333, 153);
            this.textBoxSql.TabIndex = 5;
            this.textBoxSql.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSql_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "Sql语句";
            // 
            // comboBoxReturnType
            // 
            this.comboBoxReturnType.FormattingEnabled = true;
            this.comboBoxReturnType.Items.AddRange(new object[] {
            "数据集",
            "单值",
            "无返回值"});
            this.comboBoxReturnType.Location = new System.Drawing.Point(89, 3);
            this.comboBoxReturnType.Name = "comboBoxReturnType";
            this.comboBoxReturnType.Size = new System.Drawing.Size(158, 20);
            this.comboBoxReturnType.TabIndex = 3;
            this.comboBoxReturnType.Text = "数据集";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "获取数据格式";
            // 
            // tpPdr
            // 
            this.tpPdr.Controls.Add(this.comboBoxReturnTypeProcedure);
            this.tpPdr.Controls.Add(this.label5);
            this.tpPdr.Controls.Add(this.label2);
            this.tpPdr.Controls.Add(this.textBoxPdr);
            this.tpPdr.Location = new System.Drawing.Point(4, 22);
            this.tpPdr.Name = "tpPdr";
            this.tpPdr.Padding = new System.Windows.Forms.Padding(3);
            this.tpPdr.Size = new System.Drawing.Size(415, 193);
            this.tpPdr.TabIndex = 1;
            this.tpPdr.Text = "存储过程";
            this.tpPdr.UseVisualStyleBackColor = true;
            // 
            // comboBoxReturnTypeProcedure
            // 
            this.comboBoxReturnTypeProcedure.FormattingEnabled = true;
            this.comboBoxReturnTypeProcedure.Items.AddRange(new object[] {
            "数据集",
            "单值",
            "无返回值"});
            this.comboBoxReturnTypeProcedure.Location = new System.Drawing.Point(102, 9);
            this.comboBoxReturnTypeProcedure.Name = "comboBoxReturnTypeProcedure";
            this.comboBoxReturnTypeProcedure.Size = new System.Drawing.Size(158, 20);
            this.comboBoxReturnTypeProcedure.TabIndex = 4;
            this.comboBoxReturnTypeProcedure.Text = "数据集";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "获取数据格式";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "存储过程名称：";
            // 
            // textBoxPdr
            // 
            this.textBoxPdr.Location = new System.Drawing.Point(101, 36);
            this.textBoxPdr.Name = "textBoxPdr";
            this.textBoxPdr.Size = new System.Drawing.Size(281, 21);
            this.textBoxPdr.TabIndex = 0;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(12, 253);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(83, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "自定义方法";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtonDal);
            this.panel1.Controls.Add(this.radioButtonModel);
            this.panel1.Controls.Add(this.btnGenerateClass);
            this.panel1.Controls.Add(this.checkedListBox1);
            this.panel1.Location = new System.Drawing.Point(12, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(429, 205);
            this.panel1.TabIndex = 3;
            // 
            // btnGenerateClass
            // 
            this.btnGenerateClass.Location = new System.Drawing.Point(351, 173);
            this.btnGenerateClass.Name = "btnGenerateClass";
            this.btnGenerateClass.Size = new System.Drawing.Size(75, 23);
            this.btnGenerateClass.TabIndex = 1;
            this.btnGenerateClass.Text = "生成";
            this.btnGenerateClass.UseVisualStyleBackColor = true;
            this.btnGenerateClass.Click += new System.EventHandler(this.btnGenerateClass_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Controls.Add(this.btnGenerateMethod);
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(12, 275);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(429, 254);
            this.panel2.TabIndex = 4;
            // 
            // btnGenerateMethod
            // 
            this.btnGenerateMethod.Location = new System.Drawing.Point(347, 228);
            this.btnGenerateMethod.Name = "btnGenerateMethod";
            this.btnGenerateMethod.Size = new System.Drawing.Size(75, 23);
            this.btnGenerateMethod.TabIndex = 1;
            this.btnGenerateMethod.Text = "生成方法";
            this.btnGenerateMethod.UseVisualStyleBackColor = true;
            this.btnGenerateMethod.Click += new System.EventHandler(this.btnGenerateMethod_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(469, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "输出";
            // 
            // tcOutput
            // 
            this.tcOutput.Location = new System.Drawing.Point(471, 39);
            this.tcOutput.Name = "tcOutput";
            this.tcOutput.SelectedIndex = 0;
            this.tcOutput.Size = new System.Drawing.Size(550, 490);
            this.tcOutput.TabIndex = 7;
            // 
            // radioButtonModel
            // 
            this.radioButtonModel.AutoSize = true;
            this.radioButtonModel.Location = new System.Drawing.Point(224, 179);
            this.radioButtonModel.Name = "radioButtonModel";
            this.radioButtonModel.Size = new System.Drawing.Size(53, 16);
            this.radioButtonModel.TabIndex = 2;
            this.radioButtonModel.Text = "Model";
            this.radioButtonModel.UseVisualStyleBackColor = true;
            // 
            // radioButtonDal
            // 
            this.radioButtonDal.AutoSize = true;
            this.radioButtonDal.Checked = true;
            this.radioButtonDal.Location = new System.Drawing.Point(283, 179);
            this.radioButtonDal.Name = "radioButtonDal";
            this.radioButtonDal.Size = new System.Drawing.Size(41, 16);
            this.radioButtonDal.TabIndex = 2;
            this.radioButtonDal.TabStop = true;
            this.radioButtonDal.Text = "Dal";
            this.radioButtonDal.UseVisualStyleBackColor = true;
            // 
            // FormTb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 540);
            this.Controls.Add(this.tcOutput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.radioButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTb";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "生成数据集";
            this.Load += new System.EventHandler(this.Table_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpSql.ResumeLayout(false);
            this.tpSql.PerformLayout();
            this.tpPdr.ResumeLayout(false);
            this.tpPdr.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpSql;
        private System.Windows.Forms.TabPage tpPdr;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGenerateClass;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnGenerateMethod;
        private System.Windows.Forms.TextBox textBoxPdr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tcOutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxReturnType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSql;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxReturnTypeProcedure;
        private System.Windows.Forms.RadioButton radioButtonModel;
        private System.Windows.Forms.RadioButton radioButtonDal;
    }
}