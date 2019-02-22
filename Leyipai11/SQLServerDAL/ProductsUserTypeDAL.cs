namespace Leyp.SQLServerDAL
{
    using Leyp.Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class ProductsUserTypeDAL
    {
        public void deleteByProductsID(int ProductsID)
        {
        }

        public void deleteBySubClassID(int SubClassID)
        {
        }

        public DataSet getByProductsID(int ProductsID)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ProductsID", SqlDbType.Int) };
            parameters[0].Value = ProductsID;
            return SQLHelper.RunProcedure("p_ProductsUserType_getByProductsID", parameters, "dd");
        }

        public ProductsUserType getByProductsIDAndSubClassID(int ProductsID, int SubClassID)
        {
            string price = "";
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ProductsID", SqlDbType.Int), new SqlParameter("@SubClassID", SqlDbType.Int) };
            parm[0].Value = ProductsID;
            parm[1].Value = SubClassID;
            ProductsUserType item = new ProductsUserType();
            SqlDataReader reader = SQLHelper.RunProcedure("p_ProductsUserType_getByProductsIDandSubClassID", parm);
            while (reader.Read())
            {
                price = reader.GetValue(reader.GetOrdinal("Price")).ToString();
                item.Price = double.Parse(price);
                item.SubClassID = SubClassID;
                item.ProductsID = ProductsID;
            }
            return item;
        }

        public bool insertNewRecord(ProductsUserType p)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ProductsID", SqlDbType.Int), new SqlParameter("@SubClassID", SqlDbType.Int), new SqlParameter("@Price", SqlDbType.Float) };
            parm[0].Value = p.ProductsID;
            parm[1].Value = p.SubClassID;
            parm[2].Value = p.Price;
            SQLHelper.RunProcedure("p_ProductsUserType_insertNewsNode", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public bool updateNodeupdate(ProductsUserType p)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ProductsID", SqlDbType.Int), new SqlParameter("@SubClassID", SqlDbType.Int), new SqlParameter("@Price", SqlDbType.Float) };
            parm[0].Value = p.ProductsID;
            parm[1].Value = p.SubClassID;
            parm[2].Value = p.Price;
            SQLHelper.RunProcedure("p_ProductsUserType_updateNode", parm, out rowsAffect);
            return (1 == rowsAffect);
        }
    }
}

