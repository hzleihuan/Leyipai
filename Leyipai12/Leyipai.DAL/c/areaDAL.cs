using System;
using System.Collections.Generic;
using System.Text;
using Leyipai.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace Leyipai.DAL.c
{
   public class areaDAL
    {
       public areaDAL()
       { }

       public int GetMaxId()
       {
           return DbHelperSQL.GetMaxID("id", "c_area");
       }


       /// <summary>
       /// 增加一条数据
       /// </summary>
       public int Add(Leyipai.Model.c_area model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into c_area(");
           strSql.Append("area_name,parent_id)");
           strSql.Append(" values (");
           strSql.Append("@area_name,@parent_id)");
           strSql.Append(";select @@IDENTITY");
           SqlParameter[] parameters = {
					new SqlParameter("@area_name", SqlDbType.NVarChar,255),
					new SqlParameter("@parent_id", SqlDbType.Int,4)};
           parameters[0].Value = model.area_name;
           parameters[1].Value = model.parent_id;

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
       public void Update(Leyipai.Model.c_area model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update c_area set ");
           strSql.Append("area_name=@area_name,");
           strSql.Append("parent_id=@parent_id");
           strSql.Append(" where id=@id ");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@area_name", SqlDbType.NVarChar,255),
					new SqlParameter("@parent_id", SqlDbType.Int,4)};
           parameters[0].Value = model.id;
           parameters[1].Value = model.area_name;
           parameters[2].Value = model.parent_id;

           DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public void Delete(int id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from c_area ");
           strSql.Append(" where id=@id ");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
           parameters[0].Value = id;

           DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
       }


       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public Leyipai.Model.c_area GetModel(int id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 id,area_name,parent_id from c_area ");
           strSql.Append(" where id=@id ");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
           parameters[0].Value = id;

           Leyipai.Model.c_area model = new Leyipai.Model.c_area();
           DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
           if (ds.Tables[0].Rows.Count > 0)
           {
               if (ds.Tables[0].Rows[0]["id"].ToString() != "")
               {
                   model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
               }
               model.area_name = ds.Tables[0].Rows[0]["area_name"].ToString();
               if (ds.Tables[0].Rows[0]["parent_id"].ToString() != "")
               {
                   model.parent_id = int.Parse(ds.Tables[0].Rows[0]["parent_id"].ToString());
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
           strSql.Append("select id,area_name,parent_id ");
           strSql.Append(" FROM c_area ");
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
           strSql.Append(" id,area_name,parent_id ");
           strSql.Append(" FROM c_area ");
           if (strWhere.Trim() != "")
           {
               strSql.Append(" where " + strWhere);
           }
           strSql.Append(" order by " + filedOrder);
           return DbHelperSQL.Query(strSql.ToString());
       }

       

    }
}
