namespace Leyp.SQLServerDAL
{
    using Leyp.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class SupplierDAL
    {
        public List<Supplier> getAllSupplier()
        {
            List<Supplier> list = new List<Supplier>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_Supplier_getALL", null);
            while (reader.Read())
            {
                Supplier item = new Supplier {
                    SupplierID = reader.GetInt32(reader.GetOrdinal("SupplierID")),
                    SupplierName = reader.GetString(reader.GetOrdinal("SupplierName")),
                    Area = reader.GetString(reader.GetOrdinal("Area")),
                    Postcode = reader.GetString(reader.GetOrdinal("Postcode")),
                    Address = reader.GetString(reader.GetOrdinal("Address")),
                    Linkman = reader.GetString(reader.GetOrdinal("Linkman")),
                    Tel = reader.GetString(reader.GetOrdinal("Tel")),
                    WebUrl = reader.GetString(reader.GetOrdinal("WebUrl")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    Bankname = reader.GetString(reader.GetOrdinal("Bankname")),
                    BankAccount = reader.GetString(reader.GetOrdinal("BankAccount")),
                    TaxNum = reader.GetString(reader.GetOrdinal("TaxNum")),
                    CreateDate = reader.GetString(reader.GetOrdinal("CreateDate")),
                    State = reader.GetString(reader.GetOrdinal("State")),
                    Description = reader.GetString(reader.GetOrdinal("Description"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public Supplier getBySupplierID(int SupplierID)
        {
            Supplier item = new Supplier();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SupplierID", SqlDbType.Int, 4) };
            parm[0].Value = SupplierID;
            SqlDataReader reader = SQLHelper.RunProcedure("p_Supplier_getByID", parm);
            while (reader.Read())
            {
                item.SupplierID = reader.GetInt32(reader.GetOrdinal("SupplierID"));
                item.SupplierName = reader.GetString(reader.GetOrdinal("SupplierName"));
                item.Area = reader.GetString(reader.GetOrdinal("Area"));
                item.Postcode = reader.GetString(reader.GetOrdinal("Postcode"));
                item.Address = reader.GetString(reader.GetOrdinal("Address"));
                item.Linkman = reader.GetString(reader.GetOrdinal("Linkman"));
                item.Tel = reader.GetString(reader.GetOrdinal("Tel"));
                item.WebUrl = reader.GetString(reader.GetOrdinal("WebUrl"));
                item.Email = reader.GetString(reader.GetOrdinal("Email"));
                item.Bankname = reader.GetString(reader.GetOrdinal("Bankname"));
                item.BankAccount = reader.GetString(reader.GetOrdinal("BankAccount"));
                item.TaxNum = reader.GetString(reader.GetOrdinal("TaxNum"));
                item.CreateDate = reader.GetString(reader.GetOrdinal("CreateDate"));
                item.State = reader.GetString(reader.GetOrdinal("State"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
            }
            return item;
        }

        public List<Supplier> getSearchListByKey(string Key)
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@Key", SqlDbType.VarChar) };
            parm[0].Value = Key;
            List<Supplier> list = new List<Supplier>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_Supplier_SearchByKey", parm);
            while (reader.Read())
            {
                Supplier item = new Supplier {
                    SupplierID = reader.GetInt32(reader.GetOrdinal("SupplierID")),
                    SupplierName = reader.GetString(reader.GetOrdinal("SupplierName")),
                    Area = reader.GetString(reader.GetOrdinal("Area")),
                    Postcode = reader.GetString(reader.GetOrdinal("Postcode")),
                    Address = reader.GetString(reader.GetOrdinal("Address")),
                    Linkman = reader.GetString(reader.GetOrdinal("Linkman")),
                    Tel = reader.GetString(reader.GetOrdinal("Tel")),
                    WebUrl = reader.GetString(reader.GetOrdinal("WebUrl")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    Bankname = reader.GetString(reader.GetOrdinal("Bankname")),
                    BankAccount = reader.GetString(reader.GetOrdinal("BankAccount")),
                    TaxNum = reader.GetString(reader.GetOrdinal("TaxNum")),
                    CreateDate = reader.GetString(reader.GetOrdinal("CreateDate")),
                    State = reader.GetString(reader.GetOrdinal("State")),
                    Description = reader.GetString(reader.GetOrdinal("Description"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public bool insertNewSupplier(Supplier sp)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SupplierName", SqlDbType.NVarChar), new SqlParameter("@Area", SqlDbType.NVarChar), new SqlParameter("@Postcode", SqlDbType.NVarChar), new SqlParameter("@Address", SqlDbType.NVarChar), new SqlParameter("@Linkman", SqlDbType.NVarChar), new SqlParameter("@Tel", SqlDbType.NVarChar), new SqlParameter("@WebUrl", SqlDbType.NVarChar), new SqlParameter("@Email", SqlDbType.NVarChar), new SqlParameter("@Bankname", SqlDbType.NVarChar), new SqlParameter("@BankAccount", SqlDbType.NVarChar), new SqlParameter("@TaxNum", SqlDbType.NVarChar), new SqlParameter("@CreateDate", SqlDbType.NVarChar), new SqlParameter("@State", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar) };
            parm[0].Value = sp.SupplierName;
            parm[1].Value = sp.Area;
            parm[2].Value = sp.Postcode;
            parm[3].Value = sp.Address;
            parm[4].Value = sp.Linkman;
            parm[5].Value = sp.Tel;
            parm[6].Value = sp.WebUrl;
            parm[7].Value = sp.Email;
            parm[8].Value = sp.Bankname;
            parm[9].Value = sp.BankAccount;
            parm[10].Value = sp.TaxNum;
            parm[11].Value = sp.CreateDate;
            parm[12].Value = sp.State;
            parm[13].Value = sp.Description;
            SQLHelper.RunProcedure("p_Supplier_insertNewSupplier", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public bool updateSupplier(Supplier sp)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@SupplierName", SqlDbType.NVarChar), new SqlParameter("@Area", SqlDbType.NVarChar), new SqlParameter("@Postcode", SqlDbType.NVarChar), new SqlParameter("@Address", SqlDbType.NVarChar), new SqlParameter("@Linkman", SqlDbType.NVarChar), new SqlParameter("@Tel", SqlDbType.NVarChar), new SqlParameter("@WebUrl", SqlDbType.NVarChar), new SqlParameter("@Email", SqlDbType.NVarChar), new SqlParameter("@Bankname", SqlDbType.NVarChar), new SqlParameter("@BankAccount", SqlDbType.NVarChar), new SqlParameter("@TaxNum", SqlDbType.NVarChar), new SqlParameter("@CreateDate", SqlDbType.NVarChar), new SqlParameter("@State", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar), new SqlParameter("@SupplierID", SqlDbType.Int) };
            parm[0].Value = sp.SupplierName;
            parm[1].Value = sp.Area;
            parm[2].Value = sp.Postcode;
            parm[3].Value = sp.Address;
            parm[4].Value = sp.Linkman;
            parm[5].Value = sp.Tel;
            parm[6].Value = sp.WebUrl;
            parm[7].Value = sp.Email;
            parm[8].Value = sp.Bankname;
            parm[9].Value = sp.BankAccount;
            parm[10].Value = sp.TaxNum;
            parm[11].Value = sp.CreateDate;
            parm[12].Value = sp.State;
            parm[13].Value = sp.Description;
            parm[14].Value = sp.SupplierID;
            SQLHelper.RunProcedure("p_Supplier_updateSupplier", parm, out rowsAffect);
            return (1 == rowsAffect);
        }
    }
}

