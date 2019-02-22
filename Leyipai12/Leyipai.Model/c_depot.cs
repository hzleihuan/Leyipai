using System;
namespace Leyipai.Model
{
	/// <summary>
	/// 实体类c_depot 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class c_depot
	{
		public c_depot()
		{}
		#region Model
		private int _depot_id;
		private string _depot_name;
		private int? _state;
		/// <summary>
		/// 
		/// </summary>
		public int depot_id
		{
			set{ _depot_id=value;}
			get{return _depot_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string depot_name
		{
			set{ _depot_name=value;}
			get{return _depot_name;}
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

