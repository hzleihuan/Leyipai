namespace Leyp.SQLServerDAL
{
    using Leyp.Model;
    using Leyp.Model.View;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class ProductsStockDAL
    {
        public VProductsStock getByProductsIDStockID(int ProductsID, int HouseDetailID)
        {
            bool result = false;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ProductsID", SqlDbType.Int), new SqlParameter("@HouseDetailID", SqlDbType.Int) };
            parm[0].Value = ProductsID;
            parm[1].Value = HouseDetailID;
            VProductsStock item = new VProductsStock();
            SqlDataReader reader = SQLHelper.RunProcedure("p_ProductsStock_getByProductsIDStockID", parm);
            while (reader.Read())
            {
                item.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                item.HouseDetailID = reader.GetInt32(reader.GetOrdinal("HouseDetailID"));
                item.ProductsID = reader.GetInt32(reader.GetOrdinal("ProductsID"));
                item.Num = reader.GetInt32(reader.GetOrdinal("Num"));
                result = true;
            }
            reader.Close();
            return (result ? item : null);
        }

        public DataSet getDataSetByHouseDetailID(int HouseDetailID)
        {
            DataSet ds = new DataSet();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@HouseDetailID", SqlDbType.Int) };
            parm[0].Value = HouseDetailID;
            return SQLHelper.RunProcedure("p_ProductsStock_getDataSetByHouseDetailID", parm, "dd");
        }

        public DataSet getDataSetByProductsID(int ProductsID)
        {
            DataSet ds = new DataSet();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ProductsID", SqlDbType.Int) };
            parm[0].Value = ProductsID;
            return SQLHelper.RunProcedure("p_ProductsStock_getDataSetByProductsID", parm, "dd");
        }

        public List<VProductsStock> getProductsList(int HouseDetailID)
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@HouseDetailID", SqlDbType.Int) };
            parm[0].Value = HouseDetailID;
            List<VProductsStock> list = new List<VProductsStock>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_ProductsStock_getProductsList", parm);
            while (reader.Read())
            {
                VProductsStock item = new VProductsStock {
                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                    HouseDetailID = reader.GetInt32(reader.GetOrdinal("HouseDetailID")),
                    SubareaName = reader.GetString(reader.GetOrdinal("SubareaName")),
                    HouseName = reader.GetString(reader.GetOrdinal("HouseName")),
                    ProductsID = reader.GetInt32(reader.GetOrdinal("ProductsID")),
                    ProductsName = reader.GetString(reader.GetOrdinal("ProductsName"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<VProductsStock> getStockList(int ProductsID)
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ProductsID", SqlDbType.Int) };
            parm[0].Value = ProductsID;
            List<VProductsStock> list = new List<VProductsStock>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_ProductsStock_getStockList", parm);
            while (reader.Read())
            {
                VProductsStock item = new VProductsStock {
                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                    HouseDetailID = reader.GetInt32(reader.GetOrdinal("HouseDetailID")),
                    SubareaName = reader.GetString(reader.GetOrdinal("SubareaName")),
                    HouseName = reader.GetString(reader.GetOrdinal("HouseName")),
                    ProductsID = reader.GetInt32(reader.GetOrdinal("ProductsID")),
                    ProductsName = reader.GetString(reader.GetOrdinal("ProductsName")),
                    HouseID = reader.GetInt32(reader.GetOrdinal("HouseID")),
                    Num = reader.GetInt32(reader.GetOrdinal("Num"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public bool insertNewEitity(ProductsStock p)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@HouseDetailID", SqlDbType.Int), new SqlParameter("@ProductsID", SqlDbType.Int), new SqlParameter("@Num", SqlDbType.Int) };
            parm[0].Value = p.HouseDetailID;
            parm[1].Value = p.ProductsID;
            parm[2].Value = p.Num;
            SQLHelper.RunProcedure("p_ProductsStock_insertNewEitity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public bool isHaveEitity(int HouseDetailID, int ProductsID)
        {
            bool result = false;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@HouseDetailID", SqlDbType.Int), new SqlParameter("@ProductsID", SqlDbType.Int) };
            parm[0].Value = HouseDetailID;
            parm[1].Value = ProductsID;
            if (SQLHelper.RunProcedure("p_ProductsStock_isHaveEitity", parm).Read())
            {
                result = true;
            }
            return result;
        }

        public bool updateAddNum(ProductsStock p)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@HouseDetailID", SqlDbType.Int), new SqlParameter("@ProductsID", SqlDbType.Int), new SqlParameter("@Num", SqlDbType.Int) };
            parm[0].Value = p.HouseDetailID;
            parm[1].Value = p.ProductsID;
            parm[2].Value = p.Num;
            SQLHelper.RunProcedure("p_ProductsStock_updateAddNum", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public bool updateCutNum(ProductsStock p)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@HouseDetailID", SqlDbType.Int), new SqlParameter("@ProductsID", SqlDbType.Int), new SqlParameter("@Num", SqlDbType.Int) };
            parm[0].Value = p.HouseDetailID;
            parm[1].Value = p.ProductsID;
            parm[2].Value = p.Num;
            SQLHelper.RunProcedure("p_ProductsStock_updateCutNum", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public bool updateEitityNum(ProductsStock p)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@HouseDetailID", SqlDbType.Int), new SqlParameter("@ProductsID", SqlDbType.Int), new SqlParameter("@Num", SqlDbType.Int) };
            parm[0].Value = p.HouseDetailID;
            parm[1].Value = p.ProductsID;
            parm[2].Value = p.Num;
            SQLHelper.RunProcedure("p_ProductsStock_updateEitityNum", parm, out rowsAffect);
            return (1 == rowsAffect);
        }
    }
}

