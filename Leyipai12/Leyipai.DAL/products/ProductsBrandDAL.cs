using System;
using System.Collections.Generic;
using System.Text;
using Leyipai.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace Leyipai.DAL.products
{
  public  class ProductsBrandDAL
    {
      public ProductsBrandDAL() { }
      #region  成员方法

      /// <summary>
      /// 得到最大ID
      /// </summary>
      public int GetMaxId()
      {
          return DbHelperSQL.GetMaxID("brand_id", "products_brand");
      }

      /// <summary>
      /// 是否存在该记录
      /// </summary>
      public bool Exists(int brand_id)
      {
          StringBuilder strSql = new StringBuilder();
          strSql.Append("select count(1) from products_brand");
          strSql.Append(" where brand_id=@brand_id ");
          SqlParameter[] parameters = {
					new SqlParameter("@brand_id", SqlDbType.Int,4)};
          parameters[0].Value = brand_id;

          return DbHelperSQL.Exists(strSql.ToString(), parameters);
      }


      /// <summary>
      /// 增加一条数据
      /// </summary>
      public int Add(Leyipai.Model.products_brand model)
      {
          StringBuilder strSql = new StringBuilder();
          strSql.Append("insert into products_brand(");
          strSql.Append("brand_name,description,state)");
          strSql.Append(" values (");
          strSql.Append("@brand_name,@description,@state)");
          strSql.Append(";select @@IDENTITY");
          SqlParameter[] parameters = {
					new SqlParameter("@brand_name", SqlDbType.VarChar,50),
					new SqlParameter("@description", SqlDbType.VarChar,512),
					new SqlParameter("@state", SqlDbType.TinyInt,1)};
          parameters[0].Value = model.brand_name;
          parameters[1].Value = model.description;
          parameters[2].Value = model.state;

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
      public void Update(Leyipai.Model.products_brand model)
      {
          StringBuilder strSql = new StringBuilder();
          strSql.Append("update products_brand set ");
          strSql.Append("brand_name=@brand_name,");
          strSql.Append("description=@description,");
          strSql.Append("state=@state");
          strSql.Append(" where brand_id=@brand_id ");
          SqlParameter[] parameters = {
					new SqlParameter("@brand_id", SqlDbType.Int,4),
					new SqlParameter("@brand_name", SqlDbType.VarChar,50),
					new SqlParameter("@description", SqlDbType.VarChar,512),
					new SqlParameter("@state", SqlDbType.TinyInt,1)};
          parameters[0].Value = model.brand_id;
          parameters[1].Value = model.brand_name;
          parameters[2].Value = model.description;
          parameters[3].Value = model.state;

          DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
      }

      /// <summary>
      /// 删除一条数据
      /// </summary>
      public void Delete(int brand_id)
      {

          StringBuilder strSql = new StringBuilder();
          strSql.Append("delete from products_brand ");
          strSql.Append(" where brand_id=@brand_id ");
          SqlParameter[] parameters = {
					new SqlParameter("@brand_id", SqlDbType.Int,4)};
          parameters[0].Value = brand_id;

          DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
      }


      /// <summary>
      /// 得到一个对象实体
      /// </summary>
      public Leyipai.Model.products_brand GetModel(int brand_id)
      {

          StringBuilder strSql = new StringBuilder();
          strSql.Append("select  top 1 brand_id,brand_name,description,state from products_brand ");
          strSql.Append(" where brand_id=@brand_id ");
          SqlParameter[] parameters = {
					new SqlParameter("@brand_id", SqlDbType.Int,4)};
          parameters[0].Value = brand_id;

          Leyipai.Model.products_brand model = new Leyipai.Model.products_brand();
          DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
          if (ds.Tables[0].Rows.Count > 0)
          {
              if (ds.Tables[0].Rows[0]["brand_id"].ToString() != "")
              {
                  model.brand_id = int.Parse(ds.Tables[0].Rows[0]["brand_id"].ToString());
              }
              model.brand_name = ds.Tables[0].Rows[0]["brand_name"].ToString();
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
          strSql.Append("select brand_id,brand_name,description,state ");
          strSql.Append(" FROM products_brand ");
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
          strSql.Append(" brand_id,brand_name,description,state ");
          strSql.Append(" FROM products_brand ");
          if (strWhere.Trim() != "")
          {
              strSql.Append(" where " + strWhere);
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
            parameters[0].Value = "products_brand";
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
