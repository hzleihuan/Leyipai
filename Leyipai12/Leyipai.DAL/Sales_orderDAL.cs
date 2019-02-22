using System;
using System.Collections.Generic;
using System.Text;
using Leyipai.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace Leyipai.DAL
{
    public class Sales_orderDAL
    {
        public Sales_orderDAL()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "sales_order");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sales_order");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Leyipai.Model.sales_order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sales_order(");
            strSql.Append("sales_orderId,create_date,sales_type,customer_id,depot_id,delivery_type,delivery_place,logistics_id,logistics_num,sales_income,attach_pay,discount,username,auditing_user,description,state,period_id)");
            strSql.Append(" values (");
            strSql.Append("@sales_orderId,@create_date,@sales_type,@customer_id,@depot_id,@delivery_type,@delivery_place,@logistics_id,@logistics_num,@sales_income,@attach_pay,@discount,@username,@auditing_user,@description,@state,@period_id)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@sales_orderId", SqlDbType.VarChar,50),
					new SqlParameter("@create_date", SqlDbType.VarChar,50),
					new SqlParameter("@sales_type", SqlDbType.Int,4),
					new SqlParameter("@customer_id", SqlDbType.Int,4),
					new SqlParameter("@depot_id", SqlDbType.Int,4),
					new SqlParameter("@delivery_type", SqlDbType.VarChar,50),
					new SqlParameter("@delivery_place", SqlDbType.VarChar,180),
					new SqlParameter("@logistics_id", SqlDbType.Int,4),
					new SqlParameter("@logistics_num", SqlDbType.VarChar,50),
					new SqlParameter("@sales_income", SqlDbType.Money,8),
					new SqlParameter("@attach_pay", SqlDbType.Money,8),
					new SqlParameter("@discount", SqlDbType.Money,8),
					new SqlParameter("@username", SqlDbType.VarChar,50),
					new SqlParameter("@auditing_user", SqlDbType.VarChar,50),
					new SqlParameter("@description", SqlDbType.VarChar,200),
					new SqlParameter("@state", SqlDbType.Int,4),
                    new SqlParameter("@period_id", SqlDbType.Int,4)};
            parameters[0].Value = model.sales_orderId;
            parameters[1].Value = model.create_date;
            parameters[2].Value = model.sales_type;
            parameters[3].Value = model.customer_id;
            parameters[4].Value = model.depot_id;
            parameters[5].Value = model.delivery_type;
            parameters[6].Value = model.delivery_place;
            parameters[7].Value = model.logistics_id;
            parameters[8].Value = model.logistics_num;
            parameters[9].Value = model.sales_income;
            parameters[10].Value = model.attach_pay;
            parameters[11].Value = model.discount;
            parameters[12].Value = model.username;
            parameters[13].Value = model.auditing_user;
            parameters[14].Value = model.description;
            parameters[15].Value = model.state;
            parameters[16].Value = model.period_id;


            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public void Update(Leyipai.Model.sales_order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sales_order set ");
            strSql.Append("sales_orderId=@sales_orderId,");
            strSql.Append("create_date=@create_date,");
            strSql.Append("sales_type=@sales_type,");
            strSql.Append("customer_id=@customer_id,");
            strSql.Append("depot_id=@depot_id,");
            strSql.Append("delivery_type=@delivery_type,");
            strSql.Append("delivery_place=@delivery_place,");
            strSql.Append("logistics_id=@logistics_id,");
            strSql.Append("logistics_num=@logistics_num,");
            strSql.Append("sales_income=@sales_income,");
            strSql.Append("attach_pay=@attach_pay,");
            strSql.Append("discount=@discount,");
            strSql.Append("username=@username,");
            strSql.Append("auditing_user=@auditing_user,");
            strSql.Append("description=@description,");
            strSql.Append("state=@state");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@sales_orderId", SqlDbType.VarChar,50),
					new SqlParameter("@create_date", SqlDbType.VarChar,50),
					new SqlParameter("@sales_type", SqlDbType.Int,4),
					new SqlParameter("@customer_id", SqlDbType.Int,4),
					new SqlParameter("@depot_id", SqlDbType.Int,4),
					new SqlParameter("@delivery_type", SqlDbType.VarChar,50),
					new SqlParameter("@delivery_place", SqlDbType.VarChar,180),
					new SqlParameter("@logistics_id", SqlDbType.Int,4),
					new SqlParameter("@logistics_num", SqlDbType.VarChar,50),
					new SqlParameter("@sales_income", SqlDbType.Money,8),
					new SqlParameter("@attach_pay", SqlDbType.Money,8),
					new SqlParameter("@discount", SqlDbType.Money,8),
					new SqlParameter("@username", SqlDbType.VarChar,50),
					new SqlParameter("@auditing_user", SqlDbType.VarChar,50),
					new SqlParameter("@description", SqlDbType.VarChar,200),
					new SqlParameter("@state", SqlDbType.Int,4)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.sales_orderId;
            parameters[2].Value = model.create_date;
            parameters[3].Value = model.sales_type;
            parameters[4].Value = model.customer_id;
            parameters[5].Value = model.depot_id;
            parameters[6].Value = model.delivery_type;
            parameters[7].Value = model.delivery_place;
            parameters[8].Value = model.logistics_id;
            parameters[9].Value = model.logistics_num;
            parameters[10].Value = model.sales_income;
            parameters[11].Value = model.attach_pay;
            parameters[12].Value = model.discount;
            parameters[13].Value = model.username;
            parameters[14].Value = model.auditing_user;
            parameters[15].Value = model.description;
            parameters[16].Value = model.state;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sales_order ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Leyipai.Model.sales_order GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,period_id,sales_orderId,create_date,sales_type,customer_id,depot_id,delivery_type,delivery_place,logistics_id,logistics_num,sales_income,attach_pay,discount,username,auditing_user,description,state from sales_order ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Leyipai.Model.sales_order model = new Leyipai.Model.sales_order();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.sales_orderId = ds.Tables[0].Rows[0]["sales_orderId"].ToString();
                model.create_date = ds.Tables[0].Rows[0]["create_date"].ToString();
                if (ds.Tables[0].Rows[0]["sales_type"].ToString() != "")
                {
                    model.sales_type = int.Parse(ds.Tables[0].Rows[0]["sales_type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["customer_id"].ToString() != "")
                {
                    model.customer_id = int.Parse(ds.Tables[0].Rows[0]["customer_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["depot_id"].ToString() != "")
                {
                    model.depot_id = int.Parse(ds.Tables[0].Rows[0]["depot_id"].ToString());
                }
                model.delivery_type = ds.Tables[0].Rows[0]["delivery_type"].ToString();
                model.delivery_place = ds.Tables[0].Rows[0]["delivery_place"].ToString();
                if (ds.Tables[0].Rows[0]["logistics_id"].ToString() != "")
                {
                    model.logistics_id = int.Parse(ds.Tables[0].Rows[0]["logistics_id"].ToString());
                }
                model.logistics_num = ds.Tables[0].Rows[0]["logistics_num"].ToString();
                if (ds.Tables[0].Rows[0]["sales_income"].ToString() != "")
                {
                    model.sales_income = decimal.Parse(ds.Tables[0].Rows[0]["sales_income"].ToString());
                }
                if (ds.Tables[0].Rows[0]["attach_pay"].ToString() != "")
                {
                    model.attach_pay = decimal.Parse(ds.Tables[0].Rows[0]["attach_pay"].ToString());
                }
                if (ds.Tables[0].Rows[0]["discount"].ToString() != "")
                {
                    model.discount = decimal.Parse(ds.Tables[0].Rows[0]["discount"].ToString());
                }
                model.username = ds.Tables[0].Rows[0]["username"].ToString();
                model.auditing_user = ds.Tables[0].Rows[0]["auditing_user"].ToString();
                model.description = ds.Tables[0].Rows[0]["description"].ToString();
                if (ds.Tables[0].Rows[0]["state"].ToString() != "")
                {
                    model.state = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append(" FROM sales_order_view ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,period_id,sales_orderId,create_date,sales_type,customer_id,depot_id,delivery_type,delivery_place,logistics_id,logistics_num,sales_income,attach_pay,discount,username,auditing_user,description,state ");
            strSql.Append(" FROM sales_order ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int pagesize, int cureentpage, string strWhere)
        {
            int selectCount = pagesize * cureentpage;
            string strSql = @"select * from (   select TOP " + pagesize + " * FROM ( SELECT TOP " + selectCount + "  * from sales_order_view where " + strWhere + " ORDER BY id ASC ) as aSysTable   ORDER BY id DESC ) as bSysTable   ORDER BY id ASC";
            return DbHelperSQL.Query(strSql.ToString());

        }
        /// <summary>
        /// 相关条件查出来的记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int getSqlRecodeCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) ");
            strSql.Append(" FROM sales_order_view ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Object o = DbHelperSQL.GetSingle(strSql.ToString());
            if (null == o) return 0;
            else return int.Parse(o.ToString());

        }
     

        #endregion  成员方法
    }
}