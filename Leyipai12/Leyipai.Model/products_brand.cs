using System;
namespace Leyipai.Model
{
	/// <summary>
	/// 实体类products_brand 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class products_brand
	{
		public products_brand()
		{}
		#region Model
		private int _brand_id;
		private string _brand_name;
		private string _description;
		private int? _state;
		/// <summary>
		/// 
		/// </summary>
		public int brand_id
		{
			set{ _brand_id=value;}
			get{return _brand_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string brand_name
		{
			set{ _brand_name=value;}
			get{return _brand_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? state
		{
			set{ _state=value;}
			get{return _state;}
		}
		#endregion Model

	}
}

