namespace Leyp.SQLServerDAL
{
    using Leyp.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;

    [DataObject]
    public class ShopDAL
    {
        public bool deleteShop(int ShopID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ShopID", SqlDbType.Int) };
            parm[0].Value = ShopID;
            SQLHelper.RunProcedure("p_Shop_deleteShop", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public List<Shop> getAllShop()
        {
            List<Shop> list = new List<Shop>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_Shop_getAllShop", null);
            while (reader.Read())
            {
                Shop item = new Shop {
                    ShopID = reader.GetInt32(reader.GetOrdinal("ShopID")),
                    ShopName = reader.GetString(reader.GetOrdinal("ShopName")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    PlatformName = reader.GetString(reader.GetOrdinal("PlatformName")),
                    ShopUrl = reader.GetString(reader.GetOrdinal("ShopUrl")),
                    PlatformID = reader.GetInt32(reader.GetOrdinal("PlatformID"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public Shop getByShopID(int ShopID)
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ShopID", SqlDbType.Int) };
            parm[0].Value = ShopID;
            Shop item = new Shop();
            SqlDataReader reader = SQLHelper.RunProcedure("p_shop_getByShopID", parm);
            if (reader.Read())
            {
                item.ShopID = reader.GetInt32(reader.GetOrdinal("ShopID"));
                item.ShopName = reader.GetString(reader.GetOrdinal("ShopName"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.PlatformName = reader.GetString(reader.GetOrdinal("PlatformName"));
                item.ShopUrl = reader.GetString(reader.GetOrdinal("ShopUrl"));
                item.PlatformID = reader.GetInt32(reader.GetOrdinal("PlatformID"));
            }
            reader.Close();
            return item;
        }

        public bool insertNewShop(Shop s)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ShopName", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@ShopUrl", SqlDbType.NVarChar), new SqlParameter("@PlatformID", SqlDbType.Int) };
            parm[0].Value = s.ShopName;
            parm[1].Value = s.Description;
            parm[2].Value = s.ShopUrl;
            parm[3].Value = s.PlatformID;
            SQLHelper.RunProcedure("p_Shop_insertNewShop", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public bool updateShop(Shop s)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ShopID", SqlDbType.Int), new SqlParameter("@ShopName", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@ShopUrl", SqlDbType.NVarChar), new SqlParameter("@PlatformID", SqlDbType.Int) };
            parm[0].Value = s.ShopID;
            parm[1].Value = s.ShopName;
            parm[2].Value = s.Description;
            parm[3].Value = s.ShopUrl;
            parm[4].Value = s.PlatformID;
            SQLHelper.RunProcedure("p_Shop_updateShop", parm, out rowsAffect);
            return (1 == rowsAffect);
        }
    }
}

