using System;
using System.Collections.Generic;
using System.Text;

namespace Leyipai.Common
{
   public class Page<T>
    {

    private int _totalProperty;

       private List<T> _root;

	private int _limit;

	private int _start;
	
	private bool _success;

	private string _msg;
	
	private string _currentUser;
	




       public int totalProperty
       {
           set { _totalProperty = value; }
           get { return _totalProperty; }
       }


       public List<T> root
       {
           set { _root = value; }
           get { return _root; }
       }


       public int limit
       {
           set { _limit = value; }
           get { return _limit; }
       }


       public int start
       {
           set { _start = value; }
           get { return _start; }
       }

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


       public string currentUser
       {
           set { _currentUser = value; }
           get { return _currentUser; }
       }
    }
}
