namespace Leyp.SQLServerDAL
{
    using Leyp.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class ProductsPhotoDAL
    {
        public bool deleteNodeByID(int ID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ID", SqlDbType.Int) };
            parm[0].Value = ID;
            SQLHelper.RunProcedure("p_ProductsPhoto_deleteNode", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public List<ProductsPhoto> getListByProductsID(int ProductsID)
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ProductsID", SqlDbType.Int) };
            parm[0].Value = ProductsID;
            List<ProductsPhoto> list = new List<ProductsPhoto>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_ProductsPhoto_getByProductsID", parm);
            while (reader.Read())
            {
                ProductsPhoto item = new ProductsPhoto {
                    ID = reader.GetInt32(reader.GetOrdinal("ID")),
                    ProductsID = reader.GetInt32(reader.GetOrdinal("ProductsID")),
                    PhotoUrl = reader.GetString(reader.GetOrdinal("PhotoUrl"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public bool insertNewNode(ProductsPhoto p)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ProductsID", SqlDbType.Int), new SqlParameter("@PhotoUrl", SqlDbType.NVarChar) };
            parm[0].Value = p.ProductsID;
            parm[1].Value = p.PhotoUrl;
            SQLHelper.RunProcedure("p_ProductsPhoto_insertNewNode", parm, out rowsAffect);
            return (1 == rowsAffect);
        }
    }
}

