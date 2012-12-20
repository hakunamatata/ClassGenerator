using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassGenerate
{
    public partial class FormDs : Form
    {
        private string cnnstring = null;

        public FormDs()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool connected = false;
            try
            {
                cnnstring = string.Format("{0};DataBase={1}", cnnstring, comboBoxDataSource.Text);
                DbHelper db = new DbHelper(cnnstring);
                connected = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }


            if (connected)
            {
                FormTb tb1 = new FormTb();
                tb1.ConnectionString = cnnstring;
                tb1.ShowDialog();
            }
            else
                MessageBox.Show("连接失败。");


        }

        private void btnConnect_Click(object sender, EventArgs e)
        {

            try
            {
                if (!checkBoxWindows.Checked)
                {
                    if (textBoxServer.Text.Trim() == string.Empty ||
                        textBoxUserName.Text.Trim() == string.Empty ||
                        textBoxPassword.Text.Trim() == string.Empty
                        )
                    {
                        MessageBox.Show("请填写完整服务器连接信息。");
                        return;
                    }
                    cnnstring = string.Format("SERVER={0};UID={1};PWD={2};", textBoxServer.Text, textBoxUserName.Text, textBoxPassword.Text);
                }
                else
                    cnnstring = string.Format("SERVER={0}; Integrated Security=true", textBoxServer.Text);
                DbHelper db = new DbHelper(cnnstring);
                comboBoxDataSource.DataSource = db.ExecuteDataSet("Select Name FROM Master..SysDatabases ms  WHERE NAME NOT LIKE 'master' AND NAME NOT LIKE 'model' AND NAME NOT LIKE 'msdb' AND NAME NOT LIKE 'tempdb' order by NAME").Tables[0];
                btnLogin.Enabled = true;
                comboBoxDataSource.Enabled = true;
                label4.Enabled = true;

                this.AcceptButton = btnLogin;

            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败。\n" + ex.Message);
            }
        }

        private void checkBoxWindows_Click(object sender, EventArgs e)
        {
            panelUser.Enabled = !checkBoxWindows.Checked;
        }
    }
}
