namespace Leyp.SQLServerDAL.Buy
{
    using Leyp.Model.Buy;
    using Leyp.SQLServerDAL;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class BuyReturnDetailDAL
    {
        public bool deleteEitity(int DetailID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@DetailID", SqlDbType.Int) };
            parm[0].Value = DetailID;
            SQLHelper.RunProcedure("p_BuyReturnDetail_deleteEitity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public List<VBuyReturnDetail> getBuyReturnDetailByBuyReturnID(string BuyReturnID)
        {
            string cost = "";
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@BuyReturnID", SqlDbType.NVarChar) };
            parm[0].Value = BuyReturnID;
            List<VBuyReturnDetail> list = new List<VBuyReturnDetail>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_BuyReturnDetail_getByBuyReturnID", parm);
            while (reader.Read())
            {
                VBuyReturnDetail item = new VBuyReturnDetail {
                    DetailID = reader.GetInt32(reader.GetOrdinal("DetailID")),
                    BuyReturnID = reader.GetString(reader.GetOrdinal("BuyReturnID")),
                    Description = reader.GetString(reader.GetOrdinal("Description"))
                };
                cost = reader.GetValue(reader.GetOrdinal("Price")).ToString();
                item.Price = float.Parse(cost);
                item.ProductsID = reader.GetInt32(reader.GetOrdinal("ProductsID"));
                item.ProductsName = reader.GetString(reader.GetOrdinal("ProductsName"));
                item.Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
                item.SupplierID = reader.GetInt32(reader.GetOrdinal("SupplierID"));
                item.SupplierName = reader.GetString(reader.GetOrdinal("SupplierName"));
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public VBuyReturnDetail getByID(int DetailID)
        {
            string cost = "";
            VBuyReturnDetail item = new VBuyReturnDetail();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@DetailID", SqlDbType.Int) };
            parm[0].Value = DetailID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_BuyReturnDetail_getByID", parm);
            if (reader.Read())
            {
                item.DetailID = reader.GetInt32(reader.GetOrdinal("DetailID"));
                item.BuyReturnID = reader.GetString(reader.GetOrdinal("BuyReturnID"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                cost = reader.GetValue(reader.GetOrdinal("Price")).ToString();
                item.Price = float.Parse(cost);
                item.ProductsID = reader.GetInt32(reader.GetOrdinal("ProductsID"));
                item.ProductsName = reader.GetString(reader.GetOrdinal("ProductsName"));
                item.Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
                item.SupplierID = reader.GetInt32(reader.GetOrdinal("SupplierID"));
                item.SupplierName = reader.GetString(reader.GetOrdinal("SupplierName"));
            }
            return item;
        }

        public bool insertNewEitity(BuyReturnDetail b)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@BuyReturnID", SqlDbType.NVarChar), new SqlParameter("@ProductsID", SqlDbType.Int), new SqlParameter("@SupplierID", SqlDbType.Int), new SqlParameter("@Quantity", SqlDbType.Int), new SqlParameter("@Price", SqlDbType.Money), new SqlParameter("@Description", SqlDbType.NVarChar) };
            parm[0].Value = b.BuyReturnID;
            parm[1].Value = b.ProductsID;
            parm[2].Value = b.SupplierID;
            parm[3].Value = b.Quantity;
            parm[4].Value = b.Price;
            parm[5].Value = b.Description;
            SQLHelper.RunProcedure("p_BuyReturnDetail_insertNewEntity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public bool updateEitity(BuyReturnDetail b)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@BuyReturnID", SqlDbType.NVarChar), new SqlParameter("@ProductsID", SqlDbType.Int), new SqlParameter("@SupplierID", SqlDbType.Int), new SqlParameter("@Quantity", SqlDbType.Int), new SqlParameter("@Price", SqlDbType.Money), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@DetailID", SqlDbType.Int) };
            parm[0].Value = b.BuyReturnID;
            parm[1].Value = b.ProductsID;
            parm[2].Value = b.SupplierID;
            parm[3].Value = b.Quantity;
            parm[4].Value = b.Price;
            parm[5].Value = b.Description;
            parm[6].Value = b.DetailID;
            SQLHelper.RunProcedure("p_BuyReturnDetail_updateEntity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }
    }
}

