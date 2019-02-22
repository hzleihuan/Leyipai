namespace Leyp.SQLServerDAL.Buy
{
    using Leyp.Model.Buy;
    using Leyp.SQLServerDAL;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;

    [DataObject]
    public class BuyOrderDetailDAL
    {
        public bool deleteEitity(int DetailID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@DetailID", SqlDbType.Int) };
            parm[0].Value = DetailID;
            SQLHelper.RunProcedure("p_BuyOrderDetail_deleteEitity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public List<VBuyOrderDetail> getBuyOrderDetailByBuyOrderID(string BuyOrderID)
        {
            string cost = "";
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@BuyOrderID", SqlDbType.NVarChar) };
            parm[0].Value = BuyOrderID;
            List<VBuyOrderDetail> list = new List<VBuyOrderDetail>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_BuyOrderDetail_getByBuyOrderID", parm);
            while (reader.Read())
            {
                VBuyOrderDetail item = new VBuyOrderDetail {
                    DetailID = reader.GetInt32(reader.GetOrdinal("DetailID")),
                    Description = reader.GetString(reader.GetOrdinal("Description"))
                };
                cost = reader.GetValue(reader.GetOrdinal("DiscountRate")).ToString();
                item.DiscountRate = float.Parse(cost);
                cost = reader.GetValue(reader.GetOrdinal("Price")).ToString();
                item.Price = float.Parse(cost);
                item.ProductsID = reader.GetInt32(reader.GetOrdinal("ProductsID"));
                item.ProductsName = reader.GetString(reader.GetOrdinal("ProductsName"));
                item.Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
                item.SupplierID = reader.GetInt32(reader.GetOrdinal("SupplierID"));
                item.SupplierName = reader.GetString(reader.GetOrdinal("SupplierName"));
                cost = reader.GetValue(reader.GetOrdinal("TaxRate")).ToString();
                item.TaxRate = float.Parse(cost);
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<VBuyOrderDetail> getBuyOrderDetailforAjaxString(string BuyOrderID)
        {
            string cost = "";
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@BuyOrderID", SqlDbType.NVarChar) };
            parm[0].Value = BuyOrderID;
            List<VBuyOrderDetail> list = new List<VBuyOrderDetail>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_BuyOrderDetail_getByBuyOrderID", parm);
            while (reader.Read())
            {
                VBuyOrderDetail item = new VBuyOrderDetail {
                    DetailID = reader.GetInt32(reader.GetOrdinal("DetailID")),
                    Description = reader.GetString(reader.GetOrdinal("Description"))
                };
                cost = reader.GetValue(reader.GetOrdinal("DiscountRate")).ToString();
                item.DiscountRate = float.Parse(cost);
                cost = reader.GetValue(reader.GetOrdinal("Price")).ToString();
                item.Price = float.Parse(cost);
                item.ProductsID = reader.GetInt32(reader.GetOrdinal("ProductsID"));
                item.ProductsName = reader.GetString(reader.GetOrdinal("ProductsName"));
                item.Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
                item.SupplierID = reader.GetInt32(reader.GetOrdinal("SupplierID"));
                item.SupplierName = reader.GetString(reader.GetOrdinal("SupplierName"));
                cost = reader.GetValue(reader.GetOrdinal("TaxRate")).ToString();
                item.TaxRate = float.Parse(cost);
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public DataSet getOrderDetailPhoto(string BuyOrderID)
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@BuyOrderID", SqlDbType.NVarChar) };
            parm[0].Value = BuyOrderID;
            List<VBuyOrderDetail> list = new List<VBuyOrderDetail>();
            DataSet ds = new DataSet();
            return SQLHelper.RunProcedure("p_BuyOrderDetail_getOrderDetailPhoto", parm, "dd");
        }

        public bool insertNewEitity(BuyOrderDetail b)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@BuyOrderID", SqlDbType.NVarChar), new SqlParameter("@ProductsID", SqlDbType.Int), new SqlParameter("@SupplierID", SqlDbType.Int), new SqlParameter("@Quantity", SqlDbType.Int), new SqlParameter("@ReceiptNum", SqlDbType.Int), new SqlParameter("@Price", SqlDbType.Money), new SqlParameter("@TaxRate", SqlDbType.Float), new SqlParameter("@DiscountRate", SqlDbType.Float), new SqlParameter("@Description", SqlDbType.NVarChar) };
            parm[0].Value = b.BuyOrderID;
            parm[1].Value = b.ProductsID;
            parm[2].Value = b.SupplierID;
            parm[3].Value = b.Quantity;
            parm[4].Value = 0;
            parm[5].Value = b.Price;
            parm[6].Value = b.TaxRate;
            parm[7].Value = b.DiscountRate;
            parm[8].Value = b.Description;
            SQLHelper.RunProcedure("p_BuyOrderDetail_insertNewEntity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public bool updateEitity(BuyOrderDetail b)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@DetailID", SqlDbType.Int), new SqlParameter("@ProductsID", SqlDbType.Int), new SqlParameter("@SupplierID", SqlDbType.Int), new SqlParameter("@Quantity", SqlDbType.Int), new SqlParameter("@Price", SqlDbType.Money), new SqlParameter("@TaxRate", SqlDbType.Float), new SqlParameter("@DiscountRate", SqlDbType.Float), new SqlParameter("@Description", SqlDbType.NVarChar) };
            parm[0].Value = b.DetailID;
            parm[1].Value = b.ProductsID;
            parm[2].Value = b.SupplierID;
            parm[3].Value = b.Quantity;
            parm[4].Value = b.Price;
            parm[5].Value = b.TaxRate;
            parm[6].Value = b.DiscountRate;
            parm[7].Value = b.Description;
            SQLHelper.RunProcedure("p_BuyOrderDetail_updateEitity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }
    }
}

