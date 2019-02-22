namespace Leyp.SQLServerDAL.Buy
{
    using Leyp.Model.Buy;
    using Leyp.SQLServerDAL;
    using Leyp.SQLServerDAL.Service;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class BuyReceiptDAL
    {
        public bool AuditingBuyReceiptOrder(string ReceiptOrderID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ReceiptOrderID", SqlDbType.NVarChar) };
            parm[0].Value = ReceiptOrderID;
            SQLHelper.RunProcedure("p_BuyReceipt_AuditingBuyReceiptOrder", parm, out rowsAffect);
            new BuyReceiptService().AuditingBuyReceiptOrder(ReceiptOrderID);
            return (0 < rowsAffect);
        }

        public bool deleteEitity(string ReceiptOrderID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ReceiptOrderID", SqlDbType.NVarChar) };
            parm[0].Value = ReceiptOrderID;
            SQLHelper.RunProcedure("p_BuyReceipt_deleteEntity", parm, out rowsAffect);
            return (0 < rowsAffect);
        }

        public List<VBuyReceipt> getAdminBuyReceiptOrderList(string beginDate, string endDate, int sideState)
        {
            string cost = "";
            List<VBuyReceipt> list = new List<VBuyReceipt>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@beginDate", SqlDbType.NVarChar), new SqlParameter("@endDate", SqlDbType.NVarChar), new SqlParameter("@sideState", SqlDbType.Int) };
            parm[0].Value = beginDate;
            parm[1].Value = endDate;
            parm[2].Value = sideState;
            SqlDataReader reader = SQLHelper.RunProcedure("p_BuyReceipt_getAdminBuyReceiptOrderList", parm);
            while (reader.Read())
            {
                VBuyReceipt item = new VBuyReceipt();
                cost = reader.GetValue(reader.GetOrdinal("AlreadyPay")).ToString();
                item.AlreadyPay = float.Parse(cost);
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.Identitys = reader.GetInt32(reader.GetOrdinal("Identitys"));
                item.RealName = reader.GetString(reader.GetOrdinal("RealName"));
                item.ReceiptOrderDate = reader.GetString(reader.GetOrdinal("ReceiptOrderDate"));
                item.ReceiptOrderID = reader.GetString(reader.GetOrdinal("ReceiptOrderID"));
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                cost = reader.GetValue(reader.GetOrdinal("TotalPrice")).ToString();
                item.TotalPrice = float.Parse(cost);
                item.TradeDate = reader.GetString(reader.GetOrdinal("TradeDate"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                item.HouseName = reader.GetString(reader.GetOrdinal("HouseName"));
                item.SubareaName = reader.GetString(reader.GetOrdinal("SubareaName"));
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public BuyReceipt getByID(string ReceiptOrderID)
        {
            string cost = "";
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ReceiptOrderID", SqlDbType.NVarChar) };
            parm[0].Value = ReceiptOrderID;
            BuyReceipt item = new BuyReceipt();
            SqlDataReader reader = SQLHelper.RunProcedure("p_BuyReceipt_getByID", parm);
            if (reader.Read())
            {
                item.ReceiptOrderDate = reader.GetString(reader.GetOrdinal("ReceiptOrderDate"));
                item.ReceiptOrderID = reader.GetString(reader.GetOrdinal("ReceiptOrderID"));
                item.BuyOrderID = reader.GetString(reader.GetOrdinal("BuyOrderID"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.HouseDetailID = reader.GetInt32(reader.GetOrdinal("HouseDetailID"));
                item.Identitys = reader.GetInt32(reader.GetOrdinal("Identitys"));
                item.TradeDate = reader.GetString(reader.GetOrdinal("TradeDate"));
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                cost = reader.GetValue(reader.GetOrdinal("TotalPrice")).ToString();
                item.TotalPrice = float.Parse(cost);
                cost = reader.GetValue(reader.GetOrdinal("AlreadyPay")).ToString();
                item.AlreadyPay = float.Parse(cost);
                item.StoreHouseID = reader.GetInt32(reader.GetOrdinal("StoreHouseID"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
            }
            reader.Close();
            return item;
        }

        public List<VBuyReceipt> getListByReceiptOrderID(string ReceiptOrderID)
        {
            string cost = "";
            List<VBuyReceipt> list = new List<VBuyReceipt>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ReceiptOrderID", SqlDbType.NVarChar) };
            parm[0].Value = ReceiptOrderID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_BuyReceipt_getListByReceiptOrderID", parm);
            while (reader.Read())
            {
                VBuyReceipt item = new VBuyReceipt();
                cost = reader.GetValue(reader.GetOrdinal("AlreadyPay")).ToString();
                item.AlreadyPay = float.Parse(cost);
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.Identitys = reader.GetInt32(reader.GetOrdinal("Identitys"));
                item.RealName = reader.GetString(reader.GetOrdinal("RealName"));
                item.ReceiptOrderDate = reader.GetString(reader.GetOrdinal("ReceiptOrderDate"));
                item.ReceiptOrderID = reader.GetString(reader.GetOrdinal("ReceiptOrderID"));
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                cost = reader.GetValue(reader.GetOrdinal("TotalPrice")).ToString();
                item.TotalPrice = float.Parse(cost);
                item.TradeDate = reader.GetString(reader.GetOrdinal("TradeDate"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                item.HouseName = reader.GetString(reader.GetOrdinal("HouseName"));
                item.SubareaName = reader.GetString(reader.GetOrdinal("SubareaName"));
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public VBuyReceipt getViewByID(string ReceiptOrderID)
        {
            string cost = "";
            VBuyReceipt item = new VBuyReceipt();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ReceiptOrderID", SqlDbType.NVarChar) };
            parm[0].Value = ReceiptOrderID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_BuyReceipt_getListByReceiptOrderID", parm);
            if (reader.Read())
            {
                cost = reader.GetValue(reader.GetOrdinal("AlreadyPay")).ToString();
                item.AlreadyPay = float.Parse(cost);
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.BuyOrderID = reader.GetString(reader.GetOrdinal("BuyOrderID"));
                item.Identitys = reader.GetInt32(reader.GetOrdinal("Identitys"));
                item.RealName = reader.GetString(reader.GetOrdinal("RealName"));
                item.ReceiptOrderDate = reader.GetString(reader.GetOrdinal("ReceiptOrderDate"));
                item.ReceiptOrderID = reader.GetString(reader.GetOrdinal("ReceiptOrderID"));
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                cost = reader.GetValue(reader.GetOrdinal("TotalPrice")).ToString();
                item.TotalPrice = float.Parse(cost);
                item.TradeDate = reader.GetString(reader.GetOrdinal("TradeDate"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                item.HouseName = reader.GetString(reader.GetOrdinal("HouseName"));
                item.SubareaName = reader.GetString(reader.GetOrdinal("SubareaName"));
            }
            return item;
        }

        public bool insertNewEntity(BuyReceipt b)
        {
            int rowsAffect = 0;
            float totals = float.Parse("0.00");
            if (b.Identitys == 0)
            {
                BuyReceiptDetailDAL dal = new BuyReceiptDetailDAL();
                List<VBuyOrderDetail> list = new List<VBuyOrderDetail>();
                list = new BuyOrderDetailDAL().getBuyOrderDetailByBuyOrderID(b.BuyOrderID);
                for (int i = 0; i < list.Count; i++)
                {
                    BuyReceiptDetail b0 = new BuyReceiptDetail();
                    BuyOrderDetail d = list[i];
                    b0.Description = d.Description;
                    b0.DiscountRate = d.DiscountRate;
                    b0.Price = d.Price;
                    b0.ProductsID = d.ProductsID;
                    b0.Quantity = d.Quantity;
                    b0.SupplierID = d.SupplierID;
                    b0.TaxRate = d.TaxRate;
                    b0.ReceiptOrderID = b.ReceiptOrderID;
                    dal.insertNewEitity(b0);
                    totals += (((b0.Quantity * b0.Price) * (100f + b0.TaxRate)) / 100f) - (((b0.Quantity * b0.Price) * b0.DiscountRate) / 100f);
                }
            }
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ReceiptOrderID", SqlDbType.NVarChar), new SqlParameter("@ReceiptOrderDate", SqlDbType.NVarChar), new SqlParameter("@StoreHouseID", SqlDbType.Int), new SqlParameter("@HouseDetailID", SqlDbType.Int), new SqlParameter("@BuyOrderID", SqlDbType.NVarChar), new SqlParameter("@UserName", SqlDbType.NVarChar), new SqlParameter("@TotalPrice", SqlDbType.Money), new SqlParameter("@TradeDate", SqlDbType.NVarChar), new SqlParameter("@Identitys", SqlDbType.Int), new SqlParameter("@AlreadyPay", SqlDbType.Money), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@State", SqlDbType.Int) };
            parm[0].Value = b.ReceiptOrderID;
            parm[1].Value = b.ReceiptOrderDate;
            parm[2].Value = b.StoreHouseID;
            parm[3].Value = b.HouseDetailID;
            parm[4].Value = b.BuyOrderID;
            parm[5].Value = b.UserName;
            parm[6].Value = totals;
            parm[7].Value = b.TradeDate;
            parm[8].Value = b.Identitys;
            parm[9].Value = b.AlreadyPay;
            parm[10].Value = b.Description;
            parm[11].Value = b.State;
            SQLHelper.RunProcedure("p_BuyReceipt_insertNewEntity", parm, out rowsAffect);
            return (0 < rowsAffect);
        }
    }
}

