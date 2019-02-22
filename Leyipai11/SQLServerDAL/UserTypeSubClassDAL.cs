namespace Leyp.SQLServerDAL
{
    using Leyp.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class UserTypeSubClassDAL
    {
        public bool deleteNode(int SubClassID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SubClassID", SqlDbType.Int) };
            parm[0].Value = SubClassID;
            SQLHelper.RunProcedure("p_UserTypeSubClass_deleteNodeByID", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public List<UserTypeSubClass> getAllUserTypeSubClass()
        {
            List<UserTypeSubClass> list = new List<UserTypeSubClass>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_UserTypeSubClass_getAllUserTypeSubClass", null);
            while (reader.Read())
            {
                UserTypeSubClass item = new UserTypeSubClass {
                    UserTypeID = reader.GetInt32(reader.GetOrdinal("UserTypeID")),
                    SubClassID = reader.GetInt32(reader.GetOrdinal("SubClassID")),
                    SubClassName = reader.GetString(reader.GetOrdinal("SubClassName")),
                    State = reader.GetString(reader.GetOrdinal("State"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public UserTypeSubClass getByID(int SubClassID)
        {
            UserTypeSubClass item = new UserTypeSubClass();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SubClassID", SqlDbType.Int, 4) };
            parm[0].Value = SubClassID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_UserTypeSubClass_getByID", parm);
            while (reader.Read())
            {
                item.SubClassID = reader.GetInt32(reader.GetOrdinal("SubClassID"));
                item.SubClassName = reader.GetString(reader.GetOrdinal("SubClassName"));
                item.State = reader.GetString(reader.GetOrdinal("State"));
                item.UserTypeID = reader.GetInt32(reader.GetOrdinal("UserTypeID"));
            }
            return item;
        }

        public List<UserTypeSubClass> getSubClassByUserTypeID(int UserTypeID)
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@UserTypeID", SqlDbType.Int) };
            parm[0].Value = UserTypeID;
            List<UserTypeSubClass> list = new List<UserTypeSubClass>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_UserTypeSubClass_getByUserTypeID", parm);
            while (reader.Read())
            {
                UserTypeSubClass item = new UserTypeSubClass {
                    UserTypeID = reader.GetInt32(reader.GetOrdinal("UserTypeID")),
                    SubClassID = reader.GetInt32(reader.GetOrdinal("SubClassID")),
                    SubClassName = reader.GetString(reader.GetOrdinal("SubClassName")),
                    State = reader.GetString(reader.GetOrdinal("State"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public bool insertNewUserTypeSubClass(UserTypeSubClass u)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@UserTypeID", SqlDbType.Int), new SqlParameter("@SubClassName", SqlDbType.NVarChar), new SqlParameter("@State", SqlDbType.NVarChar) };
            parm[0].Value = u.UserTypeID;
            parm[1].Value = u.SubClassName;
            parm[2].Value = u.State;
            SQLHelper.RunProcedure("p_UserTypeSubClass_insertNewUserTypeSubClass", parm, out rowsAffect);
            List<Products> al = new List<Products>();
            al = new ProductsDAL().getAllProducts();
            int SubClassID = -1;
            SqlDataReader reader = SQLHelper.RunProcedure("p_UserTypeSubClass_getLastRecond", null);
            while (reader.Read())
            {
                SubClassID = reader.GetInt32(reader.GetOrdinal("SubClassID"));
            }
            for (int i = 0; i < al.Count; i++)
            {
                ProductsUserType p = new ProductsUserType();
                Products ps = al[i];
                p.Price = ps.Price;
                p.ProductsID = ps.ProductsID;
                p.SubClassID = SubClassID;
                new ProductsUserTypeDAL().insertNewRecord(p);
            }
            return (1 == rowsAffect);
        }

        public bool updateUserTypeSubClass(UserTypeSubClass u)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SubClassID", SqlDbType.Int), new SqlParameter("@SubClassName", SqlDbType.NVarChar), new SqlParameter("@State", SqlDbType.NVarChar) };
            parm[0].Value = u.SubClassID;
            parm[1].Value = u.SubClassName;
            parm[2].Value = u.State;
            SQLHelper.RunProcedure("p_UserTypeSubClass_updateUserTypeSubClass", parm, out rowsAffect);
            return (1 == rowsAffect);
        }
    }
}

