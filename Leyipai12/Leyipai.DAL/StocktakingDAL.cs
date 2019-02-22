using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Leyipai.DBUtility;//请先添加引用
namespace Leyipai.DAL
{
	/// <summary>
	/// 数据访问类stocktaking。
	/// </summary>
	public class StocktakingDAL
	{
        public StocktakingDAL()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "stocktaking"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from stocktaking");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Leyipai.Model.stocktaking model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into stocktaking(");
			strSql.Append("depot_id,stocktaking_id,takinger,taking_date,taking_des,state)");
			strSql.Append(" values (");
			strSql.Append("@depot_id,@stocktaking_id,@takinger,@taking_date,@taking_des,@state)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@depot_id", SqlDbType.Int,4),
					new SqlParameter("@stocktaking_id", SqlDbType.VarChar,20),
					new SqlParameter("@takinger", SqlDbType.VarChar,50),
					new SqlParameter("@taking_date", SqlDbType.VarChar,50),
					new SqlParameter("@taking_des", SqlDbType.VarChar,500),
					new SqlParameter("@state", SqlDbType.TinyInt,1)};
			parameters[0].Value = model.depot_id;
			parameters[1].Value = model.stocktaking_id;
			parameters[2].Value = model.takinger;
			parameters[3].Value = model.taking_date;
			parameters[4].Value = model.taking_des;
			parameters[5].Value = model.state;

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
		public void Update(Leyipai.Model.stocktaking model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update stocktaking set ");
			strSql.Append("depot_id=@depot_id,");
			strSql.Append("stocktaking_id=@stocktaking_id,");
			strSql.Append("takinger=@takinger,");
			strSql.Append("taking_date=@taking_date,");
			strSql.Append("taking_des=@taking_des,");
			strSql.Append("state=@state");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@depot_id", SqlDbType.Int,4),
					new SqlParameter("@stocktaking_id", SqlDbType.VarChar,20),
					new SqlParameter("@takinger", SqlDbType.VarChar,50),
					new SqlParameter("@taking_date", SqlDbType.VarChar,50),
					new SqlParameter("@taking_des", SqlDbType.VarChar,500),
					new SqlParameter("@state", SqlDbType.TinyInt,1)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.depot_id;
			parameters[2].Value = model.stocktaking_id;
			parameters[3].Value = model.takinger;
			parameters[4].Value = model.taking_date;
			parameters[5].Value = model.taking_des;
			parameters[6].Value = model.state;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from stocktaking ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Leyipai.Model.stocktaking GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,depot_id,stocktaking_id,takinger,taking_date,taking_des,state from stocktaking ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Leyipai.Model.stocktaking model=new Leyipai.Model.stocktaking();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["depot_id"].ToString()!="")
				{
					model.depot_id=int.Parse(ds.Tables[0].Rows[0]["depot_id"].ToString());
				}
				model.stocktaking_id=ds.Tables[0].Rows[0]["stocktaking_id"].ToString();
				model.takinger=ds.Tables[0].Rows[0]["takinger"].ToString();
				model.taking_date=ds.Tables[0].Rows[0]["taking_date"].ToString();
				model.taking_des=ds.Tables[0].Rows[0]["taking_des"].ToString();
				if(ds.Tables[0].Rows[0]["state"].ToString()!="")
				{
					model.state=int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
				}
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
			strSql.Append("select id,depot_id,stocktaking_id,takinger,taking_date,taking_des,state ");
			strSql.Append(" FROM stocktaking ");
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
			strSql.Append(" id,depot_id,stocktaking_id,takinger,taking_date,taking_des,state ");
			strSql.Append(" FROM stocktaking ");
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
			parameters[0].Value = "stocktaking";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法
	}
}

