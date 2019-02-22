using System;
using System.Collections.Generic;
using System.Text;

namespace Leyipai.Model
{
    [Serializable]
    public class depot_products
    {

        public depot_products() { }

        private int _id;
        private int _product_id;
        private int _depot_id;
        private int _quantity;



        private string _product_name;
        private string _depot_name;


        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int product_id
        {
            set { _product_id = value; }
            get { return _product_id; }
        }


        /// <summary>
        /// 
        /// </summary>
        public int depot_id
        {
            set { _depot_id = value; }
            get { return _depot_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int quantity
        {
            set { _quantity = value; }
            get { return _quantity; }
        }



        /// <summary>
        /// 
        /// </summary>
        public string product_name
        {
            set { _product_name = value; }
            get { return _product_name; }
        }


        /// <summary>
        /// 
        /// </summary>
        public string depot_name
        {
            set { _depot_name = value; }
            get { return _depot_name; }
        }

    }
}
