using System;
namespace Leyipai.Model
{
	/// <summary>
	/// ʵ����sys_rose ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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

