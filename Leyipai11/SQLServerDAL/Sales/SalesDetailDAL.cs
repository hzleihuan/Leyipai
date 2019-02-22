namespace Leyp.SQLServerDAL.Sales
{
    using Leyp.Model.Sales;
    using Leyp.SQLServerDAL;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class SalesDetailDAL
    {
        public bool deleteEitity(int DetailID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@DetailID", SqlDbType.Int) };
            parm[0].Value = DetailID;
            SQLHelper.RunProcedure("p_SalesDetail_deleteEitity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public List<VSalesDetail> getBySalesOrderID(string SalesOrderID)
        {
            string cost = "";
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SalesOrderID", SqlDbType.NVarChar) };
            parm[0].Value = SalesOrderID;
            List<VSalesDetail> list = new List<VSalesDetail>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_SalesDetail_getBySalesOrderID", parm);
            while (reader.Read())
            {
                VSalesDetail item = new VSalesDetail {
                    DetailID = reader.GetInt32(reader.GetOrdinal("DetailID")),
                    Description = reader.GetString(reader.GetOrdinal("Description"))
                };
                cost = reader.GetValue(reader.GetOrdinal("DiscountRate")).ToString();
                item.DiscountRate = float.Parse(cost);
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

        public float getInitTotal(string SalesOrderID)
        {
            float total = float.Parse("0.00");
            List<VSalesDetail> list = this.getBySalesOrderID(SalesOrderID);
            for (int i = 0; i < list.Count; i++)
            {
                VSalesDetail v = list[i];
                total += (v.Quantity * v.Price) * (1f - (v.DiscountRate / 100f));
            }
            return total;
        }

        public bool insertNewEitity(SalesDetail b)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SalesOrderID", SqlDbType.NVarChar), new SqlParameter("@ProductsID", SqlDbType.Int), new SqlParameter("@Quantity", SqlDbType.Int), new SqlParameter("@Price", SqlDbType.Money), new SqlParameter("@DiscountRate", SqlDbType.Float), new SqlParameter("@Description", SqlDbType.NVarChar) };
            parm[0].Value = b.SalesOrderID;
            parm[1].Value = b.ProductsID;
            parm[2].Value = b.Quantity;
            parm[3].Value = b.Price;
            parm[4].Value = b.DiscountRate;
            parm[5].Value = b.Description;
            SQLHelper.RunProcedure("p_SalesDetail_insertNewEntity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }
    }
}

