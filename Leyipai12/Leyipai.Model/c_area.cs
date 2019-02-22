using System;
using System.Collections.Generic;
namespace Leyipai.Model
{
	/// <summary>
	/// 实体类c_area 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class c_area
	{
		public c_area()
		{}
		#region Model
		private int _id;
		private string _area_name;
        private int _parent_id;
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
		public string area_name
		{
			set{ _area_name=value;}
			get{return _area_name;}
		}
		/// <summary>
		/// 
		/// </summary>
        public int parent_id
		{
			set{ _parent_id=value;}
			get{return _parent_id;}
		}
		#endregion Model


        #region Model_VO
        private bool _leaf;

        private List<Leyipai.Model.c_area> _children;
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
        public List<Leyipai.Model.c_area> children
        {
            set { _children = value; }
            get { return _children; }
        }


        private string _text;

        public string text {
            set { _area_name = value; }
            get { return _area_name; }
        }
        #endregion Model
    }
}

