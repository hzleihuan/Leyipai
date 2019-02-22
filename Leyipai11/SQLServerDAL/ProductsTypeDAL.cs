namespace Leyp.SQLServerDAL
{
    using Leyp.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class ProductsTypeDAL
    {
        public bool deleteByTypeID(int typeID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@TypeID", SqlDbType.Int) };
            parm[0].Value = typeID;
            SQLHelper.RunProcedure("p_ProductsType_DeleteByTypeID", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public List<ProductsType> getAllProductsType()
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@sign", SqlDbType.Int) };
            parm[0].Value = 0;
            List<ProductsType> list = new List<ProductsType>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_ProductsType_GetAll", parm);
            while (reader.Read())
            {
                ProductsType item = new ProductsType {
                    TypeID = reader.GetInt32(reader.GetOrdinal("TypeID")),
                    TypeName = reader.GetString(reader.GetOrdinal("TypeName")),
                    State = reader.GetString(reader.GetOrdinal("State")),
                    Description = reader.GetString(reader.GetOrdinal("Description"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<ProductsType> getAllProductsTypeCanUser()
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@sign", SqlDbType.Int) };
            parm[0].Value = 1;
            List<ProductsType> list = new List<ProductsType>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_ProductsType_GetAll", parm);
            while (reader.Read())
            {
                ProductsType item = new ProductsType {
                    TypeID = reader.GetInt32(reader.GetOrdinal("TypeID")),
                    TypeName = reader.GetString(reader.GetOrdinal("TypeName")),
                    State = reader.GetString(reader.GetOrdinal("State")),
                    Description = reader.GetString(reader.GetOrdinal("Description"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public ProductsType getByTypeID(int TypeID)
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@TypeID", SqlDbType.Int) };
            parm[0].Value = TypeID;
            ProductsType pt = new ProductsType();
            SqlDataReader reader = SQLHelper.RunProcedure("p_ProductsType_GetByTypeID", parm);
            if (reader.Read())
            {
                pt.TypeID = reader.GetInt32(reader.GetOrdinal("TypeID"));
                pt.TypeName = reader.GetString(reader.GetOrdinal("TypeName"));
                pt.State = reader.GetString(reader.GetOrdinal("State"));
                pt.Description = reader.GetString(reader.GetOrdinal("Description"));
            }
            reader.Close();
            return pt;
        }

        public bool insertNewProductsType(ProductsType pt)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@TypeName", SqlDbType.NVarChar), new SqlParameter("@State", SqlDbType.NChar), new SqlParameter("@Description", SqlDbType.NVarChar) };
            parm[0].Value = pt.TypeName;
            parm[1].Value = pt.State;
            parm[2].Value = pt.Description;
            SQLHelper.RunProcedure("p_ProductsType_InsertNew", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public bool updateProductsType(ProductsType pt)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@TypeID", SqlDbType.Int), new SqlParameter("@TypeName", SqlDbType.NVarChar), new SqlParameter("@State", SqlDbType.NChar), new SqlParameter("@Description", SqlDbType.NVarChar) };
            parm[0].Value = pt.TypeID;
            parm[1].Value = pt.TypeName;
            parm[2].Value = pt.State;
            parm[3].Value = pt.Description;
            SQLHelper.RunProcedure("p_ProductsType_update", parm, out rowsAffect);
            return (1 == rowsAffect);
        }
    }
}

