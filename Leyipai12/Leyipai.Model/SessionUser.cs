using System;
using System.Collections.Generic;
using System.Text;

namespace Leyipai.Model
{
    public class SessionUser
    {
        private int _uid;
        private int _rid;
        private string _username;
        private string _password;
        private string _realname;
        private int _state;

        private List<Int32> _myresource;
        /// <summary>
        /// 
        /// </summary>
        public int uid
        {
            set { _uid = value; }
            get { return _uid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int rid
        {
            set { _rid = value; }
            get { return _rid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string username
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string realname
        {
            set { _realname = value; }
            get { return _realname; }
        }


        /// <summary>
        /// 
        /// </summary>
        public int state
        {
            set { _state = value; }
            get { return _state; }
        }


        private string _rosename;

        public string rosename
        {
            set { _rosename = value; }
            get { return _rosename; }
        }


        public List<Int32> myresource
        {
            set { _myresource = value; }
            get { return _myresource; }
        }
    }
}
