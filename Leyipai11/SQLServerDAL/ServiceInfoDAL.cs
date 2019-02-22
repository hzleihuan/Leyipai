namespace Leyp.SQLServerDAL
{
    using Leyp.Model;
    using Leyp.Model.View;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class ServiceInfoDAL
    {
        public bool addReplyInfo(int ID, string Reply)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int), new SqlParameter("@Reply", SqlDbType.NVarChar) };
            parm[0].Value = ID;
            parm[1].Value = Reply;
            SQLHelper.RunProcedure("p_ServiceInfo_addReplyInfo", parm, out rowsAffect);
            return (0 < rowsAffect);
        }

        public bool deleteEitity(int ID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int) };
            parm[0].Value = ID;
            SQLHelper.RunProcedure("p_ServiceInfo_deleteEitity", parm, out rowsAffect);
            return (0 < rowsAffect);
        }

        public List<VServiceInfo> getAll()
        {
            List<VServiceInfo> list = new List<VServiceInfo>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_ServiceInfo_getAll", null);
            while (reader.Read())
            {
                VServiceInfo item = new VServiceInfo {
                    TypeID = reader.GetInt32(reader.GetOrdinal("TypeID")),
                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                    AuditingUser = reader.GetString(reader.GetOrdinal("AuditingUser")),
                    ServiceTitle = reader.GetString(reader.GetOrdinal("ServiceTitle")),
                    CreateDate = reader.GetString(reader.GetOrdinal("CreateDate")),
                    ServiceName = reader.GetString(reader.GetOrdinal("ServiceName")),
                    UserName = reader.GetString(reader.GetOrdinal("UserName")),
                    RealName = reader.GetString(reader.GetOrdinal("RealName")),
                    State = reader.GetInt32(reader.GetOrdinal("State"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public VServiceInfo getByID(int ID)
        {
            bool result = false;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int, 4) };
            parm[0].Value = ID;
            VServiceInfo item = new VServiceInfo();
            SqlDataReader reader = SQLHelper.RunProcedure("p_ServiceInfo_getByID", parm);
            if (reader.Read())
            {
                item.TypeID = reader.GetInt32(reader.GetOrdinal("TypeID"));
                item.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                item.AuditingUser = reader.GetString(reader.GetOrdinal("AuditingUser"));
                item.ServiceTitle = reader.GetString(reader.GetOrdinal("ServiceTitle"));
                item.CreateDate = reader.GetString(reader.GetOrdinal("CreateDate"));
                item.ServiceName = reader.GetString(reader.GetOrdinal("ServiceName"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                item.RealName = reader.GetString(reader.GetOrdinal("RealName"));
                item.Content = reader.GetString(reader.GetOrdinal("Content"));
                item.ReplyInfo = reader.GetString(reader.GetOrdinal("ReplyInfo"));
                result = true;
            }
            reader.Close();
            return (result ? item : null);
        }

        public List<VServiceInfo> getMyAuditingUserTopic(string UserName)
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@UserName", SqlDbType.NVarChar) };
            parm[0].Value = UserName;
            List<VServiceInfo> list = new List<VServiceInfo>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_ServiceInfo_getMyAuditingUserTopic", parm);
            while (reader.Read())
            {
                VServiceInfo item = new VServiceInfo {
                    TypeID = reader.GetInt32(reader.GetOrdinal("TypeID")),
                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                    AuditingUser = reader.GetString(reader.GetOrdinal("AuditingUser")),
                    ServiceTitle = reader.GetString(reader.GetOrdinal("ServiceTitle")),
                    CreateDate = reader.GetString(reader.GetOrdinal("CreateDate")),
                    ServiceName = reader.GetString(reader.GetOrdinal("ServiceName")),
                    UserName = reader.GetString(reader.GetOrdinal("UserName")),
                    RealName = reader.GetString(reader.GetOrdinal("RealName")),
                    State = reader.GetInt32(reader.GetOrdinal("State"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<VServiceInfo> getMyTopic(string UserName)
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@UserName", SqlDbType.NVarChar) };
            parm[0].Value = UserName;
            List<VServiceInfo> list = new List<VServiceInfo>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_ServiceInfo_getMyTopic", parm);
            while (reader.Read())
            {
                VServiceInfo item = new VServiceInfo {
                    TypeID = reader.GetInt32(reader.GetOrdinal("TypeID")),
                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                    AuditingUser = reader.GetString(reader.GetOrdinal("AuditingUser")),
                    ServiceTitle = reader.GetString(reader.GetOrdinal("ServiceTitle")),
                    CreateDate = reader.GetString(reader.GetOrdinal("CreateDate")),
                    ServiceName = reader.GetString(reader.GetOrdinal("ServiceName")),
                    UserName = reader.GetString(reader.GetOrdinal("UserName")),
                    RealName = reader.GetString(reader.GetOrdinal("RealName")),
                    State = reader.GetInt32(reader.GetOrdinal("State"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<VServiceInfo> getSearchListByDate(string beginDate, string endDate, int sideState)
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@beginDate", SqlDbType.NVarChar), new SqlParameter("@endDate", SqlDbType.NVarChar), new SqlParameter("@sideState", SqlDbType.Int) };
            parm[0].Value = beginDate;
            parm[1].Value = endDate;
            parm[2].Value = sideState;
            List<VServiceInfo> list = new List<VServiceInfo>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_ServiceInfo_getSearchListByDate", parm);
            while (reader.Read())
            {
                VServiceInfo item = new VServiceInfo {
                    TypeID = reader.GetInt32(reader.GetOrdinal("TypeID")),
                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                    AuditingUser = reader.GetString(reader.GetOrdinal("AuditingUser")),
                    ServiceTitle = reader.GetString(reader.GetOrdinal("ServiceTitle")),
                    CreateDate = reader.GetString(reader.GetOrdinal("CreateDate")),
                    ServiceName = reader.GetString(reader.GetOrdinal("ServiceName")),
                    UserName = reader.GetString(reader.GetOrdinal("UserName")),
                    RealName = reader.GetString(reader.GetOrdinal("RealName")),
                    State = reader.GetInt32(reader.GetOrdinal("State"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<VServiceInfo> getSearchListByType(int TypeID)
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@TypeID", SqlDbType.Int, 4) };
            parm[0].Value = TypeID;
            List<VServiceInfo> list = new List<VServiceInfo>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_ServiceInfo_getSearchListByTypeID", parm);
            while (reader.Read())
            {
                VServiceInfo item = new VServiceInfo {
                    TypeID = reader.GetInt32(reader.GetOrdinal("TypeID")),
                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                    AuditingUser = reader.GetString(reader.GetOrdinal("AuditingUser")),
                    ServiceTitle = reader.GetString(reader.GetOrdinal("ServiceTitle")),
                    CreateDate = reader.GetString(reader.GetOrdinal("CreateDate")),
                    ServiceName = reader.GetString(reader.GetOrdinal("ServiceName")),
                    UserName = reader.GetString(reader.GetOrdinal("UserName")),
                    RealName = reader.GetString(reader.GetOrdinal("RealName")),
                    State = reader.GetInt32(reader.GetOrdinal("State"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public bool insertNewEntity(ServiceInfo s)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@TypeID", SqlDbType.Int), new SqlParameter("@ServiceTitle", SqlDbType.NVarChar), new SqlParameter("@CreateDate", SqlDbType.NVarChar), new SqlParameter("@SalesOrderID", SqlDbType.NVarChar), new SqlParameter("@Content", SqlDbType.NVarChar), new SqlParameter("@UserName", SqlDbType.NVarChar) };
            parm[0].Value = s.TypeID;
            parm[1].Value = s.ServiceTitle;
            parm[2].Value = s.CreateDate;
            parm[3].Value = s.SalesOrderID;
            parm[4].Value = s.Content;
            parm[5].Value = s.UserName;
            SQLHelper.RunProcedure("p_ServiceInfo_insertNewEntity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public bool updateAotoCancel(string DateNowStr)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@DateNowStr", SqlDbType.NVarChar) };
            parm[0].Value = DateNowStr;
            SQLHelper.RunProcedure("p_ServiceInfo_updateAotoCancel", parm, out rowsAffect);
            return (0 < rowsAffect);
        }

        public bool updateCancel(int ID, string UserName)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int), new SqlParameter("@UserName", SqlDbType.NVarChar) };
            parm[0].Value = ID;
            parm[1].Value = UserName;
            SQLHelper.RunProcedure("p_ServiceInfo_updateCancel", parm, out rowsAffect);
            return (0 < rowsAffect);
        }

        public bool updateSolve(int ID, string UserName)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int), new SqlParameter("@UserName", SqlDbType.NVarChar) };
            parm[0].Value = ID;
            parm[1].Value = UserName;
            SQLHelper.RunProcedure("p_ServiceInfo_updateSolve", parm, out rowsAffect);
            return (0 < rowsAffect);
        }

        public bool updateUserforAuditing(int ID, string UserName)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int), new SqlParameter("@UserName", SqlDbType.NVarChar) };
            parm[0].Value = ID;
            parm[1].Value = UserName;
            SQLHelper.RunProcedure("p_ServiceInfo_updateUserforAuditing", parm, out rowsAffect);
            return (0 < rowsAffect);
        }
    }
}

