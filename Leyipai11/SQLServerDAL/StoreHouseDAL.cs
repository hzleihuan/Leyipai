namespace Leyp.SQLServerDAL
{
    using Leyp.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class StoreHouseDAL
    {
        public bool deleteEitity(int HouseID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@houseID", SqlDbType.Int) };
            parm[0].Value = HouseID;
            SQLHelper.RunProcedure("p_StoreHouse_deleteStoreHouse", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public List<StoreHouse> getAllStoreHouse()
        {
            List<StoreHouse> list = new List<StoreHouse>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_StoreHouse_getAll", null);
            while (reader.Read())
            {
                StoreHouse item = new StoreHouse {
                    HouseID = reader.GetInt32(reader.GetOrdinal("HouseID")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    HouseName = reader.GetString(reader.GetOrdinal("HouseName"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public StoreHouse getByHouseID(int HouseID)
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@HouseID", SqlDbType.Int) };
            parm[0].Value = HouseID;
            StoreHouse item = new StoreHouse();
            SqlDataReader reader = SQLHelper.RunProcedure("p_StoreHouse_getByHouseID", parm);
            if (reader.Read())
            {
                item.HouseID = reader.GetInt32(reader.GetOrdinal("HouseID"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.HouseName = reader.GetString(reader.GetOrdinal("HouseName"));
            }
            reader.Close();
            return item;
        }

        public bool insertEitity(StoreHouse s)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@HouseName", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar) };
            parm[0].Value = s.HouseName;
            parm[1].Value = s.Description;
            SQLHelper.RunProcedure("p_StoreHouse_insertNewStoreHouse", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public bool updateStoreHouse(StoreHouse s)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@HouseID", SqlDbType.Int), new SqlParameter("@HouseName", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar) };
            parm[0].Value = s.HouseID;
            parm[1].Value = s.HouseName;
            parm[2].Value = s.Description;
            SQLHelper.RunProcedure("p_StoreHouse_updateStoreHouse", parm, out rowsAffect);
            return (1 == rowsAffect);
        }
    }
}

