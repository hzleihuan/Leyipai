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
    public class BuyOrderDAL
    {
        public bool auditingBuyOrderByID(string BuyOrderID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@BuyOrderID", SqlDbType.NVarChar) };
            parm[0].Value = BuyOrderID;
            SQLHelper.RunProcedure("p_BuyOrder_AuditingBuyOrderByID", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public bool deleteBuyOrder(string BuyOrderID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@BuyOrderID", SqlDbType.NVarChar) };
            parm[0].Value = BuyOrderID;
            SQLHelper.RunProcedure("p_BuyOrder_deleteBuyOrder", parm, out rowsAffect);
            return (0 < rowsAffect);
        }

        public bool deleteEntity()
        {
            return false;
        }

        public List<VBuyOrder> getAdminBuyOrderByBuyOrderID(string BuyOrderID)
        {
            string cost = "";
            List<VBuyOrder> list = new List<VBuyOrder>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@BuyOrderID", SqlDbType.NVarChar) };
            parm[0].Value = BuyOrderID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_BuyOrder_getAdminBuyOrderByBuyOrderID", parm);
            while (reader.Read())
            {
                VBuyOrder item = new VBuyOrder {
                    BuyOrderDate = reader.GetString(reader.GetOrdinal("BuyOrderDate")),
                    BuyOrderID = reader.GetString(reader.GetOrdinal("BuyOrderID")),
                    Delegate = reader.GetString(reader.GetOrdinal("Delegate")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    HouseDetailID = reader.GetInt32(reader.GetOrdinal("HouseDetailID")),
                    RealName = reader.GetString(reader.GetOrdinal("RealName")),
                    SignDate = reader.GetString(reader.GetOrdinal("SignDate")),
                    State = reader.GetInt32(reader.GetOrdinal("State")),
                    StoreHouseID = reader.GetInt32(reader.GetOrdinal("StoreHouseID"))
                };
                cost = reader.GetValue(reader.GetOrdinal("TotalPrice")).ToString();
                item.TotalPrice = float.Parse(cost);
                item.TradeAddress = reader.GetString(reader.GetOrdinal("TradeAddress"));
                item.TradeDate = reader.GetString(reader.GetOrdinal("TradeDate"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                item.HouseName = reader.GetString(reader.GetOrdinal("HouseName"));
                item.SubareaName = reader.GetString(reader.GetOrdinal("SubareaName"));
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<VBuyOrder> getAdminBuyOrderList(string beginDate, string endDate, int sideState, int Identitys)
        {
            string cost = "";
            List<VBuyOrder> list = new List<VBuyOrder>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@beginDate", SqlDbType.NVarChar), new SqlParameter("@endDate", SqlDbType.NVarChar), new SqlParameter("@sideState", SqlDbType.Int), new SqlParameter("@Identitys", SqlDbType.Int) };
            parm[0].Value = beginDate;
            parm[1].Value = endDate;
            parm[2].Value = sideState;
            parm[3].Value = Identitys;
            SqlDataReader reader = SQLHelper.RunProcedure("p_BuyOrder_getAdminBuyOrderList", parm);
            while (reader.Read())
            {
                VBuyOrder item = new VBuyOrder {
                    BuyOrderDate = reader.GetString(reader.GetOrdinal("BuyOrderDate")),
                    BuyOrderID = reader.GetString(reader.GetOrdinal("BuyOrderID")),
                    Delegate = reader.GetString(reader.GetOrdinal("Delegate")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    HouseDetailID = reader.GetInt32(reader.GetOrdinal("HouseDetailID")),
                    RealName = reader.GetString(reader.GetOrdinal("RealName")),
                    SignDate = reader.GetString(reader.GetOrdinal("SignDate")),
                    State = reader.GetInt32(reader.GetOrdinal("State")),
                    StoreHouseID = reader.GetInt32(reader.GetOrdinal("StoreHouseID"))
                };
                cost = reader.GetValue(reader.GetOrdinal("TotalPrice")).ToString();
                item.TotalPrice = float.Parse(cost);
                item.TradeAddress = reader.GetString(reader.GetOrdinal("TradeAddress"));
                item.TradeDate = reader.GetString(reader.GetOrdinal("TradeDate"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                item.HouseName = reader.GetString(reader.GetOrdinal("HouseName"));
                item.SubareaName = reader.GetString(reader.GetOrdinal("SubareaName"));
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<VBuyOrder> getBetweenTwoDate(string beginDate, string endDate, int State, int Identitys)
        {
            string cost = "";
            List<VBuyOrder> list = new List<VBuyOrder>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@beginDate", SqlDbType.NVarChar), new SqlParameter("@endDate", SqlDbType.NVarChar), new SqlParameter("@State", SqlDbType.Int), new SqlParameter("@Identitys", SqlDbType.Int) };
            parm[0].Value = beginDate;
            parm[1].Value = endDate;
            parm[2].Value = State;
            parm[3].Value = Identitys;
            SqlDataReader reader = SQLHelper.RunProcedure("p_BuyOrder_getBetweenTwoDate", parm);
            while (reader.Read())
            {
                VBuyOrder item = new VBuyOrder {
                    BuyOrderDate = reader.GetString(reader.GetOrdinal("BuyOrderDate")),
                    BuyOrderID = reader.GetString(reader.GetOrdinal("BuyOrderID")),
                    Delegate = reader.GetString(reader.GetOrdinal("Delegate")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    HouseDetailID = reader.GetInt32(reader.GetOrdinal("HouseDetailID")),
                    Identitys = reader.GetInt32(reader.GetOrdinal("Identitys")),
                    SignDate = reader.GetString(reader.GetOrdinal("SignDate")),
                    State = reader.GetInt32(reader.GetOrdinal("State")),
                    StoreHouseID = reader.GetInt32(reader.GetOrdinal("StoreHouseID"))
                };
                cost = reader.GetValue(reader.GetOrdinal("TotalPrice")).ToString();
                item.TotalPrice = float.Parse(cost);
                item.TradeAddress = reader.GetString(reader.GetOrdinal("TradeAddress"));
                item.TradeDate = reader.GetString(reader.GetOrdinal("TradeDate"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                item.HouseName = reader.GetString(reader.GetOrdinal("HouseName"));
                item.SubareaName = reader.GetString(reader.GetOrdinal("SubareaName"));
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public VBuyOrder getByID(string BuyOrderID)
        {
            string cost = "";
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@BuyOrderID", SqlDbType.NVarChar) };
            parm[0].Value = BuyOrderID;
            VBuyOrder item = new VBuyOrder();
            SqlDataReader reader = SQLHelper.RunProcedure("p_BuyOrder_getByID", parm);
            if (reader.Read())
            {
                item.BuyOrderDate = reader.GetString(reader.GetOrdinal("BuyOrderDate"));
                item.BuyOrderID = reader.GetString(reader.GetOrdinal("BuyOrderID"));
                item.Delegate = reader.GetString(reader.GetOrdinal("Delegate"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.HouseDetailID = reader.GetInt32(reader.GetOrdinal("HouseDetailID"));
                item.Identitys = reader.GetInt32(reader.GetOrdinal("Identitys"));
                item.SignDate = reader.GetString(reader.GetOrdinal("SignDate"));
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                item.StoreHouseID = reader.GetInt32(reader.GetOrdinal("StoreHouseID"));
                cost = reader.GetValue(reader.GetOrdinal("TotalPrice")).ToString();
                item.TotalPrice = float.Parse(cost);
                item.TradeAddress = reader.GetString(reader.GetOrdinal("TradeAddress"));
                item.TradeDate = reader.GetString(reader.GetOrdinal("TradeDate"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                item.HouseName = reader.GetString(reader.GetOrdinal("HouseName"));
                item.SubareaName = reader.GetString(reader.GetOrdinal("SubareaName"));
                item.RealName = reader.GetString(reader.GetOrdinal("RealName"));
            }
            reader.Close();
            return item;
        }

        public List<VBuyOrder> getUserBuyOrderByBuyOrderID(string UserName, string BuyOrderID)
        {
            string cost = "";
            List<VBuyOrder> list = new List<VBuyOrder>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@UserName", SqlDbType.NVarChar), new SqlParameter("@BuyOrderID", SqlDbType.NVarChar) };
            parm[0].Value = UserName;
            parm[1].Value = BuyOrderID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_BuyOrder_getUserBuyOrderByBuyOrderID", parm);
            while (reader.Read())
            {
                VBuyOrder item = new VBuyOrder {
                    BuyOrderDate = reader.GetString(reader.GetOrdinal("BuyOrderDate")),
                    BuyOrderID = reader.GetString(reader.GetOrdinal("BuyOrderID")),
                    Delegate = reader.GetString(reader.GetOrdinal("Delegate")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    HouseDetailID = reader.GetInt32(reader.GetOrdinal("HouseDetailID")),
                    Identitys = reader.GetInt32(reader.GetOrdinal("Identitys")),
                    SignDate = reader.GetString(reader.GetOrdinal("SignDate")),
                    State = reader.GetInt32(reader.GetOrdinal("State")),
                    StoreHouseID = reader.GetInt32(reader.GetOrdinal("StoreHouseID"))
                };
                cost = reader.GetValue(reader.GetOrdinal("TotalPrice")).ToString();
                item.TotalPrice = float.Parse(cost);
                item.TradeAddress = reader.GetString(reader.GetOrdinal("TradeAddress"));
                item.TradeDate = reader.GetString(reader.GetOrdinal("TradeDate"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                item.HouseName = reader.GetString(reader.GetOrdinal("HouseName"));
                item.SubareaName = reader.GetString(reader.GetOrdinal("SubareaName"));
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<VBuyOrder> getUserOrderList(string UserName, string beginDate, string endDate, int sideState, int Identitys)
        {
            string cost = "";
            List<VBuyOrder> list = new List<VBuyOrder>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@UserName", SqlDbType.NVarChar), new SqlParameter("@beginDate", SqlDbType.NVarChar), new SqlParameter("@endDate", SqlDbType.NVarChar), new SqlParameter("@sideState", SqlDbType.Int), new SqlParameter("@Identitys", SqlDbType.Int) };
            parm[0].Value = UserName;
            parm[1].Value = beginDate;
            parm[2].Value = endDate;
            parm[3].Value = sideState;
            parm[4].Value = Identitys;
            SqlDataReader reader = SQLHelper.RunProcedure("p_BuyOrder_getUserBuyOrderList", parm);
            while (reader.Read())
            {
                VBuyOrder item = new VBuyOrder {
                    BuyOrderDate = reader.GetString(reader.GetOrdinal("BuyOrderDate")),
                    BuyOrderID = reader.GetString(reader.GetOrdinal("BuyOrderID")),
                    Delegate = reader.GetString(reader.GetOrdinal("Delegate")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    HouseDetailID = reader.GetInt32(reader.GetOrdinal("HouseDetailID")),
                    Identitys = reader.GetInt32(reader.GetOrdinal("Identitys")),
                    SignDate = reader.GetString(reader.GetOrdinal("SignDate")),
                    State = reader.GetInt32(reader.GetOrdinal("State")),
                    StoreHouseID = reader.GetInt32(reader.GetOrdinal("StoreHouseID"))
                };
                cost = reader.GetValue(reader.GetOrdinal("TotalPrice")).ToString();
                item.TotalPrice = float.Parse(cost);
                item.TradeAddress = reader.GetString(reader.GetOrdinal("TradeAddress"));
                item.TradeDate = reader.GetString(reader.GetOrdinal("TradeDate"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                item.HouseName = reader.GetString(reader.GetOrdinal("HouseName"));
                item.SubareaName = reader.GetString(reader.GetOrdinal("SubareaName"));
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public bool insertNewEntity(BuyOrder b)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@BuyOrderID", SqlDbType.NVarChar), new SqlParameter("@BuyOrderDate", SqlDbType.NVarChar), new SqlParameter("@StoreHouseID", SqlDbType.Int), new SqlParameter("@HouseDetailID", SqlDbType.Int), new SqlParameter("@Delegate", SqlDbType.NVarChar), new SqlParameter("@UserName", SqlDbType.NVarChar), new SqlParameter("@TotalPrice", SqlDbType.Money), new SqlParameter("@SignDate", SqlDbType.NVarChar), new SqlParameter("@TradeDate", SqlDbType.NVarChar), new SqlParameter("@TradeAddress", SqlDbType.NVarChar), new SqlParameter("@Identitys", SqlDbType.Int), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@State", SqlDbType.Int) };
            parm[0].Value = b.BuyOrderID;
            parm[1].Value = b.BuyOrderDate;
            parm[2].Value = b.StoreHouseID;
            parm[3].Value = b.HouseDetailID;
            parm[4].Value = b.Delegate;
            parm[5].Value = b.UserName;
            parm[6].Value = b.TotalPrice;
            parm[7].Value = b.SignDate;
            parm[8].Value = b.TradeDate;
            parm[9].Value = b.TradeAddress;
            parm[10].Value = b.Identitys;
            parm[11].Value = b.Description;
            parm[12].Value = b.State;
            SQLHelper.RunProcedure("p_BuyOrder_insertNewEntity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public bool rAuditingBuyOrderByID(string BuyOrderID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@BuyOrderID", SqlDbType.NVarChar) };
            parm[0].Value = BuyOrderID;
            SQLHelper.RunProcedure("p_BuyOrder_rAuditingBuyOrderByID", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public bool updateEntity(BuyOrder b)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@BuyOrderID", SqlDbType.NVarChar), new SqlParameter("@StoreHouseID", SqlDbType.Int), new SqlParameter("@HouseDetailID", SqlDbType.Int), new SqlParameter("@Delegate", SqlDbType.NVarChar), new SqlParameter("@TotalPrice", SqlDbType.Money), new SqlParameter("@SignDate", SqlDbType.NVarChar), new SqlParameter("@TradeDate", SqlDbType.NVarChar), new SqlParameter("@TradeAddress", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar) };
            parm[0].Value = b.BuyOrderID;
            parm[1].Value = b.StoreHouseID;
            parm[2].Value = b.HouseDetailID;
            parm[3].Value = b.Delegate;
            parm[4].Value = b.TotalPrice;
            parm[5].Value = b.SignDate;
            parm[6].Value = b.TradeDate;
            parm[7].Value = b.TradeAddress;
            parm[8].Value = b.Description;
            SQLHelper.RunProcedure("p_BuyOrder_updateEntity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        protected bool userDeleteSelfBuyOrder(string UserName, string BuyOrderID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@UserName", SqlDbType.NVarChar), new SqlParameter("@BuyOrderID", SqlDbType.NVarChar) };
            parm[0].Value = UserName;
            parm[1].Value = BuyOrderID;
            SQLHelper.RunProcedure("p_BuyOrder_userDeleteSelfBuyOrder", parm, out rowsAffect);
            return (0 < rowsAffect);
        }
    }
}

