using System;
namespace Leyipai.Model
{
	/// <summary>
	/// 实体类sales_order 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class sales_order
	{
		public sales_order()
		{}
		#region Model
		private int _id;
        private int _period_id;
		private string _sales_orderid;
		private string _create_date;
		private int _sales_type;
		private int _customer_id;
		private int _depot_id;
		private string _delivery_type;
		private string _delivery_place;
		private int? _logistics_id;
		private string _logistics_num;
		private decimal _sales_income;
		private decimal _attach_pay;
		private decimal _discount;
		private string _username;
		private string _auditing_user;
		private string _description;
		private int _state;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}


        public int period_id
		{
            set { _period_id = value; }
            get { return _period_id; }
		}
        
		/// <summary>
		/// 
		/// </summary>
		public string sales_orderId
		{
			set{ _sales_orderid=value;}
			get{return _sales_orderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string create_date
		{
			set{ _create_date=value;}
			get{return _create_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int sales_type
		{
			set{ _sales_type=value;}
			get{return _sales_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int customer_id
		{
			set{ _customer_id=value;}
			get{return _customer_id;}
		}
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
		public string delivery_type
		{
			set{ _delivery_type=value;}
			get{return _delivery_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string delivery_place
		{
			set{ _delivery_place=value;}
			get{return _delivery_place;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? logistics_id
		{
			set{ _logistics_id=value;}
			get{return _logistics_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string logistics_num
		{
			set{ _logistics_num=value;}
			get{return _logistics_num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal sales_income
		{
			set{ _sales_income=value;}
			get{return _sales_income;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal attach_pay
		{
			set{ _attach_pay=value;}
			get{return _attach_pay;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal discount
		{
			set{ _discount=value;}
			get{return _discount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string auditing_user
		{
			set{ _auditing_user=value;}
			get{return _auditing_user;}
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
		public int state
		{
			set{ _state=value;}
			get{return _state;}
		}
		#endregion Model




        #region ModelVO
        private string _customer_name;
        private string _depot_name;
        private string _logistics_name;


        public string customer_name
        {
            set { _customer_name = value; }
            get { return _customer_name; }
        }


        public string depot_name
        {
            set { _depot_name = value; }
            get { return _depot_name; }
        }


        public string logistics_name
        {
            set { _logistics_name = value; }
            get { return _logistics_name; }
        }
        #endregion ModelVO


    }
}

