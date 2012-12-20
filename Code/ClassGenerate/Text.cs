using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public class dnt_tags
{
    #region DAL类头部，请务必保留。

    private DbHelper db;
    private DBHelperConnectionState connState;
    public dnt_tags()
    {
        db = new DbHelper();
        connState = DBHelperConnectionState.CloseOnExit;
    }
    public dnt_tags(DbHelper keep)
    {
        db = keep;
        connState = DBHelperConnectionState.KeepOpen;
    }

    #endregion

    public void Insert(int parm_tagid, string parm_tagname, int parm_userid, DateTime parm_postdatetime, int parm_orderid, string parm_color, int parm_count, int parm_fcount, int parm_pcount, int parm_scount, int parm_vcount, int parm_gcount)
    {
        try
        {
            string Query = @"INSERT INTO [dnt_tags]
					([tagid]
					,[tagname]
					,[userid]
					,[postdatetime]
					,[orderid]
					,[color]
					,[count]
					,[fcount]
					,[pcount]
					,[scount]
					,[vcount]
					,[gcount])
				VALUES
					(@tagid
					,@tagname
					,@userid
					,@postdatetime
					,@orderid
					,@color
					,@count
					,@fcount
					,@pcount
					,@scount
					,@vcount
					,@gcount)";
            SqlParameter[] Parms = {
				new SqlParameter("@tagid", parm_tagid),
				new SqlParameter("@tagname", parm_tagname),
				new SqlParameter("@userid", parm_userid),
				new SqlParameter("@postdatetime", parm_postdatetime),
				new SqlParameter("@orderid", parm_orderid),
				new SqlParameter("@color", parm_color),
				new SqlParameter("@count", parm_count),
				new SqlParameter("@fcount", parm_fcount),
				new SqlParameter("@pcount", parm_pcount),
				new SqlParameter("@scount", parm_scount),
				new SqlParameter("@vcount", parm_vcount),
				new SqlParameter("@gcount", parm_gcount)
			};
            db.AddParameter(Parms);
            db.ExecuteNonQuery(Query, connState);
        }
        catch (Exception ex)
        {
            throw new Exception("向表 dnt_tags 中插入数据失败。\n" + ex.Message);
        }
    }

    public void DeleteBy(int parm_tagid)
    {
        try
        {
            string Query = @"DELETE FROM [dnt_tags]  WHERE [tagid] = @tagid";
            SqlParameter[] Parms = {
				new SqlParameter("@tagid", parm_tagid),
			};
            db.AddParameter(Parms);
            db.ExecuteNonQuery(Query, connState);
        }
        catch (Exception ex)
        {
            throw new Exception("从表 dnt_tags 中删除数据失败。\n" + ex.Message);
        }
    }

    public void Update(string parm_tagname, int parm_userid, DateTime parm_postdatetime, int parm_orderid, string parm_color, int parm_count, int parm_fcount, int parm_pcount, int parm_scount, int parm_vcount, int parm_gcount, int parm_tagid)
    {
        try
        {
            string Query = @"UPDATE [dnt_tags] 
				SET[tagname] = @tagname
				,[userid] = @userid
				,[postdatetime] = @postdatetime
				,[orderid] = @orderid
				,[color] = @color
				,[count] = @count
				,[fcount] = @fcount
				,[pcount] = @pcount
				,[scount] = @scount
				,[vcount] = @vcount
				,[gcount] = @gcount
				 WHERE [tagid] = @tagid ";
            SqlParameter[] Parms = {
				new SqlParameter("@tagid", parm_tagid),
				new SqlParameter("@tagname", parm_tagname),
				new SqlParameter("@userid", parm_userid),
				new SqlParameter("@postdatetime", parm_postdatetime),
				new SqlParameter("@orderid", parm_orderid),
				new SqlParameter("@color", parm_color),
				new SqlParameter("@count", parm_count),
				new SqlParameter("@fcount", parm_fcount),
				new SqlParameter("@pcount", parm_pcount),
				new SqlParameter("@scount", parm_scount),
				new SqlParameter("@vcount", parm_vcount),
				new SqlParameter("@gcount", parm_gcount)
			};
            db.AddParameter(Parms);
            db.ExecuteNonQuery(Query, connState);
        }
        catch (Exception ex)
        {
            throw new Exception("更新表 dnt_tags 时失败。\n" + ex.Message);
        }
    }


    public DataTable GetData()
    {
        try
        {
            string Query = @"SELECT 
				tagid,
				tagname,
				userid,
				postdatetime,
				orderid,
				color,
				count,
				fcount,
				pcount,
				scount,
				vcount,
				gcount
				gcount,
				FROM dnt_tags";
            return db.ExecuteDataSet(Query, connState).Tables[0];
        }
        catch (Exception ex)
        {
            throw new Exception("获取表 dnt_tags 数据时失败。\n" + ex.Message);
        }
    }




}
