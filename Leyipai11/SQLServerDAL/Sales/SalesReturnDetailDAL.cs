namespace Leyp.SQLServerDAL.Sales
{
    using Leyp.Model.Sales;
    using Leyp.SQLServerDAL;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class SalesReturnDetailDAL
    {
        public bool deleteEitity(int DetailID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@DetailID", SqlDbType.Int) };
            parm[0].Value = DetailID;
            SQLHelper.RunProcedure("p_SalesReturnDetail_deleteEitity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public VSalesReturnDetail getByID(int DetailID)
        {
            string cost = "";
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@DetailID", SqlDbType.Int) };
            parm[0].Value = DetailID;
            VSalesReturnDetail item = new VSalesReturnDetail();
            SqlDataReader reader = SQLHelper.RunProcedure("p_SalesReturnDetail_getByID", parm);
            while (reader.Read())
            {
                item.DetailID = reader.GetInt32(reader.GetOrdinal("DetailID"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                cost = reader.GetValue(reader.GetOrdinal("Price")).ToString();
                item.Price = float.Parse(cost);
                item.ProductsID = reader.GetInt32(reader.GetOrdinal("ProductsID"));
                item.ProductsName = reader.GetString(reader.GetOrdinal("ProductsName"));
                item.Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
            }
            reader.Close();
            return item;
        }

        public List<VSalesReturnDetail> getBySalesReturnID(string SalesReturnID)
        {
            string cost = "";
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SalesReturnID", SqlDbType.NVarChar) };
            parm[0].Value = SalesReturnID;
            List<VSalesReturnDetail> list = new List<VSalesReturnDetail>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_SalesReturnDetail_getBySalesReturnID", parm);
            while (reader.Read())
            {
                VSalesReturnDetail item = new VSalesReturnDetail {
                    DetailID = reader.GetInt32(reader.GetOrdinal("DetailID")),
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

        public bool insertNewEitity(SalesReturnDetail b)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SalesReturnID", SqlDbType.NVarChar), new SqlParameter("@ProductsID", SqlDbType.Int), new SqlParameter("@Quantity", SqlDbType.Int), new SqlParameter("@Price", SqlDbType.Money), new SqlParameter("@Description", SqlDbType.NVarChar) };
            parm[0].Value = b.SalesReturnID;
            parm[1].Value = b.ProductsID;
            parm[2].Value = b.Quantity;
            parm[3].Value = b.Price;
            parm[4].Value = b.Description;
            SQLHelper.RunProcedure("p_SalesReturnDetail_insertNewEntity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public bool updateEitity(SalesReturnDetail b)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@DetailID", SqlDbType.Int), new SqlParameter("@SalesReturnID", SqlDbType.NVarChar), new SqlParameter("@ProductsID", SqlDbType.Int), new SqlParameter("@Quantity", SqlDbType.Int), new SqlParameter("@Price", SqlDbType.Money), new SqlParameter("@Description", SqlDbType.NVarChar) };
            parm[0].Value = b.DetailID;
            parm[1].Value = b.SalesReturnID;
            parm[2].Value = b.ProductsID;
            parm[3].Value = b.Quantity;
            parm[4].Value = b.Price;
            parm[5].Value = b.Description;
            SQLHelper.RunProcedure("p_SalesReturnDetail_updateEntity", parm, out rowsAffect);
            return (1 < rowsAffect);
        }
    }
}

