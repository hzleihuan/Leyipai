namespace Leyp.SQLServerDAL.Sales
{
    using Leyp.Model.Sales;
    using Leyp.SQLServerDAL;
    using Leyp.SQLServerDAL.Service;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class SalesReturnDAL
    {
        public bool AuditingOrder(string SalesReturnID, string UserName)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SalesReturnID", SqlDbType.NVarChar), new SqlParameter("@UserName", SqlDbType.NVarChar) };
            parm[0].Value = SalesReturnID;
            parm[1].Value = UserName;
            SQLHelper.RunProcedure("p_SalesReturn_AuditingOrder", parm, out rowsAffect);
            new SalesReturnService().AuditingSalesOutOrder(SalesReturnID);
            return (0 < rowsAffect);
        }

        public bool deleteEitity(string SalesReturnID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SalesReturnID", SqlDbType.NVarChar) };
            parm[0].Value = SalesReturnID;
            SQLHelper.RunProcedure("p_SalesReturn_deleteEitity", parm, out rowsAffect);
            return (0 < rowsAffect);
        }

        public VSalesReturn getByID(string SalesReturnID)
        {
            return this.getSearchListByID(SalesReturnID)[0];
        }

        public List<VSalesReturn> getSearchList(string beginDate, string endDate, int sideState)
        {
            string cost = "";
            List<VSalesReturn> list = new List<VSalesReturn>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@beginDate", SqlDbType.NVarChar), new SqlParameter("@endDate", SqlDbType.NVarChar), new SqlParameter("@sideState", SqlDbType.Int) };
            parm[0].Value = beginDate;
            parm[1].Value = endDate;
            parm[2].Value = sideState;
            SqlDataReader reader = SQLHelper.RunProcedure("p_SalesReturn_getSearchList", parm);
            while (reader.Read())
            {
                VSalesReturn item = new VSalesReturn();
                cost = reader.GetValue(reader.GetOrdinal("TotalPrice")).ToString();
                item.TotalPrice = float.Parse(cost);
                item.AuditingUser = reader.GetString(reader.GetOrdinal("AuditingUser"));
                item.ReturnType = reader.GetString(reader.GetOrdinal("ReturnType"));
                item.CreateDate = reader.GetString(reader.GetOrdinal("CreateDate"));
                cost = reader.GetValue(reader.GetOrdinal("Deposits")).ToString();
                item.Deposits = float.Parse(cost);
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.HouseDetailID = reader.GetInt32(reader.GetOrdinal("HouseDetailID"));
                item.HouseName = reader.GetString(reader.GetOrdinal("HouseName"));
                item.RealName = reader.GetString(reader.GetOrdinal("RealName"));
                item.SalesReturnID = reader.GetString(reader.GetOrdinal("SalesReturnID"));
                item.SalesOutID = reader.GetString(reader.GetOrdinal("SalesOutID"));
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                item.SubareaName = reader.GetString(reader.GetOrdinal("SubareaName"));
                item.TradeDate = reader.GetString(reader.GetOrdinal("TradeDate"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<VSalesReturn> getSearchListByID(string SalesReturnID)
        {
            string cost = "";
            List<VSalesReturn> list = new List<VSalesReturn>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SalesReturnID", SqlDbType.NVarChar) };
            parm[0].Value = SalesReturnID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_SalesReturn_getSearchListByID", parm);
            while (reader.Read())
            {
                VSalesReturn item = new VSalesReturn();
                cost = reader.GetValue(reader.GetOrdinal("TotalPrice")).ToString();
                item.TotalPrice = float.Parse(cost);
                item.AuditingUser = reader.GetString(reader.GetOrdinal("AuditingUser"));
                item.ReturnType = reader.GetString(reader.GetOrdinal("ReturnType"));
                item.CreateDate = reader.GetString(reader.GetOrdinal("CreateDate"));
                cost = reader.GetValue(reader.GetOrdinal("Deposits")).ToString();
                item.Deposits = float.Parse(cost);
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.HouseDetailID = reader.GetInt32(reader.GetOrdinal("HouseDetailID"));
                item.HouseName = reader.GetString(reader.GetOrdinal("HouseName"));
                item.RealName = reader.GetString(reader.GetOrdinal("RealName"));
                item.SalesReturnID = reader.GetString(reader.GetOrdinal("SalesReturnID"));
                item.SalesOutID = reader.GetString(reader.GetOrdinal("SalesOutID"));
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                item.SubareaName = reader.GetString(reader.GetOrdinal("SubareaName"));
                item.TradeDate = reader.GetString(reader.GetOrdinal("TradeDate"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public bool insertNewEntity(SalesReturn s)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SalesReturnID", SqlDbType.NVarChar), new SqlParameter("@SalesOutID", SqlDbType.NVarChar), new SqlParameter("@CreateDate", SqlDbType.NVarChar), new SqlParameter("@ReturnType", SqlDbType.NVarChar), new SqlParameter("@StoreHouseID", SqlDbType.Int), new SqlParameter("@HouseDetailID", SqlDbType.Int), new SqlParameter("@TradeDate", SqlDbType.NVarChar), new SqlParameter("@TotalPrice", SqlDbType.Float), new SqlParameter("@Deposits", SqlDbType.Float), new SqlParameter("@UserName", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@State", SqlDbType.Int) };
            parm[0].Value = s.SalesReturnID;
            parm[1].Value = s.SalesOutID;
            parm[2].Value = s.CreateDate;
            parm[3].Value = s.ReturnType;
            parm[4].Value = s.StoreHouseID;
            parm[5].Value = s.HouseDetailID;
            parm[6].Value = s.TradeDate;
            parm[7].Value = s.TotalPrice;
            parm[8].Value = s.Deposits;
            parm[9].Value = s.UserName;
            parm[10].Value = s.Description;
            parm[11].Value = s.State;
            SQLHelper.RunProcedure("p_SalesReturn_insertNewEntity", parm, out rowsAffect);
            List<VSalesOutDetail> list = new List<VSalesOutDetail>();
            SalesReturnDetailDAL dl = new SalesReturnDetailDAL();
            list = new SalesOutDetailDAL().getBySalesOutID(s.SalesOutID);
            for (int i = 0; i < list.Count; i++)
            {
                VSalesOutDetail s0 = list[i];
                SalesReturnDetail v = new SalesReturnDetail {
                    Price = s0.Price,
                    ProductsID = s0.ProductsID,
                    Quantity = s0.Quantity,
                    Description = "",
                    SalesReturnID = s.SalesReturnID
                };
                dl.insertNewEitity(v);
            }
            return (1 == rowsAffect);
        }
    }
}

