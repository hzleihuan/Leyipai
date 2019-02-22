using System;
namespace Leyipai.Model
{
	/// <summary>
	/// 实体类accountant_period 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class accountant_period
	{
		public accountant_period()
		{}
		#region Model
		private int _id;
		private string _period_name;
		private string _period_bdate;
		private string _period_edate;
		private decimal _income;
		private decimal _outpay;
		private int _state;
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
		public string period_name
		{
			set{ _period_name=value;}
			get{return _period_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Period_bdate
		{
			set{ _period_bdate=value;}
			get{return _period_bdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Period_edate
		{
			set{ _period_edate=value;}
			get{return _period_edate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal income
		{
			set{ _income=value;}
			get{return _income;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal outpay
		{
			set{ _outpay=value;}
			get{return _outpay;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int state
		{
			set{ _state=value;}
			get{return _state;}
		}
		#endregion Model

	}
}

