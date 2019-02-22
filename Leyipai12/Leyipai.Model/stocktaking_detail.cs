using System;
namespace Leyipai.Model
{
	/// <summary>
	/// 实体类stocktaking_detail 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class stocktaking_detail
	{
		public stocktaking_detail()
		{}
		#region Model
		private int _id;
		private string _stocktaking_id;
		private int _product_id;
		private int? _oldstock;
		private int? _newstock;
		private int? _dealstock;
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
		public string stocktaking_id
		{
			set{ _stocktaking_id=value;}
			get{return _stocktaking_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int product_id
		{
			set{ _product_id=value;}
			get{return _product_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? oldstock
		{
			set{ _oldstock=value;}
			get{return _oldstock;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? newstock
		{
			set{ _newstock=value;}
			get{return _newstock;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? dealstock
		{
			set{ _dealstock=value;}
			get{return _dealstock;}
		}
		#endregion Model

	}
}

