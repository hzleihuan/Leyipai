namespace Leyp.SQLServerDAL
{
    using Leyp.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;

    [DataObject]
    public class ProductsDAL
    {
        public bool deleteByProductsID(int ProductsID)
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ProductsID", SqlDbType.Int) };
            parm[0].Value = ProductsID;
            int i = SQLHelper.ExecuteNonQuery(SQLHelper.strCon, CommandType.StoredProcedure, "p_Products_DeleteByProductsID", parm);
            return (1 == i);
        }

        public List<Products> getAllProducts()
        {
            string cost = "";
            List<Products> list = new List<Products>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_Products_GetAll", null);
            while (reader.Read())
            {
                Products item = new Products {
                    ProductsID = reader.GetInt32(reader.GetOrdinal("ProductsID")),
                    ProductsName = reader.GetString(reader.GetOrdinal("ProductsName")),
                    TypeID = reader.GetInt32(reader.GetOrdinal("TypeID")),
                    BrandID = reader.GetInt32(reader.GetOrdinal("BrandID")),
                    BeginEnterDate = reader.GetString(reader.GetOrdinal("BeginEnterDate")),
                    FinalEnterDate = reader.GetString(reader.GetOrdinal("FinalEnterDate")),
                    LatelyOFSDate = reader.GetString(reader.GetOrdinal("LatelyOFSDate")),
                    LoadingDate = reader.GetString(reader.GetOrdinal("LoadingDate"))
                };
                cost = reader.GetValue(reader.GetOrdinal("Cost")).ToString();
                item.Cost = float.Parse(cost);
                cost = reader.GetValue(reader.GetOrdinal("Price")).ToString();
                item.Price = float.Parse(cost);
                item.UnshelveDate = reader.GetString(reader.GetOrdinal("UnshelveDate"));
                item.ProductsUints = reader.GetString(reader.GetOrdinal("ProductsUints"));
                item.Color = reader.GetString(reader.GetOrdinal("Color"));
                item.Weight = reader.GetString(reader.GetOrdinal("Weight"));
                item.Material = reader.GetString(reader.GetOrdinal("Material"));
                item.Spec = reader.GetString(reader.GetOrdinal("Spec"));
                item.UpperLimit = reader.GetInt32(reader.GetOrdinal("UpperLimit"));
                item.LowerLimit = reader.GetInt32(reader.GetOrdinal("LowerLimit"));
                item.PhotoUrl = reader.GetString(reader.GetOrdinal("PhotoUrl"));
                item.TotalSalesNum = reader.GetInt32(reader.GetOrdinal("TotalSalesNum"));
                item.StocksNum = reader.GetInt32(reader.GetOrdinal("StocksNum"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public Products getByProductsID(int ProductsID)
        {
            string cost = "";
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ProductsID", SqlDbType.Int) };
            parm[0].Value = ProductsID;
            Products item = new Products();
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
                item.LoadingDate = reader.GetString(reader.GetOrdinal("LoadingDate"));
                item.ProductsUints = reader.GetString(reader.GetOrdinal("ProductsUints"));
                item.UpperLimit = reader.GetInt32(reader.GetOrdinal("UpperLimit"));
                item.LowerLimit = reader.GetInt32(reader.GetOrdinal("LowerLimit"));
                cost = reader.GetValue(reader.GetOrdinal("Cost")).ToString();
                item.Cost = float.Parse(cost);
                item.Color = reader.GetString(reader.GetOrdinal("Color"));
                item.Weight = reader.GetString(reader.GetOrdinal("Weight"));
                item.Material = reader.GetString(reader.GetOrdinal("Material"));
                item.Spec = reader.GetString(reader.GetOrdinal("Spec"));
                item.TotalSalesNum = reader.GetInt32(reader.GetOrdinal("TotalSalesNum"));
                item.StocksNum = reader.GetInt32(reader.GetOrdinal("StocksNum"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
            }
            reader.Close();
            return item;
        }

        public bool insertNewProducts(Products pro)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { 
                new SqlParameter("@ProductsName", SqlDbType.NVarChar), new SqlParameter("@TypeID", SqlDbType.Int), new SqlParameter("@BrandID", SqlDbType.Int), new SqlParameter("@Color", SqlDbType.NVarChar), new SqlParameter("@Weight", SqlDbType.NVarChar), new SqlParameter("@Spec", SqlDbType.NVarChar), new SqlParameter("@Cost", SqlDbType.Money), new SqlParameter("@ProductsUints", SqlDbType.NVarChar), new SqlParameter("@Material", SqlDbType.NVarChar), new SqlParameter("@UpperLimit", SqlDbType.Int), new SqlParameter("@LowerLimit", SqlDbType.Int), new SqlParameter("@BeginEnterDate", SqlDbType.NVarChar), new SqlParameter("@FinalEnterDate", SqlDbType.NVarChar), new SqlParameter("@LatelyOFSDate", SqlDbType.NVarChar), new SqlParameter("@UnshelveDate", SqlDbType.NVarChar), new SqlParameter("@LoadingDate", SqlDbType.NVarChar), 
                new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@Price", SqlDbType.Float)
             };
            parm[0].Value = pro.ProductsName;
            parm[1].Value = pro.TypeID;
            parm[2].Value = pro.BrandID;
            parm[3].Value = pro.Color;
            parm[4].Value = pro.Weight;
            parm[5].Value = pro.Spec;
            parm[6].Value = pro.Cost;
            parm[7].Value = pro.ProductsUints;
            parm[8].Value = pro.Material;
            parm[9].Value = pro.UpperLimit;
            parm[10].Value = pro.LowerLimit;
            parm[11].Value = pro.BeginEnterDate;
            parm[12].Value = pro.FinalEnterDate;
            parm[13].Value = pro.LatelyOFSDate;
            parm[14].Value = pro.UnshelveDate;
            parm[15].Value = pro.LoadingDate;
            parm[0x10].Value = pro.Description;
            parm[0x11].Value = pro.Price;
            SQLHelper.RunProcedure("p_Products_InsertNew", parm, out rowsAffect);
            if (rowsAffect == 1)
            {
                List<UserTypeSubClass> al = new List<UserTypeSubClass>();
                al = new UserTypeSubClassDAL().getAllUserTypeSubClass();
                int ProductsID = -1;
                SqlDataReader reader = SQLHelper.RunProcedure("p_Products_GetLastRecond", null);
                while (reader.Read())
                {
                    ProductsID = reader.GetInt32(reader.GetOrdinal("ProductsID"));
                }
                for (int i = 0; i < al.Count; i++)
                {
                    ProductsUserType p = new ProductsUserType();
                    UserTypeSubClass u = al[i];
                    p.Price = pro.Price;
                    p.ProductsID = ProductsID;
                    p.SubClassID = u.SubClassID;
                    new ProductsUserTypeDAL().insertNewRecord(p);
                }
            }
            return (1 == rowsAffect);
        }

        public bool updateProducts(Products pro)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { 
                new SqlParameter("@ProductsName", SqlDbType.NVarChar), new SqlParameter("@TypeID", SqlDbType.Int), new SqlParameter("@BrandID", SqlDbType.Int), new SqlParameter("@Color", SqlDbType.NVarChar), new SqlParameter("@Weight", SqlDbType.NVarChar), new SqlParameter("@Spec", SqlDbType.NVarChar), new SqlParameter("@Cost", SqlDbType.Money), new SqlParameter("@ProductsUints", SqlDbType.NVarChar), new SqlParameter("@Material", SqlDbType.NVarChar), new SqlParameter("@UpperLimit", SqlDbType.Int), new SqlParameter("@LowerLimit", SqlDbType.Int), new SqlParameter("@BeginEnterDate", SqlDbType.NVarChar), new SqlParameter("@FinalEnterDate", SqlDbType.NVarChar), new SqlParameter("@LatelyOFSDate", SqlDbType.NVarChar), new SqlParameter("@UnshelveDate", SqlDbType.NVarChar), new SqlParameter("@LoadingDate", SqlDbType.NVarChar), 
                new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@ProductsID", SqlDbType.Int), new SqlParameter("@Price", SqlDbType.Money)
             };
            parm[0].Value = pro.ProductsName;
            parm[1].Value = pro.TypeID;
            parm[2].Value = pro.BrandID;
            parm[3].Value = pro.Color;
            parm[4].Value = pro.Weight;
            parm[5].Value = pro.Spec;
            parm[6].Value = pro.Cost;
            parm[7].Value = pro.ProductsUints;
            parm[8].Value = pro.Material;
            parm[9].Value = pro.UpperLimit;
            parm[10].Value = pro.LowerLimit;
            parm[11].Value = pro.BeginEnterDate;
            parm[12].Value = pro.FinalEnterDate;
            parm[13].Value = pro.LatelyOFSDate;
            parm[14].Value = pro.UnshelveDate;
            parm[15].Value = pro.LoadingDate;
            parm[0x10].Value = pro.Description;
            parm[0x11].Value = pro.ProductsID;
            parm[0x12].Value = pro.Price;
            SQLHelper.RunProcedure("p_Products_updateProducts", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public bool updateProductsPhoto(int ProductsID, string PhotoUrl)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@ProductsID", SqlDbType.Int), new SqlParameter("@PhotoUrl", SqlDbType.NVarChar) };
            parm[0].Value = ProductsID;
            parm[1].Value = PhotoUrl;
            SQLHelper.RunProcedure("p_Products_updateProductsPhoto", parm, out rowsAffect);
            return (1 == rowsAffect);
        }
    }
}

