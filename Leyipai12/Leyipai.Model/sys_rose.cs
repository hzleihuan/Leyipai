using System;
namespace Leyipai.Model
{
	/// <summary>
	/// 实体类sys_rose 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class sys_rose
	{
		public sys_rose()
		{}
		#region Model
		private int _rid;
		private string _rose_name;
		private string _des;
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
		public string rose_name
		{
			set{ _rose_name=value;}
			get{return _rose_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string des
		{
			set{ _des=value;}
			get{return _des;}
		}
		#endregion Model

	}
}

