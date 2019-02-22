using System;
using System.Collections.Generic;
namespace Leyipai.Model
{
	/// <summary>
	/// 实体类products_type 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class products_type
	{
		public products_type()
		{}
		#region Model
		private int _type_id;
		private int? _parent_id;
		private string _type_name;
		private string _description;
		private int? _state;
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
		public int? parent_id
		{
			set{ _parent_id=value;}
			get{return _parent_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string type_name
		{
			set{ _type_name=value;}
			get{return _type_name;}
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
		public int? state
		{
			set{ _state=value;}
			get{return _state;}
		}
		#endregion Model


        #region Model vo
        /// <summary>
        /// 
        /// </summary>
        public string text
        {
            set { _type_name = value; }
            get { return _type_name; }
        }


        private bool _leaf;

        private List<Leyipai.Model.products_type> _children;
        public bool leaf
        {
            set { _leaf = value; }
            get
            {
                if (children == null) return true;
                else
                    return children.Count == 0;
            }
        }
        public List<Leyipai.Model.products_type> children
        {
            set { _children = value; }
            get { return _children; }
        }

        #endregion Model vo

    }
}

