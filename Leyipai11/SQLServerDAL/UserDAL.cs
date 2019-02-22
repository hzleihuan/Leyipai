namespace Leyp.SQLServerDAL
{
    using Leyp.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class UserDAL
    {
        public bool deleteUser(string UserName)
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@UserName", SqlDbType.NVarChar) };
            parm[0].Value = UserName;
            int i = SQLHelper.ExecuteNonQuery(SQLHelper.strCon, CommandType.StoredProcedure, "p_user_deleateUser", parm);
            return (1 == i);
        }

        public List<User> getAllUser()
        {
            return null;
        }

        public User getByUserName(string UserName)
        {
            User item = new User();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@UserName", SqlDbType.NVarChar) };
            parm[0].Value = UserName;
            SqlDataReader reader = SQLHelper.RunProcedure("p_user_getByUserName", parm);
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
            }
            return item;
        }

        public List<User> getSearchByRealName(string RealName)
        {
            return null;
        }

        public List<User> getUserListByGroup(int GroupID)
        {
            return null;
        }

        public bool insertNewUser(User u)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { 
                new SqlParameter("@UserName", SqlDbType.NVarChar), new SqlParameter("@Password", SqlDbType.NVarChar), new SqlParameter("@TypeID", SqlDbType.Int, 4), new SqlParameter("@RealName", SqlDbType.NVarChar), new SqlParameter("@Sex", SqlDbType.NVarChar), new SqlParameter("@GroupID", SqlDbType.Int), new SqlParameter("@Tel", SqlDbType.NVarChar), new SqlParameter("@Email", SqlDbType.NVarChar), new SqlParameter("@QQ", SqlDbType.NVarChar), new SqlParameter("@WangWang", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@State", SqlDbType.NVarChar), new SqlParameter("@Dept", SqlDbType.NVarChar), new SqlParameter("@SubClassID", SqlDbType.Int), new SqlParameter("@Character", SqlDbType.NVarChar), new SqlParameter("@Address", SqlDbType.NVarChar), 
                new SqlParameter("@CompanyName", SqlDbType.NVarChar), new SqlParameter("@CompanyInfo", SqlDbType.NVarChar), new SqlParameter("@Bankname", SqlDbType.NVarChar), new SqlParameter("@BankAccount", SqlDbType.NVarChar), new SqlParameter("@LatelyLogin", SqlDbType.NVarChar)
             };
            parm[0].Value = u.UserName;
            parm[1].Value = u.Password;
            parm[2].Value = u.TypeID;
            parm[3].Value = u.RealName;
            parm[4].Value = u.Sex;
            parm[5].Value = u.GroupID;
            parm[6].Value = u.Tel;
            parm[7].Value = u.Email;
            parm[8].Value = u.QQ;
            parm[9].Value = u.WangWang;
            parm[10].Value = u.Description;
            parm[11].Value = u.State;
            parm[12].Value = u.Dept;
            parm[13].Value = u.SubClassID;
            parm[14].Value = u.Character;
            parm[15].Value = u.Address;
            parm[0x10].Value = u.CompanyName;
            parm[0x11].Value = u.CompanyInfo;
            parm[0x12].Value = u.Bankname;
            parm[0x13].Value = u.BankAccount;
            SQLHelper.RunProcedure("p_user_insertNewUser", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public bool isExistsUserName(string UserName)
        {
            bool result = false;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@UserName", SqlDbType.NVarChar) };
            parm[0].Value = UserName;
            SqlDataReader reader = SQLHelper.RunProcedure("p_user_isExistsUserName", parm);
            while (reader.Read())
            {
                result = true;
            }
            reader.Close();
            return result;
        }

        public bool isLoginValidate(string UserName, string PassWord)
        {
            if (this.isExistsUserName(UserName))
            {
                User u = this.getByUserName(UserName);
                if (PassWord.Equals(u.Password))
                {
                    if (u.State.Equals("N"))
                    {
                        return false;
                    }
                    return true;
                }
                return false;
            }
            return false;
        }

        public bool lockUser(string UserName)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@UserName", SqlDbType.NVarChar) };
            parm[0].Value = UserName;
            int i = SQLHelper.RunProcedure("p_user_lockUser", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public bool resetPassWord(string oldPwd, string newPwd, string UserName)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@oldPwd", SqlDbType.NVarChar), new SqlParameter("@newPwd", SqlDbType.NVarChar), new SqlParameter("@UserName", SqlDbType.NVarChar) };
            parm[0].Value = oldPwd;
            parm[1].Value = newPwd;
            parm[2].Value = UserName;
            SQLHelper.RunProcedure("p_user_resetPassword", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public bool updateUser(User u)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { 
                new SqlParameter("@UserName", SqlDbType.NVarChar), new SqlParameter("@TypeID", SqlDbType.Int, 4), new SqlParameter("@RealName", SqlDbType.NVarChar), new SqlParameter("@Sex", SqlDbType.NVarChar), new SqlParameter("@GroupID", SqlDbType.Int), new SqlParameter("@Tel", SqlDbType.NVarChar), new SqlParameter("@Email", SqlDbType.NVarChar), new SqlParameter("@QQ", SqlDbType.NVarChar), new SqlParameter("@WangWang", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@State", SqlDbType.NVarChar), new SqlParameter("@SubClassID", SqlDbType.Int), new SqlParameter("@Character", SqlDbType.NVarChar), new SqlParameter("@Address", SqlDbType.NVarChar), new SqlParameter("@CompanyName", SqlDbType.NVarChar), new SqlParameter("@CompanyInfo", SqlDbType.NVarChar), 
                new SqlParameter("@Bankname", SqlDbType.NVarChar), new SqlParameter("@BankAccount", SqlDbType.NVarChar), new SqlParameter("@LatelyLogin", SqlDbType.NVarChar)
             };
            parm[0].Value = u.UserName;
            parm[1].Value = u.TypeID;
            parm[2].Value = u.RealName;
            parm[3].Value = u.Sex;
            parm[4].Value = u.GroupID;
            parm[5].Value = u.Tel;
            parm[6].Value = u.Email;
            parm[7].Value = u.QQ;
            parm[8].Value = u.WangWang;
            parm[9].Value = u.Description;
            parm[10].Value = u.State;
            parm[11].Value = u.SubClassID;
            parm[12].Value = u.Character;
            parm[13].Value = u.Address;
            parm[14].Value = u.CompanyName;
            parm[15].Value = u.CompanyInfo;
            parm[0x10].Value = u.Bankname;
            parm[0x11].Value = u.BankAccount;
            int i = SQLHelper.RunProcedure("p_user_UpdateUser", parm, out rowsAffect);
            return (1 == i);
        }
    }
}

