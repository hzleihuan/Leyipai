namespace Leyp.SQLServerDAL
{
    using Leyp.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;

    [DataObject]
    public class AccountsDAL
    {
        public bool deleteEitity(string AccountsID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@AccountsID", SqlDbType.NVarChar) };
            parm[0].Value = AccountsID;
            SQLHelper.RunProcedure("p_Accounts_deleteEitity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public List<Accounts> getAll()
        {
            List<Accounts> list = new List<Accounts>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_Accounts_getAll", null);
            while (reader.Read())
            {
                Accounts item = new Accounts {
                    AccountsID = reader.GetString(reader.GetOrdinal("AccountsID")),
                    AccountsName = reader.GetString(reader.GetOrdinal("AccountsName")),
                    Description = reader.GetString(reader.GetOrdinal("Description"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public Accounts getByID(string AccountsID)
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@AccountsID", SqlDbType.NVarChar) };
            parm[0].Value = AccountsID;
            Accounts item = new Accounts();
            SqlDataReader reader = SQLHelper.RunProcedure("p_Accounts_getByID", parm);
            if (reader.Read())
            {
                item.AccountsID = reader.GetString(reader.GetOrdinal("AccountsID"));
                item.AccountsName = reader.GetString(reader.GetOrdinal("AccountsName"));
                item.Description = reader.GetString(reader.GetOrdinal("Description"));
            }
            reader.Close();
            return item;
        }

        public bool insertEitity(Accounts s)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@AccountsID", SqlDbType.NVarChar), new SqlParameter("@AccountsName", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar) };
            parm[0].Value = s.AccountsID;
            parm[1].Value = s.AccountsName;
            parm[2].Value = s.Description;
            SQLHelper.RunProcedure("p_Accounts_insertEitity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }

        public bool updateEitity(Accounts s)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@AccountsID", SqlDbType.NVarChar), new SqlParameter("@AccountsName", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar) };
            parm[0].Value = s.AccountsID;
            parm[1].Value = s.AccountsName;
            parm[2].Value = s.Description;
            SQLHelper.RunProcedure("p_Accounts_updateEitity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }
    }
}

