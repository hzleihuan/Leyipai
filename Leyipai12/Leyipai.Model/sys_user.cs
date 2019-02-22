using System;
namespace Leyipai.Model
{
	/// <summary>
	/// 实体类sys_user 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class sys_user
	{
		public sys_user()
		{}
		#region Model
		private int _uid;
		private int _rid;
		private string _username;
		private string _password;
		private string _realname;
		private string _department;
		private string _qq;
		private string _email;
		private string _tel;
		private int _state;
		/// <summary>
		/// 
		/// </summary>
		public int uid
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int rid
		{
			set{ _rid=value;}
			get{return _rid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string realname
		{
			set{ _realname=value;}
			get{return _realname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string department
		{
			set{ _department=value;}
			get{return _department;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string qq
		{
			set{ _qq=value;}
			get{return _qq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int state
		{
			set{ _state=value;}
			get{return _state;}
		}
		#endregion Model

        private string _rosename;

        public string rosename
        {
            set { _rosename = value; }
            get { return _rosename; }
        }
	}
}

