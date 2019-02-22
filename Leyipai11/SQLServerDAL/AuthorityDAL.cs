namespace Leyp.SQLServerDAL
{
    using Leyp.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;

    [DataObject]
    public class AuthorityDAL
    {
        public List<Authority> getAllAuthority()
        {
            List<Authority> list = new List<Authority>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_Authority_getALL", null);
            while (reader.Read())
            {
                Authority item = new Authority {
                    AuthorityID = reader.GetInt32(reader.GetOrdinal("AuthorityID")),
                    TypeID = reader.GetInt32(reader.GetOrdinal("TypeID")),
                    AuthorityName = reader.GetString(reader.GetOrdinal("AuthorityName")),
                    ModuleUrl = reader.GetString(reader.GetOrdinal("ModuleUrl")),
                    WebUrl = reader.GetString(reader.GetOrdinal("WebUrl")),
                    Description = reader.GetString(reader.GetOrdinal("Description"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<Authority> getAuthorityByTypeID(int TypeID)
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@TypeID", SqlDbType.Int) };
            parm[0].Value = TypeID;
            List<Authority> list = new List<Authority>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_Authority_getAuthorityByTypeID", parm);
            while (reader.Read())
            {
                Authority item = new Authority {
                    AuthorityID = reader.GetInt32(reader.GetOrdinal("AuthorityID")),
                    TypeID = reader.GetInt32(reader.GetOrdinal("TypeID")),
                    AuthorityName = reader.GetString(reader.GetOrdinal("AuthorityName")),
                    ModuleUrl = reader.GetString(reader.GetOrdinal("ModuleUrl")),
                    WebUrl = reader.GetString(reader.GetOrdinal("WebUrl")),
                    Description = reader.GetString(reader.GetOrdinal("Description"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public Authority getByID(int AuthorityID)
        {
            Authority item = new Authority();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@AuthorityID", SqlDbType.Int, 4) };
            parm[0].Value = AuthorityID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_Authority_getByID", parm);
            while (reader.Read())
            {
                item.AuthorityID = reader.GetInt32(reader.GetOrdinal("AuthorityID"));
                item.TypeID = reader.GetInt32(reader.GetOrdinal("TypeID"));
                item.AuthorityName = reader.GetString(reader.GetOrdinal("AuthorityName"));
                item.ModuleUrl = reader.GetString(reader.GetOrdinal("ModuleUrl"));
                item.WebUrl = reader.GetString(reader.GetOrdinal("WebUrl"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
            }
            reader.Close();
            return item;
        }
    }
}

