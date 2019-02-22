using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Leyipai.DBUtility;//请先添加引用

namespace Leyipai.DAL.accountant
{
   public class AccountantPeriodDAL
    {

       public AccountantPeriodDAL()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "accountant_period"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from accountant_period");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Leyipai.Model.accountant_period model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into accountant_period(");
			strSql.Append("period_name,Period_bdate,Period_edate,income,outpay,state)");
			strSql.Append(" values (");
			strSql.Append("@period_name,@Period_bdate,@Period_edate,@income,@outpay,@state)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@period_name", SqlDbType.VarChar,50),
					new SqlParameter("@Period_bdate", SqlDbType.VarChar,50),
					new SqlParameter("@Period_edate", SqlDbType.VarChar,50),
					new SqlParameter("@income", SqlDbType.Money,8),
					new SqlParameter("@outpay", SqlDbType.Money,8),
					new SqlParameter("@state", SqlDbType.Int,4)};
			parameters[0].Value = model.period_name;
			parameters[1].Value = model.Period_bdate;
			parameters[2].Value = model.Period_edate;
			parameters[3].Value = model.income;
			parameters[4].Value = model.outpay;
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
		public void Update(Leyipai.Model.accountant_period model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update accountant_period set ");
			strSql.Append("period_name=@period_name,");
			strSql.Append("Period_bdate=@Period_bdate,");
			strSql.Append("Period_edate=@Period_edate,");
			strSql.Append("income=@income,");
			strSql.Append("outpay=@outpay,");
			strSql.Append("state=@state");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@period_name", SqlDbType.VarChar,50),
					new SqlParameter("@Period_bdate", SqlDbType.VarChar,50),
					new SqlParameter("@Period_edate", SqlDbType.VarChar,50),
					new SqlParameter("@income", SqlDbType.Money,8),
					new SqlParameter("@outpay", SqlDbType.Money,8),
					new SqlParameter("@state", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.period_name;
			parameters[2].Value = model.Period_bdate;
			parameters[3].Value = model.Period_edate;
			parameters[4].Value = model.income;
			parameters[5].Value = model.outpay;
			parameters[6].Value = model.state;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from accountant_period ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Leyipai.Model.accountant_period GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,period_name,Period_bdate,Period_edate,income,outpay,state from accountant_period ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Leyipai.Model.accountant_period model=new Leyipai.Model.accountant_period();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.period_name=ds.Tables[0].Rows[0]["period_name"].ToString();
				model.Period_bdate=ds.Tables[0].Rows[0]["Period_bdate"].ToString();
				model.Period_edate=ds.Tables[0].Rows[0]["Period_edate"].ToString();
				if(ds.Tables[0].Rows[0]["income"].ToString()!="")
				{
					model.income=decimal.Parse(ds.Tables[0].Rows[0]["income"].ToString());
				}
				if(ds.Tables[0].Rows[0]["outpay"].ToString()!="")
				{
					model.outpay=decimal.Parse(ds.Tables[0].Rows[0]["outpay"].ToString());
				}
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
			strSql.Append("select id,period_name,Period_bdate,Period_edate,income,outpay,state ");
			strSql.Append(" FROM accountant_period ");
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
			strSql.Append(" id,period_name,Period_bdate,Period_edate,income,outpay,state ");
			strSql.Append(" FROM accountant_period ");
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
			parameters[0].Value = "accountant_period";
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


