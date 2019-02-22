namespace Leyp.SQLServerDAL
{
    using Leyp.Model;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class NoticeDAL
    {
        public bool deleteEitity(int NoticeID)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@NoticeID", SqlDbType.Int) };
            parm[0].Value = NoticeID;
            SQLHelper.RunProcedure("p_Notice_deleteEitity", parm, out rowsAffect);
            return (0 < rowsAffect);
        }

        public List<Notice> getAll()
        {
            List<Notice> list = new List<Notice>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_Notice_getAll", null);
            while (reader.Read())
            {
                Notice item = new Notice {
                    NoticeID = reader.GetInt32(reader.GetOrdinal("NoticeID")),
                    Info = reader.GetString(reader.GetOrdinal("Info")),
                    State = reader.GetInt32(reader.GetOrdinal("State")),
                    Title = reader.GetString(reader.GetOrdinal("Title")),
                    CreateDate = reader.GetString(reader.GetOrdinal("CreateDate")),
                    Type = reader.GetInt32(reader.GetOrdinal("Type")),
                    UserName = reader.GetString(reader.GetOrdinal("UserName"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public Notice getByID(int NoticeID)
        {
            bool result = false;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@NoticeID", SqlDbType.Int, 4) };
            parm[0].Value = NoticeID;
            Notice item = new Notice();
            SqlDataReader reader = SQLHelper.RunProcedure("p_Notice_getByID", parm);
            if (reader.Read())
            {
                item.NoticeID = reader.GetInt32(reader.GetOrdinal("NoticeID"));
                item.Info = reader.GetString(reader.GetOrdinal("Info"));
                item.State = reader.GetInt32(reader.GetOrdinal("State"));
                item.Title = reader.GetString(reader.GetOrdinal("Title"));
                item.CreateDate = reader.GetString(reader.GetOrdinal("CreateDate"));
                item.Type = reader.GetInt32(reader.GetOrdinal("Type"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                result = true;
            }
            reader.Close();
            return (result ? item : null);
        }

        public List<Notice> getNewsByType(int Type)
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@Type", SqlDbType.Int, 4) };
            parm[0].Value = Type;
            List<Notice> list = new List<Notice>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_Notice_getNewsByType", parm);
            while (reader.Read())
            {
                Notice item = new Notice {
                    NoticeID = reader.GetInt32(reader.GetOrdinal("NoticeID")),
                    Info = reader.GetString(reader.GetOrdinal("Info")),
                    State = reader.GetInt32(reader.GetOrdinal("State")),
                    Title = reader.GetString(reader.GetOrdinal("Title")),
                    CreateDate = reader.GetString(reader.GetOrdinal("CreateDate")),
                    Type = reader.GetInt32(reader.GetOrdinal("Type")),
                    UserName = reader.GetString(reader.GetOrdinal("UserName"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public List<Notice> getSearchListByType(int Type)
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@Type", SqlDbType.Int, 4) };
            parm[0].Value = Type;
            List<Notice> list = new List<Notice>();
            SqlDataReader reader = SQLHelper.RunProcedure("p_Notice_getSearchListByType", parm);
            while (reader.Read())
            {
                Notice item = new Notice {
                    NoticeID = reader.GetInt32(reader.GetOrdinal("NoticeID")),
                    Info = reader.GetString(reader.GetOrdinal("Info")),
                    State = reader.GetInt32(reader.GetOrdinal("State")),
                    Title = reader.GetString(reader.GetOrdinal("Title")),
                    CreateDate = reader.GetString(reader.GetOrdinal("CreateDate")),
                    Type = reader.GetInt32(reader.GetOrdinal("Type")),
                    UserName = reader.GetString(reader.GetOrdinal("UserName"))
                };
                list.Add(item);
            }
            reader.Close();
            return list;
        }

        public bool insertNewEntity(Notice s)
        {
            int rowsAffect = 0;
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@Type", SqlDbType.Int), new SqlParameter("@Title", SqlDbType.NVarChar), new SqlParameter("@UserName", SqlDbType.NVarChar), new SqlParameter("@CreateDate", SqlDbType.NVarChar), new SqlParameter("@Info", SqlDbType.NVarChar) };
            parm[0].Value = s.Type;
            parm[1].Value = s.Title;
            parm[2].Value = s.UserName;
            parm[3].Value = s.CreateDate;
            parm[4].Value = s.Info;
            SQLHelper.RunProcedure("p_Notice_insertNewEntity", parm, out rowsAffect);
            return (1 == rowsAffect);
        }
    }
}

