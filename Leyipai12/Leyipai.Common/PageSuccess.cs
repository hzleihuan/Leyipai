using System;
using System.Collections.Generic;
using System.Text;

namespace Leyipai.Common
{
    /// <summary>
    /// ³É¹¦result Page
    /// </summary>
   public class PageSuccess
    {

        private bool _success;

        private string _msg;

        public bool success
        {
            set { _success = value; }
            get { return _success; }
        }

        public string msg
        {
            set { _msg = value; }
            get { return _msg; }
        }


    }
}
