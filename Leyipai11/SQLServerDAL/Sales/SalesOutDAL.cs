namespace Leyp.SQLServerDAL.Sales
{
    using Leyp.Model.Sales;
    using Leyp.SQLServerDAL;
    using Leyp.SQLServerDAL.Service;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class SalesOutDAL
    {
        public bool AuditingOrder(string SalesOutID, string UserName)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SalesOutID", SqlDbType.NVarChar), new SqlParameter("@UserName", SqlDbType.NVarChar) };
            parm[0].Value = SalesOutID;
            parm[1].Value = UserName;
            if (new SalesOutService().AuditingSalesOutOrder(SalesOutID))
            {
                SQLHelper.RunProcedure("p_SalesOut_AuditingOrder", parm, out rowsAffect);
            }
            return (0 < rowsAffect);
        }

        public bool AuditingOrder(string SalesOutID, string UserName, string TradeDate, string Consignee)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SalesOutID", SqlDbType.NVarChar), new SqlParameter("@UserName", SqlDbType.NVarChar), new SqlParameter("@TradeDate", SqlDbType.NVarChar), new SqlParameter("@Consignee", SqlDbType.NVarChar) };
            parm[0].Value = SalesOutID;
            parm[1].Value = UserName;
            parm[2].Value = TradeDate;
            parm[3].Value = Consignee;
            try
            {
                SQLHelper.RunProcedure("p_SalesOut_NewAuditingOrder", parm, out rowsAffect);
                new SalesOutService().AuditingSalesOutOrder(SalesOutID);
            }
            catch
            {
                return false;
            }
            return (0 < rowsAffect);
        }

        public bool deleteEitity(string SalesOutID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SalesOutID", SqlDbType.NVarChar) };
            parm[0].Value = SalesOutID;
            SQLHelper.RunProcedure("p_SalesOut_deleteEitity", parm, out rowsAffect);
            return (0 < rowsAffect);
        }

        public VSalesOut getByID(string SalesOutID)
        {
            bool result = false;
            string cost = "";
            VSalesOut item = new VSalesOut();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SalesOutID", SqlDbType.NVarChar) };
            parm[0].Value = SalesOutID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_SalesOut_getByID", parm);
            while (reader.Read())
            {
                cost = reader.GetValue(reader.GetOrdinal("TotalPrice")).ToString();
                item.TotalPrice = float.Parse(cost);
                item.AuditingUser = reader.GetString(reader.GetOrdinal("AuditingUser"));
                item.Consignee = reader.GetString(reader.GetOrdinal("Consignee"));
                item.CreateDate = reader.GetString(reader.GetOrdinal("CreateDate"));
                cost = reader.GetValue(reader.GetOrdinal("Deposits")).ToString();
                item.Deposits = float.Parse(cost);
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.RealName = reader.GetString(reader.GetOrdinal("RealName"));
                item.SalesOrderID = reader.GetString(reader.GetOrdinal("SalesOrderID"));
                item.SalesOutID = reader.GetString(reader.GetOrdinal("SalesOutID"));
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                item.TradeDate = reader.GetString(reader.GetOrdinal("TradeDate"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                item.DeliveryName = reader.GetString(reader.GetOrdinal("DeliveryName"));
                item.DeliveryID = reader.GetInt32(reader.GetOrdinal("DeliveryID"));
                item.AccountsID = reader.GetString(reader.GetOrdinal("AccountsID"));
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                result = true;
            }
            reader.Close();
            return (result ? item : null);
        }

        public List<VSalesOut> getSearchList(string beginDate, string endDate, int sideState)
        {
            string cost = "";
            List<VSalesOut> list = new List<VSalesOut>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@beginDate", SqlDbType.NVarChar), new SqlParameter("@endDate", SqlDbType.NVarChar), new SqlParameter("@sideState", SqlDbType.Int) };
            parm[0].Value = beginDate;
            parm[1].Value = endDate;
            parm[2].Value = sideState;
            SqlDataReader reader = SQLHelper.RunProcedure("p_SalesOut_getSearchList", parm);
            while (reader.Read())
            {
                VSalesOut item = new VSalesOut();
                cost = reader.GetValue(reader.GetOrdinal("TotalPrice")).ToString();
                item.TotalPrice = float.Parse(cost);
                item.AuditingUser = reader.GetString(reader.GetOrdinal("AuditingUser"));
                item.Consignee = reader.GetString(reader.GetOrdinal("Consignee"));
                item.CreateDate = reader.GetString(reader.GetOrdinal("CreateDate"));
                cost = reader.GetValue(reader.GetOrdinal("Deposits")).ToString();
                item.Deposits = float.Parse(cost);
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.RealName = reader.GetString(reader.GetOrdinal("RealName"));
                item.SalesOrderID = reader.GetString(reader.GetOrdinal("SalesOrderID"));
                item.SalesOutID = reader.GetString(reader.GetOrdinal("SalesOutID"));
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                item.TradeDate = reader.GetString(reader.GetOrdinal("TradeDate"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                item.DeliveryName = reader.GetString(reader.GetOrdinal("DeliveryName"));
                item.AccountsID = reader.GetString(reader.GetOrdinal("AccountsID"));
                item.DeliveryID = reader.GetInt32(reader.GetOrdinal("DeliveryID"));
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<VSalesOut> getSearchListByID(string SalesOutID)
        {
            string cost = "";
            List<VSalesOut> list = new List<VSalesOut>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SalesOutID", SqlDbType.NVarChar) };
            parm[0].Value = SalesOutID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_SalesOut_getSearchListByID", parm);
            while (reader.Read())
            {
                VSalesOut item = new VSalesOut();
                cost = reader.GetValue(reader.GetOrdinal("TotalPrice")).ToString();
                item.TotalPrice = float.Parse(cost);
                item.AuditingUser = reader.GetString(reader.GetOrdinal("AuditingUser"));
                item.Consignee = reader.GetString(reader.GetOrdinal("Consignee"));
                item.CreateDate = reader.GetString(reader.GetOrdinal("CreateDate"));
                cost = reader.GetValue(reader.GetOrdinal("Deposits")).ToString();
                item.Deposits = float.Parse(cost);
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.RealName = reader.GetString(reader.GetOrdinal("RealName"));
                item.SalesOrderID = reader.GetString(reader.GetOrdinal("SalesOrderID"));
                item.SalesOutID = reader.GetString(reader.GetOrdinal("SalesOutID"));
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                item.TradeDate = reader.GetString(reader.GetOrdinal("TradeDate"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                item.DeliveryName = reader.GetString(reader.GetOrdinal("DeliveryName"));
                item.AccountsID = reader.GetString(reader.GetOrdinal("AccountsID"));
                item.DeliveryID = reader.GetInt32(reader.GetOrdinal("DeliveryID"));
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public bool insertNewEntity(SalesOut s)
        {
            int rowsAffect = 0;
            float total = float.Parse("0.00");
            List<VSalesOutDetail> list = new SalesOutDetailDAL().getBySalesOutID(s.SalesOutID);
            for (int i = 0; i < list.Count; i++)
            {
                VSalesOutDetail v = list[i];
                total += (v.Price * v.Quantity) * (1f - (v.DiscountRate / 100f));
            }
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SalesOutID", SqlDbType.NVarChar), new SqlParameter("@SalesOrderID", SqlDbType.NVarChar), new SqlParameter("@CreateDate", SqlDbType.NVarChar), new SqlParameter("@Consignee", SqlDbType.NVarChar), new SqlParameter("@TradeDate", SqlDbType.NVarChar), new SqlParameter("@TotalPrice", SqlDbType.Float), new SqlParameter("@Deposits", SqlDbType.Float), new SqlParameter("@UserName", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@State", SqlDbType.Int), new SqlParameter("@DeliveryID", SqlDbType.Int), new SqlParameter("@AccountsID", SqlDbType.NVarChar) };
            parm[0].Value = s.SalesOutID;
            parm[1].Value = s.SalesOrderID;
            parm[2].Value = s.CreateDate;
            parm[3].Value = s.Consignee;
            parm[4].Value = s.TradeDate;
            parm[5].Value = total;
            parm[6].Value = s.Deposits;
            parm[7].Value = s.UserName;
            parm[8].Value = s.Description;
            parm[9].Value = s.State;
            parm[10].Value = s.DeliveryID;
            parm[11].Value = s.AccountsID;
            SQLHelper.RunProcedure("p_SalesOut_insertNewEntity", parm, out rowsAffect);
            if (rowsAffect == 1)
            {
                new SalesOrderDAL().updateSate(2, s.SalesOrderID);
            }
            return (1 == rowsAffect);
        }

        public bool insertSalesDetailFrist(string SalesOrderID, string SalesOutID)
        {
            try
            {
                List<VSalesDetail> list = new List<VSalesDetail>();
                SalesOutDetailDAL dl = new SalesOutDetailDAL();
                list = new SalesDetailDAL().getBySalesOrderID(SalesOrderID);
                for (int i = 0; i < list.Count; i++)
                {
                    SalesOutDetail d = new SalesOutDetail();
                    VSalesDetail v = list[i];
                    d.ProductsID = v.ProductsID;
                    d.Quantity = v.Quantity;
                    d.SalesOutID = SalesOutID;
                    d.DiscountRate = v.DiscountRate;
                    d.Description = v.Description;
                    d.Price = v.Price;
                    dl.insertNewEitity(d);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<VSalesOut> selectProductsByImg(string Date, int sideState)
        {
            string cost = "";
            List<VSalesOut> list = new List<VSalesOut>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@Date", SqlDbType.NVarChar), new SqlParameter("@sideState", SqlDbType.Int) };
            parm[0].Value = Date;
            parm[1].Value = sideState;
            SqlDataReader reader = SQLHelper.RunProcedure("p_SalesOut_selectProductsByImg", parm);
            while (reader.Read())
            {
                VSalesOut item = new VSalesOut();
                cost = reader.GetValue(reader.GetOrdinal("TotalPrice")).ToString();
                item.TotalPrice = float.Parse(cost);
                item.AuditingUser = reader.GetString(reader.GetOrdinal("AuditingUser"));
                item.Consignee = reader.GetString(reader.GetOrdinal("Consignee"));
                item.CreateDate = reader.GetString(reader.GetOrdinal("CreateDate"));
                cost = reader.GetValue(reader.GetOrdinal("Deposits")).ToString();
                item.Deposits = float.Parse(cost);
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.RealName = reader.GetString(reader.GetOrdinal("RealName"));
                item.SalesOrderID = reader.GetString(reader.GetOrdinal("SalesOrderID"));
                item.SalesOutID = reader.GetString(reader.GetOrdinal("SalesOutID"));
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                item.TradeDate = reader.GetString(reader.GetOrdinal("TradeDate"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                item.DeliveryName = reader.GetString(reader.GetOrdinal("DeliveryName"));
                item.AccountsID = reader.GetString(reader.GetOrdinal("AccountsID"));
                item.DeliveryID = reader.GetInt32(reader.GetOrdinal("DeliveryID"));
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public bool updataEntity(SalesOut s)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SalesOutID", SqlDbType.NVarChar), new SqlParameter("@CreateDate", SqlDbType.NVarChar), new SqlParameter("@Consignee", SqlDbType.NVarChar), new SqlParameter("@TradeDate", SqlDbType.NVarChar), new SqlParameter("@UserName", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@DeliveryID", SqlDbType.Int) };
            parm[0].Value = s.SalesOutID;
            parm[1].Value = s.CreateDate;
            parm[2].Value = s.Consignee;
            parm[3].Value = s.TradeDate;
            parm[4].Value = s.UserName;
            parm[5].Value = s.Description;
            parm[6].Value = s.DeliveryID;
            SQLHelper.RunProcedure("p_SalesOut_updataEntity", parm, out rowsAffect);
            if (rowsAffect == 1)
            {
            }
            return (1 == rowsAffect);
        }

        public bool updateSate(int State, string SalesOutID)
        {
            if ((State > 3) || (State < 2))
            {
                return false;
            }
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@State", SqlDbType.Int), new SqlParameter("@SalesOutID", SqlDbType.NVarChar) };
            parm[0].Value = State;
            parm[1].Value = SalesOutID;
            SQLHelper.RunProcedure("p_SalesOut_updateSate", parm, out rowsAffect);
            return (0 < rowsAffect);
        }
    }
}

