using System;
using System.Collections.Generic;
using System.Text;
using Leyipai.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace Leyipai.DAL
{
    public class OrderDetailDAL
    {
        public OrderDetailDAL()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "order_detail"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from order_detail");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Leyipai.Model.order_detail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into order_detail(");
			strSql.Append("order_id,products_id,quantity,price,discount_rate)");
			strSql.Append(" values (");
			strSql.Append("@order_id,@products_id,@quantity,@price,@discount_rate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@order_id", SqlDbType.VarChar,50),
					new SqlParameter("@products_id", SqlDbType.Int,4),
					new SqlParameter("@quantity", SqlDbType.Int,4),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@discount_rate", SqlDbType.Float,8)};
			parameters[0].Value = model.order_id;
			parameters[1].Value = model.products_id;
			parameters[2].Value = model.quantity;
			parameters[3].Value = model.price;
			parameters[4].Value = model.discount_rate;

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
		public void Update(Leyipai.Model.order_detail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update order_detail set ");
			strSql.Append("order_id=@order_id,");
			strSql.Append("products_id=@products_id,");
			strSql.Append("quantity=@quantity,");
			strSql.Append("price=@price,");
			strSql.Append("discount_rate=@discount_rate");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@order_id", SqlDbType.VarChar,50),
					new SqlParameter("@products_id", SqlDbType.Int,4),
					new SqlParameter("@quantity", SqlDbType.Int,4),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@discount_rate", SqlDbType.Float,8)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.order_id;
			parameters[2].Value = model.products_id;
			parameters[3].Value = model.quantity;
			parameters[4].Value = model.price;
			parameters[5].Value = model.discount_rate;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from order_detail ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Leyipai.Model.order_detail GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,order_id,products_id,quantity,price,discount_rate from order_detail ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Leyipai.Model.order_detail model=new Leyipai.Model.order_detail();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.order_id=ds.Tables[0].Rows[0]["order_id"].ToString();
				if(ds.Tables[0].Rows[0]["products_id"].ToString()!="")
				{
					model.products_id=int.Parse(ds.Tables[0].Rows[0]["products_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["quantity"].ToString()!="")
				{
					model.quantity=int.Parse(ds.Tables[0].Rows[0]["quantity"].ToString());
				}
				if(ds.Tables[0].Rows[0]["price"].ToString()!="")
				{
					model.price=decimal.Parse(ds.Tables[0].Rows[0]["price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["discount_rate"].ToString()!="")
				{
					model.discount_rate=decimal.Parse(ds.Tables[0].Rows[0]["discount_rate"].ToString());
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
			strSql.Append("select id,order_id,products_id,quantity,price,discount_rate ");
			strSql.Append(" FROM order_detail ");
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
			strSql.Append(" id,order_id,products_id,quantity,price,discount_rate ");
			strSql.Append(" FROM order_detail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}


        /// <summary>
        /// 按订单编号删除
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public bool DeleteByOrderId(string orderId)
        {
            string sql = @"delete from order_detail where order_id='" + orderId + "'";
            return DbHelperSQL.ExecuteSql(sql) > 0;
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
			parameters[0].Value = "order_detail";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法



        /// <summary>
        /// 
        /// 一段时间内一个商品销售量
        /// </summary>
        /// <param name="bdate"></param>
        /// <param name="edate"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        public DataSet getTotalNumByDate(string bdate,string edate ,int pid)
        {
            //sales_product_report
            string sql = @"SELECT order_detail.*, sales_order.state, sales_order.create_date FROM order_detail INNER JOIN sales_order ON order_detail.order_id = sales_order.sales_orderId where sales_order.state=1 and products_id=" + pid + " and  create_date<'" + edate + "' and create_date > '" + bdate + "'";

            return DbHelperSQL.Query(sql);
        }
    }
}
