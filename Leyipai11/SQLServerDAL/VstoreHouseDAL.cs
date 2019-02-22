namespace Leyp.SQLServerDAL
{
    using Leyp.Model.View;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class VstoreHouseDAL
    {
        public List<VstoreHouse> getAll()
        {
            List<VstoreHouse> list = new List<VstoreHouse>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_storeHouse_getAllview", null);
            while (reader.Read())
            {
                VstoreHouse item = new VstoreHouse {
                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                    HouseID = reader.GetInt32(reader.GetOrdinal("HouseID")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    SubareaName = reader.GetString(reader.GetOrdinal("SubareaName")),
                    HouseName = reader.GetString(reader.GetOrdinal("HouseName")),
                    State = reader.GetString(reader.GetOrdinal("State"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }
    }
}

