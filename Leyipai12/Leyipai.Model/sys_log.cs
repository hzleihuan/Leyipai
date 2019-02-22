using System;
namespace Leyipai.Model
{
	/// <summary>
	/// 实体类sys_log 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class sys_log
	{
		public sys_log()
		{}
		#region Model
		private int _id;
		private string _log_time;
		private string _log_username;
		private string _log_info;
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
		public string log_time
		{
			set{ _log_time=value;}
			get{return _log_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string log_username
		{
			set{ _log_username=value;}
			get{return _log_username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string log_info
		{
			set{ _log_info=value;}
			get{return _log_info;}
		}
		#endregion Model

	}
}

