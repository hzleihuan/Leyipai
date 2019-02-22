namespace Leyp.SQLServerDAL.Stock
{
    using Leyp.Model.Stock;
    using Leyp.SQLServerDAL;
    using Leyp.SQLServerDAL.Service;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class AppendStockDAL
    {
        public bool AuditingOrder(string AppendID, string UserName)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@AppendID", SqlDbType.NVarChar), new SqlParameter("@UserName", SqlDbType.NVarChar) };
            parm[0].Value = AppendID;
            parm[1].Value = UserName;
            SQLHelper.RunProcedure("p_AppendStock_AuditingOrder", parm, out rowsAffect);
            new AppendStockService().AuditingAppendStockOrder(AppendID);
            return (0 < rowsAffect);
        }

        public bool deleteEitity(string AppendID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@AppendID", SqlDbType.NVarChar) };
            parm[0].Value = AppendID;
            SQLHelper.RunProcedure("p_AppendStock_deleteEitity", parm, out rowsAffect);
            return (0 < rowsAffect);
        }

        public VAppendStock getByID(string AppendID)
        {
            string cost = "";
            VAppendStock item = new VAppendStock();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@AppendID", SqlDbType.NVarChar) };
            parm[0].Value = AppendID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_AppendStock_getByID", parm);
            while (reader.Read())
            {
                cost = reader.GetValue(reader.GetOrdinal("AlreadyPay")).ToString();
                item.AlreadyPay = float.Parse(cost);
                item.AppendID = reader.GetString(reader.GetOrdinal("AppendID"));
                item.CreateDate = reader.GetString(reader.GetOrdinal("CreateDate"));
                item.RealName = reader.GetString(reader.GetOrdinal("RealName"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.AppendType = reader.GetInt32(reader.GetOrdinal("AppendType"));
                item.HouseDetailID = reader.GetInt32(reader.GetOrdinal("HouseDetailID"));
                item.StoreHouseID = reader.GetInt32(reader.GetOrdinal("StoreHouseID"));
                cost = reader.GetValue(reader.GetOrdinal("TotalPrice")).ToString();
                item.TotalPrice = float.Parse(cost);
                item.SubareaName = reader.GetString(reader.GetOrdinal("SubareaName"));
                item.HouseName = reader.GetString(reader.GetOrdinal("HouseName"));
                item.TradeDate = reader.GetString(reader.GetOrdinal("TradeDate"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
            }
            reader.Close();
            return item;
        }

        public List<VAppendStock> getSearchList(string beginDate, string endDate, int sideState)
        {
            string cost = "";
            List<VAppendStock> list = new List<VAppendStock>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@beginDate", SqlDbType.NVarChar), new SqlParameter("@endDate", SqlDbType.NVarChar), new SqlParameter("@sideState", SqlDbType.Int) };
            parm[0].Value = beginDate;
            parm[1].Value = endDate;
            parm[2].Value = sideState;
            SqlDataReader reader = SQLHelper.RunProcedure("p_AppendStock_getSearchList", parm);
            while (reader.Read())
            {
                VAppendStock item = new VAppendStock();
                cost = reader.GetValue(reader.GetOrdinal("AlreadyPay")).ToString();
                item.AlreadyPay = float.Parse(cost);
                item.AppendID = reader.GetString(reader.GetOrdinal("AppendID"));
                item.CreateDate = reader.GetString(reader.GetOrdinal("CreateDate"));
                item.RealName = reader.GetString(reader.GetOrdinal("RealName"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.AppendType = reader.GetInt32(reader.GetOrdinal("AppendType"));
                item.HouseDetailID = reader.GetInt32(reader.GetOrdinal("HouseDetailID"));
                item.StoreHouseID = reader.GetInt32(reader.GetOrdinal("StoreHouseID"));
                cost = reader.GetValue(reader.GetOrdinal("TotalPrice")).ToString();
                item.TotalPrice = float.Parse(cost);
                item.SubareaName = reader.GetString(reader.GetOrdinal("SubareaName"));
                item.HouseName = reader.GetString(reader.GetOrdinal("HouseName"));
                item.TradeDate = reader.GetString(reader.GetOrdinal("TradeDate"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<VAppendStock> getSearchListByID(string AppendID)
        {
            string cost = "";
            List<VAppendStock> list = new List<VAppendStock>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@AppendID", SqlDbType.NVarChar) };
            parm[0].Value = AppendID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_AppendStock_getSearchListByID", parm);
            while (reader.Read())
            {
                VAppendStock item = new VAppendStock();
                cost = reader.GetValue(reader.GetOrdinal("AlreadyPay")).ToString();
                item.AlreadyPay = float.Parse(cost);
                item.AppendID = reader.GetString(reader.GetOrdinal("AppendID"));
                item.CreateDate = reader.GetString(reader.GetOrdinal("CreateDate"));
                item.RealName = reader.GetString(reader.GetOrdinal("RealName"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.AppendType = reader.GetInt32(reader.GetOrdinal("AppendType"));
                item.HouseDetailID = reader.GetInt32(reader.GetOrdinal("HouseDetailID"));
                item.StoreHouseID = reader.GetInt32(reader.GetOrdinal("StoreHouseID"));
                cost = reader.GetValue(reader.GetOrdinal("TotalPrice")).ToString();
                item.TotalPrice = float.Parse(cost);
                item.SubareaName = reader.GetString(reader.GetOrdinal("SubareaName"));
                item.HouseName = reader.GetString(reader.GetOrdinal("HouseName"));
                item.TradeDate = reader.GetString(reader.GetOrdinal("TradeDate"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public bool insertNewEntity(AppendStock s)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@AppendID", SqlDbType.NVarChar), new SqlParameter("@AppendType", SqlDbType.Int), new SqlParameter("@StoreHouseID", SqlDbType.Int), new SqlParameter("@HouseDetailID", SqlDbType.Int), new SqlParameter("@UserName", SqlDbType.NVarChar), new SqlParameter("@TradeDate", SqlDbType.NVarChar), new SqlParameter("@TotalPrice", SqlDbType.Float), new SqlParameter("@AlreadyPay", SqlDbType.Float), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@State", SqlDbType.Int), new SqlParameter("@CreateDate", SqlDbType.NVarChar) };
            parm[0].Value = s.AppendID;
            parm[1].Value = s.AppendType;
            parm[2].Value = s.StoreHouseID;
            parm[3].Value = s.HouseDetailID;
            parm[4].Value = s.UserName;
            parm[5].Value = s.TradeDate;
            parm[6].Value = s.TotalPrice;
            parm[7].Value = s.AlreadyPay;
            parm[8].Value = s.Description;
            parm[9].Value = s.State;
            parm[10].Value = s.CreateDate;
            SQLHelper.RunProcedure("p_AppendStock_insertNewEntity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }
    }
}

