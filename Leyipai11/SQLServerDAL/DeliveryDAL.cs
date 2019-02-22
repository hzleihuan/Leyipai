namespace Leyp.SQLServerDAL
{
    using Leyp.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class DeliveryDAL
    {
        public bool deleteDelivery(int DeliveryID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@DeliveryID", SqlDbType.Int) };
            parm[0].Value = DeliveryID;
            SQLHelper.RunProcedure("p_Delivery_deleteDelivery", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public List<Delivery> getAllDelivery()
        {
            List<Delivery> list = new List<Delivery>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_Delivery_getAllDelivery", null);
            while (reader.Read())
            {
                Delivery item = new Delivery {
                    DeliveryID = reader.GetInt32(reader.GetOrdinal("DeliveryID")),
                    DeliveryName = reader.GetString(reader.GetOrdinal("DeliveryName")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    Default = reader.GetInt32(reader.GetOrdinal("Default"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public Delivery getByID(int DeliveryID)
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@DeliveryID", SqlDbType.Int) };
            parm[0].Value = DeliveryID;
            Delivery item = new Delivery();
            SqlDataReader reader = SQLHelper.RunProcedure("p_Delivery_getByID", parm);
            if (reader.Read())
            {
                item.DeliveryID = reader.GetInt32(reader.GetOrdinal("DeliveryID"));
                item.DeliveryName = reader.GetString(reader.GetOrdinal("DeliveryName"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.Default = reader.GetInt32(reader.GetOrdinal("Default"));
            }
            reader.Close();
            return item;
        }

        public Delivery getDefaultEitity()
        {
            Delivery item = new Delivery();
            SqlDataReader reader = SQLHelper.RunProcedure("p_Delivery_getDefaultEitity", null);
            if (reader.Read())
            {
                item.DeliveryID = reader.GetInt32(reader.GetOrdinal("DeliveryID"));
                item.DeliveryName = reader.GetString(reader.GetOrdinal("DeliveryName"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.Default = reader.GetInt32(reader.GetOrdinal("Default"));
            }
            reader.Close();
            return item;
        }

        public bool insertNewEitity(Delivery s)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@DeliveryName", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@Default", SqlDbType.Int) };
            parm[0].Value = s.DeliveryName;
            parm[1].Value = s.Description;
            parm[2].Value = s.Default;
            SQLHelper.RunProcedure("p_Delivery_insertNewEitity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public bool updataDefault(int DeliveryID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@DeliveryID", SqlDbType.Int) };
            parm[0].Value = DeliveryID;
            SQLHelper.RunProcedure("p_Delivery_updataDefault", parm, out rowsAffect);
            return (0 < rowsAffect);
        }

        public bool updateDelivery(Delivery s)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@DeliveryID", SqlDbType.Int), new SqlParameter("@DeliveryName", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar) };
            parm[0].Value = s.DeliveryID;
            parm[1].Value = s.DeliveryName;
            parm[2].Value = s.Description;
            SQLHelper.RunProcedure("p_Delivery_updateDelivery", parm, out rowsAffect);
            return (1 == rowsAffect);
        }
    }
}

