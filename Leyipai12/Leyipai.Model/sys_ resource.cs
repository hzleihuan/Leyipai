using System;
namespace Leyipai.Model
{
	/// <summary>
	/// 实体类sys_ resource 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class sys_resource
	{
		public sys_resource()
		{}
		#region Model
		private int _rs_id;
		private string _rs_name;
		private string _rs_url;
		private string _rs_type;
		/// <summary>
		/// 
		/// </summary>
		public int rs_id
		{
			set{ _rs_id=value;}
			get{return _rs_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string rs_name
		{
			set{ _rs_name=value;}
			get{return _rs_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string rs_url
		{
			set{ _rs_url=value;}
			get{return _rs_url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string rs_type
		{
			set{ _rs_type=value;}
			get{return _rs_type;}
		}
		#endregion Model

	}
}

