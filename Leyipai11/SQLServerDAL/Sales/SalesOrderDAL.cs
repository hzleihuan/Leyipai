namespace Leyp.SQLServerDAL.Sales
{
    using Leyp.Model.Sales;
    using Leyp.SQLServerDAL;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class SalesOrderDAL
    {
        public bool AuditingOrder(string SalesOrderID, string UserName)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SalesOrderID", SqlDbType.NVarChar), new SqlParameter("@UserName", SqlDbType.NVarChar) };
            parm[0].Value = SalesOrderID;
            parm[1].Value = UserName;
            SQLHelper.RunProcedure("p_SalesOrder_AuditingOrder", parm, out rowsAffect);
            return (0 < rowsAffect);
        }

        public bool deleteEitity(string SalesOrderID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SalesOrderID", SqlDbType.NVarChar) };
            parm[0].Value = SalesOrderID;
            SQLHelper.RunProcedure("p_SalesOrder_deleteEitity", parm, out rowsAffect);
            return (0 < rowsAffect);
        }

        public VSalesOrder getByID(string SalesOrderID)
        {
            bool reslut = false;
            string cost = "";
            VSalesOrder item = new VSalesOrder();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SalesOrderID", SqlDbType.NVarChar) };
            parm[0].Value = SalesOrderID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_SalesOrder_getByID", parm);
            while (reader.Read())
            {
                cost = reader.GetValue(reader.GetOrdinal("SalesIncome")).ToString();
                item.SalesIncome = float.Parse(cost);
                item.AuditingUser = reader.GetString(reader.GetOrdinal("AuditingUser"));
                item.ClosingDate = reader.GetString(reader.GetOrdinal("ClosingDate"));
                item.RealName = reader.GetString(reader.GetOrdinal("RealName"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.ClosingType = reader.GetString(reader.GetOrdinal("ClosingType"));
                item.ShopID = reader.GetInt32(reader.GetOrdinal("ShopID"));
                item.SalesType = reader.GetInt32(reader.GetOrdinal("SalesType"));
                item.DeliveryPlace = reader.GetString(reader.GetOrdinal("DeliveryPlace"));
                item.DeliveryType = reader.GetString(reader.GetOrdinal("DeliveryType"));
                item.CreateDate = reader.GetString(reader.GetOrdinal("CreateDate"));
                item.SalesOrderID = reader.GetString(reader.GetOrdinal("SalesOrderID"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                cost = reader.GetValue(reader.GetOrdinal("AttachPay")).ToString();
                item.AttachPay = float.Parse(cost);
                cost = reader.GetValue(reader.GetOrdinal("Discount")).ToString();
                item.Discount = float.Parse(cost);
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                item.CustomerName = reader.GetString(reader.GetOrdinal("CustomerName"));
                item.CustomerPost = reader.GetString(reader.GetOrdinal("CustomerPost"));
                item.CustomerTel = reader.GetString(reader.GetOrdinal("CustomerTel"));
                item.CustomerArea = reader.GetString(reader.GetOrdinal("CustomerArea"));
                item.CustomerID = reader.GetString(reader.GetOrdinal("CustomerID"));
                item.PlatformName = reader.GetString(reader.GetOrdinal("PlatformName"));
                item.PlatformID = reader.GetInt32(reader.GetOrdinal("PlatformID"));
                reslut = true;
            }
            reader.Close();
            return (reslut ? item : null);
        }

        public List<VSalesOrder> getReportListByPlatformID(string beginDate, string endDate, int PlatformID)
        {
            string cost = "";
            List<VSalesOrder> list = new List<VSalesOrder>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@beginDate", SqlDbType.NVarChar), new SqlParameter("@endDate", SqlDbType.NVarChar), new SqlParameter("@PlatformID", SqlDbType.Int) };
            parm[0].Value = beginDate;
            parm[1].Value = endDate;
            parm[2].Value = PlatformID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_SalesOrder_getReportListByPlatformID", parm);
            while (reader.Read())
            {
                VSalesOrder item = new VSalesOrder();
                cost = reader.GetValue(reader.GetOrdinal("SalesIncome")).ToString();
                item.SalesIncome = float.Parse(cost);
                item.AuditingUser = reader.GetString(reader.GetOrdinal("AuditingUser"));
                item.ClosingDate = reader.GetString(reader.GetOrdinal("ClosingDate"));
                item.RealName = reader.GetString(reader.GetOrdinal("RealName"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.ClosingType = reader.GetString(reader.GetOrdinal("ClosingType"));
                item.ShopID = reader.GetInt32(reader.GetOrdinal("ShopID"));
                item.SalesType = reader.GetInt32(reader.GetOrdinal("SalesType"));
                item.DeliveryPlace = reader.GetString(reader.GetOrdinal("DeliveryPlace"));
                item.DeliveryType = reader.GetString(reader.GetOrdinal("DeliveryType"));
                item.CreateDate = reader.GetString(reader.GetOrdinal("CreateDate"));
                item.SalesOrderID = reader.GetString(reader.GetOrdinal("SalesOrderID"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                cost = reader.GetValue(reader.GetOrdinal("AttachPay")).ToString();
                item.AttachPay = float.Parse(cost);
                cost = reader.GetValue(reader.GetOrdinal("Discount")).ToString();
                item.Discount = float.Parse(cost);
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                item.CustomerName = reader.GetString(reader.GetOrdinal("CustomerName"));
                item.CustomerPost = reader.GetString(reader.GetOrdinal("CustomerPost"));
                item.CustomerTel = reader.GetString(reader.GetOrdinal("CustomerTel"));
                item.CustomerArea = reader.GetString(reader.GetOrdinal("CustomerArea"));
                item.CustomerID = reader.GetString(reader.GetOrdinal("CustomerID"));
                item.PlatformName = reader.GetString(reader.GetOrdinal("PlatformName"));
                item.PlatformID = reader.GetInt32(reader.GetOrdinal("PlatformID"));
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<VSalesOrder> getSearchList(string beginDate, string endDate, int sideState)
        {
            string cost = "";
            List<VSalesOrder> list = new List<VSalesOrder>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@beginDate", SqlDbType.NVarChar), new SqlParameter("@endDate", SqlDbType.NVarChar), new SqlParameter("@sideState", SqlDbType.Int) };
            parm[0].Value = beginDate;
            parm[1].Value = endDate;
            parm[2].Value = sideState;
            SqlDataReader reader = SQLHelper.RunProcedure("p_SalesOrder_getSearchList", parm);
            while (reader.Read())
            {
                VSalesOrder item = new VSalesOrder();
                cost = reader.GetValue(reader.GetOrdinal("SalesIncome")).ToString();
                item.SalesIncome = float.Parse(cost);
                item.AuditingUser = reader.GetString(reader.GetOrdinal("AuditingUser"));
                item.ClosingDate = reader.GetString(reader.GetOrdinal("ClosingDate"));
                item.RealName = reader.GetString(reader.GetOrdinal("RealName"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.ClosingType = reader.GetString(reader.GetOrdinal("ClosingType"));
                item.ShopID = reader.GetInt32(reader.GetOrdinal("ShopID"));
                item.SalesType = reader.GetInt32(reader.GetOrdinal("SalesType"));
                item.DeliveryPlace = reader.GetString(reader.GetOrdinal("DeliveryPlace"));
                item.DeliveryType = reader.GetString(reader.GetOrdinal("DeliveryType"));
                item.CreateDate = reader.GetString(reader.GetOrdinal("CreateDate"));
                item.SalesOrderID = reader.GetString(reader.GetOrdinal("SalesOrderID"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                cost = reader.GetValue(reader.GetOrdinal("AttachPay")).ToString();
                item.AttachPay = float.Parse(cost);
                cost = reader.GetValue(reader.GetOrdinal("Discount")).ToString();
                item.Discount = float.Parse(cost);
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                item.CustomerName = reader.GetString(reader.GetOrdinal("CustomerName"));
                item.CustomerPost = reader.GetString(reader.GetOrdinal("CustomerPost"));
                item.CustomerTel = reader.GetString(reader.GetOrdinal("CustomerTel"));
                item.CustomerArea = reader.GetString(reader.GetOrdinal("CustomerArea"));
                item.CustomerID = reader.GetString(reader.GetOrdinal("CustomerID"));
                item.PlatformName = reader.GetString(reader.GetOrdinal("PlatformName"));
                item.PlatformID = reader.GetInt32(reader.GetOrdinal("PlatformID"));
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<VSalesOrder> getSearchListByID(string SalesOrderID)
        {
            string cost = "";
            List<VSalesOrder> list = new List<VSalesOrder>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SalesOrderID", SqlDbType.NVarChar) };
            parm[0].Value = SalesOrderID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_SalesOrder_getSearchListByID", parm);
            while (reader.Read())
            {
                VSalesOrder item = new VSalesOrder();
                cost = reader.GetValue(reader.GetOrdinal("SalesIncome")).ToString();
                item.SalesIncome = float.Parse(cost);
                item.AuditingUser = reader.GetString(reader.GetOrdinal("AuditingUser"));
                item.ClosingDate = reader.GetString(reader.GetOrdinal("ClosingDate"));
                item.RealName = reader.GetString(reader.GetOrdinal("RealName"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.ClosingType = reader.GetString(reader.GetOrdinal("ClosingType"));
                item.ShopID = reader.GetInt32(reader.GetOrdinal("ShopID"));
                item.SalesType = reader.GetInt32(reader.GetOrdinal("SalesType"));
                item.DeliveryPlace = reader.GetString(reader.GetOrdinal("DeliveryPlace"));
                item.DeliveryType = reader.GetString(reader.GetOrdinal("DeliveryType"));
                item.CreateDate = reader.GetString(reader.GetOrdinal("CreateDate"));
                item.SalesOrderID = reader.GetString(reader.GetOrdinal("SalesOrderID"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                cost = reader.GetValue(reader.GetOrdinal("AttachPay")).ToString();
                item.AttachPay = float.Parse(cost);
                cost = reader.GetValue(reader.GetOrdinal("Discount")).ToString();
                item.Discount = float.Parse(cost);
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                item.CustomerName = reader.GetString(reader.GetOrdinal("CustomerName"));
                item.CustomerPost = reader.GetString(reader.GetOrdinal("CustomerPost"));
                item.CustomerTel = reader.GetString(reader.GetOrdinal("CustomerTel"));
                item.CustomerArea = reader.GetString(reader.GetOrdinal("CustomerArea"));
                item.CustomerID = reader.GetString(reader.GetOrdinal("CustomerID"));
                item.PlatformName = reader.GetString(reader.GetOrdinal("PlatformName"));
                item.PlatformID = reader.GetInt32(reader.GetOrdinal("PlatformID"));
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<VSalesOrder> getSearchListByUserName(string beginDate, string endDate, int sideState, string UserName)
        {
            string cost = "";
            List<VSalesOrder> list = new List<VSalesOrder>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@beginDate", SqlDbType.NVarChar), new SqlParameter("@endDate", SqlDbType.NVarChar), new SqlParameter("@sideState", SqlDbType.Int), new SqlParameter("@UserName", SqlDbType.NVarChar) };
            parm[0].Value = beginDate;
            parm[1].Value = endDate;
            parm[2].Value = sideState;
            parm[3].Value = UserName;
            SqlDataReader reader = SQLHelper.RunProcedure("p_SalesOrder_getSearchListByUserName", parm);
            while (reader.Read())
            {
                VSalesOrder item = new VSalesOrder();
                cost = reader.GetValue(reader.GetOrdinal("SalesIncome")).ToString();
                item.SalesIncome = float.Parse(cost);
                item.AuditingUser = reader.GetString(reader.GetOrdinal("AuditingUser"));
                item.ClosingDate = reader.GetString(reader.GetOrdinal("ClosingDate"));
                item.RealName = reader.GetString(reader.GetOrdinal("RealName"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.ClosingType = reader.GetString(reader.GetOrdinal("ClosingType"));
                item.ShopID = reader.GetInt32(reader.GetOrdinal("ShopID"));
                item.SalesType = reader.GetInt32(reader.GetOrdinal("SalesType"));
                item.DeliveryPlace = reader.GetString(reader.GetOrdinal("DeliveryPlace"));
                item.DeliveryType = reader.GetString(reader.GetOrdinal("DeliveryType"));
                item.CreateDate = reader.GetString(reader.GetOrdinal("CreateDate"));
                item.SalesOrderID = reader.GetString(reader.GetOrdinal("SalesOrderID"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                cost = reader.GetValue(reader.GetOrdinal("AttachPay")).ToString();
                item.AttachPay = float.Parse(cost);
                cost = reader.GetValue(reader.GetOrdinal("Discount")).ToString();
                item.Discount = float.Parse(cost);
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                item.CustomerName = reader.GetString(reader.GetOrdinal("CustomerName"));
                item.CustomerPost = reader.GetString(reader.GetOrdinal("CustomerPost"));
                item.CustomerTel = reader.GetString(reader.GetOrdinal("CustomerTel"));
                item.CustomerArea = reader.GetString(reader.GetOrdinal("CustomerArea"));
                item.CustomerID = reader.GetString(reader.GetOrdinal("CustomerID"));
                item.PlatformName = reader.GetString(reader.GetOrdinal("PlatformName"));
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public bool insertNewEntity(SalesOrder s)
        {
            int rowsAffect = 0;
            float total = float.Parse("0.00");
            SqlParameter[] parm = new SqlParameter[] { 
                new SqlParameter("@SalesOrderID", SqlDbType.NVarChar), new SqlParameter("@CreateDate", SqlDbType.NVarChar), new SqlParameter("@SalesType", SqlDbType.Int), new SqlParameter("@ShopID", SqlDbType.Int), new SqlParameter("@CustomerID", SqlDbType.NVarChar), new SqlParameter("@DeliveryType", SqlDbType.NVarChar), new SqlParameter("@DeliveryPlace", SqlDbType.NVarChar), new SqlParameter("@ClosingType", SqlDbType.NVarChar), new SqlParameter("@ClosingDate", SqlDbType.NVarChar), new SqlParameter("@SalesIncome", SqlDbType.Float), new SqlParameter("@UserName", SqlDbType.NVarChar), new SqlParameter("@State", SqlDbType.Int), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@AttachPay", SqlDbType.Float), new SqlParameter("@Discount", SqlDbType.Float), new SqlParameter("@CustomerName", SqlDbType.NVarChar), 
                new SqlParameter("@CustomerTel", SqlDbType.NVarChar), new SqlParameter("@CustomerPost", SqlDbType.NVarChar), new SqlParameter("@CustomerArea", SqlDbType.NVarChar), new SqlParameter("@PlatformID", SqlDbType.Int)
             };
            parm[0].Value = s.SalesOrderID;
            parm[1].Value = s.CreateDate;
            parm[2].Value = s.SalesType;
            parm[3].Value = s.ShopID;
            parm[4].Value = s.CustomerID;
            parm[5].Value = s.DeliveryType;
            parm[6].Value = s.DeliveryPlace;
            parm[7].Value = s.ClosingType;
            parm[8].Value = s.ClosingDate;
            parm[9].Value = (new SalesDetailDAL().getInitTotal(s.SalesOrderID) + s.AttachPay) - s.Discount;
            parm[10].Value = s.UserName;
            parm[11].Value = s.State;
            parm[12].Value = s.Description;
            parm[13].Value = s.AttachPay;
            parm[14].Value = s.Discount;
            parm[15].Value = s.CustomerName;
            parm[0x10].Value = s.CustomerTel;
            parm[0x11].Value = s.CustomerPost;
            parm[0x12].Value = s.CustomerArea;
            parm[0x13].Value = s.PlatformID;
            SQLHelper.RunProcedure("p_SalesOrder_insertNewEntity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public bool rAuditingOrder(string SalesOrderID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SalesOrderID", SqlDbType.NVarChar) };
            parm[0].Value = SalesOrderID;
            SQLHelper.RunProcedure("p_SalesOrder_rAuditingOrder", parm, out rowsAffect);
            return (0 < rowsAffect);
        }

        public bool updateCustomerInfo(SalesOrder s)
        {
            int rowsAffect = 0;
            float total = float.Parse("0.00");
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SalesOrderID", SqlDbType.NVarChar), new SqlParameter("@AttachPay", SqlDbType.Float), new SqlParameter("@Discount", SqlDbType.Float), new SqlParameter("@CustomerName", SqlDbType.NVarChar), new SqlParameter("@CustomerTel", SqlDbType.NVarChar), new SqlParameter("@CustomerPost", SqlDbType.NVarChar), new SqlParameter("@CustomerArea", SqlDbType.NVarChar), new SqlParameter("@PlatformID", SqlDbType.Int), new SqlParameter("@CustomerID", SqlDbType.NVarChar) };
            parm[0].Value = s.SalesOrderID;
            parm[1].Value = s.AttachPay;
            parm[2].Value = s.Discount;
            parm[3].Value = s.CustomerName;
            parm[4].Value = s.CustomerTel;
            parm[5].Value = s.CustomerPost;
            parm[6].Value = s.CustomerArea;
            parm[7].Value = s.PlatformID;
            parm[8].Value = s.CustomerID;
            SQLHelper.RunProcedure("p_SalesOrder_updateCustomerInfo", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public bool updatePayInfo(string SalesOrderID, string payInfo)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SalesOrderID", SqlDbType.NVarChar), new SqlParameter("@payInfo", SqlDbType.NVarChar) };
            parm[0].Value = SalesOrderID;
            parm[1].Value = payInfo;
            SQLHelper.RunProcedure("p_SalesOrder_updatePayInfo", parm, out rowsAffect);
            return (0 < rowsAffect);
        }

        public bool updateSate(int State, string SalesOrderID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@State", SqlDbType.Int), new SqlParameter("@SalesOrderID", SqlDbType.NVarChar) };
            parm[0].Value = State;
            parm[1].Value = SalesOrderID;
            SQLHelper.RunProcedure("p_SalesOrder_updateSate", parm, out rowsAffect);
            return (0 < rowsAffect);
        }
    }
}

