using System;
using System.Collections.Generic;
using System.Text;
using Leyipai.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace Leyipai.DAL
{
    public class SysUserDAL
    {

        public SysUserDAL() { }

        #region  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string username)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sys_user");
            strSql.Append(" where username=@username ");
            SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.VarChar,50)};
            parameters[0].Value = username;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Leyipai.Model.sys_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sys_user(");
            strSql.Append("uid,rid,username,password,realname,department,qq,email,tel,state)");
            strSql.Append(" values (");
            strSql.Append("@uid,@rid,@username,@password,@realname,@department,@qq,@email,@tel,@state)");
            SqlParameter[] parameters = {
					new SqlParameter("@uid", SqlDbType.Int,4),
					new SqlParameter("@rid", SqlDbType.Int,4),
					new SqlParameter("@username", SqlDbType.VarChar,128),
					new SqlParameter("@password", SqlDbType.VarChar,128),
					new SqlParameter("@realname", SqlDbType.VarChar,128),
					new SqlParameter("@department", SqlDbType.VarChar,128),
					new SqlParameter("@qq", SqlDbType.VarChar,128),
					new SqlParameter("@email", SqlDbType.VarChar,128),
					new SqlParameter("@tel", SqlDbType.VarChar,128),
					new SqlParameter("@state", SqlDbType.TinyInt,1)};
            parameters[0].Value = model.uid;
            parameters[1].Value = model.rid;
            parameters[2].Value = model.username;
            parameters[3].Value = model.password;
            parameters[4].Value = model.realname;
            parameters[5].Value = model.department;
            parameters[6].Value = model.qq;
            parameters[7].Value = model.email;
            parameters[8].Value = model.tel;
            parameters[9].Value = model.state;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Leyipai.Model.sys_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sys_user set ");
            strSql.Append("uid=@uid,");
            strSql.Append("rid=@rid,");
            strSql.Append("password=@password,");
            strSql.Append("realname=@realname,");
            strSql.Append("department=@department,");
            strSql.Append("qq=@qq,");
            strSql.Append("email=@email,");
            strSql.Append("tel=@tel,");
            strSql.Append("state=@state");
            strSql.Append(" where username=@username ");
            SqlParameter[] parameters = {
					new SqlParameter("@uid", SqlDbType.Int,4),
					new SqlParameter("@rid", SqlDbType.Int,4),
					new SqlParameter("@username", SqlDbType.VarChar,128),
					new SqlParameter("@password", SqlDbType.VarChar,128),
					new SqlParameter("@realname", SqlDbType.VarChar,128),
					new SqlParameter("@department", SqlDbType.VarChar,128),
					new SqlParameter("@qq", SqlDbType.VarChar,128),
					new SqlParameter("@email", SqlDbType.VarChar,128),
					new SqlParameter("@tel", SqlDbType.VarChar,128),
					new SqlParameter("@state", SqlDbType.TinyInt,1)};
            parameters[0].Value = model.uid;
            parameters[1].Value = model.rid;
            parameters[2].Value = model.username;
            parameters[3].Value = model.password;
            parameters[4].Value = model.realname;
            parameters[5].Value = model.department;
            parameters[6].Value = model.qq;
            parameters[7].Value = model.email;
            parameters[8].Value = model.tel;
            parameters[9].Value = model.state;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string username)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sys_user ");
            strSql.Append(" where username=@username ");
            SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.VarChar,50)};
            parameters[0].Value = username;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Leyipai.Model.sys_user GetModel(string username)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 uid,rid,username,password,realname,department,qq,email,tel,state from sys_user ");
            strSql.Append(" where username=@username ");
            SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.VarChar,50)};
            parameters[0].Value = username;

            Leyipai.Model.sys_user model = new Leyipai.Model.sys_user();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["uid"].ToString() != "")
                {
                    model.uid = int.Parse(ds.Tables[0].Rows[0]["uid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["rid"].ToString() != "")
                {
                    model.rid = int.Parse(ds.Tables[0].Rows[0]["rid"].ToString());
                }
                model.username = ds.Tables[0].Rows[0]["username"].ToString();
                model.password = ds.Tables[0].Rows[0]["password"].ToString();
                model.realname = ds.Tables[0].Rows[0]["realname"].ToString();
                model.department = ds.Tables[0].Rows[0]["department"].ToString();
                model.qq = ds.Tables[0].Rows[0]["qq"].ToString();
                model.email = ds.Tables[0].Rows[0]["email"].ToString();
                model.tel = ds.Tables[0].Rows[0]["tel"].ToString();
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
            strSql.Append("select uid,rid,username,password,realname,department,qq,email,tel,state ");
            strSql.Append(" FROM sys_user ");
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
            strSql.Append(" uid,rid,username,password,realname,department,qq,email,tel,state ");
            strSql.Append(" FROM sys_user ");
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
            string strSql = @"select * from (   select TOP " + pagesize + " * FROM ( SELECT TOP " + selectCount + "  * from sys_user_view where " + strWhere + " ORDER BY rid ASC ) as aSysTable   ORDER BY rid DESC ) as bSysTable   ORDER BY rid ASC";
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
            strSql.Append(" FROM sys_user ");
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
