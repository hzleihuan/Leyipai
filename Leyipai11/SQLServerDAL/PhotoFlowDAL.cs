namespace Leyp.SQLServerDAL
{
    using Leyp.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class PhotoFlowDAL
    {
        public bool AuditingOrder(int FlowID, string Reply, string UserName)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@FlowID", SqlDbType.Int), new SqlParameter("@Reply", SqlDbType.NVarChar), new SqlParameter("@UserName", SqlDbType.NVarChar) };
            parm[0].Value = FlowID;
            parm[1].Value = Reply;
            parm[2].Value = UserName;
            SQLHelper.RunProcedure("p_PhotoFlow__AuditingOrder", parm, out rowsAffect);
            return (0 < rowsAffect);
        }

        public bool deleteEitity(int FlowID, string UserName)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@FlowID", SqlDbType.Int), new SqlParameter("@UserName", SqlDbType.NVarChar) };
            parm[0].Value = FlowID;
            parm[1].Value = UserName;
            SQLHelper.RunProcedure("p_PhotoFlow_deleteEitity", parm, out rowsAffect);
            return (0 < rowsAffect);
        }

        public PhotoFlow getByID(int FlowID)
        {
            PhotoFlow item = new PhotoFlow();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@FlowID", SqlDbType.Int) };
            parm[0].Value = FlowID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_PhotoFlow_getByID", parm);
            while (reader.Read())
            {
                item.Content = reader.GetString(reader.GetOrdinal("Content"));
                item.CreateDate = reader.GetString(reader.GetOrdinal("CreateDate"));
                item.FlowID = reader.GetInt32(reader.GetOrdinal("FlowID"));
                item.FlowTitle = reader.GetString(reader.GetOrdinal("FlowTitle"));
                item.Reply = reader.GetString(reader.GetOrdinal("Reply"));
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                item.AuditingUser = reader.GetString(reader.GetOrdinal("AuditingUser"));
            }
            reader.Close();
            return item;
        }

        public List<PhotoFlow> getSearchList()
        {
            List<PhotoFlow> list = new List<PhotoFlow>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_PhotoFlow_getSearchList", null);
            while (reader.Read())
            {
                PhotoFlow item = new PhotoFlow {
                    Content = reader.GetString(reader.GetOrdinal("Content")),
                    CreateDate = reader.GetString(reader.GetOrdinal("CreateDate")),
                    FlowID = reader.GetInt32(reader.GetOrdinal("FlowID")),
                    FlowTitle = reader.GetString(reader.GetOrdinal("FlowTitle")),
                    Reply = reader.GetString(reader.GetOrdinal("Reply")),
                    State = reader.GetInt32(reader.GetOrdinal("State")),
                    UserName = reader.GetString(reader.GetOrdinal("UserName")),
                    AuditingUser = reader.GetString(reader.GetOrdinal("AuditingUser"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public bool insertNewEntity(PhotoFlow s)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@FlowTitle", SqlDbType.NVarChar), new SqlParameter("@CreateDate", SqlDbType.NVarChar), new SqlParameter("@UserName", SqlDbType.NVarChar), new SqlParameter("@Content", SqlDbType.NVarChar), new SqlParameter("@State", SqlDbType.Int) };
            parm[0].Value = s.FlowTitle;
            parm[1].Value = s.CreateDate;
            parm[2].Value = s.UserName;
            parm[3].Value = s.Content;
            parm[4].Value = s.State;
            SQLHelper.RunProcedure("p_PhotoFlow_insertNewEntity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }
    }
}

