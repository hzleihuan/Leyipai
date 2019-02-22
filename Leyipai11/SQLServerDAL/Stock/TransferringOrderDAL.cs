namespace Leyp.SQLServerDAL.Stock
{
    using Leyp.Model.Stock;
    using Leyp.SQLServerDAL;
    using Leyp.SQLServerDAL.Service;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class TransferringOrderDAL
    {
        public bool AuditingOrder(string ID, string UserName)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@TransferringOrderID", SqlDbType.NVarChar), new SqlParameter("@UserName", SqlDbType.NVarChar) };
            parm[0].Value = ID;
            parm[1].Value = UserName;
            if (new TransferringService().AuditingTransferring(ID))
            {
                SQLHelper.RunProcedure("p_TransferringOrder_AuditingOrder", parm, out rowsAffect);
            }
            return (0 < rowsAffect);
        }

        public bool deleteEitity(string ID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@TransferringOrderID", SqlDbType.NVarChar) };
            parm[0].Value = ID;
            SQLHelper.RunProcedure("p_TransferringOrder_deleteEitity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public VTransferringOrder getByID(string ID)
        {
            return this.getSearchListByID(ID)[0];
        }

        public List<VTransferringOrder> getSearchList(string beginDate, string endDate, int sideState)
        {
            string cost = "";
            List<VTransferringOrder> list = new List<VTransferringOrder>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@beginDate", SqlDbType.NVarChar), new SqlParameter("@endDate", SqlDbType.NVarChar), new SqlParameter("@sideState", SqlDbType.Int) };
            parm[0].Value = beginDate;
            parm[1].Value = endDate;
            parm[2].Value = sideState;
            SqlDataReader reader = SQLHelper.RunProcedure("p_TransferringOrder_getSearchList", parm);
            while (reader.Read())
            {
                VTransferringOrder item = new VTransferringOrder {
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    Date = reader.GetString(reader.GetOrdinal("Date")),
                    RealName = reader.GetString(reader.GetOrdinal("RealName")),
                    ID = reader.GetString(reader.GetOrdinal("ID")),
                    InHouseID = reader.GetInt32(reader.GetOrdinal("InHouseID")),
                    OutHouseID = reader.GetInt32(reader.GetOrdinal("OutHouseID")),
                    ProductsID = reader.GetInt32(reader.GetOrdinal("ProductsID")),
                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                    TradeDate = reader.GetString(reader.GetOrdinal("TradeDate")),
                    State = reader.GetInt32(reader.GetOrdinal("State")),
                    InHouseName = reader.GetString(reader.GetOrdinal("InHouseName")),
                    InSubareaName = reader.GetString(reader.GetOrdinal("InSubareaName")),
                    OutHouseName = reader.GetString(reader.GetOrdinal("OutHouseName")),
                    OutSubareaName = reader.GetString(reader.GetOrdinal("OutSubareaName")),
                    Operator = reader.GetString(reader.GetOrdinal("Operator")),
                    Ticket = reader.GetString(reader.GetOrdinal("Ticket")),
                    ProductsName = reader.GetString(reader.GetOrdinal("ProductsName"))
                };
                cost = reader.GetValue(reader.GetOrdinal("Price")).ToString();
                item.Price = float.Parse(cost);
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<VTransferringOrder> getSearchListByID(string ID)
        {
            string cost = "";
            List<VTransferringOrder> list = new List<VTransferringOrder>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.NVarChar) };
            parm[0].Value = ID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_TransferringOrder_getSearchListByID", parm);
            while (reader.Read())
            {
                VTransferringOrder item = new VTransferringOrder {
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    Date = reader.GetString(reader.GetOrdinal("Date")),
                    RealName = reader.GetString(reader.GetOrdinal("RealName")),
                    ID = reader.GetString(reader.GetOrdinal("ID")),
                    InHouseID = reader.GetInt32(reader.GetOrdinal("InHouseID")),
                    OutHouseID = reader.GetInt32(reader.GetOrdinal("OutHouseID")),
                    ProductsID = reader.GetInt32(reader.GetOrdinal("ProductsID")),
                    Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                    TradeDate = reader.GetString(reader.GetOrdinal("TradeDate")),
                    State = reader.GetInt32(reader.GetOrdinal("State")),
                    InHouseName = reader.GetString(reader.GetOrdinal("InHouseName")),
                    InSubareaName = reader.GetString(reader.GetOrdinal("InSubareaName")),
                    OutHouseName = reader.GetString(reader.GetOrdinal("OutHouseName")),
                    OutSubareaName = reader.GetString(reader.GetOrdinal("OutSubareaName")),
                    Operator = reader.GetString(reader.GetOrdinal("Operator")),
                    Ticket = reader.GetString(reader.GetOrdinal("Ticket")),
                    ProductsName = reader.GetString(reader.GetOrdinal("ProductsName"))
                };
                cost = reader.GetValue(reader.GetOrdinal("Price")).ToString();
                item.Price = float.Parse(cost);
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public bool insertNewEntity(TransferringOrder b)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@Date", SqlDbType.NVarChar), new SqlParameter("@OutHouseID", SqlDbType.Int), new SqlParameter("@InHouseID", SqlDbType.Int), new SqlParameter("@ProductsID", SqlDbType.Int), new SqlParameter("@Quantity", SqlDbType.Int), new SqlParameter("@Price", SqlDbType.Float), new SqlParameter("@UserName", SqlDbType.NVarChar), new SqlParameter("@Operator", SqlDbType.NVarChar), new SqlParameter("@TradeDate", SqlDbType.NVarChar), new SqlParameter("@Ticket", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@State", SqlDbType.Int), new SqlParameter("@ID", SqlDbType.NVarChar) };
            parm[0].Value = b.Date;
            parm[1].Value = b.OutHouseID;
            parm[2].Value = b.InHouseID;
            parm[3].Value = b.ProductsID;
            parm[4].Value = b.Quantity;
            parm[5].Value = b.Price;
            parm[6].Value = b.UserName;
            parm[7].Value = b.Operator;
            parm[8].Value = b.TradeDate;
            parm[9].Value = b.Ticket;
            parm[10].Value = b.Description;
            parm[11].Value = b.State;
            parm[12].Value = b.ID;
            SQLHelper.RunProcedure("p_TransferringOrder_insertNewEntity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }
    }
}

