using System;
using System.Collections.Generic;
using System.Text;

namespace Leyipai.Common
{
    public class PageList<T>
    {
        private List<T> _root;

        public List<T> root
        {
            set { _root = value; }
            get { return _root; }
        }
    }
}
