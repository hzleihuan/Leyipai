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
    public class SalesPlatformDAL
    {
        public bool deleteEitity(int PlatformID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@PlatformID", SqlDbType.NVarChar) };
            parm[0].Value = PlatformID;
            SQLHelper.RunProcedure("p_SalesPlatform_deleteEitity", parm, out rowsAffect);
            return (0 < rowsAffect);
        }

        public SalesPlatform getByID(int PlatformID)
        {
            SalesPlatform item = new SalesPlatform();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@PlatformID", SqlDbType.NVarChar) };
            parm[0].Value = PlatformID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_SalesPlatform_getByID", parm);
            if (reader.Read())
            {
                item.PlatformID = reader.GetInt32(reader.GetOrdinal("PlatformID"));
                item.PlatformName = reader.GetString(reader.GetOrdinal("PlatformName"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
            }
            reader.Close();
            return item;
        }

        public List<SalesPlatform> getList()
        {
            List<SalesPlatform> list = new List<SalesPlatform>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_SalesPlatform_getList", null);
            while (reader.Read())
            {
                SalesPlatform item = new SalesPlatform {
                    PlatformID = reader.GetInt32(reader.GetOrdinal("PlatformID")),
                    PlatformName = reader.GetString(reader.GetOrdinal("PlatformName")),
                    Description = reader.GetString(reader.GetOrdinal("Description"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public bool insertNewEntity(SalesPlatform s)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@PlatformName", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar) };
            parm[0].Value = s.PlatformName;
            parm[1].Value = s.Description;
            SQLHelper.RunProcedure("p_SalesPlatform_insertNewEntity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public bool updateEitity(SalesPlatform s)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@PlatformName", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@PlatformID", SqlDbType.Int) };
            parm[0].Value = s.PlatformName;
            parm[1].Value = s.Description;
            parm[2].Value = s.PlatformID;
            SQLHelper.RunProcedure("p_SalesPlatform_updateEntity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }
    }
}

