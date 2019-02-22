namespace Leyp.SQLServerDAL.Sales
{
    using Leyp.Model.Sales;
    using Leyp.SQLServerDAL;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;

    [DataObject]
    public class SalesRecordDAL
    {
        public bool deleteEitity(int ID, string UserName)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int), new SqlParameter("@UserName", SqlDbType.NVarChar) };
            parm[0].Value = ID;
            parm[1].Value = UserName;
            SQLHelper.RunProcedure("p_SalesRecord_deleteEitity", parm, out rowsAffect);
            return (0 < rowsAffect);
        }

        public List<VSalesRecord> getAll()
        {
            List<VSalesRecord> list = new List<VSalesRecord>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_SalesRecord_getAll", null);
            while (reader.Read())
            {
                VSalesRecord item = new VSalesRecord {
                    PlatformID = reader.GetInt32(reader.GetOrdinal("PlatformID")),
                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                    SalesOrderID = reader.GetString(reader.GetOrdinal("SalesOrderID")),
                    CustomerID = reader.GetString(reader.GetOrdinal("CustomerID")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    PlatformName = reader.GetString(reader.GetOrdinal("PlatformName")),
                    UserName = reader.GetString(reader.GetOrdinal("UserName")),
                    CreateDate = reader.GetString(reader.GetOrdinal("CreateDate"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public VSalesRecord getBySalesOrderID(string SalesOrderID)
        {
            bool result = false;
            VSalesRecord item = new VSalesRecord();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SalesOrderID", SqlDbType.NVarChar) };
            parm[0].Value = SalesOrderID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_SalesRecord_getBySalesOrderID", parm);
            if (reader.Read())
            {
                item.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                item.SalesOrderID = reader.GetString(reader.GetOrdinal("SalesOrderID"));
                item.PlatformID = reader.GetInt32(reader.GetOrdinal("PlatformID"));
                item.CustomerID = reader.GetString(reader.GetOrdinal("CustomerID"));
                item.PlatformName = reader.GetString(reader.GetOrdinal("PlatformName"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                item.CreateDate = reader.GetString(reader.GetOrdinal("CreateDate"));
                result = true;
            }
            reader.Close();
            return (result ? item : null);
        }

        public List<VSalesRecord> getListByCustomerID(int PlatformID, string CustomerID)
        {
            List<VSalesRecord> list = new List<VSalesRecord>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@PlatformID", SqlDbType.Int), new SqlParameter("@CustomerID", SqlDbType.NVarChar) };
            parm[0].Value = PlatformID;
            parm[1].Value = CustomerID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_SalesRecord_getListByCustomerID", parm);
            while (reader.Read())
            {
                VSalesRecord item = new VSalesRecord {
                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                    SalesOrderID = reader.GetString(reader.GetOrdinal("SalesOrderID")),
                    PlatformID = reader.GetInt32(reader.GetOrdinal("PlatformID")),
                    CustomerID = reader.GetString(reader.GetOrdinal("CustomerID")),
                    PlatformName = reader.GetString(reader.GetOrdinal("PlatformName")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    UserName = reader.GetString(reader.GetOrdinal("UserName")),
                    CreateDate = reader.GetString(reader.GetOrdinal("CreateDate"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<VSalesRecord> getListByPlatformID(int PlatformID)
        {
            List<VSalesRecord> list = new List<VSalesRecord>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@PlatformID", SqlDbType.Int) };
            parm[0].Value = PlatformID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_SalesRecord_getListByPlatformID", parm);
            while (reader.Read())
            {
                VSalesRecord item = new VSalesRecord {
                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                    SalesOrderID = reader.GetString(reader.GetOrdinal("SalesOrderID")),
                    PlatformID = reader.GetInt32(reader.GetOrdinal("PlatformID")),
                    CustomerID = reader.GetString(reader.GetOrdinal("CustomerID")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    PlatformName = reader.GetString(reader.GetOrdinal("PlatformName")),
                    UserName = reader.GetString(reader.GetOrdinal("UserName")),
                    CreateDate = reader.GetString(reader.GetOrdinal("CreateDate"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<VSalesRecord> getListByUserName(string UserName)
        {
            List<VSalesRecord> list = new List<VSalesRecord>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@UserName", SqlDbType.NVarChar) };
            parm[0].Value = UserName;
            SqlDataReader reader = SQLHelper.RunProcedure("p_SalesRecord_getListByUserName", parm);
            while (reader.Read())
            {
                VSalesRecord item = new VSalesRecord {
                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                    SalesOrderID = reader.GetString(reader.GetOrdinal("SalesOrderID")),
                    PlatformID = reader.GetInt32(reader.GetOrdinal("PlatformID")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    CustomerID = reader.GetString(reader.GetOrdinal("CustomerID")),
                    PlatformName = reader.GetString(reader.GetOrdinal("PlatformName")),
                    UserName = reader.GetString(reader.GetOrdinal("UserName")),
                    CreateDate = reader.GetString(reader.GetOrdinal("CreateDate"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public bool insertNewEntity(SalesRecord s)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@PlatformID", SqlDbType.Int), new SqlParameter("@CustomerID", SqlDbType.NVarChar), new SqlParameter("@SalesOrderID", SqlDbType.NVarChar), new SqlParameter("@CreateDate", SqlDbType.NVarChar), new SqlParameter("@UserName", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar) };
            parm[0].Value = s.PlatformID;
            parm[1].Value = s.CustomerID;
            parm[2].Value = s.SalesOrderID;
            parm[3].Value = s.CreateDate;
            parm[4].Value = s.UserName;
            parm[5].Value = s.Description;
            SQLHelper.RunProcedure("p_SalesRecord_insertNewEntity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }
    }
}

