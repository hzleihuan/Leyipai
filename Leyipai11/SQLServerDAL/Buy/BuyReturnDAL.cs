namespace Leyp.SQLServerDAL.Buy
{
    using Leyp.Model.Buy;
    using Leyp.SQLServerDAL;
    using Leyp.SQLServerDAL.Service;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class BuyReturnDAL
    {
        public bool AuditingBuyReturnOrder(string BuyReturnID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@BuyReturnID", SqlDbType.NVarChar) };
            parm[0].Value = BuyReturnID;
            if (new BuyReturnService().AuditingBuyReturnOrder(BuyReturnID))
            {
                SQLHelper.RunProcedure("p_BuyReturn_AuditingBuyReturnOrder", parm, out rowsAffect);
            }
            return (0 < rowsAffect);
        }

        public bool deleteEitity(string BuyReturnID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@BuyReturnID", SqlDbType.NVarChar) };
            parm[0].Value = BuyReturnID;
            SQLHelper.RunProcedure("p_BuyReturn_deleteEntity", parm, out rowsAffect);
            return (0 < rowsAffect);
        }

        public List<VBuyReturn> getBuyReturnOrderList(string beginDate, string endDate, int sideState)
        {
            string cost = "";
            List<VBuyReturn> list = new List<VBuyReturn>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@beginDate", SqlDbType.NVarChar), new SqlParameter("@endDate", SqlDbType.NVarChar), new SqlParameter("@sideState", SqlDbType.Int) };
            parm[0].Value = beginDate;
            parm[1].Value = endDate;
            parm[2].Value = sideState;
            SqlDataReader reader = SQLHelper.RunProcedure("p_BuyReturn_getBuyReturnOrderList", parm);
            while (reader.Read())
            {
                VBuyReturn item = new VBuyReturn();
                cost = reader.GetValue(reader.GetOrdinal("AlreadyPay")).ToString();
                item.AlreadyPay = float.Parse(cost);
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.Identitys = reader.GetInt32(reader.GetOrdinal("Identitys"));
                item.RealName = reader.GetString(reader.GetOrdinal("RealName"));
                item.BuyReturnDate = reader.GetString(reader.GetOrdinal("BuyReturnDate"));
                item.BuyReturnID = reader.GetString(reader.GetOrdinal("BuyReturnID"));
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

        public VBuyReturn getByID(string BuyReturnID)
        {
            bool result = false;
            string cost = "";
            VBuyReturn item = new VBuyReturn();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@BuyReturnID", SqlDbType.NVarChar) };
            parm[0].Value = BuyReturnID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_BuyReturn_getListByBuyReturnID", parm);
            if (reader.Read())
            {
                cost = reader.GetValue(reader.GetOrdinal("AlreadyPay")).ToString();
                item.AlreadyPay = float.Parse(cost);
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.Identitys = reader.GetInt32(reader.GetOrdinal("Identitys"));
                item.HouseDetailID = reader.GetInt32(reader.GetOrdinal("HouseDetailID"));
                item.RealName = reader.GetString(reader.GetOrdinal("RealName"));
                item.BuyReturnDate = reader.GetString(reader.GetOrdinal("BuyReturnDate"));
                item.BuyReturnID = reader.GetString(reader.GetOrdinal("BuyReturnID"));
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                cost = reader.GetValue(reader.GetOrdinal("TotalPrice")).ToString();
                item.TotalPrice = float.Parse(cost);
                item.TradeDate = reader.GetString(reader.GetOrdinal("TradeDate"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                item.HouseName = reader.GetString(reader.GetOrdinal("HouseName"));
                item.SubareaName = reader.GetString(reader.GetOrdinal("SubareaName"));
                result = true;
            }
            reader.Close();
            return (result ? item : null);
        }

        public List<VBuyReturn> getListByBuyReturnID(string BuyReturnID)
        {
            string cost = "";
            List<VBuyReturn> list = new List<VBuyReturn>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@BuyReturnID", SqlDbType.NVarChar) };
            parm[0].Value = BuyReturnID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_BuyReturn_getListByBuyReturnID", parm);
            while (reader.Read())
            {
                VBuyReturn item = new VBuyReturn();
                cost = reader.GetValue(reader.GetOrdinal("AlreadyPay")).ToString();
                item.AlreadyPay = float.Parse(cost);
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.Identitys = reader.GetInt32(reader.GetOrdinal("Identitys"));
                item.RealName = reader.GetString(reader.GetOrdinal("RealName"));
                item.BuyReturnDate = reader.GetString(reader.GetOrdinal("BuyReturnDate"));
                item.BuyReturnID = reader.GetString(reader.GetOrdinal("BuyReturnID"));
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

        public VBuyReturn getViewNodeByID(string BuyReturnID)
        {
            string cost = "";
            VBuyReturn item = new VBuyReturn();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@BuyReturnID", SqlDbType.NVarChar) };
            parm[0].Value = BuyReturnID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_BuyReturn_getViewNodeByID", parm);
            if (reader.Read())
            {
                cost = reader.GetValue(reader.GetOrdinal("AlreadyPay")).ToString();
                item.AlreadyPay = float.Parse(cost);
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.ReceiptOrderID = reader.GetString(reader.GetOrdinal("ReceiptOrderID"));
                item.Identitys = reader.GetInt32(reader.GetOrdinal("Identitys"));
                item.RealName = reader.GetString(reader.GetOrdinal("RealName"));
                item.BuyReturnDate = reader.GetString(reader.GetOrdinal("BuyReturnDate"));
                item.BuyReturnID = reader.GetString(reader.GetOrdinal("BuyReturnID"));
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

        public bool insertNewEntity(BuyReturn b)
        {
            int rowsAffect = 0;
            float totals = float.Parse("0.00");
            if (b.Identitys == 0)
            {
                BuyReturnDetailDAL dal = new BuyReturnDetailDAL();
                List<VBuyReceiptDetail> list = new List<VBuyReceiptDetail>();
                list = new BuyReceiptDetailDAL().getBuyReceiptDetailByReceiptOrderID(b.ReceiptOrderID);
                for (int i = 0; i < list.Count; i++)
                {
                    BuyReturnDetail b0 = new BuyReturnDetail();
                    VBuyReceiptDetail d = list[i];
                    b0.Description = d.Description;
                    b0.Price = d.Price;
                    b0.ProductsID = d.ProductsID;
                    b0.Quantity = d.Quantity;
                    b0.SupplierID = d.SupplierID;
                    b0.BuyReturnID = b.BuyReturnID;
                    dal.insertNewEitity(b0);
                    totals += b0.Quantity * b0.Price;
                }
            }
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@BuyReturnID", SqlDbType.NVarChar), new SqlParameter("@BuyReturnDate", SqlDbType.NVarChar), new SqlParameter("@StoreHouseID", SqlDbType.Int), new SqlParameter("@HouseDetailID", SqlDbType.Int), new SqlParameter("@ReceiptOrderID", SqlDbType.NVarChar), new SqlParameter("@UserName", SqlDbType.NVarChar), new SqlParameter("@TotalPrice", SqlDbType.Money), new SqlParameter("@TradeDate", SqlDbType.NVarChar), new SqlParameter("@Identitys", SqlDbType.Int), new SqlParameter("@AlreadyPay", SqlDbType.Money), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@State", SqlDbType.Int) };
            parm[0].Value = b.BuyReturnID;
            parm[1].Value = b.BuyReturnDate;
            parm[2].Value = b.StoreHouseID;
            parm[3].Value = b.HouseDetailID;
            parm[4].Value = b.ReceiptOrderID;
            parm[5].Value = b.UserName;
            parm[6].Value = totals;
            parm[7].Value = b.TradeDate;
            parm[8].Value = b.Identitys;
            parm[9].Value = b.AlreadyPay;
            parm[10].Value = b.Description;
            parm[11].Value = b.State;
            SQLHelper.RunProcedure("p_BuyReturn_insertNewEntity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }
    }
}

