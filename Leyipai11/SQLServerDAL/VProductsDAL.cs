namespace Leyp.SQLServerDAL
{
    using Leyp.Model.View;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class VProductsDAL
    {
        public VProducts getByID(int ProductsID)
        {
            string cost = "0";
            VProducts item = new VProducts();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ProductsID", SqlDbType.Int) };
            parm[0].Value = ProductsID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_Products_GetByProductsID", parm);
            if (reader.Read())
            {
                item.ProductsID = reader.GetInt32(reader.GetOrdinal("ProductsID"));
                item.ProductsName = reader.GetString(reader.GetOrdinal("ProductsName"));
                item.TypeID = reader.GetInt32(reader.GetOrdinal("TypeID"));
                item.BrandID = reader.GetInt32(reader.GetOrdinal("BrandID"));
                item.BeginEnterDate = reader.GetString(reader.GetOrdinal("BeginEnterDate"));
                item.FinalEnterDate = reader.GetString(reader.GetOrdinal("FinalEnterDate"));
                item.LatelyOFSDate = reader.GetString(reader.GetOrdinal("LatelyOFSDate"));
                item.UnshelveDate = reader.GetString(reader.GetOrdinal("UnshelveDate"));
                item.Color = reader.GetString(reader.GetOrdinal("Color"));
                item.Weight = reader.GetString(reader.GetOrdinal("Weight"));
                item.Material = reader.GetString(reader.GetOrdinal("Material"));
                item.Spec = reader.GetString(reader.GetOrdinal("Spec"));
                item.TotalSalesNum = reader.GetInt32(reader.GetOrdinal("TotalSalesNum"));
                item.StocksNum = reader.GetInt32(reader.GetOrdinal("StocksNum"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                item.PhotoUrl = reader.GetString(reader.GetOrdinal("PhotoUrl"));
                item.ProductsUints = reader.GetString(reader.GetOrdinal("ProductsUints"));
                cost = reader.GetValue(reader.GetOrdinal("Cost")).ToString();
                item.Cost = float.Parse(cost);
                item.UpperLimit = reader.GetInt32(reader.GetOrdinal("UpperLimit"));
                item.LowerLimit = reader.GetInt32(reader.GetOrdinal("LowerLimit"));
                item.TypeName = reader.GetString(reader.GetOrdinal("TypeName"));
                item.BrandName = reader.GetString(reader.GetOrdinal("BrandName"));
                item.PhotoUrl = reader.GetString(reader.GetOrdinal("PhotoUrl"));
            }
            reader.Close();
            return item;
        }

        public List<VProducts> getNewsProducts()
        {
            string cost = "";
            List<VProducts> list = new List<VProducts>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_Products_getNewsProducts", null);
            while (reader.Read())
            {
                VProducts item = new VProducts {
                    ProductsID = reader.GetInt32(reader.GetOrdinal("ProductsID")),
                    ProductsName = reader.GetString(reader.GetOrdinal("ProductsName")),
                    TypeID = reader.GetInt32(reader.GetOrdinal("TypeID")),
                    BrandID = reader.GetInt32(reader.GetOrdinal("BrandID")),
                    BeginEnterDate = reader.GetString(reader.GetOrdinal("BeginEnterDate")),
                    FinalEnterDate = reader.GetString(reader.GetOrdinal("FinalEnterDate")),
                    LatelyOFSDate = reader.GetString(reader.GetOrdinal("LatelyOFSDate")),
                    UnshelveDate = reader.GetString(reader.GetOrdinal("UnshelveDate")),
                    Color = reader.GetString(reader.GetOrdinal("Color")),
                    Weight = reader.GetString(reader.GetOrdinal("Weight")),
                    Material = reader.GetString(reader.GetOrdinal("Material")),
                    Spec = reader.GetString(reader.GetOrdinal("Spec")),
                    TotalSalesNum = reader.GetInt32(reader.GetOrdinal("TotalSalesNum")),
                    StocksNum = reader.GetInt32(reader.GetOrdinal("StocksNum")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    UpperLimit = reader.GetInt32(reader.GetOrdinal("UpperLimit")),
                    LowerLimit = reader.GetInt32(reader.GetOrdinal("LowerLimit"))
                };
                cost = reader.GetValue(reader.GetOrdinal("Cost")).ToString();
                item.Cost = float.Parse(cost);
                item.TypeName = reader.GetString(reader.GetOrdinal("TypeName"));
                item.BrandName = reader.GetString(reader.GetOrdinal("BrandName"));
                item.PhotoUrl = reader.GetString(reader.GetOrdinal("PhotoUrl"));
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<VProducts> searchProducts(int TypeID, int BrandID, string Key)
        {
            string cost = "0";
            List<VProducts> list = new List<VProducts>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@TypeID", SqlDbType.Int), new SqlParameter("@BrandID", SqlDbType.Int), new SqlParameter("@Key", SqlDbType.NVarChar) };
            parm[0].Value = TypeID;
            parm[1].Value = BrandID;
            parm[2].Value = Key;
            SqlDataReader reader = SQLHelper.RunProcedure("ps_VProdocts_getForSearch", parm);
            while (reader.Read())
            {
                VProducts item = new VProducts {
                    ProductsID = reader.GetInt32(reader.GetOrdinal("ProductsID")),
                    ProductsName = reader.GetString(reader.GetOrdinal("ProductsName")),
                    TypeID = reader.GetInt32(reader.GetOrdinal("TypeID")),
                    BrandID = reader.GetInt32(reader.GetOrdinal("BrandID")),
                    BeginEnterDate = reader.GetString(reader.GetOrdinal("BeginEnterDate")),
                    FinalEnterDate = reader.GetString(reader.GetOrdinal("FinalEnterDate")),
                    LatelyOFSDate = reader.GetString(reader.GetOrdinal("LatelyOFSDate")),
                    UnshelveDate = reader.GetString(reader.GetOrdinal("UnshelveDate")),
                    Color = reader.GetString(reader.GetOrdinal("Color")),
                    Weight = reader.GetString(reader.GetOrdinal("Weight")),
                    Material = reader.GetString(reader.GetOrdinal("Material")),
                    Spec = reader.GetString(reader.GetOrdinal("Spec")),
                    TotalSalesNum = reader.GetInt32(reader.GetOrdinal("TotalSalesNum")),
                    StocksNum = reader.GetInt32(reader.GetOrdinal("StocksNum")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    UpperLimit = reader.GetInt32(reader.GetOrdinal("UpperLimit")),
                    LowerLimit = reader.GetInt32(reader.GetOrdinal("LowerLimit"))
                };
                cost = reader.GetValue(reader.GetOrdinal("Cost")).ToString();
                item.Cost = float.Parse(cost);
                item.TypeName = reader.GetString(reader.GetOrdinal("TypeName"));
                item.BrandName = reader.GetString(reader.GetOrdinal("BrandName"));
                item.PhotoUrl = reader.GetString(reader.GetOrdinal("PhotoUrl"));
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<VProducts> searchProductsForAll(int TypeID, int BrandID, string Key)
        {
            string cost = "0";
            List<VProducts> list = new List<VProducts>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@TypeID", SqlDbType.Int), new SqlParameter("@BrandID", SqlDbType.Int), new SqlParameter("@Key", SqlDbType.NVarChar) };
            parm[0].Value = TypeID;
            parm[1].Value = BrandID;
            parm[2].Value = Key;
            SqlDataReader reader = SQLHelper.RunProcedure("p_Prodocts_getForSearch", parm);
            while (reader.Read())
            {
                VProducts item = new VProducts {
                    ProductsID = reader.GetInt32(reader.GetOrdinal("ProductsID")),
                    ProductsName = reader.GetString(reader.GetOrdinal("ProductsName")),
                    TypeID = reader.GetInt32(reader.GetOrdinal("TypeID")),
                    BrandID = reader.GetInt32(reader.GetOrdinal("BrandID")),
                    BeginEnterDate = reader.GetString(reader.GetOrdinal("BeginEnterDate")),
                    FinalEnterDate = reader.GetString(reader.GetOrdinal("FinalEnterDate")),
                    LatelyOFSDate = reader.GetString(reader.GetOrdinal("LatelyOFSDate")),
                    UnshelveDate = reader.GetString(reader.GetOrdinal("UnshelveDate")),
                    Color = reader.GetString(reader.GetOrdinal("Color")),
                    Weight = reader.GetString(reader.GetOrdinal("Weight")),
                    Material = reader.GetString(reader.GetOrdinal("Material")),
                    Spec = reader.GetString(reader.GetOrdinal("Spec")),
                    TotalSalesNum = reader.GetInt32(reader.GetOrdinal("TotalSalesNum")),
                    StocksNum = reader.GetInt32(reader.GetOrdinal("StocksNum")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    UpperLimit = reader.GetInt32(reader.GetOrdinal("UpperLimit")),
                    LowerLimit = reader.GetInt32(reader.GetOrdinal("LowerLimit"))
                };
                cost = reader.GetValue(reader.GetOrdinal("Cost")).ToString();
                item.Cost = float.Parse(cost);
                item.TypeName = reader.GetString(reader.GetOrdinal("TypeName"));
                item.BrandName = reader.GetString(reader.GetOrdinal("BrandName"));
                item.PhotoUrl = reader.GetString(reader.GetOrdinal("PhotoUrl"));
                list.Add(item);
            }
            reader.Close();
            return list;
        }
    }
}

