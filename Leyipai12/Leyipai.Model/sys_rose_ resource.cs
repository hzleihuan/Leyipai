using System;
namespace Leyipai.Model
{
	/// <summary>
	/// ʵ����sys_rose_ resource ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class sys_rose_resource
	{
		public sys_rose_resource()
		{}
		#region Model
		private int? _rid;
		private int? _rsid;
		/// <summary>
		/// 
		/// </summary>
		public int? rid
		{
			set{ _rid=value;}
			get{return _rid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? rsid
		{
			set{ _rsid=value;}
			get{return _rsid;}
		}
		#endregion Model

	}
}

