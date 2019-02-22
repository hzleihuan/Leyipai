﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Leyp.Model.Stock
{
   public  class OutStockDetail
    {
        private int _DetailID;
        private string _OutID;
        private int _ProductsID;
        private int _Quantity = 0;

        private float _Price = float.Parse("0.00");
        private string _Description;


        /// <summary>
        /// 标识主键
        /// </summary>
        public int DetailID
        {
            get { return _DetailID; }
            set { _DetailID = value; }
        }

        /// <summary>
        /// 对应简明表ID
        /// </summary>
       public string OutID
        {
            get { return _OutID; }
            set { _OutID = value; }
        }

        /// <summary>
        /// 商品ID
        /// </summary>
        public int ProductsID
        {
            get { return _ProductsID; }
            set { _ProductsID = value; }
        }


       


        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }




        /////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 标准价
        /// </summary>
        public float Price
        {
            get { return _Price; }
            set { _Price = value; }
        }





        /// <summary>
        /// 摘要
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

    }
}
