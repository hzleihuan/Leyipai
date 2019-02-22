namespace Leyp.SQLServerDAL
{
    using Leyp.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;

    [DataObject]
    public class GroupDAL
    {
        private GroupAuthorityDAL groupAuthorityDAL = null;

        public GroupDAL()
        {
            this.groupAuthorityDAL = new GroupAuthorityDAL();
        }

        public bool deleteNode(int GroupID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@GroupID", SqlDbType.Int, 4) };
            parm[0].Value = GroupID;
            SQLHelper.RunProcedure("p_Group_deleteNode", parm, out rowsAffect);
            return (0 < rowsAffect);
        }

        public List<Group> getAllGroup()
        {
            List<Group> list = new List<Group>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_Group_getALL", null);
            while (reader.Read())
            {
                Group item = new Group {
                    GroupID = reader.GetInt32(reader.GetOrdinal("GroupID")),
                    GroupName = reader.GetString(reader.GetOrdinal("GroupName")),
                    Description = reader.GetString(reader.GetOrdinal("Description"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public Group getByGroupID(int GroupID)
        {
            Group item = new Group();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@GroupID", SqlDbType.Int, 4) };
            parm[0].Value = GroupID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_Group_getByID", parm);
            while (reader.Read())
            {
                item.GroupID = reader.GetInt32(reader.GetOrdinal("GroupID"));
                item.GroupName = reader.GetString(reader.GetOrdinal("GroupName"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
            }
            return item;
        }

        public void insertGroupAuthority(int GroupID, int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                GroupAuthority g = new GroupAuthority {
                    GroupID = GroupID,
                    AuthorityID = a[i]
                };
                this.groupAuthorityDAL.insertNode(g);
            }
        }

        public bool insertNewGroup(Group g)
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@GroupName", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar) };
            parm[0].Value = g.GroupName;
            parm[1].Value = g.Description;
            return (SQLHelper.ExecuteNonQuery(SQLHelper.strCon, CommandType.StoredProcedure, "p_Group_insertNewGroup", parm) == 1);
        }

        public bool updateGroup(Group g, int[] a)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@GroupID", SqlDbType.Int, 4), new SqlParameter("@GroupName", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar) };
                parm[0].Value = g.GroupID;
                parm[1].Value = g.GroupName;
                parm[2].Value = g.Description;
                int i = SQLHelper.ExecuteNonQuery(SQLHelper.strCon, CommandType.StoredProcedure, "p_Group_update", parm);
                this.insertGroupAuthority(g.GroupID, a);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

