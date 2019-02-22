using System;
using System.Collections.Generic;
using System.Text;
using Leyipai.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace Leyipai.DAL
{
  public  class SysLogDAL
    {
      public SysLogDAL()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "sys_log"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sys_log");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Leyipai.Model.sys_log model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sys_log(");
			strSql.Append("log_time,log_username,log_info)");
			strSql.Append(" values (");
			strSql.Append("@log_time,@log_username,@log_info)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@log_time", SqlDbType.VarChar,50),
					new SqlParameter("@log_username", SqlDbType.VarChar,50),
					new SqlParameter("@log_info", SqlDbType.VarChar,200)};
			parameters[0].Value = model.log_time;
			parameters[1].Value = model.log_username;
			parameters[2].Value = model.log_info;

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
		public void Update(Leyipai.Model.sys_log model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sys_log set ");
			strSql.Append("log_time=@log_time,");
			strSql.Append("log_username=@log_username,");
			strSql.Append("log_info=@log_info");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@log_time", SqlDbType.VarChar,50),
					new SqlParameter("@log_username", SqlDbType.VarChar,50),
					new SqlParameter("@log_info", SqlDbType.VarChar,200)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.log_time;
			parameters[2].Value = model.log_username;
			parameters[3].Value = model.log_info;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sys_log ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Leyipai.Model.sys_log GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,log_time,log_username,log_info from sys_log ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Leyipai.Model.sys_log model=new Leyipai.Model.sys_log();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.log_time=ds.Tables[0].Rows[0]["log_time"].ToString();
				model.log_username=ds.Tables[0].Rows[0]["log_username"].ToString();
				model.log_info=ds.Tables[0].Rows[0]["log_info"].ToString();
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
			strSql.Append("select id,log_time,log_username,log_info ");
			strSql.Append(" FROM sys_log ");
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
			strSql.Append(" id,log_time,log_username,log_info ");
			strSql.Append(" FROM sys_log ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public DataSet GetList(int startIndex, int endIndex)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@startIndex",SqlDbType.Int),
					new SqlParameter("@endIndex",  SqlDbType.Int),
					new SqlParameter("@docount", SqlDbType.Int)
					};
            parameters[0].Value = startIndex;
            parameters[1].Value = endIndex;
			parameters[2].Value = 0;
            return DbHelperSQL.RunProcedure("get_sys_logs", parameters, "ds");
		}


        public int getListCount()
        {

           object O= DbHelperSQL.GetSingle("select count(*) from sys_log");
           if (null != O)
           {
               return Int32.Parse(O.ToString());
           }
           else return 0;
        }

		#endregion  成员方法
	}
}

