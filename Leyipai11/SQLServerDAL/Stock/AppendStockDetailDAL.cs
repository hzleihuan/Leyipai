namespace Leyp.SQLServerDAL.Stock
{
    using Leyp.Model.Stock;
    using Leyp.SQLServerDAL;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class AppendStockDetailDAL
    {
        public bool deleteEitity(int DetailID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@DetailID", SqlDbType.Int) };
            parm[0].Value = DetailID;
            SQLHelper.RunProcedure("p_AppendStockDetail_deleteEitity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public VAppendStockDetail getByID(int DetailID)
        {
            string cost = "";
            VAppendStockDetail item = new VAppendStockDetail();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@DetailID", SqlDbType.Int) };
            parm[0].Value = DetailID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_AppendStockDetail_getByID", parm);
            if (reader.Read())
            {
                item.DetailID = reader.GetInt32(reader.GetOrdinal("DetailID"));
                item.AppendID = reader.GetString(reader.GetOrdinal("AppendID"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                cost = reader.GetValue(reader.GetOrdinal("Price")).ToString();
                item.Price = float.Parse(cost);
                item.ProductsID = reader.GetInt32(reader.GetOrdinal("ProductsID"));
                item.ProductsName = reader.GetString(reader.GetOrdinal("ProductsName"));
                item.Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
                item.SupplierID = reader.GetInt32(reader.GetOrdinal("SupplierID"));
                item.SupplierName = reader.GetString(reader.GetOrdinal("SupplierName"));
            }
            return item;
        }

        public List<VAppendStockDetail> getListByAppendID(string AppendID)
        {
            string cost = "";
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@AppendID", SqlDbType.NVarChar) };
            parm[0].Value = AppendID;
            List<VAppendStockDetail> list = new List<VAppendStockDetail>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_AppendStockDetail_getListByAppendID", parm);
            while (reader.Read())
            {
                VAppendStockDetail item = new VAppendStockDetail {
                    DetailID = reader.GetInt32(reader.GetOrdinal("DetailID")),
                    AppendID = reader.GetString(reader.GetOrdinal("AppendID")),
                    Description = reader.GetString(reader.GetOrdinal("Description"))
                };
                cost = reader.GetValue(reader.GetOrdinal("Price")).ToString();
                item.Price = float.Parse(cost);
                item.ProductsID = reader.GetInt32(reader.GetOrdinal("ProductsID"));
                item.ProductsName = reader.GetString(reader.GetOrdinal("ProductsName"));
                item.Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
                item.SupplierID = reader.GetInt32(reader.GetOrdinal("SupplierID"));
                item.SupplierName = reader.GetString(reader.GetOrdinal("SupplierName"));
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public bool insertNewEitity(AppendStockDetail s)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@AppendID", SqlDbType.NVarChar), new SqlParameter("@ProductsID", SqlDbType.Int), new SqlParameter("@SupplierID", SqlDbType.Int), new SqlParameter("@Quantity", SqlDbType.Int), new SqlParameter("@Price", SqlDbType.Money), new SqlParameter("@Description", SqlDbType.NVarChar) };
            parm[0].Value = s.AppendID;
            parm[1].Value = s.ProductsID;
            parm[2].Value = s.SupplierID;
            parm[3].Value = s.Quantity;
            parm[4].Value = s.Price;
            parm[5].Value = s.Description;
            SQLHelper.RunProcedure("p_AppendStockDetail_insertNewEntity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public bool updateEitity(AppendStockDetail s)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@AppendID", SqlDbType.NVarChar), new SqlParameter("@ProductsID", SqlDbType.Int), new SqlParameter("@SupplierID", SqlDbType.Int), new SqlParameter("@Quantity", SqlDbType.Int), new SqlParameter("@Price", SqlDbType.Money), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@DetailID", SqlDbType.Int) };
            parm[0].Value = s.AppendID;
            parm[1].Value = s.ProductsID;
            parm[2].Value = s.SupplierID;
            parm[3].Value = s.Quantity;
            parm[4].Value = s.Price;
            parm[5].Value = s.Description;
            parm[6].Value = s.DetailID;
            SQLHelper.RunProcedure("p_AppendStockDetail_updateEitity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }
    }
}

