using System;
namespace Leyipai.Model
{
	/// <summary>
	/// ʵ����c_logistics ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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

