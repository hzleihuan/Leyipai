namespace Leyp.SQLServerDAL.Stock
{
    using Leyp.Model.Stock;
    using Leyp.SQLServerDAL;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class OutStockDetailDAL
    {
        public bool deleteEitity(int DetailID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@DetailID", SqlDbType.Int) };
            parm[0].Value = DetailID;
            SQLHelper.RunProcedure("p_OutStockDetail_deleteEitity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public VOutStockDetail getByID(int DetailID)
        {
            string cost = "";
            VOutStockDetail item = new VOutStockDetail();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@DetailID", SqlDbType.Int) };
            parm[0].Value = DetailID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_OutStockDetail_getByID", parm);
            if (reader.Read())
            {
                item.DetailID = reader.GetInt32(reader.GetOrdinal("DetailID"));
                item.OutID = reader.GetString(reader.GetOrdinal("OutID"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                cost = reader.GetValue(reader.GetOrdinal("Price")).ToString();
                item.Price = float.Parse(cost);
                item.ProductsID = reader.GetInt32(reader.GetOrdinal("ProductsID"));
                item.ProductsName = reader.GetString(reader.GetOrdinal("ProductsName"));
                item.Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
            }
            return item;
        }

        public List<VOutStockDetail> getListByOutID(string OutID)
        {
            string cost = "";
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@OutID", SqlDbType.NVarChar) };
            parm[0].Value = OutID;
            List<VOutStockDetail> list = new List<VOutStockDetail>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_OutStockDetail_getListByOutID", parm);
            while (reader.Read())
            {
                VOutStockDetail item = new VOutStockDetail {
                    DetailID = reader.GetInt32(reader.GetOrdinal("DetailID")),
                    OutID = reader.GetString(reader.GetOrdinal("OutID")),
                    Description = reader.GetString(reader.GetOrdinal("Description"))
                };
                cost = reader.GetValue(reader.GetOrdinal("Price")).ToString();
                item.Price = float.Parse(cost);
                item.ProductsID = reader.GetInt32(reader.GetOrdinal("ProductsID"));
                item.ProductsName = reader.GetString(reader.GetOrdinal("ProductsName"));
                item.Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public bool insertNewEitity(OutStockDetail s)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@OutID", SqlDbType.NVarChar), new SqlParameter("@ProductsID", SqlDbType.Int), new SqlParameter("@Quantity", SqlDbType.Int), new SqlParameter("@Price", SqlDbType.Money), new SqlParameter("@Description", SqlDbType.NVarChar) };
            parm[0].Value = s.OutID;
            parm[1].Value = s.ProductsID;
            parm[2].Value = s.Quantity;
            parm[3].Value = s.Price;
            parm[4].Value = s.Description;
            SQLHelper.RunProcedure("p_OutStockDetail_insertNewEntity", parm, out rowsAffect);
            return (0 < rowsAffect);
        }

        public bool updateEitity(OutStockDetail s)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@OutID", SqlDbType.NVarChar), new SqlParameter("@ProductsID", SqlDbType.Int), new SqlParameter("@Quantity", SqlDbType.Int), new SqlParameter("@Price", SqlDbType.Money), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@DetailID", SqlDbType.Int) };
            parm[0].Value = s.OutID;
            parm[1].Value = s.ProductsID;
            parm[2].Value = s.Quantity;
            parm[3].Value = s.Price;
            parm[4].Value = s.Description;
            parm[5].Value = s.DetailID;
            SQLHelper.RunProcedure("p_OutStockDetail_updateEitity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }
    }
}

