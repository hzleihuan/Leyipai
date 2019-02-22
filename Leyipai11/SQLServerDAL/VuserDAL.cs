namespace Leyp.SQLServerDAL
{
    using Leyp.Model.View;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class VuserDAL
    {
        public List<Vuser> getAllVuser()
        {
            List<Vuser> list = new List<Vuser>();
            SqlDataReader reader = SQLHelper.RunProcedure("pv_vUser_getAll", null);
            while (reader.Read())
            {
                Vuser item = new Vuser {
                    Dept = reader.GetString(reader.GetOrdinal("Dept")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    GroupID = reader.GetInt32(reader.GetOrdinal("GroupID")),
                    TypeID = reader.GetInt32(reader.GetOrdinal("TypeID")),
                    SubClassID = reader.GetInt32(reader.GetOrdinal("SubClassID")),
                    QQ = reader.GetString(reader.GetOrdinal("QQ")),
                    RealName = reader.GetString(reader.GetOrdinal("RealName")),
                    Password = reader.GetString(reader.GetOrdinal("Password")),
                    Sex = reader.GetString(reader.GetOrdinal("Sex")),
                    State = reader.GetString(reader.GetOrdinal("State")),
                    WangWang = reader.GetString(reader.GetOrdinal("WangWang")),
                    Tel = reader.GetString(reader.GetOrdinal("Tel")),
                    UserName = reader.GetString(reader.GetOrdinal("UserName")),
                    TypeName = reader.GetString(reader.GetOrdinal("TypeName")),
                    SubClassName = reader.GetString(reader.GetOrdinal("SubClassName")),
                    GroupName = reader.GetString(reader.GetOrdinal("GroupName"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<Vuser> getSearchByUserTypeID(int UserTypeID)
        {
            List<Vuser> list = new List<Vuser>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@UserTypeID", SqlDbType.Int, 4) };
            parm[0].Value = UserTypeID;
            SqlDataReader reader = SQLHelper.RunProcedure("pv_vUser_SearchByUserType", parm);
            while (reader.Read())
            {
                Vuser item = new Vuser {
                    Dept = reader.GetString(reader.GetOrdinal("Dept")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    GroupID = reader.GetInt32(reader.GetOrdinal("GroupID")),
                    TypeID = reader.GetInt32(reader.GetOrdinal("TypeID")),
                    SubClassID = reader.GetInt32(reader.GetOrdinal("SubClassID")),
                    QQ = reader.GetString(reader.GetOrdinal("QQ")),
                    RealName = reader.GetString(reader.GetOrdinal("RealName")),
                    Password = reader.GetString(reader.GetOrdinal("Password")),
                    Sex = reader.GetString(reader.GetOrdinal("Sex")),
                    State = reader.GetString(reader.GetOrdinal("State")),
                    WangWang = reader.GetString(reader.GetOrdinal("WangWang")),
                    Tel = reader.GetString(reader.GetOrdinal("Tel")),
                    UserName = reader.GetString(reader.GetOrdinal("UserName")),
                    TypeName = reader.GetString(reader.GetOrdinal("TypeName")),
                    SubClassName = reader.GetString(reader.GetOrdinal("SubClassName"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<Vuser> getSearchUser(string key, int UserTypeID, int SubClassID)
        {
            List<Vuser> list = new List<Vuser>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@Key", SqlDbType.NVarChar), new SqlParameter("@UserTypeID", SqlDbType.Int), new SqlParameter("@SubClassID", SqlDbType.Int) };
            parm[0].Value = key;
            parm[1].Value = UserTypeID;
            parm[2].Value = SubClassID;
            SqlDataReader reader = SQLHelper.RunProcedure("pv_vUser_SearchList", parm);
            while (reader.Read())
            {
                Vuser item = new Vuser {
                    Dept = reader.GetString(reader.GetOrdinal("Dept")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    GroupID = reader.GetInt32(reader.GetOrdinal("GroupID")),
                    TypeID = reader.GetInt32(reader.GetOrdinal("TypeID")),
                    SubClassID = reader.GetInt32(reader.GetOrdinal("SubClassID")),
                    QQ = reader.GetString(reader.GetOrdinal("QQ")),
                    RealName = reader.GetString(reader.GetOrdinal("RealName")),
                    Password = reader.GetString(reader.GetOrdinal("Password")),
                    Sex = reader.GetString(reader.GetOrdinal("Sex")),
                    State = reader.GetString(reader.GetOrdinal("State")),
                    WangWang = reader.GetString(reader.GetOrdinal("WangWang")),
                    Tel = reader.GetString(reader.GetOrdinal("Tel")),
                    UserName = reader.GetString(reader.GetOrdinal("UserName")),
                    TypeName = reader.GetString(reader.GetOrdinal("TypeName")),
                    SubClassName = reader.GetString(reader.GetOrdinal("SubClassName"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public Vuser getUserViewByID(string UserName)
        {
            Vuser item = new Vuser();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@UserName", SqlDbType.NVarChar) };
            parm[0].Value = UserName;
            SqlDataReader reader = SQLHelper.RunProcedure("pv_vUser_getByUserName", parm);
            while (reader.Read())
            {
                item.Dept = reader.GetString(reader.GetOrdinal("Dept"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.Email = reader.GetString(reader.GetOrdinal("Email"));
                item.GroupID = reader.GetInt32(reader.GetOrdinal("GroupID"));
                item.TypeID = reader.GetInt32(reader.GetOrdinal("TypeID"));
                item.SubClassID = reader.GetInt32(reader.GetOrdinal("SubClassID"));
                item.QQ = reader.GetString(reader.GetOrdinal("QQ"));
                item.RealName = reader.GetString(reader.GetOrdinal("RealName"));
                item.Password = reader.GetString(reader.GetOrdinal("Password"));
                item.Sex = reader.GetString(reader.GetOrdinal("Sex"));
                item.State = reader.GetString(reader.GetOrdinal("State"));
                item.WangWang = reader.GetString(reader.GetOrdinal("WangWang"));
                item.Tel = reader.GetString(reader.GetOrdinal("Tel"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                item.TypeName = reader.GetString(reader.GetOrdinal("TypeName"));
                item.SubClassName = reader.GetString(reader.GetOrdinal("SubClassName"));
                item.GroupName = reader.GetString(reader.GetOrdinal("GroupName"));
                item.Address = reader.GetString(reader.GetOrdinal("Address"));
                item.BankAccount = reader.GetString(reader.GetOrdinal("BankAccount"));
                item.Bankname = reader.GetString(reader.GetOrdinal("Bankname"));
                item.Character = reader.GetString(reader.GetOrdinal("Character"));
                item.CompanyInfo = reader.GetString(reader.GetOrdinal("CompanyInfo"));
                item.CompanyName = reader.GetString(reader.GetOrdinal("CompanyName"));
                item.LatelyLogin = reader.GetString(reader.GetOrdinal("LatelyLogin"));
            }
            return item;
        }
    }
}

