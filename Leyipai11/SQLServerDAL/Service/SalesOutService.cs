namespace Leyp.SQLServerDAL.Service
{
    using Leyp.Model;
    using Leyp.Model.Sales;
    using Leyp.SQLServerDAL;
    using Leyp.SQLServerDAL.Sales;
    using System;
    using System.Collections.Generic;

    public class SalesOutService
    {
        public bool AuditingSalesOutOrder(string SalesOutID)
        {
            bool result = false;
            try
            {
                VSalesOut bp = new VSalesOut();
                List<VSalesOutDetail> list = new List<VSalesOutDetail>();
                ProductsStockDAL pd = new ProductsStockDAL();
                bp = new SalesOutDAL().getByID(SalesOutID);
                list = new SalesOutDetailDAL().getBySalesOutID(SalesOutID);
                for (int i = 0; i < list.Count; i++)
                {
                    ProductsStock ps;
                    SalesOutDetail b = list[i];
                    if (pd.isHaveEitity(b.HouseDetailID, b.ProductsID))
                    {
                        ps = new ProductsStock {
                            HouseDetailID = b.HouseDetailID,
                            ProductsID = b.ProductsID,
                            Num = b.Quantity
                        };
                        pd.updateCutNum(ps);
                    }
                    else
                    {
                        ps = new ProductsStock {
                            HouseDetailID = b.HouseDetailID,
                            ProductsID = b.ProductsID,
                            Num = -b.Quantity
                        };
                        pd.insertNewEitity(ps);
                    }
                }
                result = true;
            }
            catch
            {
            }
            return result;
        }
    }
}

