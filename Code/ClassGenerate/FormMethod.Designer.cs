namespace ClassGenerate
{
    partial class FormMethod
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDeco = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxRetu = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxProp = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textboxMethodName = new System.Windows.Forms.TextBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNullable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "方法修饰符";
            // 
            // comboBoxDeco
            // 
            this.comboBoxDeco.FormattingEnabled = true;
            this.comboBoxDeco.Items.AddRange(new object[] {
            "public",
            "protected",
            "private"});
            this.comboBoxDeco.Location = new System.Drawing.Point(84, 9);
            this.comboBoxDeco.Name = "comboBoxDeco";
            this.comboBoxDeco.Size = new System.Drawing.Size(65, 20);
            this.comboBoxDeco.TabIndex = 1;
            this.comboBoxDeco.Text = "public";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "返回值类型";
            // 
            // comboBoxRetu
            // 
            this.comboBoxRetu.FormattingEnabled = true;
            this.comboBoxRetu.Items.AddRange(new object[] {
            "void",
            "string",
            "int",
            "bool",
            "decimal",
            "DateTime",
            "DataTable",
            "int16",
            "int64",
            "float",
            "double"});
            this.comboBoxRetu.Location = new System.Drawing.Point(398, 9);
            this.comboBoxRetu.Name = "comboBoxRetu";
            this.comboBoxRetu.Size = new System.Drawing.Size(69, 20);
            this.comboBoxRetu.TabIndex = 3;
            this.comboBoxRetu.Text = "void";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(164, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "方法特性";
            // 
            // comboBoxProp
            // 
            this.comboBoxProp.FormattingEnabled = true;
            this.comboBoxProp.Items.AddRange(new object[] {
            "",
            "static",
            "abstract",
            "virtual"});
            this.comboBoxProp.Location = new System.Drawing.Point(223, 9);
            this.comboBoxProp.Name = "comboBoxProp";
            this.comboBoxProp.Size = new System.Drawing.Size(84, 20);
            this.comboBoxProp.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.ColumnNullable});
            this.dataGridView1.Location = new System.Drawing.Point(12, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(630, 374);
            this.dataGridView1.TabIndex = 7;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(567, 420);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(75, 23);
            this.buttonSubmit.TabIndex = 8;
            this.buttonSubmit.Text = "确定";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(478, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "方法名称";
            // 
            // textboxMethodName
            // 
            this.textboxMethodName.Location = new System.Drawing.Point(541, 9);
            this.textboxMethodName.Name = "textboxMethodName";
            this.textboxMethodName.Size = new System.Drawing.Size(97, 21);
            this.textboxMethodName.TabIndex = 9;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "param";
            this.Column1.HeaderText = "参数";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "datatype";
            this.Column2.HeaderText = "类型";
            this.Column2.Name = "Column2";
            // 
            // ColumnNullable
            // 
            this.ColumnNullable.DataPropertyName = "nullable";
            this.ColumnNullable.HeaderText = "允许为空";
            this.ColumnNullable.Name = "ColumnNullable";
            // 
            // FormMethod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 455);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textboxMethodName);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBoxProp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxRetu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxDeco);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMethod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "生成方法";
            this.Load += new System.EventHandler(this.FormMethod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDeco;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxRetu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxProp;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textboxMethodName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnNullable;
    }
}