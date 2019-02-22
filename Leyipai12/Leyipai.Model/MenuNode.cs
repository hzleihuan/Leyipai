using System;
using System.Collections.Generic;
using System.Text;

namespace Leyipai.Model
{
  public  class MenuNode
    {
      private string _menuname;
      private string _url;
      private int _type;
      private int _pruviewnum;


      public MenuNode(string _menuname, string _url,int _type, int _pruviewnum)
      {
          this.menuname = _menuname;
          this.url = _url;
          this.type = _type;
          this.pruviewnum = _pruviewnum;
      
      }
      /// <summary>
      /// 
      /// </summary>
      public string menuname
      {
          set { _menuname = value; }
          get { return _menuname; }
      }

      /// <summary>
      /// 
      /// </summary>
      public string url
      {
          set { _url = value; }
          get { return _url; }
      }


      /// <summary>
      /// 
      /// </summary>
      public int pruviewnum
      {
          set { _pruviewnum = value; }
          get { return _pruviewnum; }
      }


      /// <summary>
      /// 
      /// </summary>
      public int type
      {
          set { _type = value; }
          get { return _type; }
      }
    }
}
