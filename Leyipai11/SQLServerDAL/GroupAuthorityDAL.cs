namespace Leyp.SQLServerDAL
{
    using Leyp.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;

    [DataObject]
    public class GroupAuthorityDAL
    {
        public List<GroupAuthority> getALLGroupAuthorityByGroupID(int GroupID)
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@GroupID", SqlDbType.Int, 4) };
            parm[0].Value = GroupID;
            List<GroupAuthority> list = new List<GroupAuthority>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_GroupAuthority_getAll_ByGroupID", parm);
            while (reader.Read())
            {
                GroupAuthority item = new GroupAuthority {
                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                    AuthorityID = reader.GetInt32(reader.GetOrdinal("AuthorityID")),
                    GroupID = reader.GetInt32(reader.GetOrdinal("GroupID"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public void insertNode(GroupAuthority g)
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@GroupID", SqlDbType.Int, 4), new SqlParameter("@AuthorityID", SqlDbType.Int, 4) };
            parm[0].Value = g.GroupID;
            parm[1].Value = g.AuthorityID;
            int i = SQLHelper.ExecuteNonQuery(SQLHelper.strCon, CommandType.StoredProcedure, "p_GroupAuthority_insertNewNode", parm);
        }

        public bool validataAuthorityAndGroupID(string ModuleName, int GroupID)
        {
            bool result = false;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ModuleUrl", SqlDbType.NVarChar), new SqlParameter("@GroupID", SqlDbType.Int) };
            parm[0].Value = ModuleName;
            parm[1].Value = GroupID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_GroupAuthority_validataModule", parm);
            while (reader.Read())
            {
                result = true;
            }
            return result;
        }
    }
}

