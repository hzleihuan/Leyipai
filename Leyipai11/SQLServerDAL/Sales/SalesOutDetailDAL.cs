namespace Leyp.SQLServerDAL.Sales
{
    using Leyp.Model.Sales;
    using Leyp.SQLServerDAL;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class SalesOutDetailDAL
    {
        public bool deleteEitity(int DetailID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@DetailID", SqlDbType.Int) };
            parm[0].Value = DetailID;
            SQLHelper.RunProcedure("p_SalesOutDetail_deleteEitity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public VSalesOutDetail getByID(int DetailID)
        {
            string cost = "";
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@DetailID", SqlDbType.Int) };
            parm[0].Value = DetailID;
            VSalesOutDetail item = new VSalesOutDetail();
            SqlDataReader reader = SQLHelper.RunProcedure("p_SalesOutDetail_getByID", parm);
            while (reader.Read())
            {
                item.DetailID = reader.GetInt32(reader.GetOrdinal("DetailID"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                cost = reader.GetValue(reader.GetOrdinal("DiscountRate")).ToString();
                item.DiscountRate = float.Parse(cost);
                cost = reader.GetValue(reader.GetOrdinal("Price")).ToString();
                item.Price = float.Parse(cost);
                item.ProductsID = reader.GetInt32(reader.GetOrdinal("ProductsID"));
                item.ProductsName = reader.GetString(reader.GetOrdinal("ProductsName"));
                item.PhotoUrl = reader.GetString(reader.GetOrdinal("PhotoUrl"));
                item.Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
                item.StoreHouseID = reader.GetInt32(reader.GetOrdinal("StoreHouseID"));
                item.HouseDetailID = reader.GetInt32(reader.GetOrdinal("HouseDetailID"));
            }
            reader.Close();
            return item;
        }

        public List<VSalesOutDetail> getBySalesOutID(string SalesOutID)
        {
            string cost = "";
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SalesOutID", SqlDbType.NVarChar) };
            parm[0].Value = SalesOutID;
            List<VSalesOutDetail> list = new List<VSalesOutDetail>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_SalesOutDetail_getBySalesOrderID", parm);
            while (reader.Read())
            {
                VSalesOutDetail item = new VSalesOutDetail {
                    DetailID = reader.GetInt32(reader.GetOrdinal("DetailID")),
                    Description = reader.GetString(reader.GetOrdinal("Description"))
                };
                cost = reader.GetValue(reader.GetOrdinal("DiscountRate")).ToString();
                item.DiscountRate = float.Parse(cost);
                cost = reader.GetValue(reader.GetOrdinal("Price")).ToString();
                item.Price = float.Parse(cost);
                item.ProductsID = reader.GetInt32(reader.GetOrdinal("ProductsID"));
                item.ProductsName = reader.GetString(reader.GetOrdinal("ProductsName"));
                item.PhotoUrl = reader.GetString(reader.GetOrdinal("PhotoUrl"));
                item.Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
                item.StoreHouseID = reader.GetInt32(reader.GetOrdinal("StoreHouseID"));
                item.HouseDetailID = reader.GetInt32(reader.GetOrdinal("HouseDetailID"));
                item.HouseName = reader.GetString(reader.GetOrdinal("HouseName"));
                item.SubareaName = reader.GetString(reader.GetOrdinal("SubareaName"));
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<VSalesOutDetail> getBySalesOutIDinit(string SalesOutID)
        {
            string cost = "";
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SalesOutID", SqlDbType.NVarChar) };
            parm[0].Value = SalesOutID;
            List<VSalesOutDetail> list = new List<VSalesOutDetail>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_SalesOutDetail_getBySalesOrderIDinit", parm);
            while (reader.Read())
            {
                VSalesOutDetail item = new VSalesOutDetail {
                    DetailID = reader.GetInt32(reader.GetOrdinal("DetailID")),
                    Description = reader.GetString(reader.GetOrdinal("Description"))
                };
                cost = reader.GetValue(reader.GetOrdinal("DiscountRate")).ToString();
                item.DiscountRate = float.Parse(cost);
                cost = reader.GetValue(reader.GetOrdinal("Price")).ToString();
                item.Price = float.Parse(cost);
                item.ProductsID = reader.GetInt32(reader.GetOrdinal("ProductsID"));
                item.ProductsName = reader.GetString(reader.GetOrdinal("ProductsName"));
                item.PhotoUrl = reader.GetString(reader.GetOrdinal("PhotoUrl"));
                item.Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
                item.StoreHouseID = reader.GetInt32(reader.GetOrdinal("StoreHouseID"));
                item.HouseDetailID = reader.GetInt32(reader.GetOrdinal("HouseDetailID"));
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public bool insertNewEitity(SalesOutDetail b)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SalesOutID", SqlDbType.NVarChar), new SqlParameter("@ProductsID", SqlDbType.Int), new SqlParameter("@Quantity", SqlDbType.Int), new SqlParameter("@Price", SqlDbType.Money), new SqlParameter("@DiscountRate", SqlDbType.Float), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@StoreHouseID", SqlDbType.Int), new SqlParameter("@HouseDetailID", SqlDbType.Int) };
            parm[0].Value = b.SalesOutID;
            parm[1].Value = b.ProductsID;
            parm[2].Value = b.Quantity;
            parm[3].Value = b.Price;
            parm[4].Value = b.DiscountRate;
            parm[5].Value = b.Description;
            parm[6].Value = b.StoreHouseID;
            parm[7].Value = b.HouseDetailID;
            SQLHelper.RunProcedure("p_SalesOutDetail_insertNewEntity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public bool updateEitity(SalesOutDetail b)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@DetailID", SqlDbType.Int), new SqlParameter("@SalesOutID", SqlDbType.NVarChar), new SqlParameter("@ProductsID", SqlDbType.Int), new SqlParameter("@Quantity", SqlDbType.Int), new SqlParameter("@Price", SqlDbType.Money), new SqlParameter("@DiscountRate", SqlDbType.Float), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@StoreHouseID", SqlDbType.Int), new SqlParameter("@HouseDetailID", SqlDbType.Int) };
            parm[0].Value = b.DetailID;
            parm[1].Value = b.SalesOutID;
            parm[2].Value = b.ProductsID;
            parm[3].Value = b.Quantity;
            parm[4].Value = b.Price;
            parm[5].Value = b.DiscountRate;
            parm[6].Value = b.Description;
            parm[7].Value = b.StoreHouseID;
            parm[8].Value = b.HouseDetailID;
            SQLHelper.RunProcedure("p_SalesOutDetail_updateEntity", parm, out rowsAffect);
            return (1 < rowsAffect);
        }
    }
}

