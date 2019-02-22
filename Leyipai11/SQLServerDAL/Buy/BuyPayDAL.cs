namespace Leyp.SQLServerDAL.Buy
{
    using Leyp.Model.Buy;
    using Leyp.SQLServerDAL;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class BuyPayDAL
    {
        public bool AuditingBuyPay(int PayID, string UserName)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@PayID", SqlDbType.Int), new SqlParameter("@UserName", SqlDbType.NVarChar) };
            parm[0].Value = PayID;
            parm[1].Value = UserName;
            SQLHelper.RunProcedure("p_BuyPay_AuditingBuyPay", parm, out rowsAffect);
            return (0 < rowsAffect);
        }

        public bool deleteEitity(int PayID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@PayID", SqlDbType.Int) };
            parm[0].Value = PayID;
            SQLHelper.RunProcedure("p_BuyPay_deleteEntity", parm, out rowsAffect);
            return (0 < rowsAffect);
        }

        public List<VBuyPay> getBuyPayOrderList(string beginDate, string endDate, int sideState)
        {
            string cost = "";
            List<VBuyPay> list = new List<VBuyPay>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@beginDate", SqlDbType.NVarChar), new SqlParameter("@endDate", SqlDbType.NVarChar), new SqlParameter("@sideState", SqlDbType.Int) };
            parm[0].Value = beginDate;
            parm[1].Value = endDate;
            parm[2].Value = sideState;
            SqlDataReader reader = SQLHelper.RunProcedure("p_BuyPay_getBuyPayOrderList", parm);
            while (reader.Read())
            {
                VBuyPay item = new VBuyPay();
                cost = reader.GetValue(reader.GetOrdinal("RealPay")).ToString();
                item.RealPay = float.Parse(cost);
                cost = reader.GetValue(reader.GetOrdinal("AttachPay")).ToString();
                item.AttachPay = float.Parse(cost);
                item.PayID = reader.GetInt32(reader.GetOrdinal("PayID"));
                item.AuditingUser = reader.GetString(reader.GetOrdinal("AuditingUser"));
                item.BuyReceiptID = reader.GetString(reader.GetOrdinal("BuyReceiptID"));
                item.CreateDate = reader.GetString(reader.GetOrdinal("CreateDate"));
                item.RealName = reader.GetString(reader.GetOrdinal("RealName"));
                item.PayType = reader.GetString(reader.GetOrdinal("PayType"));
                item.Ticket = reader.GetString(reader.GetOrdinal("Ticket"));
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<VBuyPay> getByBuyReceiptID(string BuyReceiptID)
        {
            string cost = "";
            List<VBuyPay> list = new List<VBuyPay>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@BuyReceiptID", SqlDbType.NVarChar) };
            parm[0].Value = BuyReceiptID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_BuyPay_getByBuyReceiptID", parm);
            while (reader.Read())
            {
                VBuyPay item = new VBuyPay();
                cost = reader.GetValue(reader.GetOrdinal("RealPay")).ToString();
                item.RealPay = float.Parse(cost);
                cost = reader.GetValue(reader.GetOrdinal("AttachPay")).ToString();
                item.AttachPay = float.Parse(cost);
                item.PayID = reader.GetInt32(reader.GetOrdinal("PayID"));
                item.AuditingUser = reader.GetString(reader.GetOrdinal("AuditingUser"));
                item.BuyReceiptID = reader.GetString(reader.GetOrdinal("BuyReceiptID"));
                item.CreateDate = reader.GetString(reader.GetOrdinal("CreateDate"));
                item.RealName = reader.GetString(reader.GetOrdinal("RealName"));
                item.PayType = reader.GetString(reader.GetOrdinal("PayType"));
                item.Ticket = reader.GetString(reader.GetOrdinal("Ticket"));
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public VBuyPay getViewNodeByID(int PayID)
        {
            string cost = "";
            VBuyPay item = new VBuyPay();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@PayID", SqlDbType.NVarChar) };
            parm[0].Value = PayID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_BuyPay_getViewNodeByID", parm);
            if (reader.Read())
            {
                cost = reader.GetValue(reader.GetOrdinal("RealPay")).ToString();
                item.RealPay = float.Parse(cost);
                cost = reader.GetValue(reader.GetOrdinal("AttachPay")).ToString();
                item.AttachPay = float.Parse(cost);
                item.PayID = reader.GetInt32(reader.GetOrdinal("PayID"));
                item.AuditingUser = reader.GetString(reader.GetOrdinal("AuditingUser"));
                item.BuyReceiptID = reader.GetString(reader.GetOrdinal("BuyReceiptID"));
                item.CreateDate = reader.GetString(reader.GetOrdinal("CreateDate"));
                item.RealName = reader.GetString(reader.GetOrdinal("RealName"));
                item.PayType = reader.GetString(reader.GetOrdinal("PayType"));
                item.Ticket = reader.GetString(reader.GetOrdinal("Ticket"));
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
            }
            reader.Close();
            return item;
        }

        public bool insertNewEntity(BuyPay b)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@BuyReceiptID", SqlDbType.NVarChar), new SqlParameter("@Ticket", SqlDbType.NVarChar), new SqlParameter("@CreateDate", SqlDbType.NVarChar), new SqlParameter("@UserName", SqlDbType.NVarChar), new SqlParameter("@PayType", SqlDbType.NVarChar), new SqlParameter("@RealPay", SqlDbType.Money), new SqlParameter("@AttachPay", SqlDbType.Money), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@State", SqlDbType.Int) };
            parm[0].Value = b.BuyReceiptID;
            parm[1].Value = b.Ticket;
            parm[2].Value = b.CreateDate;
            parm[3].Value = b.UserName;
            parm[4].Value = b.PayType;
            parm[5].Value = b.RealPay;
            parm[6].Value = b.AttachPay;
            parm[7].Value = b.Description;
            parm[8].Value = b.State;
            SQLHelper.RunProcedure("p_BuyPay_insertNewEntity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }
    }
}

