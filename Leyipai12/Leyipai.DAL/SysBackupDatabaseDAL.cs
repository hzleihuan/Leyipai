using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Leyipai.DBUtility;//请先添加引用
namespace Leyipai.DAL
{
   public class SysBackupDatabaseDAL
    {
       public SysBackupDatabaseDAL()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "backup_database"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from backup_database");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Leyipai.Model.backup_database model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into backup_database(");
			strSql.Append("file_name,deal_time)");
			strSql.Append(" values (");
			strSql.Append("@file_name,@deal_time)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@file_name", SqlDbType.VarChar,50),
					new SqlParameter("@deal_time", SqlDbType.VarChar,50)};
			parameters[0].Value = model.file_name;
			parameters[1].Value = model.deal_time;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Leyipai.Model.backup_database model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update backup_database set ");
			strSql.Append("file_name=@file_name,");
			strSql.Append("deal_time=@deal_time");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@file_name", SqlDbType.VarChar,50),
					new SqlParameter("@deal_time", SqlDbType.VarChar,50)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.file_name;
			parameters[2].Value = model.deal_time;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from backup_database ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Leyipai.Model.backup_database GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,file_name,deal_time from backup_database ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Leyipai.Model.backup_database model=new Leyipai.Model.backup_database();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.file_name=ds.Tables[0].Rows[0]["file_name"].ToString();
				model.deal_time=ds.Tables[0].Rows[0]["deal_time"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,file_name,deal_time ");
			strSql.Append(" FROM backup_database ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,file_name,deal_time ");
			strSql.Append(" FROM backup_database ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "backup_database";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/


     

            /// <summary>
       /// 
       /// </summary>
       /// <returns></returns>
        public bool BackupDatabase()
        {
            bool result = false;
            try
            {
                string backName = DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + "-" + System.DateTime.Now.DayOfYear.ToString() + System.DateTime.Now.Millisecond.ToString() + ".bak";
                string backPath = Leyipai.Common.ConfigHelper.GetdatabasebackupPath();
                string sql = "backup database leyipai to disk = '" + backPath + "" + backName+"'";

                DbHelperSQL.ExecuteSql(sql);

                Leyipai.Model.backup_database back = new Model.backup_database();
                back.file_name = backName;
                back.deal_time = DateTime.UtcNow.ToString();
                Add(back);
                result = true;
            }
            catch
            { 
            
            }
            return result;
        }

       /// <summary>
       /// 还原数据
       /// </summary>
       /// <param name="restoreId"></param>
       /// <returns></returns>
        public bool restoreDatabase(string restoreId)
        {
            bool result = false;
            Leyipai.Model.backup_database back = this.GetModel(Int32.Parse(restoreId));
            if(back==null)
                return result;

            string backPath = Leyipai.Common.ConfigHelper.GetdatabasebackupPath();
           // string sql = "backup database leyipai to disk = '" + backPath + "" + backName + "'";

            string sql = "Alter Database leyipai Set Offline with Rollback immediate;"; //db 是要备份的数据库名
            sql += "restore database leyipai from disk = '";
            sql += backPath;
            sql += back.file_name + "';";  //bakname 是备份文件名
            sql += "Alter Database leyipai Set OnLine With rollback Immediate;";

            try
            {
                DbHelperSQL.ExecuteSql(sql);
                result = true;
            }
            catch
            { 
            }


            return result;
        }
		#endregion  成员方法
	}
}

