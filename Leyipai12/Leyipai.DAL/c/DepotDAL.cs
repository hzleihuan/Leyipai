using System;
using System.Collections.Generic;
using System.Text;
using Leyipai.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace Leyipai.DAL.c
{
   public class DepotDAL
    {
       public DepotDAL() { }

       #region  成员方法

       /// <summary>
       /// 得到最大ID
       /// </summary>
       public int GetMaxId()
       {
           return DbHelperSQL.GetMaxID("depot_id", "c_depot");
       }

       /// <summary>
       /// 是否存在该记录
       /// </summary>
       public bool Exists(int depot_id)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select count(1) from c_depot");
           strSql.Append(" where depot_id=@depot_id ");
           SqlParameter[] parameters = {
					new SqlParameter("@depot_id", SqlDbType.Int,4)};
           parameters[0].Value = depot_id;

           return DbHelperSQL.Exists(strSql.ToString(), parameters);
       }


       /// <summary>
       /// 增加一条数据
       /// </summary>
       public int Add(Leyipai.Model.c_depot model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into c_depot(");
           strSql.Append("depot_name,state)");
           strSql.Append(" values (");
           strSql.Append("@depot_name,@state)");
           strSql.Append(";select @@IDENTITY");
           SqlParameter[] parameters = {
					new SqlParameter("@depot_name", SqlDbType.VarChar,128),
					new SqlParameter("@state", SqlDbType.TinyInt,1)};
           parameters[0].Value = model.depot_name;
           parameters[1].Value = model.state;

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
       public void Update(Leyipai.Model.c_depot model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update c_depot set ");
           strSql.Append("depot_name=@depot_name,");
           strSql.Append("state=@state");
           strSql.Append(" where depot_id=@depot_id ");
           SqlParameter[] parameters = {
					new SqlParameter("@depot_id", SqlDbType.Int,4),
					new SqlParameter("@depot_name", SqlDbType.VarChar,128),
					new SqlParameter("@state", SqlDbType.TinyInt,1)};
           parameters[0].Value = model.depot_id;
           parameters[1].Value = model.depot_name;
           parameters[2].Value = model.state;

           DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public void Delete(int depot_id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from c_depot ");
           strSql.Append(" where depot_id=@depot_id ");
           SqlParameter[] parameters = {
					new SqlParameter("@depot_id", SqlDbType.Int,4)};
           parameters[0].Value = depot_id;

           DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
       }


       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public Leyipai.Model.c_depot GetModel(int depot_id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 depot_id,depot_name,state from c_depot ");
           strSql.Append(" where depot_id=@depot_id ");
           SqlParameter[] parameters = {
					new SqlParameter("@depot_id", SqlDbType.Int,4)};
           parameters[0].Value = depot_id;

           Leyipai.Model.c_depot model = new Leyipai.Model.c_depot();
           DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
           if (ds.Tables[0].Rows.Count > 0)
           {
               if (ds.Tables[0].Rows[0]["depot_id"].ToString() != "")
               {
                   model.depot_id = int.Parse(ds.Tables[0].Rows[0]["depot_id"].ToString());
               }
               model.depot_name = ds.Tables[0].Rows[0]["depot_name"].ToString();
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
           strSql.Append("select depot_id,depot_name,state ");
           strSql.Append(" FROM c_depot ");
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
           strSql.Append(" depot_id,depot_name,state ");
           strSql.Append(" FROM c_depot ");
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
            parameters[0].Value = "c_depot";
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
