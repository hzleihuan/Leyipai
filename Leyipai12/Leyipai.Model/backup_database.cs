using System;
namespace Leyipai.Model
{
	/// <summary>
	/// ʵ����backup_database ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class backup_database
	{
		public backup_database()
		{}
		#region Model
		private int _id;
		private string _file_name;
		private string _deal_time;
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
		public string file_name
		{
			set{ _file_name=value;}
			get{return _file_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string deal_time
		{
			set{ _deal_time=value;}
			get{return _deal_time;}
		}
		#endregion Model

	}
}

