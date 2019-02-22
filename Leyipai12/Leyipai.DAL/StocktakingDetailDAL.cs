using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Leyipai.DBUtility;//请先添加引用
namespace Leyipai.DAL
{
	/// <summary>
	/// 数据访问类stocktaking_detail。
	/// </summary>
	public class StocktakingDetailDAL
	{
        public StocktakingDetailDAL()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "stocktaking_detail"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from stocktaking_detail");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Leyipai.Model.stocktaking_detail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into stocktaking_detail(");
			strSql.Append("id,stocktaking_id,product_id,oldstock,newstock,dealstock)");
			strSql.Append(" values (");
			strSql.Append("@id,@stocktaking_id,@product_id,@oldstock,@newstock,@dealstock)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@stocktaking_id", SqlDbType.VarChar,20),
					new SqlParameter("@product_id", SqlDbType.Int,4),
					new SqlParameter("@oldstock", SqlDbType.Int,4),
					new SqlParameter("@newstock", SqlDbType.Int,4),
					new SqlParameter("@dealstock", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.stocktaking_id;
			parameters[2].Value = model.product_id;
			parameters[3].Value = model.oldstock;
			parameters[4].Value = model.newstock;
			parameters[5].Value = model.dealstock;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Leyipai.Model.stocktaking_detail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update stocktaking_detail set ");
			strSql.Append("stocktaking_id=@stocktaking_id,");
			strSql.Append("product_id=@product_id,");
			strSql.Append("oldstock=@oldstock,");
			strSql.Append("newstock=@newstock,");
			strSql.Append("dealstock=@dealstock");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@stocktaking_id", SqlDbType.VarChar,20),
					new SqlParameter("@product_id", SqlDbType.Int,4),
					new SqlParameter("@oldstock", SqlDbType.Int,4),
					new SqlParameter("@newstock", SqlDbType.Int,4),
					new SqlParameter("@dealstock", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.stocktaking_id;
			parameters[2].Value = model.product_id;
			parameters[3].Value = model.oldstock;
			parameters[4].Value = model.newstock;
			parameters[5].Value = model.dealstock;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from stocktaking_detail ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Leyipai.Model.stocktaking_detail GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,stocktaking_id,product_id,oldstock,newstock,dealstock from stocktaking_detail ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Leyipai.Model.stocktaking_detail model=new Leyipai.Model.stocktaking_detail();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.stocktaking_id=ds.Tables[0].Rows[0]["stocktaking_id"].ToString();
				if(ds.Tables[0].Rows[0]["product_id"].ToString()!="")
				{
					model.product_id=int.Parse(ds.Tables[0].Rows[0]["product_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["oldstock"].ToString()!="")
				{
					model.oldstock=int.Parse(ds.Tables[0].Rows[0]["oldstock"].ToString());
				}
				if(ds.Tables[0].Rows[0]["newstock"].ToString()!="")
				{
					model.newstock=int.Parse(ds.Tables[0].Rows[0]["newstock"].ToString());
				}
				if(ds.Tables[0].Rows[0]["dealstock"].ToString()!="")
				{
					model.dealstock=int.Parse(ds.Tables[0].Rows[0]["dealstock"].ToString());
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
			strSql.Append("select id,stocktaking_id,product_id,oldstock,newstock,dealstock ");
			strSql.Append(" FROM stocktaking_detail ");
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
			strSql.Append(" id,stocktaking_id,product_id,oldstock,newstock,dealstock ");
			strSql.Append(" FROM stocktaking_detail ");
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
			parameters[0].Value = "stocktaking_detail";
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

