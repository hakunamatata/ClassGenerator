namespace ClassGenerate
{
    partial class FormDs
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxDataSource = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.checkBoxWindows = new System.Windows.Forms.CheckBox();
            this.panelUser = new System.Windows.Forms.Panel();
            this.panelUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(135, 33);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(139, 21);
            this.textBoxServer.TabIndex = 0;
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(102, 3);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(223, 21);
            this.textBoxUserName.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(101, 35);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(223, 21);
            this.textBoxPassword.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "数据库服务器：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "用户名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "密码：";
            // 
            // btnLogin
            // 
            this.btnLogin.Enabled = false;
            this.btnLogin.Location = new System.Drawing.Point(236, 203);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "登陆";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(43, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "选择数据库：";
            // 
            // comboBoxDataSource
            // 
            this.comboBoxDataSource.DisplayMember = "Name";
            this.comboBoxDataSource.Enabled = false;
            this.comboBoxDataSource.FormattingEnabled = true;
            this.comboBoxDataSource.Location = new System.Drawing.Point(135, 139);
            this.comboBoxDataSource.Name = "comboBoxDataSource";
            this.comboBoxDataSource.Size = new System.Drawing.Size(246, 20);
            this.comboBoxDataSource.TabIndex = 4;
            this.comboBoxDataSource.ValueMember = "Name";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(110, 203);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "测试连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // checkBoxWindows
            // 
            this.checkBoxWindows.AutoSize = true;
            this.checkBoxWindows.Location = new System.Drawing.Point(280, 36);
            this.checkBoxWindows.Name = "checkBoxWindows";
            this.checkBoxWindows.Size = new System.Drawing.Size(114, 16);
            this.checkBoxWindows.TabIndex = 1;
            this.checkBoxWindows.Text = "windows身份登陆";
            this.checkBoxWindows.UseVisualStyleBackColor = true;
            this.checkBoxWindows.Click += new System.EventHandler(this.checkBoxWindows_Click);
            // 
            // panelUser
            // 
            this.panelUser.Controls.Add(this.textBoxUserName);
            this.panelUser.Controls.Add(this.textBoxPassword);
            this.panelUser.Controls.Add(this.label2);
            this.panelUser.Controls.Add(this.label3);
            this.panelUser.Location = new System.Drawing.Point(33, 63);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new System.Drawing.Size(337, 75);
            this.panelUser.TabIndex = 12;
            // 
            // FormDs
            // 
            this.AcceptButton = this.btnConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 258);
            this.Controls.Add(this.panelUser);
            this.Controls.Add(this.checkBoxWindows);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.comboBoxDataSource);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库登陆";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelUser.ResumeLayout(false);
            this.panelUser.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxDataSource;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.CheckBox checkBoxWindows;
        private System.Windows.Forms.Panel panelUser;
    }
}

