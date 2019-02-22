namespace Leyp.SQLServerDAL
{
    using Leyp.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class StoreHouseDetailDAL
    {
        public bool deleteNode(int ID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int) };
            parm[0].Value = ID;
            SQLHelper.RunProcedure("p_StoreHouseDetail_deleteNode", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public List<StoreHouseDetail> getAll()
        {
            List<StoreHouseDetail> list = new List<StoreHouseDetail>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_StoreHouseDetail_getAll", null);
            while (reader.Read())
            {
                StoreHouseDetail item = new StoreHouseDetail {
                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                    HouseID = reader.GetInt32(reader.GetOrdinal("HouseID")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    SubareaName = reader.GetString(reader.GetOrdinal("SubareaName"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public StoreHouseDetail getByID(int ID)
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int) };
            parm[0].Value = ID;
            StoreHouseDetail item = new StoreHouseDetail();
            SqlDataReader reader = SQLHelper.RunProcedure("p_StoreHouseDetail_getByID", parm);
            if (reader.Read())
            {
                item.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                item.HouseID = reader.GetInt32(reader.GetOrdinal("HouseID"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.SubareaName = reader.GetString(reader.GetOrdinal("SubareaName"));
            }
            reader.Close();
            return item;
        }

        public List<StoreHouseDetail> getListByHouseID(int HouseID)
        {
            List<StoreHouseDetail> list = new List<StoreHouseDetail>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@HouseID", SqlDbType.Int) };
            parm[0].Value = HouseID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_StoreHouseDetail_getListByHouseID", parm);
            while (reader.Read())
            {
                StoreHouseDetail item = new StoreHouseDetail {
                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                    HouseID = reader.GetInt32(reader.GetOrdinal("HouseID")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    SubareaName = reader.GetString(reader.GetOrdinal("SubareaName"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public bool insertNewNode(StoreHouseDetail s)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@HouseID", SqlDbType.Int), new SqlParameter("@SubareaName ", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar) };
            parm[0].Value = s.HouseID;
            parm[1].Value = s.SubareaName;
            parm[2].Value = s.Description;
            SQLHelper.RunProcedure("p_StoreHouseDetail_insertNewNode", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public bool updateStoreHouseDetail(StoreHouseDetail s)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int), new SqlParameter("@SubareaName ", SqlDbType.NVarChar), new SqlParameter("@State ", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar) };
            parm[0].Value = s.ID;
            parm[1].Value = s.SubareaName;
            parm[2].Value = s.State;
            parm[3].Value = s.Description;
            SQLHelper.RunProcedure("p_StoreHouseDetail_updateNode", parm, out rowsAffect);
            return (1 == rowsAffect);
        }
    }
}

