using System;
namespace Leyipai.Model
{
	/// <summary>
	/// 实体类c_logistics 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class c_logistics
	{
		public c_logistics()
		{}
		#region Model
		private int _id;
		private string _logistics_name;
		private string _description;
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
		public string logistics_name
		{
			set{ _logistics_name=value;}
			get{return _logistics_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string description
		{
			set{ _description=value;}
			get{return _description;}
		}
		#endregion Model

	}
}

