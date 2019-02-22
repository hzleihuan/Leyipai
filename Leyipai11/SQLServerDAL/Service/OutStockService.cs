namespace Leyp.SQLServerDAL.Service
{
    using Leyp.Model;
    using Leyp.Model.Stock;
    using Leyp.SQLServerDAL;
    using Leyp.SQLServerDAL.Stock;
    using System;
    using System.Collections.Generic;

    public class OutStockService
    {
        public bool AuditingOutStockOrder(string OutStockID)
        {
            bool result = false;
            try
            {
                VOutStock bp = new VOutStock();
                List<VOutStockDetail> list = new List<VOutStockDetail>();
                ProductsStockDAL pd = new ProductsStockDAL();
                bp = new OutStockDAL().getByID(OutStockID);
                list = new OutStockDetailDAL().getListByOutID(OutStockID);
                for (int i = 0; i < list.Count; i++)
                {
                    ProductsStock ps;
                    OutStockDetail b = list[i];
                    if (pd.isHaveEitity(bp.HouseDetailID, b.ProductsID))
                    {
                        ps = new ProductsStock {
                            HouseDetailID = bp.HouseDetailID,
                            ProductsID = b.ProductsID,
                            Num = b.Quantity
                        };
                        pd.updateCutNum(ps);
                    }
                    else
                    {
                        ps = new ProductsStock {
                            HouseDetailID = bp.HouseDetailID,
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

