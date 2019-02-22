using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Leyipai.DBUtility;//请先添加引用

namespace Leyipai.DAL.c
{
   public class CustomerDAL
    {
       public CustomerDAL() { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "c_customer");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from c_customer");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from c_customer");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Leyipai.Model.c_customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into c_customer(");
            strSql.Append("username,password,types,c_name,c_code,tariffline,tel,mobile,email,link_men,address,account_info,prestige_info,remark,rank,state)");
            strSql.Append(" values (");
            strSql.Append("@username,@password,@types,@c_name,@c_code,@tariffline,@tel,@mobile,@email,@link_men,@address,@account_info,@prestige_info,@remark,@rank,@state)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.VarChar,50),
					new SqlParameter("@password", SqlDbType.VarChar,50),
					new SqlParameter("@types", SqlDbType.Int,4),
					new SqlParameter("@c_name", SqlDbType.VarChar,128),
					new SqlParameter("@c_code", SqlDbType.VarChar,128),
					new SqlParameter("@tariffline", SqlDbType.VarChar,128),
					new SqlParameter("@tel", SqlDbType.VarChar,128),
					new SqlParameter("@mobile", SqlDbType.VarChar,128),
					new SqlParameter("@email", SqlDbType.VarChar,128),
					new SqlParameter("@link_men", SqlDbType.VarChar,128),
					new SqlParameter("@address", SqlDbType.VarChar,128),
					new SqlParameter("@account_info", SqlDbType.VarChar,128),
					new SqlParameter("@prestige_info", SqlDbType.VarChar,1024),
					new SqlParameter("@remark", SqlDbType.VarChar,1024),
					new SqlParameter("@rank", SqlDbType.TinyInt,1),
					new SqlParameter("@state", SqlDbType.TinyInt,1)};
            parameters[0].Value = model.username;
            parameters[1].Value = model.password;
            parameters[2].Value = model.types;
            parameters[3].Value = model.c_name;
            parameters[4].Value = model.c_code;
            parameters[5].Value = model.tariffline;
            parameters[6].Value = model.tel;
            parameters[7].Value = model.mobile;
            parameters[8].Value = model.email;
            parameters[9].Value = model.link_men;
            parameters[10].Value = model.address;
            parameters[11].Value = model.account_info;
            parameters[12].Value = model.prestige_info;
            parameters[13].Value = model.remark;
            parameters[14].Value = model.rank;
            parameters[15].Value = model.state;

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
        public void Update(Leyipai.Model.c_customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update c_customer set ");
            strSql.Append("username=@username,");
            strSql.Append("password=@password,");
            strSql.Append("types=@types,");
            strSql.Append("c_name=@c_name,");
            strSql.Append("c_code=@c_code,");
            strSql.Append("tariffline=@tariffline,");
            strSql.Append("tel=@tel,");
            strSql.Append("mobile=@mobile,");
            strSql.Append("email=@email,");
            strSql.Append("link_men=@link_men,");
            strSql.Append("address=@address,");
            strSql.Append("account_info=@account_info,");
            strSql.Append("prestige_info=@prestige_info,");
            strSql.Append("remark=@remark,");
            strSql.Append("rank=@rank,");
            strSql.Append("state=@state");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@username", SqlDbType.VarChar,50),
					new SqlParameter("@password", SqlDbType.VarChar,50),
					new SqlParameter("@types", SqlDbType.Int,4),
					new SqlParameter("@c_name", SqlDbType.VarChar,128),
					new SqlParameter("@c_code", SqlDbType.VarChar,128),
					new SqlParameter("@tariffline", SqlDbType.VarChar,128),
					new SqlParameter("@tel", SqlDbType.VarChar,128),
					new SqlParameter("@mobile", SqlDbType.VarChar,128),
					new SqlParameter("@email", SqlDbType.VarChar,128),
					new SqlParameter("@link_men", SqlDbType.VarChar,128),
					new SqlParameter("@address", SqlDbType.VarChar,128),
					new SqlParameter("@account_info", SqlDbType.VarChar,128),
					new SqlParameter("@prestige_info", SqlDbType.VarChar,1024),
					new SqlParameter("@remark", SqlDbType.VarChar,1024),
					new SqlParameter("@rank", SqlDbType.TinyInt,1),
					new SqlParameter("@state", SqlDbType.TinyInt,1)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.username;
            parameters[2].Value = model.password;
            parameters[3].Value = model.types;
            parameters[4].Value = model.c_name;
            parameters[5].Value = model.c_code;
            parameters[6].Value = model.tariffline;
            parameters[7].Value = model.tel;
            parameters[8].Value = model.mobile;
            parameters[9].Value = model.email;
            parameters[10].Value = model.link_men;
            parameters[11].Value = model.address;
            parameters[12].Value = model.account_info;
            parameters[13].Value = model.prestige_info;
            parameters[14].Value = model.remark;
            parameters[15].Value = model.rank;
            parameters[16].Value = model.state;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from c_customer ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Leyipai.Model.c_customer GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,username,password,types,c_name,c_code,tariffline,tel,mobile,email,link_men,address,account_info,prestige_info,remark,rank,state from c_customer ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Leyipai.Model.c_customer model = new Leyipai.Model.c_customer();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.username = ds.Tables[0].Rows[0]["username"].ToString();
                model.password = ds.Tables[0].Rows[0]["password"].ToString();
                if (ds.Tables[0].Rows[0]["types"].ToString() != "")
                {
                    model.types = int.Parse(ds.Tables[0].Rows[0]["types"].ToString());
                }
                model.c_name = ds.Tables[0].Rows[0]["c_name"].ToString();
                model.c_code = ds.Tables[0].Rows[0]["c_code"].ToString();
                model.tariffline = ds.Tables[0].Rows[0]["tariffline"].ToString();
                model.tel = ds.Tables[0].Rows[0]["tel"].ToString();
                model.mobile = ds.Tables[0].Rows[0]["mobile"].ToString();
                model.email = ds.Tables[0].Rows[0]["email"].ToString();
                model.link_men = ds.Tables[0].Rows[0]["link_men"].ToString();
                model.address = ds.Tables[0].Rows[0]["address"].ToString();
                model.account_info = ds.Tables[0].Rows[0]["account_info"].ToString();
                model.prestige_info = ds.Tables[0].Rows[0]["prestige_info"].ToString();
                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                if (ds.Tables[0].Rows[0]["rank"].ToString() != "")
                {
                    model.rank = int.Parse(ds.Tables[0].Rows[0]["rank"].ToString());
                }
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
            strSql.Append("select id,username,password,types,c_name,c_code,tariffline,tel,mobile,email,link_men,address,account_info,prestige_info,remark,rank,state ");
            strSql.Append(" FROM c_customer ");
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
            strSql.Append(" id,username,password,types,c_name,c_code,tariffline,tel,mobile,email,link_men,address,account_info,prestige_info,remark,rank,state ");
            strSql.Append(" FROM c_customer ");
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
            parameters[0].Value = "c_customer";
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
