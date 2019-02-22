namespace Leyp.SQLServerDAL.Buy
{
    using Leyp.Model.Buy;
    using Leyp.SQLServerDAL;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class BuyReceiptDetailDAL
    {
        public bool deleteEitity(int DetailID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@DetailID", SqlDbType.Int) };
            parm[0].Value = DetailID;
            SQLHelper.RunProcedure("p_BuyReceiptDetail_deleteEitity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public List<VBuyReceiptDetail> getBuyReceiptDetailByReceiptOrderID(string ReceiptOrderID)
        {
            string cost = "";
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ReceiptOrderID", SqlDbType.NVarChar) };
            parm[0].Value = ReceiptOrderID;
            List<VBuyReceiptDetail> list = new List<VBuyReceiptDetail>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_BuyReceiptDetail_getReceiptOrderID", parm);
            while (reader.Read())
            {
                VBuyReceiptDetail item = new VBuyReceiptDetail {
                    DetailID = reader.GetInt32(reader.GetOrdinal("DetailID")),
                    ReceiptOrderID = reader.GetString(reader.GetOrdinal("ReceiptOrderID")),
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

        public VBuyReceiptDetail getByID(int DetailID)
        {
            string cost = "";
            VBuyReceiptDetail item = new VBuyReceiptDetail();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@DetailID", SqlDbType.Int) };
            parm[0].Value = DetailID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_BuyReceiptDetail_getByID", parm);
            if (reader.Read())
            {
                item.DetailID = reader.GetInt32(reader.GetOrdinal("DetailID"));
                item.ReceiptOrderID = reader.GetString(reader.GetOrdinal("ReceiptOrderID"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
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
            }
            return item;
        }

        public bool insertNewEitity(BuyReceiptDetail b)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ReceiptOrderID", SqlDbType.NVarChar), new SqlParameter("@ProductsID", SqlDbType.Int), new SqlParameter("@SupplierID", SqlDbType.Int), new SqlParameter("@Quantity", SqlDbType.Int), new SqlParameter("@Price", SqlDbType.Money), new SqlParameter("@TaxRate", SqlDbType.Float), new SqlParameter("@DiscountRate", SqlDbType.Float), new SqlParameter("@Description", SqlDbType.NVarChar) };
            parm[0].Value = b.ReceiptOrderID;
            parm[1].Value = b.ProductsID;
            parm[2].Value = b.SupplierID;
            parm[3].Value = b.Quantity;
            parm[4].Value = b.Price;
            parm[5].Value = b.TaxRate;
            parm[6].Value = b.DiscountRate;
            parm[7].Value = b.Description;
            SQLHelper.RunProcedure("p_BuyReceiptDetail_insertNewEntity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public bool updateEitity(BuyReceiptDetail b)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ReceiptOrderID", SqlDbType.NVarChar), new SqlParameter("@ProductsID", SqlDbType.Int), new SqlParameter("@SupplierID", SqlDbType.Int), new SqlParameter("@Quantity", SqlDbType.Int), new SqlParameter("@Price", SqlDbType.Money), new SqlParameter("@TaxRate", SqlDbType.Float), new SqlParameter("@DiscountRate", SqlDbType.Float), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@DetailID", SqlDbType.Int) };
            parm[0].Value = b.ReceiptOrderID;
            parm[1].Value = b.ProductsID;
            parm[2].Value = b.SupplierID;
            parm[3].Value = b.Quantity;
            parm[4].Value = b.Price;
            parm[5].Value = b.TaxRate;
            parm[6].Value = b.DiscountRate;
            parm[7].Value = b.Description;
            parm[8].Value = b.DetailID;
            SQLHelper.RunProcedure("p_BuyReceiptDetail_updateEntity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }
    }
}

