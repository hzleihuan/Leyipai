using System;
namespace Leyipai.Model
{
	/// <summary>
	/// 实体类stocktaking 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class stocktaking
	{
		public stocktaking()
		{}
		#region Model
		private int _id;
		private int? _depot_id;
		private string _stocktaking_id;
		private string _takinger;
		private string _taking_date;
		private string _taking_des;
		private int? _state;
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
		public int? depot_id
		{
			set{ _depot_id=value;}
			get{return _depot_id;}
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
		public string takinger
		{
			set{ _takinger=value;}
			get{return _takinger;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string taking_date
		{
			set{ _taking_date=value;}
			get{return _taking_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string taking_des
		{
			set{ _taking_des=value;}
			get{return _taking_des;}
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

