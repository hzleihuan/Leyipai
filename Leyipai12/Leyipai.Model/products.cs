using System;
namespace Leyipai.Model
{
	/// <summary>
	/// 实体类products 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class products
	{
		public products()
		{}
		#region Model
		private int _product_id;
		private string _product_name;
		private int _type_id;
		private int _brand_id;
        private double _cost_price;
        private double _wholesale_price;
        private double _retail_price;
		private string _units;
		private string _weight;
		private string _material;
		private string _spec;
		private string _prc;
		private int? _upperlimit;
		private int? _lowerlimit;
		private string _expiry_date;
		private string _code;
		private string _description;

      
		/// <summary>
		/// 
		/// </summary>
		public int product_id
		{
			set{ _product_id=value;}
			get{return _product_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string product_name
		{
			set{ _product_name=value;}
			get{return _product_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int type_id
		{
			set{ _type_id=value;}
			get{return _type_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int brand_id
		{
			set{ _brand_id=value;}
			get{return _brand_id;}
		}
		/// <summary>
		/// 
		/// </summary>
        public double cost_price
		{
			set{ _cost_price=value;}
			get{return _cost_price;}
		}
		/// <summary>
		/// 
		/// </summary>
        public double wholesale_price
		{
			set{ _wholesale_price=value;}
			get{return _wholesale_price;}
		}
		/// <summary>
		/// 
		/// </summary>
        public double retail_price
		{
			set{ _retail_price=value;}
			get{return _retail_price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string units
		{
			set{ _units=value;}
			get{return _units;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string weight
		{
			set{ _weight=value;}
			get{return _weight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string material
		{
			set{ _material=value;}
			get{return _material;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string spec
		{
			set{ _spec=value;}
			get{return _spec;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string prc
		{
			set{ _prc=value;}
			get{return _prc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? upperLimit
		{
			set{ _upperlimit=value;}
			get{return _upperlimit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? lowerLimit
		{
			set{ _lowerlimit=value;}
			get{return _lowerlimit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string expiry_date
		{
			set{ _expiry_date=value;}
			get{return _expiry_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
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




        #region Model_VO
        private string _brand_name;
        private string _type_name;

        public string brand_name
        {
            set { _brand_name = value; }
            get { return _brand_name; }
        }

        public string type_name
        {
            set { _type_name = value; }
            get { return _type_name; }
        }

        #endregion Model_VO
    }
}

