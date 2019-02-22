using System;
using System.Collections.Generic;
using System.Text;
using Leyipai.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace Leyipai.DAL.products
{
    public class ProductsDAL
    {


        public ProductsDAL()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("product_id", "products"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int product_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from products");
			strSql.Append(" where product_id=@product_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@product_id", SqlDbType.Int,4)};
			parameters[0].Value = product_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Leyipai.Model.products model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into products(");
			strSql.Append("product_name,type_id,brand_id,cost_price,wholesale_price,retail_price,units,weight,material,spec,prc,upperLimit,lowerLimit,expiry_date,code,description)");
			strSql.Append(" values (");
			strSql.Append("@product_name,@type_id,@brand_id,@cost_price,@wholesale_price,@retail_price,@units,@weight,@material,@spec,@prc,@upperLimit,@lowerLimit,@expiry_date,@code,@description)");
			strSql.Append(";select @@IDENTITY");

            SqlParameter cost_price = new SqlParameter("@cost_price", SqlDbType.Money, 8);
            cost_price.Precision = 10;
            cost_price.Scale = 2;

            SqlParameter wholesale_price = new SqlParameter("@wholesale_price", SqlDbType.Money, 8);
            wholesale_price.Precision = 10;
            wholesale_price.Scale = 2;


            SqlParameter retail_price = new SqlParameter("@retail_price", SqlDbType.Money, 8);
            retail_price.Precision = 10;
            retail_price.Scale = 2;

			SqlParameter[] parameters = {
					new SqlParameter("@product_name", SqlDbType.VarChar,256),
					new SqlParameter("@type_id", SqlDbType.Int,4),
					new SqlParameter("@brand_id", SqlDbType.Int,4),
					cost_price,
					wholesale_price,
					retail_price,
					new SqlParameter("@units", SqlDbType.VarChar,50),
					new SqlParameter("@weight", SqlDbType.VarChar,50),
					new SqlParameter("@material", SqlDbType.VarChar,50),
					new SqlParameter("@spec", SqlDbType.VarChar,50),
					new SqlParameter("@prc", SqlDbType.VarChar,512),
					new SqlParameter("@upperLimit", SqlDbType.Int,4),
					new SqlParameter("@lowerLimit", SqlDbType.Int,4),
					new SqlParameter("@expiry_date", SqlDbType.VarChar,50),
					new SqlParameter("@code", SqlDbType.VarChar,50),
					new SqlParameter("@description", SqlDbType.VarChar,4000)};
			parameters[0].Value = model.product_name;
			parameters[1].Value = model.type_id;
			parameters[2].Value = model.brand_id;
			parameters[3].Value = model.cost_price;
			parameters[4].Value = model.wholesale_price;
			parameters[5].Value = model.retail_price;
			parameters[6].Value = model.units;
			parameters[7].Value = model.weight;
			parameters[8].Value = model.material;
			parameters[9].Value = model.spec;
			parameters[10].Value = model.prc;
			parameters[11].Value = model.upperLimit;
			parameters[12].Value = model.lowerLimit;
			parameters[13].Value = model.expiry_date;
			parameters[14].Value = model.code;
			parameters[15].Value = model.description;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Leyipai.Model.products model)
		{
			StringBuilder strSql=new StringBuilder();


            SqlParameter cost_price = new SqlParameter("@cost_price", SqlDbType.Money, 8);
            cost_price.Precision = 10;
            cost_price.Scale = 2;

            SqlParameter wholesale_price = new SqlParameter("@wholesale_price", SqlDbType.Money, 8);
            wholesale_price.Precision = 10;
            wholesale_price.Scale = 2;


            SqlParameter retail_price = new SqlParameter("@retail_price", SqlDbType.Money, 8);
            retail_price.Precision = 10;
            retail_price.Scale = 2;
			strSql.Append("update products set ");
			strSql.Append("product_name=@product_name,");
			strSql.Append("type_id=@type_id,");
			strSql.Append("brand_id=@brand_id,");
			strSql.Append("cost_price=@cost_price,");
			strSql.Append("wholesale_price=@wholesale_price,");
			strSql.Append("retail_price=@retail_price,");
			strSql.Append("units=@units,");
			strSql.Append("weight=@weight,");
			strSql.Append("material=@material,");
			strSql.Append("spec=@spec,");
			strSql.Append("prc=@prc,");
			strSql.Append("upperLimit=@upperLimit,");
			strSql.Append("lowerLimit=@lowerLimit,");
			strSql.Append("expiry_date=@expiry_date,");
			strSql.Append("code=@code,");
			strSql.Append("description=@description");
			strSql.Append(" where product_id=@product_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@product_id", SqlDbType.Int,4),
					new SqlParameter("@product_name", SqlDbType.VarChar,256),
					new SqlParameter("@type_id", SqlDbType.Int,4),
					new SqlParameter("@brand_id", SqlDbType.Int,4),
					cost_price,
					wholesale_price,
					retail_price,
					new SqlParameter("@units", SqlDbType.VarChar,50),
					new SqlParameter("@weight", SqlDbType.VarChar,50),
					new SqlParameter("@material", SqlDbType.VarChar,50),
					new SqlParameter("@spec", SqlDbType.VarChar,50),
					new SqlParameter("@prc", SqlDbType.VarChar,512),
					new SqlParameter("@upperLimit", SqlDbType.Int,4),
					new SqlParameter("@lowerLimit", SqlDbType.Int,4),
					new SqlParameter("@expiry_date", SqlDbType.VarChar,50),
					new SqlParameter("@code", SqlDbType.VarChar,50),
					new SqlParameter("@description", SqlDbType.VarChar,4000)};
			parameters[0].Value = model.product_id;
			parameters[1].Value = model.product_name;
			parameters[2].Value = model.type_id;
			parameters[3].Value = model.brand_id;
			parameters[4].Value = model.cost_price;
			parameters[5].Value = model.wholesale_price;
			parameters[6].Value = model.retail_price;
			parameters[7].Value = model.units;
			parameters[8].Value = model.weight;
			parameters[9].Value = model.material;
			parameters[10].Value = model.spec;
			parameters[11].Value = model.prc;
			parameters[12].Value = model.upperLimit;
			parameters[13].Value = model.lowerLimit;
			parameters[14].Value = model.expiry_date;
			parameters[15].Value = model.code;
			parameters[16].Value = model.description;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int product_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from products ");
			strSql.Append(" where product_id=@product_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@product_id", SqlDbType.Int,4)};
			parameters[0].Value = product_id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Leyipai.Model.products GetModel(int product_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append(@"select  top 1  products.*, products_type.type_name, products_brand.brand_name FROM products INNER JOIN products_brand ON products.brand_id = products_brand.brand_id INNER JOIN products_type ON products.type_id = products_type.type_id ");
			strSql.Append(" where product_id=@product_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@product_id", SqlDbType.Int,4)};
			parameters[0].Value = product_id;

			Leyipai.Model.products model=new Leyipai.Model.products();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["product_id"].ToString()!="")
				{
					model.product_id=int.Parse(ds.Tables[0].Rows[0]["product_id"].ToString());
				}
				model.product_name=ds.Tables[0].Rows[0]["product_name"].ToString();
				if(ds.Tables[0].Rows[0]["type_id"].ToString()!="")
				{
					model.type_id=int.Parse(ds.Tables[0].Rows[0]["type_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["brand_id"].ToString()!="")
				{
					model.brand_id=int.Parse(ds.Tables[0].Rows[0]["brand_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["cost_price"].ToString()!="")
				{
                    model.cost_price = double.Parse(ds.Tables[0].Rows[0]["cost_price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["wholesale_price"].ToString()!="")
				{
                    model.wholesale_price = double.Parse(ds.Tables[0].Rows[0]["wholesale_price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["retail_price"].ToString()!="")
				{
                    model.retail_price = double.Parse(ds.Tables[0].Rows[0]["retail_price"].ToString());
				}
				model.units=ds.Tables[0].Rows[0]["units"].ToString();
				model.weight=ds.Tables[0].Rows[0]["weight"].ToString();
				model.material=ds.Tables[0].Rows[0]["material"].ToString();
				model.spec=ds.Tables[0].Rows[0]["spec"].ToString();
				model.prc=ds.Tables[0].Rows[0]["prc"].ToString();
				if(ds.Tables[0].Rows[0]["upperLimit"].ToString()!="")
				{
					model.upperLimit=int.Parse(ds.Tables[0].Rows[0]["upperLimit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lowerLimit"].ToString()!="")
				{
					model.lowerLimit=int.Parse(ds.Tables[0].Rows[0]["lowerLimit"].ToString());
				}
				model.expiry_date=ds.Tables[0].Rows[0]["expiry_date"].ToString();
				model.code=ds.Tables[0].Rows[0]["code"].ToString();
				model.description=ds.Tables[0].Rows[0]["description"].ToString();
                if (ds.Tables[0].Rows[0]["type_name"] != null)
                {
                    model.type_name = ds.Tables[0].Rows[0]["type_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["brand_name"] != null)
                {
                    model.brand_name = ds.Tables[0].Rows[0]["brand_name"].ToString();
                }
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select products.*, products_type.type_name, products_brand.brand_name FROM products INNER JOIN products_brand ON products.brand_id = products_brand.brand_id INNER JOIN products_type ON products.type_id = products_type.type_id ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append("products.*, products_type.type_name, products_brand.brand_name FROM products INNER JOIN products_brand ON products.brand_id = products_brand.brand_id INNER JOIN products_type ON products.type_id = products_type.type_id ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int pagesize, int cureentpage, string strWhere)
        {
            int selectCount = pagesize * cureentpage;
            string strSql = @"select * from (   select TOP " + pagesize + " * FROM ( SELECT TOP " + selectCount + "  * from products_view where " + strWhere + " ORDER BY product_id ASC ) as aSysTable   ORDER BY product_id DESC ) as bSysTable   ORDER BY product_id ASC";
            return DbHelperSQL.Query(strSql.ToString());

        }


        /// <summary>
        /// 相关条件查出来的记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int getSqlRecodeCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) ");
            strSql.Append(" FROM products ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Object o = DbHelperSQL.GetSingle(strSql.ToString());
            if (null == o) return 0;
            else return int.Parse(o.ToString());

        }

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "products";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法
    }


}
