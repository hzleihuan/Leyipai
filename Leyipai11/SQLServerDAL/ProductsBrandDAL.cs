namespace Leyp.SQLServerDAL
{
    using Leyp.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class ProductsBrandDAL
    {
        public bool deleteByBrandID(int brandID)
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@BrandID", SqlDbType.Int) };
            parm[0].Value = brandID;
            int i = SQLHelper.ExecuteNonQuery(SQLHelper.strCon, CommandType.StoredProcedure, "p_ProductsBrand_DeleteByBrandID", parm);
            return (1 == i);
        }

        public List<ProductsBrand> getAllProductsBrand()
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@sign", SqlDbType.Int) };
            parm[0].Value = 0;
            List<ProductsBrand> list = new List<ProductsBrand>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_ProductsBrand_GetAll", parm);
            while (reader.Read())
            {
                ProductsBrand item = new ProductsBrand {
                    BrandID = reader.GetInt32(reader.GetOrdinal("BrandID")),
                    BrandName = reader.GetString(reader.GetOrdinal("BrandName")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    State = reader.GetString(reader.GetOrdinal("State"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<ProductsBrand> getAllProductsBrandCanUser()
        {
            List<ProductsBrand> list = new List<ProductsBrand>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@sign", SqlDbType.Int) };
            parm[0].Value = 1;
            SqlDataReader reader = SQLHelper.RunProcedure("p_ProductsBrand_GetAll", parm);
            while (reader.Read())
            {
                ProductsBrand item = new ProductsBrand {
                    BrandID = reader.GetInt32(reader.GetOrdinal("BrandID")),
                    BrandName = reader.GetString(reader.GetOrdinal("BrandName")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    State = reader.GetString(reader.GetOrdinal("State"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public ProductsBrand getByBrandID(int BrandID)
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@BrandID", SqlDbType.Int) };
            parm[0].Value = BrandID;
            ProductsBrand pb = new ProductsBrand();
            SqlDataReader reader = SQLHelper.RunProcedure("p_ProductsBrand_GetByBrandID", parm);
            if (reader.Read())
            {
                pb.BrandID = reader.GetInt32(reader.GetOrdinal("BrandID"));
                pb.BrandName = reader.GetString(reader.GetOrdinal("BrandName"));
                pb.Description = reader.GetString(reader.GetOrdinal("Description"));
                pb.State = reader.GetString(reader.GetOrdinal("State"));
            }
            reader.Close();
            return pb;
        }

        public bool insertNewProductsBrand(ProductsBrand pb)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@BrandName", SqlDbType.NVarChar), new SqlParameter("@State", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar) };
            parm[0].Value = pb.BrandName;
            parm[1].Value = pb.State;
            parm[2].Value = pb.Description;
            SQLHelper.RunProcedure("p_ProductsBrand_InsertNew", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public bool updataProductsBrand(ProductsBrand pb)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@BrandID", SqlDbType.NVarChar), new SqlParameter("@BrandName", SqlDbType.NVarChar), new SqlParameter("@State", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar) };
            parm[0].Value = pb.BrandID;
            parm[1].Value = pb.BrandName;
            parm[2].Value = pb.State;
            parm[3].Value = pb.Description;
            SQLHelper.RunProcedure("p_ProductsBrand_update", parm, out rowsAffect);
            return (1 == rowsAffect);
        }
    }
}

