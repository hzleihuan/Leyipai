using System;
namespace Leyipai.Model
{
	/// <summary>
	/// 实体类order_detail 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class order_detail
	{
		public order_detail()
		{}
		#region Model
		private int _id;
		private string _order_id;
		private int _products_id;
		private int _quantity;
		private decimal _price;
		private decimal _discount_rate;
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
		public string order_id
		{
			set{ _order_id=value;}
			get{return _order_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int products_id
		{
			set{ _products_id=value;}
			get{return _products_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int quantity
		{
			set{ _quantity=value;}
			get{return _quantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal discount_rate
		{
			set{ _discount_rate=value;}
			get{return _discount_rate;}
		}
		#endregion Model



        //VO
        private string _products_name;

        /// <summary>
        /// 
        /// </summary>
        public string products_name
        {
            set { _products_name = value; }
            get { return _products_name; }
        }

        private string _units;

        /// <summary>
        /// 
        /// </summary>
        public string units
        {
            set { _units = value; }
            get { return _units; }
        }

	}
}

