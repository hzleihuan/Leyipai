using System;
using System.Collections.Generic;
using System.Text;
using Leyipai.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace Leyipai.DAL
{
    public class SysRoseDAL
    {
        public SysRoseDAL() { }

        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("rid", "sys_rose");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int rid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sys_rose");
            strSql.Append(" where rid=@rid ");
            SqlParameter[] parameters = {
					new SqlParameter("@rid", SqlDbType.Int,4)};
            parameters[0].Value = rid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Leyipai.Model.sys_rose model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sys_rose(");
            strSql.Append("rose_name,des)");
            strSql.Append(" values (");
            strSql.Append("@rose_name,@des)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@rose_name", SqlDbType.VarChar,128),
					new SqlParameter("@des", SqlDbType.VarChar,256)};
            parameters[0].Value = model.rose_name;
            parameters[1].Value = model.des;

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
        public void Update(Leyipai.Model.sys_rose model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sys_rose set ");
            strSql.Append("rose_name=@rose_name,");
            strSql.Append("des=@des");
            strSql.Append(" where rid=@rid ");
            SqlParameter[] parameters = {
					new SqlParameter("@rid", SqlDbType.Int,4),
					new SqlParameter("@rose_name", SqlDbType.VarChar,128),
					new SqlParameter("@des", SqlDbType.VarChar,256)};
            parameters[0].Value = model.rid;
            parameters[1].Value = model.rose_name;
            parameters[2].Value = model.des;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int rid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sys_rose ");
            strSql.Append(" where rid=@rid ");
            SqlParameter[] parameters = {
					new SqlParameter("@rid", SqlDbType.Int,4)};
            parameters[0].Value = rid;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Leyipai.Model.sys_rose GetModel(int rid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 rid,rose_name,des from sys_rose ");
            strSql.Append(" where rid=@rid ");
            SqlParameter[] parameters = {
					new SqlParameter("@rid", SqlDbType.Int,4)};
            parameters[0].Value = rid;

            Leyipai.Model.sys_rose model = new Leyipai.Model.sys_rose();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["rid"].ToString() != "")
                {
                    model.rid = int.Parse(ds.Tables[0].Rows[0]["rid"].ToString());
                }
                model.rose_name = ds.Tables[0].Rows[0]["rose_name"].ToString();
                model.des = ds.Tables[0].Rows[0]["des"].ToString();
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
            strSql.Append("select rid,rose_name,des ");
            strSql.Append(" FROM sys_rose ");
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
            strSql.Append(" rid,rose_name,des ");
            strSql.Append(" FROM sys_rose ");
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
            parameters[0].Value = "sys_rose";
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
        /// 获得资源数据列表
        /// </summary>
        public DataSet GetAllResourceList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select rs_id,rs_name,rs_url,rs_type ");
            strSql.Append(" FROM sys_resource ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 得到一个角色的资源
        /// </summary>
        /// <param name="rid"></param>
        /// <returns></returns>
        public DataSet GetResouceByRoseID(int rid)
        {
            string strSql = @"SELECT sys_resource.* FROM sys_rose_resource INNER JOIN sys_rose ON sys_rose_resource.rid = sys_rose.rid INNER JOIN
                            sys_resource ON sys_rose_resource.rsid = sys_resource.rs_id " + "where sys_rose_resource.rid=" + rid;
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 删除一个角色的资源
        /// </summary>
        /// <param name="rid"></param>
        /// <returns></returns>
        public bool delRoseAllResource(int rid)
        {
            string strSql = @"delete from sys_rose_resource where rid="+rid;
            DbHelperSQL.ExecuteSql(strSql);
            return true;
        }

        /// <summary>
        /// 添加角色资源
        /// </summary>
        /// <param name="rid"></param>
        /// <param name="rsid"></param>
        /// <returns></returns>
        public bool AddRoseResouce(int rid , int[] rsid)
        {
            StringBuilder strSql = new StringBuilder();
            for (int i = 0; i < rsid.Length; i++)
                strSql.Append("insert into sys_rose_resource(rid,rsid) values(" + rid + "," + rsid[i] + ")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
            return true;
        }
    }
}
