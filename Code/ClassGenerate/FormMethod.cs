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
    public partial class FormMethod : Form
    {
        private FormTb parent_form = null;
        public FormTb ParentFormTb
        {
            get
            {
                return parent_form;
            }
            set
            {
                parent_form = value;
            }
        }
        public FormMethod()
        {
            InitializeComponent();
        }

        private DataSet ds = null;
        public DataSet DataSource
        {
            set
            {
                ds = value;
            }
        }

        private string method_procedure = "method";
        public string Type
        {
            set
            {
                method_procedure = value;
            }
        }

        private void FormMethod_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Tables["params"];
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            DataTable dtp = ds.Tables["params"];
            foreach (DataRow dr in dtp.Rows)
            {
                dr[0] = dr[0].ToString().Substring(1);
            }

            DataTable dtc = ds.Tables["decorate"];
            dtc.Rows[0]["deco"] = comboBoxDeco.Text;
            dtc.Rows[0]["prop"] = comboBoxProp.Text;
            dtc.Rows[0]["retu"] = comboBoxRetu.Text;
            dtc.Rows[0]["menm"] = textboxMethodName.Text.Trim();
            this.ParentFormTb.ParamsDataSet = ds;
            if (method_procedure == "method")
                this.ParentFormTb.write_g_method();
            else
                this.ParentFormTb.write_p_method();
            this.Close();
        }
    }
}
