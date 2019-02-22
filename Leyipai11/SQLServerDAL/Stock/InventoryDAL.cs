namespace Leyp.SQLServerDAL.Stock
{
    using Leyp.Model.Stock;
    using Leyp.SQLServerDAL;
    using Leyp.SQLServerDAL.Service;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class InventoryDAL
    {
        public bool AuditingOrder(string InventoryID, string UserName)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@InventoryID", SqlDbType.NVarChar), new SqlParameter("@UserName", SqlDbType.NVarChar) };
            parm[0].Value = InventoryID;
            parm[1].Value = UserName;
            if (new InventoryService().AuditingInventoryOrder(InventoryID))
            {
                SQLHelper.RunProcedure("p_Inventory_AuditingOrder", parm, out rowsAffect);
            }
            return (0 < rowsAffect);
        }

        public bool deleteEitity(string ID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@InventoryID", SqlDbType.NVarChar) };
            parm[0].Value = ID;
            SQLHelper.RunProcedure("p_Inventory_deleteEitity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public VInventory getByID(string InventoryID)
        {
            return this.getSearchListByID(InventoryID)[0];
        }

        public List<VInventory> getSearchList(string beginDate, string endDate, int sideState)
        {
            List<VInventory> list = new List<VInventory>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@beginDate", SqlDbType.NVarChar), new SqlParameter("@endDate", SqlDbType.NVarChar), new SqlParameter("@sideState", SqlDbType.Int) };
            parm[0].Value = beginDate;
            parm[1].Value = endDate;
            parm[2].Value = sideState;
            SqlDataReader reader = SQLHelper.RunProcedure("p_Inventory_getSearchList", parm);
            while (reader.Read())
            {
                VInventory item = new VInventory {
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    CreateDate = reader.GetString(reader.GetOrdinal("CreateDate")),
                    RealName = reader.GetString(reader.GetOrdinal("RealName")),
                    InventoryID = reader.GetString(reader.GetOrdinal("InventoryID")),
                    AdjustNum = reader.GetInt32(reader.GetOrdinal("AdjustNum")),
                    BillNum = reader.GetInt32(reader.GetOrdinal("BillNum")),
                    RealityNum = reader.GetInt32(reader.GetOrdinal("RealityNum")),
                    ProductsID = reader.GetInt32(reader.GetOrdinal("ProductsID")),
                    TradeDate = reader.GetString(reader.GetOrdinal("TradeDate")),
                    State = reader.GetInt32(reader.GetOrdinal("State")),
                    HouseName = reader.GetString(reader.GetOrdinal("HouseName")),
                    SubareaName = reader.GetString(reader.GetOrdinal("SubareaName")),
                    Operator = reader.GetString(reader.GetOrdinal("Operator")),
                    ProductsName = reader.GetString(reader.GetOrdinal("ProductsName"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<VInventory> getSearchListByID(string InventoryID)
        {
            List<VInventory> list = new List<VInventory>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@InventoryID", SqlDbType.NVarChar) };
            parm[0].Value = InventoryID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_Inventory_getSearchListByID", parm);
            while (reader.Read())
            {
                VInventory item = new VInventory {
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    CreateDate = reader.GetString(reader.GetOrdinal("CreateDate")),
                    RealName = reader.GetString(reader.GetOrdinal("RealName")),
                    InventoryID = reader.GetString(reader.GetOrdinal("InventoryID")),
                    AdjustNum = reader.GetInt32(reader.GetOrdinal("AdjustNum")),
                    BillNum = reader.GetInt32(reader.GetOrdinal("BillNum")),
                    RealityNum = reader.GetInt32(reader.GetOrdinal("RealityNum")),
                    ProductsID = reader.GetInt32(reader.GetOrdinal("ProductsID")),
                    TradeDate = reader.GetString(reader.GetOrdinal("TradeDate")),
                    State = reader.GetInt32(reader.GetOrdinal("State")),
                    HouseDetailID = reader.GetInt32(reader.GetOrdinal("HouseDetailID")),
                    HouseName = reader.GetString(reader.GetOrdinal("HouseName")),
                    SubareaName = reader.GetString(reader.GetOrdinal("SubareaName")),
                    Operator = reader.GetString(reader.GetOrdinal("Operator")),
                    ProductsName = reader.GetString(reader.GetOrdinal("ProductsName"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public bool insertNewEntity(Inventory b)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@InventoryID", SqlDbType.NVarChar), new SqlParameter("@CreateDate", SqlDbType.NVarChar), new SqlParameter("@StoreHouseID", SqlDbType.Int), new SqlParameter("@HouseDetailID", SqlDbType.Int), new SqlParameter("@ProductsID", SqlDbType.Int), new SqlParameter("@RealityNum", SqlDbType.Int), new SqlParameter("@BillNum", SqlDbType.Int), new SqlParameter("@AdjustNum", SqlDbType.Int), new SqlParameter("@UserName", SqlDbType.NVarChar), new SqlParameter("@Operator", SqlDbType.NVarChar), new SqlParameter("@TradeDate", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@State", SqlDbType.Int) };
            parm[0].Value = b.InventoryID;
            parm[1].Value = b.CreateDate;
            parm[2].Value = b.StoreHouseID;
            parm[3].Value = b.HouseDetailID;
            parm[4].Value = b.ProductsID;
            parm[5].Value = b.RealityNum;
            parm[6].Value = b.BillNum;
            parm[7].Value = b.AdjustNum;
            parm[8].Value = b.UserName;
            parm[9].Value = b.Operator;
            parm[10].Value = b.TradeDate;
            parm[11].Value = b.Description;
            parm[12].Value = b.State;
            SQLHelper.RunProcedure("p_Inventory_insertNewEntity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }
    }
}

