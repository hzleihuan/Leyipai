namespace Leyp.SQLServerDAL.Sales
{
    using Leyp.Model.Sales;
    using Leyp.SQLServerDAL;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class SalesDispatchDAL
    {
        public bool deleteEitity(int DispatchID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@DispatchID", SqlDbType.Int) };
            parm[0].Value = DispatchID;
            SQLHelper.RunProcedure("p_SalesDispatch_deleteEitity", parm, out rowsAffect);
            return (0 < rowsAffect);
        }

        public List<VSalesDispatch> getByConsignorByDeliveryDate(string beginDate, string endDate, int sideState, string Consignor)
        {
            List<VSalesDispatch> list = new List<VSalesDispatch>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@beginDate", SqlDbType.NVarChar), new SqlParameter("@endDate", SqlDbType.NVarChar), new SqlParameter("@Consignor", SqlDbType.NVarChar), new SqlParameter("@sideState", SqlDbType.Int) };
            parm[0].Value = beginDate;
            parm[1].Value = endDate;
            parm[2].Value = Consignor;
            parm[3].Value = sideState;
            SqlDataReader reader = SQLHelper.RunProcedure("p_SalesDispatch_getByConsignorByDeliveryDate", parm);
            while (reader.Read())
            {
                VSalesDispatch item = new VSalesDispatch {
                    Consignor = reader.GetString(reader.GetOrdinal("Consignor")),
                    CreateDate = reader.GetString(reader.GetOrdinal("CreateDate")),
                    DeliveryDate = reader.GetString(reader.GetOrdinal("DeliveryDate")),
                    DeliveryType = reader.GetString(reader.GetOrdinal("DeliveryType")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    DispatchID = reader.GetInt32(reader.GetOrdinal("DispatchID")),
                    RealName = reader.GetString(reader.GetOrdinal("RealName")),
                    SalesOrderID = reader.GetString(reader.GetOrdinal("SalesOrderID")),
                    SalesOutID = reader.GetString(reader.GetOrdinal("SalesOutID")),
                    SentDate = reader.GetString(reader.GetOrdinal("SentDate")),
                    State = reader.GetInt32(reader.GetOrdinal("State")),
                    UserName = reader.GetString(reader.GetOrdinal("UserName")),
                    DeliveryName = reader.GetString(reader.GetOrdinal("DeliveryName"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<VSalesDispatch> getByDeliveryDate(string beginDate, string endDate, int sideState)
        {
            List<VSalesDispatch> list = new List<VSalesDispatch>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@beginDate", SqlDbType.NVarChar), new SqlParameter("@endDate", SqlDbType.NVarChar), new SqlParameter("@sideState", SqlDbType.Int) };
            parm[0].Value = beginDate;
            parm[1].Value = endDate;
            parm[2].Value = sideState;
            SqlDataReader reader = SQLHelper.RunProcedure("p_SalesDispatch_getByDeliveryDate", parm);
            while (reader.Read())
            {
                VSalesDispatch item = new VSalesDispatch {
                    Consignor = reader.GetString(reader.GetOrdinal("Consignor")),
                    CreateDate = reader.GetString(reader.GetOrdinal("CreateDate")),
                    DeliveryDate = reader.GetString(reader.GetOrdinal("DeliveryDate")),
                    DeliveryType = reader.GetString(reader.GetOrdinal("DeliveryType")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    DispatchID = reader.GetInt32(reader.GetOrdinal("DispatchID")),
                    RealName = reader.GetString(reader.GetOrdinal("RealName")),
                    SalesOrderID = reader.GetString(reader.GetOrdinal("SalesOrderID")),
                    SalesOutID = reader.GetString(reader.GetOrdinal("SalesOutID")),
                    SentDate = reader.GetString(reader.GetOrdinal("SentDate")),
                    State = reader.GetInt32(reader.GetOrdinal("State")),
                    UserName = reader.GetString(reader.GetOrdinal("UserName")),
                    DeliveryName = reader.GetString(reader.GetOrdinal("DeliveryName"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<VSalesDispatch> getByDeliveryType(int DeliveryID, int sideState, int PrintFlag)
        {
            List<VSalesDispatch> list = new List<VSalesDispatch>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@DeliveryID", SqlDbType.Int), new SqlParameter("@sideState", SqlDbType.Int), new SqlParameter("@PrintFlag", SqlDbType.Int) };
            parm[0].Value = DeliveryID;
            parm[1].Value = sideState;
            parm[2].Value = PrintFlag;
            SqlDataReader reader = SQLHelper.RunProcedure("p_SalesDispatch_getByDeliveryType", parm);
            while (reader.Read())
            {
                VSalesDispatch item = new VSalesDispatch {
                    Consignor = reader.GetString(reader.GetOrdinal("Consignor")),
                    CreateDate = reader.GetString(reader.GetOrdinal("CreateDate")),
                    DeliveryDate = reader.GetString(reader.GetOrdinal("DeliveryDate")),
                    DeliveryType = reader.GetString(reader.GetOrdinal("DeliveryType")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    DispatchID = reader.GetInt32(reader.GetOrdinal("DispatchID")),
                    RealName = reader.GetString(reader.GetOrdinal("RealName")),
                    SalesOrderID = reader.GetString(reader.GetOrdinal("SalesOrderID")),
                    SalesOutID = reader.GetString(reader.GetOrdinal("SalesOutID")),
                    SentDate = reader.GetString(reader.GetOrdinal("SentDate")),
                    State = reader.GetInt32(reader.GetOrdinal("State")),
                    UserName = reader.GetString(reader.GetOrdinal("UserName")),
                    DeliveryName = reader.GetString(reader.GetOrdinal("DeliveryName"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public VSalesDispatch getByID(int DispatchID)
        {
            bool result = false;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@DispatchID", SqlDbType.Int) };
            parm[0].Value = DispatchID;
            VSalesDispatch item = new VSalesDispatch();
            SqlDataReader reader = SQLHelper.RunProcedure("p_SalesDispatch_getByID", parm);
            if (reader.Read())
            {
                item.Consignor = reader.GetString(reader.GetOrdinal("Consignor"));
                item.CreateDate = reader.GetString(reader.GetOrdinal("CreateDate"));
                item.DeliveryDate = reader.GetString(reader.GetOrdinal("DeliveryDate"));
                item.DeliveryType = reader.GetString(reader.GetOrdinal("DeliveryType"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.DispatchID = reader.GetInt32(reader.GetOrdinal("DispatchID"));
                item.RealName = reader.GetString(reader.GetOrdinal("RealName"));
                item.SalesOrderID = reader.GetString(reader.GetOrdinal("SalesOrderID"));
                item.SalesOutID = reader.GetString(reader.GetOrdinal("SalesOutID"));
                item.SentDate = reader.GetString(reader.GetOrdinal("SentDate"));
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                item.DeliveryName = reader.GetString(reader.GetOrdinal("DeliveryName"));
                result = true;
            }
            reader.Close();
            return (result ? item : null);
        }

        public VSalesDispatch getBySalesOrderID(string SalesOrderID)
        {
            bool result = false;
            VSalesDispatch item = new VSalesDispatch();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SalesOrderID", SqlDbType.NVarChar) };
            parm[0].Value = SalesOrderID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_SalesDispatch_getBySalesOrderID", parm);
            while (reader.Read())
            {
                item.Consignor = reader.GetString(reader.GetOrdinal("Consignor"));
                item.CreateDate = reader.GetString(reader.GetOrdinal("CreateDate"));
                item.DeliveryDate = reader.GetString(reader.GetOrdinal("DeliveryDate"));
                item.DeliveryType = reader.GetString(reader.GetOrdinal("DeliveryType"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.DispatchID = reader.GetInt32(reader.GetOrdinal("DispatchID"));
                item.RealName = reader.GetString(reader.GetOrdinal("RealName"));
                item.SalesOrderID = reader.GetString(reader.GetOrdinal("SalesOrderID"));
                item.SalesOutID = reader.GetString(reader.GetOrdinal("SalesOutID"));
                item.SentDate = reader.GetString(reader.GetOrdinal("SentDate"));
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                item.DeliveryName = reader.GetString(reader.GetOrdinal("DeliveryName"));
                result = true;
            }
            reader.Close();
            return (result ? item : null);
        }

        public VSalesDispatch getBySalesOutID(string SalesOutID)
        {
            bool result = false;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SalesOutID", SqlDbType.NVarChar) };
            parm[0].Value = SalesOutID;
            VSalesDispatch item = new VSalesDispatch();
            SqlDataReader reader = SQLHelper.RunProcedure("p_SalesDispatch_getBySalesOutID", parm);
            if (reader.Read())
            {
                item.Consignor = reader.GetString(reader.GetOrdinal("Consignor"));
                item.CreateDate = reader.GetString(reader.GetOrdinal("CreateDate"));
                item.DeliveryDate = reader.GetString(reader.GetOrdinal("DeliveryDate"));
                item.DeliveryType = reader.GetString(reader.GetOrdinal("DeliveryType"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.DispatchID = reader.GetInt32(reader.GetOrdinal("DispatchID"));
                item.RealName = reader.GetString(reader.GetOrdinal("RealName"));
                item.SalesOrderID = reader.GetString(reader.GetOrdinal("SalesOrderID"));
                item.SalesOutID = reader.GetString(reader.GetOrdinal("SalesOutID"));
                item.SentDate = reader.GetString(reader.GetOrdinal("SentDate"));
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                item.DeliveryName = reader.GetString(reader.GetOrdinal("DeliveryName"));
                result = true;
            }
            reader.Close();
            return (result ? item : null);
        }

        public DataSet getDataForPrintByDeliveryID(int DeliveryID)
        {
            DataSet ds = new DataSet();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@DeliveryID", SqlDbType.Int) };
            parm[0].Value = DeliveryID;
            return SQLHelper.RunProcedure("p_SalesDispatch_getDataForPrintByDeliveryID", parm, "dd");
        }

        public bool insertNewEntity(SalesDispatch s)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SalesOutID", SqlDbType.NVarChar), new SqlParameter("@CreateDate", SqlDbType.NVarChar), new SqlParameter("@DeliveryType", SqlDbType.NVarChar), new SqlParameter("@DeliveryDate", SqlDbType.NVarChar), new SqlParameter("@SentDate", SqlDbType.NVarChar), new SqlParameter("@Consignor ", SqlDbType.NVarChar), new SqlParameter("@UserName", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@State", SqlDbType.Int) };
            parm[0].Value = s.SalesOutID;
            parm[1].Value = s.CreateDate;
            parm[2].Value = s.DeliveryType;
            parm[3].Value = s.DeliveryDate;
            parm[4].Value = s.SentDate;
            parm[5].Value = s.Consignor;
            parm[6].Value = s.UserName;
            parm[7].Value = s.Description;
            parm[8].Value = s.State;
            SQLHelper.RunProcedure("p_SalesDispatch_insertNewEntity", parm, out rowsAffect);
            if (s.State == 0)
            {
                new SalesOutDAL().updateSate(2, s.SalesOutID);
            }
            else if (s.State == 1)
            {
                new SalesOutDAL().updateSate(3, s.SalesOutID);
            }
            return (1 == rowsAffect);
        }

        public bool sentUpdate(int DispatchID, string SentDate, int State, string Description, float Postage)
        {
            VSalesDispatch vl;
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@DispatchID", SqlDbType.Int), new SqlParameter("@SentDate", SqlDbType.NVarChar), new SqlParameter("@State", SqlDbType.Int), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@Postage", SqlDbType.Float) };
            parm[0].Value = DispatchID;
            parm[1].Value = SentDate;
            parm[2].Value = State;
            parm[3].Value = Description;
            parm[4].Value = Postage;
            SQLHelper.RunProcedure("p_SalesDispatch_sentUpdate", parm, out rowsAffect);
            if (State == 1)
            {
                vl = this.getByID(DispatchID);
                new SalesOutDAL().updateSate(3, vl.SalesOutID);
            }
            if (State == 3)
            {
                vl = this.getByID(DispatchID);
                new SalesOutDAL().updateSate(4, vl.SalesOutID);
            }
            return (0 < rowsAffect);
        }

        public void updataPrintFlag(int DispatchID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@DispatchID", SqlDbType.Int) };
            parm[0].Value = DispatchID;
            SQLHelper.RunProcedure("p_SalesDispatch_updataPrintFlag", parm, out rowsAffect);
        }

        public bool updateEntity(SalesDispatch s)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@DeliveryType", SqlDbType.NVarChar), new SqlParameter("@DeliveryDate", SqlDbType.NVarChar), new SqlParameter("@SentDate", SqlDbType.NVarChar), new SqlParameter("@Consignor ", SqlDbType.NVarChar), new SqlParameter("@UserName", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@State", SqlDbType.Int), new SqlParameter("@DispatchID", SqlDbType.Int) };
            parm[0].Value = s.DeliveryType;
            parm[1].Value = s.DeliveryDate;
            parm[2].Value = s.SentDate;
            parm[3].Value = s.Consignor;
            parm[4].Value = s.UserName;
            parm[5].Value = s.Description;
            parm[6].Value = s.State;
            parm[7].Value = s.DispatchID;
            SQLHelper.RunProcedure("p_SalesDispatch_updateEntity", parm, out rowsAffect);
            if (s.State == 1)
            {
                new SalesOutDAL().updateSate(3, s.SalesOutID);
            }
            return (1 == rowsAffect);
        }
    }
}

