using System;
using System.Collections.Generic;
using System.Text;
using Leyipai.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace Leyipai.DAL
{
   public class DepotProductsDAL
    {
       public DepotProductsDAL() { }


       /// <summary>
       /// 增加一条数据
       /// </summary>
       public int Add(Leyipai.Model.depot_products model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into depot_products(");
           strSql.Append("product_id,depot_id,quantity)");
           strSql.Append(" values (");
           strSql.Append("@product_id,@depot_id,@quantity)");
           strSql.Append(";select @@IDENTITY");
           SqlParameter[] parameters = {
					new SqlParameter("@product_id", SqlDbType.Int,4),
					new SqlParameter("@depot_id", SqlDbType.Int,4),
					new SqlParameter("@quantity", SqlDbType.Int,4)};
           parameters[0].Value = model.product_id;
           parameters[1].Value = model.depot_id;
           parameters[2].Value = model.quantity;

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
       /// 更新一条数据 quantity
       /// </summary>
       public void Update(Leyipai.Model.depot_products model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update depot_products set ");
           strSql.Append("quantity=@quantity");
           strSql.Append(" where id=@id ");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@quantity", SqlDbType.Int,4)};
           parameters[0].Value = model.id;
           parameters[1].Value = model.quantity;

           DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public void Delete(int id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from depot_products ");
           strSql.Append(" where id=@id ");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
           parameters[0].Value = id;

           DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
       }


       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public Leyipai.Model.depot_products GetModel(int id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 id,product_id,depot_id,quantity from depot_products ");
           strSql.Append(" where id=@id ");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
           parameters[0].Value = id;

           Leyipai.Model.depot_products model = new Leyipai.Model.depot_products();
           DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
           if (ds.Tables[0].Rows.Count > 0)
           {
               if (ds.Tables[0].Rows[0]["id"].ToString() != "")
               {
                   model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
               }
               if (ds.Tables[0].Rows[0]["product_id"].ToString() != "")
               {
                   model.product_id = int.Parse(ds.Tables[0].Rows[0]["product_id"].ToString());
               }
               if (ds.Tables[0].Rows[0]["quantity"].ToString() != "")
               {
                   model.quantity = int.Parse(ds.Tables[0].Rows[0]["quantity"].ToString());
               }
               if (ds.Tables[0].Rows[0]["depot_id"].ToString() != "")
               {
                   model.depot_id = int.Parse(ds.Tables[0].Rows[0]["depot_id"].ToString());
               }
              
               return model;
           }
           else
           {
               return null;
           }
       }


       /// <summary>
       /// 
       /// </summary>
       /// <param name="pid">商品ID</param>
       /// <param name="did">仓库id</param>
       /// <returns></returns>
       public Leyipai.Model.depot_products GetModelByPidDid(int pid,int did)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 id,product_id,depot_id,quantity from depot_products ");
           strSql.Append(" where product_id=@product_id and depot_id=@depot_id ");
           SqlParameter[] parameters = {
					new SqlParameter("@product_id", SqlDbType.Int,4),
                    new SqlParameter("@depot_id", SqlDbType.Int,4)
           
           };
           parameters[0].Value = pid;
           parameters[1].Value = did;

           Leyipai.Model.depot_products model = new Leyipai.Model.depot_products();
           DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
           if (ds.Tables[0].Rows.Count > 0)
           {
               if (ds.Tables[0].Rows[0]["id"].ToString() != "")
               {
                   model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
               }
               if (ds.Tables[0].Rows[0]["product_id"].ToString() != "")
               {
                   model.product_id = int.Parse(ds.Tables[0].Rows[0]["product_id"].ToString());
               }
               if (ds.Tables[0].Rows[0]["quantity"].ToString() != "")
               {
                   model.quantity = int.Parse(ds.Tables[0].Rows[0]["quantity"].ToString());
               }
               if (ds.Tables[0].Rows[0]["depot_id"].ToString() != "")
               {
                   model.depot_id = int.Parse(ds.Tables[0].Rows[0]["depot_id"].ToString());
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
           strSql.Append("select id,product_id,depot_id,quantity,product_name,depot_name ");
           strSql.Append(" FROM depot_products_view ");
           if (strWhere.Trim() != "")
           {
               strSql.Append(" where " + strWhere);
           }
           return DbHelperSQL.Query(strSql.ToString());
       }
   
   }
}
