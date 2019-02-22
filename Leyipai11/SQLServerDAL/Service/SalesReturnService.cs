namespace Leyp.SQLServerDAL.Service
{
    using Leyp.Model;
    using Leyp.Model.Sales;
    using Leyp.SQLServerDAL;
    using Leyp.SQLServerDAL.Sales;
    using System;
    using System.Collections.Generic;

    public class SalesReturnService
    {
        public bool AuditingSalesOutOrder(string SalesReturnID)
        {
            bool result = false;
            try
            {
                VSalesReturn bp = new VSalesReturn();
                List<VSalesReturnDetail> list = new List<VSalesReturnDetail>();
                ProductsStockDAL pd = new ProductsStockDAL();
                bp = new SalesReturnDAL().getByID(SalesReturnID);
                list = new SalesReturnDetailDAL().getBySalesReturnID(SalesReturnID);
                for (int i = 0; i < list.Count; i++)
                {
                    ProductsStock ps;
                    SalesReturnDetail b = list[i];
                    if (pd.isHaveEitity(bp.HouseDetailID, b.ProductsID))
                    {
                        ps = new ProductsStock {
                            HouseDetailID = bp.HouseDetailID,
                            ProductsID = b.ProductsID,
                            Num = b.Quantity
                        };
                        pd.updateAddNum(ps);
                    }
                    else
                    {
                        ps = new ProductsStock {
                            HouseDetailID = bp.HouseDetailID,
                            ProductsID = b.ProductsID,
                            Num = b.Quantity
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

