using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;

namespace ClassGenerate
{
    public partial class FormTb : Form
    {
        private string cnnstring = null;
        public string ConnectionString
        {
            set
            {
                cnnstring = value;
            }
        }
        private DataSet params_set = null;
        public DataSet ParamsDataSet
        {
            set
            {
                params_set = value;
            }

        }
        public FormTb()
        {
            InitializeComponent();

        }

        private void clear_dataset()
        {
            params_set = new DataSet();
            DataTable dt1 = new DataTable("params");
            dt1.Columns.Add("param", typeof(string));
            dt1.Columns.Add("datatype", typeof(string));
            dt1.Columns.Add("nullable", typeof(string));
            DataTable dt2 = new DataTable("decorate");
            dt2.Columns.Add("deco", typeof(string));
            dt2.Columns.Add("prop", typeof(string));
            dt2.Columns.Add("retu", typeof(string));
            dt2.Columns.Add("menm", typeof(string));
            DataRow dr = dt2.NewRow();
            dt2.Rows.Add(dr);
            params_set.Tables.Add(dt1);
            params_set.Tables.Add(dt2);
        }

        private void Table_Load(object sender, EventArgs e)
        {
            DbHelper db = new DbHelper(cnnstring);
            checkedListBox1.DataSource = db.ExecuteDataSet("select * from sys.tables").Tables[0];
            checkedListBox1.ValueMember = "name";
            checkedListBox1.DisplayMember = "name";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                panel1.Enabled = true;
                panel2.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                panel2.Enabled = true;
                panel1.Enabled = false;
            }
        }

        private void btnGenerateClass_Click(object sender, EventArgs e)
        {
            string tablename = string.Empty;
            TabPage new_tp = null;
            TextBox tb_out = null;
            clear_tabpages(tcOutput);
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    tablename = checkedListBox1.GetItemText(checkedListBox1.Items[i]);
                    new_tp = new TabPage(tablename);
                    tb_out = new TextBox();
                    tb_out.Text = a_class(tablename);
                    tb_out.Width = 545;
                    tb_out.Height = 480;
                    tb_out.Multiline = true;
                    tb_out.ScrollBars = ScrollBars.Vertical;
                    tb_out.KeyDown += new KeyEventHandler(KeyDownForSelectAll);
                    new_tp.Controls.Add(tb_out);
                    tcOutput.TabPages.Add(new_tp);
                }
            }
        }

        private void clear_tabpages(TabControl tc)
        {
            for (int i = tc.TabPages.Count - 1; i >= 0; i--)
            {
                tc.TabPages.Remove(tc.TabPages[i]);
            }
        }


        private string a_class(string tablename)
        {
            try
            {

                /*
                 * 
                 *  获取数据库中该表的信息
                 * 
                 */
                DbHelper db = new DbHelper(cnnstring);
                string Query = @"SELECT syscolumns.name AS ColumnName,
                                       systypes.name AS DataType,
                                       syscolumns.length AS ColumnLength,
                                       syscolumns.prec AS ColumnPrecision,
                                       IsPrimaryKey = CASE 
                                                           WHEN EXISTS (
                                                                    SELECT 1
                                                                    FROM   sysobjects
                                                                           INNER JOIN sysindexes
                                                                                ON  sysindexes.name = sysobjects.name
                                                                           INNER JOIN sysindexkeys
                                                                                ON  sysindexes.id = sysindexkeys.id
                                                                                AND sysindexes.indid = 
                                                                                    sysindexkeys.indid
                                                                    WHERE  xtype = 'PK'
                                                                           AND parent_obj = syscolumns.id
                                                                           AND sysindexkeys.colid = syscolumns.colid
                                                                ) THEN 1
                                                           ELSE 0
                                                      END,
                                       syscolumns.isnullable AS IsNullable,
                                       sys.extended_properties.value AS ColumnDiscription
       
       
                                       --IsIdentity = CASE syscolumns.status
                                       --                  WHEN 128 THEN 1
                                       --                  ELSE 0
                                       --             END
                                FROM   syscolumns
                                       INNER JOIN systypes
                                            ON  (
                                                    syscolumns.xtype = systypes.xtype
                                                    AND systypes.name <> '_default_'
                                                    AND systypes.name <> 'sysname'
                                                )
                                       LEFT OUTER JOIN sys.extended_properties
                                            ON  (
                                                    sys.extended_properties.major_id = syscolumns.id
                                                    AND minor_id = syscolumns.colid
                                                )
                                WHERE  syscolumns.id = (
                                           SELECT id
                                           FROM   sysobjects
                                           WHERE  NAME = @TableName
                                       )
                                ORDER BY
                                       syscolumns.colid";

                db.AddParameter("@TableName", tablename);
                DataTable dt = db.ExecuteDataSet(Query, CommandType.Text).Tables[0];


                /*
                 *
                 *  组合成类
                 * 
                 */

                string o = string.Empty;

                write_class_head(ref o, tablename);
                write_insert_method(ref o, tablename, dt, 1);
                write_delete_method(ref o, tablename, dt, 1);
                write_update_method(ref o, tablename, dt, 1);
                write_get_method(ref o, tablename, dt, 1);
                write_end(ref o);

                return o;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 打印类头部
        /// </summary>
        /// <param name="o"></param>
        /// <param name="tablename"></param>
        private void write_class_head(ref string o, string tablename)
        {
            append(ref o, "using System;");
            append(ref o, "using System.Collections.Generic;");
            append(ref o, "using System.Linq;");
            append(ref o, "using System.Text;");
            append(ref o, "using System.Data.SqlClient;");
            append(ref o, "using System.Data;");
            append(ref o, "");
            append(ref o, "public class " + tablename);
            append(ref o, "{");
            append(ref o, "#region DAL类头部，请务必保留。", 1);
            append(ref o, "");
            append(ref o, "private DbHelper db;", 1);
            append(ref o, "private DBHelperConnectionState connState;", 1);
            append(ref o, "public " + tablename + "()", 1);
            append(ref o, "{", 1);
            append(ref o, "db = new DbHelper();", 2);
            append(ref o, "connState = DBHelperConnectionState.CloseOnExit;", 2);
            append(ref o, "}", 1);
            append(ref o, "public " + tablename + "(DbHelper keep)", 1);
            append(ref o, "{", 1);
            append(ref o, "db = keep;", 2);
            append(ref o, "connState = DBHelperConnectionState.KeepOpen;", 2);
            append(ref o, "}", 1);
            append(ref o, "");
            append(ref o, "#endregion", 1);
            append(ref o, "");
        }

        private void write_insert_method(ref string o, string tablename, DataTable dt, int base_indent)
        {
            string insert_params = "public void Insert(";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                insert_params += data_type_convert(dr["datatype"].ToString()) + param_null_set(dr["datatype"].ToString(), dr["isnullable"].ToString()) + " parm_" + dr["columnname"].ToString();
                if (i < dt.Rows.Count - 1)
                    insert_params += ",";
            }
            insert_params += ")";

            append(ref o, insert_params, base_indent);
            append(ref o, "{", base_indent);
            append(ref o, "try", base_indent + 1);
            append(ref o, "{", base_indent + 1);
            append(ref o, "string Query=@\"INSERT INTO [" + tablename + "]", base_indent + 2);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                if (i == 0)
                {
                    append(ref o, "([" + dr[0].ToString() + "]", base_indent + 4);
                    continue;
                }

                if (i == dt.Rows.Count - 1)
                {
                    append(ref o, ",[" + dr[0].ToString() + "])", base_indent + 4);
                    continue;
                }

                append(ref o, ",[" + dr[0].ToString() + "]", base_indent + 4);

            }
            append(ref o, "VALUES", base_indent + 3);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                if (i == 0)
                {
                    append(ref o, "(@" + dr[0].ToString(), base_indent + 4);
                    continue;
                }

                if (i == dt.Rows.Count - 1)
                {
                    append(ref o, ",@" + dr[0].ToString() + ")\";", base_indent + 4);
                    continue;
                }

                append(ref o, ",@" + dr[0].ToString(), base_indent + 4);

            }

            append(ref o, "SqlParameter[] Parms = {", base_indent + 1);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                if (i == dt.Rows.Count - 1)
                {
                    append(ref o, "new SqlParameter(\"@" + dr[0].ToString() + "\", parm_" + dr[0].ToString() + ")", base_indent + 3);
                    continue;
                }

                append(ref o, "new SqlParameter(\"@" + dr[0].ToString() + "\", parm_" + dr[0].ToString() + "),", base_indent + 3);


            }
            append(ref o, "};", base_indent + 2);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                if (Convert.ToInt16(dr["isnullable"]) == 1)
                    append(ref o, "if( parm_" + dr[0].ToString() + " == null ) Parms[" + i + "].Value = DBNull.Value;");
            }

            append(ref o, "db.AddParameter(Parms);", base_indent + 2);
            append(ref o, "db.ExecuteNonQuery(Query, connState);", base_indent + 2);

            append(ref o, "}", base_indent + 1);
            append(ref o, "catch (Exception ex)", base_indent + 1);
            append(ref o, "{", base_indent + 1);
            append(ref o, "throw new Exception(\"向表 " + tablename + " 中插入数据失败。\\n\" + ex.Message);", base_indent + 2);
            append(ref o, "}", base_indent + 1);
            append(ref o, "}", base_indent);
            append(ref o, "");
        }


        private void write_delete_method(ref string o, string tablename, DataTable dt, int base_indent)
        {
            DataRow[] private_keys = dt.Select("isprimarykey = 1");
            string delete_parms = "public void DeleteBy(";
            for (int i = 0; i < private_keys.Count(); i++)
            {
                DataRow dr = private_keys[i];
                delete_parms += data_type_convert(dr["datatype"].ToString()) + param_null_set(dr["datatype"].ToString(), dr["isnullable"].ToString()) + " parm_" + dr["columnname"].ToString();
                if (i < private_keys.Count() - 1)
                    delete_parms += ",";
            }
            delete_parms += ")";
            append(ref o, delete_parms, base_indent);
            append(ref o, "{", base_indent);
            append(ref o, "try", base_indent + 1);
            append(ref o, "{", base_indent + 1);

            string piece = string.Empty;
            for (int i = 0; i < private_keys.Count(); i++)
            {
                DataRow dr = private_keys[i];
                piece += "[" + dr["columnname"].ToString() + "] = @" + dr["columnname"].ToString();
                if (i < private_keys.Count() - 1)
                    piece += " AND ";
            }


            string delete_query = "string Query=@\"DELETE FROM [" + tablename + "] ";
            if (piece.Length > 0) delete_query += " WHERE " + piece + "\";";
            append(ref o, delete_query, base_indent + 2);
            if (private_keys.Count() > 0)
            {
                append(ref o, "SqlParameter[] Parms = {", base_indent + 1);
                for (int i = 0; i < private_keys.Count(); i++)
                {
                    DataRow dr = private_keys[i];
                    if (i == dt.Rows.Count - 1)
                    {
                        append(ref o, "new SqlParameter(\"@" + dr[0].ToString() + "\", parm_" + dr[0].ToString() + ")", base_indent + 3);
                        continue;
                    }
                    append(ref o, "new SqlParameter(\"@" + dr[0].ToString() + "\", parm_" + dr[0].ToString() + "),", base_indent + 3);
                }
                append(ref o, "};", base_indent + 2);
                append(ref o, "db.AddParameter(Parms);", base_indent + 2);
            }
            append(ref o, "db.ExecuteNonQuery(Query, connState);", base_indent + 2);

            append(ref o, "}", base_indent + 1);
            append(ref o, "catch (Exception ex)", base_indent + 1);
            append(ref o, "{", base_indent + 1);
            append(ref o, "throw new Exception(\"从表 " + tablename + " 中删除数据失败。\\n\" + ex.Message);", base_indent + 2);
            append(ref o, "}", base_indent + 1);
            append(ref o, "}", base_indent);
            append(ref o, "");

        }


        private void write_update_method(ref string o, string tablename, DataTable dt, int base_indent)
        {
            DataRow[] private_keys = dt.Select("isprimarykey = 1");
            DataRow[] common_keys = dt.Select("isprimarykey = 0");
            DataRow[] contacted_keys = common_keys.Concat(private_keys).ToArray();
            string update_params = "public void Update(";
            for (int i = 0; i < contacted_keys.Count(); i++)
            {
                DataRow dr = contacted_keys[i];
                update_params += data_type_convert(dr["datatype"].ToString()) + param_null_set(dr["datatype"].ToString(), dr["isnullable"].ToString()) + " parm_" + dr["columnname"].ToString();
                if (i < contacted_keys.Count() - 1)
                    update_params += ",";
            }
            update_params += ")";

            append(ref o, update_params, base_indent);
            append(ref o, "{", base_indent);
            append(ref o, "try", base_indent + 1);
            append(ref o, "{", base_indent + 1);

            string piece = string.Empty;
            append(ref o, "string Query=@\"UPDATE [" + tablename + "] ", base_indent + 2);
            for (int i = 0; i < common_keys.Count(); i++)
            {
                DataRow dr = common_keys[i];
                if (i == 0)
                {
                    append(ref o, "SET[" + dr[0].ToString() + "] = @" + dr[0].ToString(), base_indent + 3);
                    continue;
                }
                append(ref o, ",[" + dr[0].ToString() + "] = @" + dr[0].ToString(), base_indent + 3);
            }

            string update_where_piece = " WHERE ";
            if (private_keys.Count() > 0)
                for (int i = 0; i < private_keys.Count(); i++)
                {
                    DataRow dr = private_keys[i];
                    if (i == private_keys.Count() - 1)
                    {
                        update_where_piece += "[" + dr[0].ToString() + "] = @" + dr[0].ToString() + " ";
                        continue;
                    }
                    update_where_piece += "[" + dr[0].ToString() + "] = @" + dr[0].ToString() + " AND ";
                }
            else
                for (int i = 0; i < common_keys.Count(); i++)
                {
                    DataRow dr = common_keys[i];
                    if (i == common_keys.Count() - 1)
                    {
                        update_where_piece += "[" + dr[0].ToString() + "] = @" + dr[0].ToString() + " ";
                        continue;
                    }
                    update_where_piece += "[" + dr[0].ToString() + "] = @" + dr[0].ToString() + " AND ";
                }
            append(ref o, update_where_piece + piece + "\";", base_indent + 3);

            append(ref o, "SqlParameter[] Parms = {", base_indent + 2);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                if (i == dt.Rows.Count - 1)
                {
                    append(ref o, "new SqlParameter(\"@" + dr[0].ToString() + "\", parm_" + dr[0].ToString() + ")", base_indent + 3);
                    continue;
                }

                append(ref o, "new SqlParameter(\"@" + dr[0].ToString() + "\", parm_" + dr[0].ToString() + "),", base_indent + 3);
            }
            append(ref o, "};", base_indent + 2);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                if (Convert.ToInt16(dr["isnullable"]) == 1)
                    append(ref o, "if( parm_" + dr[0].ToString() + " == null ) Parms[" + i + "].Value = DBNull.Value;");
            }

            append(ref o, "db.AddParameter(Parms);", base_indent + 2);
            append(ref o, "db.ExecuteNonQuery(Query, connState);", base_indent + 2);

            append(ref o, "}", base_indent + 1);
            append(ref o, "catch (Exception ex)", base_indent + 1);
            append(ref o, "{", base_indent + 1);
            append(ref o, "throw new Exception(\"更新表 " + tablename + " 时失败。\\n\" + ex.Message);", base_indent + 2);
            append(ref o, "}", base_indent + 1);
            append(ref o, "}", base_indent);
            append(ref o, "");

        }

        private void write_get_method(ref string o, string tablename, DataTable dt, int base_indent)
        {
            append(ref o, "public DataTable GetData()", base_indent);
            append(ref o, "{", base_indent);
            append(ref o, "try", base_indent + 1);
            append(ref o, "{", base_indent + 1);
            append(ref o, "string Query = @\"SELECT ", base_indent + 2);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                if (i == dt.Rows.Count - 1)
                {
                    append(ref o, dr[0].ToString(), base_indent + 3);
                    continue;
                }
                append(ref o, dr[0].ToString() + ",", base_indent + 3);
            }
            append(ref o, "FROM " + tablename + "\";", base_indent + 3);
            append(ref o, "return db.ExecuteDataSet(Query, connState).Tables[0];", base_indent + 2);

            append(ref o, "}", base_indent + 1);
            append(ref o, "catch (Exception ex)", base_indent + 1);
            append(ref o, "{", base_indent + 1);
            append(ref o, "throw new Exception(\"获取表 " + tablename + " 数据时失败。\\n\" + ex.Message);", base_indent + 2);
            append(ref o, "}", base_indent + 1);
            append(ref o, "}", base_indent);
            append(ref o, "");
        }


        private void write_end(ref string o)
        {
            append(ref o, "}");
        }

        private void append(ref string s1, string s2)
        {
            s1 = s1 + s2 + "\r\n";
        }

        private void append(ref string s1, string s2, int indent)
        {
            for (int i = 0; i < indent; i++)
                s1 += "\t";
            s1 = s1 + s2 + "\r\n";
        }


        private string data_type_convert(string type)
        {
            switch (type.ToLower())
            {

                case "nvarchar":
                    return "string";

                case "ntext":
                    return "string";

                case "nchar":
                    return "string";

                case "char":
                    return "string";

                case "varchar":
                    return "string";

                case "int":
                    return "int";

                case "tinyint":
                    return "int";
                case "bit":
                    return "int";

                case "datetime":
                    return "DateTime";

                case "smallint":
                    return "int";


                default:
                    return null;
            }
        }



        private void KeyDownForSelectAll(object sender, KeyEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (e.Control && e.KeyCode == Keys.A)
                tb.SelectAll();
        }

        private void btnGenerateMethod_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tpSql")
            {
                // sql语句
                Regex rg = new Regex("@[a-zA-z0-9_]+");
                MatchCollection mc = rg.Matches(textBoxSql.Text.Trim());
                List<string> listed_params = new List<string>();
                clear_dataset();
                DataTable dt = params_set.Tables["params"];
                foreach (Match m in mc)
                {
                    if (!listed_params.Contains(m.Value))
                    {
                        DataRow dr = dt.NewRow();
                        string match_param = m.Value;
                        dr[0] = match_param;
                        dr[1] = "string";
                        dt.Rows.Add(dr);
                        listed_params.Add(match_param);
                    }
                }
                FormMethod fm = new FormMethod();
                fm.ParentFormTb = this;
                fm.Type = "method";
                fm.DataSource = params_set;
                fm.ShowDialog();
            }
            else if (tabControl1.SelectedTab.Name == "tpPdr")
            {
                string procedure_name = textBoxPdr.Text.Trim();
                // 存储过程
                DbHelper db = new DbHelper(cnnstring);
                string Query = @"SELECT
                                    param.name AS [Name],
                                    ISNULL(baset.name, N'') AS [SystemType],
                                    CAST(CASE WHEN baset.name IN (N'nchar', N'nvarchar') AND param.max_length <> -1 THEN param.max_length/2 ELSE param.max_length END AS int) AS [Length]
                                    FROM
                                    sys.all_objects AS sp
                                    INNER JOIN sys.all_parameters AS param ON param.object_id=sp.object_id
                                    LEFT OUTER JOIN sys.types AS baset ON baset.user_type_id = param.system_type_id and baset.user_type_id = baset.system_type_id
                                    WHERE
                                    (sp.type = N'P' OR sp.type = N'RF' OR sp.type='PC')and(sp.name=
                                    @procedurename and SCHEMA_NAME(sp.schema_id)=N'dbo')
                                    ORDER BY
                                    param.parameter_id ASC";

                db.AddParameter("@procedurename", procedure_name);
                DataTable dtparams = db.ExecuteDataSet(Query, CommandType.Text).Tables[0];
                List<string> listed_params = new List<string>();
                clear_dataset();
                DataTable dt = params_set.Tables["params"];
                foreach (DataRow drp in dtparams.Rows)
                {
                    if (!listed_params.Contains(drp["name"].ToString()))
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = drp["name"].ToString();
                        dr[1] = data_type_convert(drp["systemtype"].ToString());
                        dt.Rows.Add(dr);
                        listed_params.Add(drp["name"].ToString());
                    }
                }

                FormMethod fm = new FormMethod();
                fm.ParentFormTb = this;
                fm.Type = "procedure";
                fm.DataSource = params_set;
                fm.ShowDialog();
            }

        }


        public void write_g_method()
        {
            DataTable dt_params = params_set.Tables["params"];
            DataTable dt_decos = params_set.Tables["decorate"];
            string o = string.Empty;
            string return_type = comboBoxReturnType.Text.Trim();
            string private_public = dt_decos.Rows[0]["deco"].ToString();
            string static_none = dt_decos.Rows[0]["prop"].ToString();
            string int_string = dt_decos.Rows[0]["retu"].ToString();
            string method_name = dt_decos.Rows[0]["menm"].ToString();
            string method_dec = (private_public == string.Empty ? "public" : private_public) + " " + (static_none == string.Empty ? "" : static_none) + " " + (int_string == string.Empty ? "string" : int_string) + " " + method_name + "(";

            for (int i = 0; i < dt_params.Rows.Count; i++)
            {
                DataRow dr = dt_params.Rows[i];
                method_dec += (dr["datatype"].ToString()) + param_null_set(dr["datatype"].ToString(), dr["nullable"].ToString()) + " param_" + dr["param"].ToString();
                if (i < dt_params.Rows.Count - 1)
                    method_dec += ",";
            }
            method_dec += ")";
            append(ref o, method_dec);
            append(ref o, "{");
            append(ref o, "try", 1);
            append(ref o, "{", 1);

            append(ref o, string.Format("string Query=@\"{0}\";", textBoxSql.Text.Trim()), 2);
            append(ref o, "SqlParameter[] Parms = {", 1);
            for (int i = 0; i < dt_params.Rows.Count; i++)
            {
                DataRow dr = dt_params.Rows[i];

                if (i == dt_params.Rows.Count - 1)
                {
                    append(ref o, "new SqlParameter(\"@" + dr[0].ToString() + "\",  param_" + dr[0].ToString() + ")", 3);
                    continue;
                }

                append(ref o, "new SqlParameter(\"@" + dr[0].ToString() + "\",  param_" + dr[0].ToString() + "),", 3);


            }
            append(ref o, "};", 2);

            for (int i = 0; i < dt_params.Rows.Count; i++)
            {
                DataRow dr = dt_params.Rows[i];
                if (dr["nullable"].ToString().ToLower() == "true")
                    append(ref o, "if( parm_" + dr[0].ToString() + " == null ) Parms[" + i + "].Value = DBNull.Value;");
            }


            append(ref o, "db.AddParameter(Parms);", 2);

            switch (comboBoxReturnType.Text)
            {
                case "数据集":
                    append(ref o, "return db.ExecuteDataSet(Query, connState).Tables[0];", 2);
                    break;

                case "单值":
                    append(ref o, "return (" + return_type + ")db.ExecuteScalar(Query, connState);", 2);
                    break;

                case "无返回值":
                    append(ref o, "db.ExecuteNonQuery(Query, connState);", 2);
                    break;
            }



            append(ref o, "}", 1);
            append(ref o, "catch (Exception ex)", 1);
            append(ref o, "{", 1);
            append(ref o, "throw new Exception(\"执行方法 " + method_name + " 时出错。\\n\" + ex.Message);", 2);
            append(ref o, "}", 1);
            append(ref o, "}");
            append(ref o, "");

            TabPage new_tp = null;
            TextBox tb_out = null;
            clear_tabpages(tcOutput);
            new_tp = new TabPage(method_name);
            tb_out = new TextBox();
            tb_out.Text = o; ;
            tb_out.Width = 545;
            tb_out.Height = 480;
            tb_out.Multiline = true;
            tb_out.ScrollBars = ScrollBars.Vertical;
            tb_out.KeyDown += new KeyEventHandler(KeyDownForSelectAll);
            new_tp.Controls.Add(tb_out);
            tcOutput.TabPages.Add(new_tp);

        }


        public void write_p_method()
        {
            DataTable dt_params = params_set.Tables["params"];
            DataTable dt_decos = params_set.Tables["decorate"];
            string o = string.Empty;
            string return_type = comboBoxReturnType.Text.Trim();
            string private_public = dt_decos.Rows[0]["deco"].ToString();
            string static_none = dt_decos.Rows[0]["prop"].ToString();
            string int_string = dt_decos.Rows[0]["retu"].ToString();
            string method_name = dt_decos.Rows[0]["menm"].ToString();
            string method_dec = (private_public == string.Empty ? "public" : private_public) + " " + (static_none == string.Empty ? "" : static_none) + " " + (int_string == string.Empty ? "string" : int_string) + " " + method_name + "(";

            for (int i = 0; i < dt_params.Rows.Count; i++)
            {
                DataRow dr = dt_params.Rows[i];
                method_dec += (dr["datatype"].ToString()) + param_null_set(dr["datatype"].ToString(), dr["nullable"].ToString()) + " param_" + dr["param"].ToString();
                if (i < dt_params.Rows.Count - 1)
                    method_dec += ",";
            }
            method_dec += ")";
            append(ref o, method_dec);
            append(ref o, "{");
            append(ref o, "try", 1);
            append(ref o, "{", 1);

            append(ref o, string.Format("string Query=@\"{0}\";", textBoxPdr.Text.Trim(), 2));
            append(ref o, "SqlParameter[] Parms = {", 1);
            for (int i = 0; i < dt_params.Rows.Count; i++)
            {
                DataRow dr = dt_params.Rows[i];

                if (i == dt_params.Rows.Count - 1)
                {
                    append(ref o, "new SqlParameter(\"@" + dr[0].ToString() + "\",  param_" + dr[0].ToString() + ")", 3);
                    continue;
                }

                append(ref o, "new SqlParameter(\"@" + dr[0].ToString() + "\",  param_" + dr[0].ToString() + "),", 3);


            }
            append(ref o, "};", 2);

            for (int i = 0; i < dt_params.Rows.Count; i++)
            {
                DataRow dr = dt_params.Rows[i];
                if (dr["nullable"].ToString().ToLower() == "true")
                    append(ref o, "if( parm_" + dr[0].ToString() + " == null ) Parms[" + i + "].Value = DBNull.Value;");
            }

            append(ref o, "db.AddParameter(Parms);", 2);

            switch (comboBoxReturnTypeProcedure.Text)
            {
                case "数据集":
                    append(ref o, "return db.ExecuteDataSet(Query, CommandType.StoredProcedure, connState).Tables[0];", 2);
                    break;

                case "单值":
                    append(ref o, "return (" + return_type + ")db.ExecuteScalar(Query, CommandType.StoredProcedure, connState);", 2);
                    break;

                case "无返回值":
                    append(ref o, "db.ExecuteNonQuery(Query, CommandType.StoredProcedure, connState);", 2);
                    break;
            }



            append(ref o, "}", 1);
            append(ref o, "catch (Exception ex)", 1);
            append(ref o, "{", 1);
            append(ref o, "throw new Exception(\"执行方法 " + method_name + " 时出错。\\n\" + ex.Message);", 2);
            append(ref o, "}", 1);
            append(ref o, "}");
            append(ref o, "");

            TabPage new_tp = null;
            TextBox tb_out = null;
            clear_tabpages(tcOutput);
            new_tp = new TabPage(method_name);
            tb_out = new TextBox();
            tb_out.Text = o; ;
            tb_out.Width = 545;
            tb_out.Height = 480;
            tb_out.Multiline = true;
            tb_out.ScrollBars = ScrollBars.Vertical;
            tb_out.KeyDown += new KeyEventHandler(KeyDownForSelectAll);
            new_tp.Controls.Add(tb_out);
            tcOutput.TabPages.Add(new_tp);

        }

        private void textBoxSql_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (e.Control && e.KeyCode == Keys.A)
                tb.SelectAll();
        }

        private string param_null_set(string param, string nullable)
        {
            if ((nullable.ToLower() == "true" || nullable.ToLower() == "1") && data_type_convert(param) != "string")
                return "?";
            else
                return "";
        }

    }
}

