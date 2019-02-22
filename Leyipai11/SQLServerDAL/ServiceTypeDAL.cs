namespace Leyp.SQLServerDAL
{
    using Leyp.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class ServiceTypeDAL
    {
        public bool deleteDelivery(int TypeID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@TypeID", SqlDbType.Int) };
            parm[0].Value = TypeID;
            SQLHelper.RunProcedure("p_ServiceType_deleteDelivery", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public List<ServiceType> getAll()
        {
            List<ServiceType> list = new List<ServiceType>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_ServiceType_getAll", null);
            while (reader.Read())
            {
                ServiceType item = new ServiceType {
                    TypeID = reader.GetInt32(reader.GetOrdinal("TypeID")),
                    ServiceName = reader.GetString(reader.GetOrdinal("ServiceName")),
                    Description = reader.GetString(reader.GetOrdinal("Description"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public ServiceType getByID(int TypeID)
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@TypeID", SqlDbType.Int) };
            parm[0].Value = TypeID;
            ServiceType item = new ServiceType();
            SqlDataReader reader = SQLHelper.RunProcedure("p_ServiceType_getByID", parm);
            if (reader.Read())
            {
                item.TypeID = reader.GetInt32(reader.GetOrdinal("TypeID"));
                item.ServiceName = reader.GetString(reader.GetOrdinal("ServiceName"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
            }
            reader.Close();
            return item;
        }

        public bool insertNewEitity(ServiceType s)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ServiceName", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar) };
            parm[0].Value = s.ServiceName;
            parm[1].Value = s.Description;
            SQLHelper.RunProcedure("p_ServiceType_insertNewEitity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public bool updateEitity(ServiceType s)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@TypeID", SqlDbType.Int), new SqlParameter("@ServiceName", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar) };
            parm[0].Value = s.TypeID;
            parm[1].Value = s.ServiceName;
            parm[2].Value = s.Description;
            SQLHelper.RunProcedure("p_ServiceType_updateEitity(", parm, out rowsAffect);
            return (1 == rowsAffect);
        }
    }
}

