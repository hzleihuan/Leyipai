using System;
namespace Leyipai.Model
{
	/// <summary>
	/// 实体类c_customer 。(属性说明自动提取数据库字段的描述信息)
    /// 0供应商 1物流公司 2顾客 3.网站注册用户
	/// </summary>
	[Serializable]
	public class c_customer
	{
		public c_customer()
		{}
		#region Model
		private int _id;
		private string _username;
		private string _password;
		private int _types;
		private string _c_name;
		private string _c_code;
		private string _tariffline;
		private string _tel;
		private string _mobile;
		private string _email;
		private string _link_men;
		private string _address;
		private string _account_info;
		private string _prestige_info;
		private string _remark;
		private int? _rank;
		private int _state;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
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
		public int types
		{
			set{ _types=value;}
			get{return _types;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string c_name
		{
			set{ _c_name=value;}
			get{return _c_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string c_code
		{
			set{ _c_code=value;}
			get{return _c_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tariffline
		{
			set{ _tariffline=value;}
			get{return _tariffline;}
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
		public string mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
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
		public string link_men
		{
			set{ _link_men=value;}
			get{return _link_men;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string account_info
		{
			set{ _account_info=value;}
			get{return _account_info;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string prestige_info
		{
			set{ _prestige_info=value;}
			get{return _prestige_info;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? rank
		{
			set{ _rank=value;}
			get{return _rank;}
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

	}
}

