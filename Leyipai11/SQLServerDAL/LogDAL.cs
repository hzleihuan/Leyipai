namespace Leyp.SQLServerDAL
{
    using Leyp.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;

    [DataObject]
    public class LogDAL
    {
        public bool addLog(Log log)
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@LogTime", SqlDbType.NVarChar), new SqlParameter("@Description", SqlDbType.NVarChar) };
            parm[0].Value = log.LogTime;
            parm[1].Value = log.Description;
            int i = SQLHelper.ExecuteNonQuery(SQLHelper.strCon, CommandType.StoredProcedure, "p_log_addNewLog", parm);
            return (1 == i);
        }

        public List<Log> getAllLog()
        {
            List<Log> LogList = new List<Log>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_log_getAll", null);
            while (reader.Read())
            {
                Log item = new Log {
                    LogID = reader.GetInt32(reader.GetOrdinal("LogID")),
                    LogTime = reader.GetString(reader.GetOrdinal("LogTime")),
                    Description = reader.GetString(reader.GetOrdinal("Description"))
                };
                LogList.Add(item);
            }
            reader.Close();
            return LogList;
        }
    }
}

