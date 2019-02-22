﻿using System;
using System.Collections.Generic;
using System.Text;
using Leyipai.DBUtility;
using System.Data;
using System.Data.SqlClient;
namespace Leyipai.DAL.c
{
   public class LogisticsDAL
    {

       public LogisticsDAL() { }

       #region  成员方法

       /// <summary>
       /// 得到最大ID
       /// </summary>
       public int GetMaxId()
       {
           return DbHelperSQL.GetMaxID("id", "c_logistics");
       }

       /// <summary>
       /// 是否存在该记录
       /// </summary>
       public bool Exists(int id)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select count(1) from c_logistics");
           strSql.Append(" where id=@id ");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
           parameters[0].Value = id;

           return DbHelperSQL.Exists(strSql.ToString(), parameters);
       }


       /// <summary>
       /// 增加一条数据
       /// </summary>
       public int Add(Leyipai.Model.c_logistics model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into c_logistics(");
           strSql.Append("logistics_name,description)");
           strSql.Append(" values (");
           strSql.Append("@logistics_name,@description)");
           strSql.Append(";select @@IDENTITY");
           SqlParameter[] parameters = {
					new SqlParameter("@logistics_name", SqlDbType.VarChar,50),
					new SqlParameter("@description", SqlDbType.VarChar,500)};
           parameters[0].Value = model.logistics_name;
           parameters[1].Value = model.description;

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
       public void Update(Leyipai.Model.c_logistics model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update c_logistics set ");
           strSql.Append("logistics_name=@logistics_name,");
           strSql.Append("description=@description");
           strSql.Append(" where id=@id ");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@logistics_name", SqlDbType.VarChar,50),
					new SqlParameter("@description", SqlDbType.VarChar,500)};
           parameters[0].Value = model.id;
           parameters[1].Value = model.logistics_name;
           parameters[2].Value = model.description;

           DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public void Delete(int id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from c_logistics ");
           strSql.Append(" where id=@id ");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
           parameters[0].Value = id;

           DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
       }


       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public Leyipai.Model.c_logistics GetModel(int id)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 id,logistics_name,description from c_logistics ");
           strSql.Append(" where id=@id ");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
           parameters[0].Value = id;

           Leyipai.Model.c_logistics model = new Leyipai.Model.c_logistics();
           DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
           if (ds.Tables[0].Rows.Count > 0)
           {
               if (ds.Tables[0].Rows[0]["id"].ToString() != "")
               {
                   model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
               }
               model.logistics_name = ds.Tables[0].Rows[0]["logistics_name"].ToString();
               model.description = ds.Tables[0].Rows[0]["description"].ToString();
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
           strSql.Append("select id,logistics_name,description ");
           strSql.Append(" FROM c_logistics ");
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
           strSql.Append(" id,logistics_name,description ");
           strSql.Append(" FROM c_logistics ");
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
            parameters[0].Value = "c_logistics";
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
