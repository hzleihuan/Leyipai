namespace Leyp.SQLServerDAL.Service
{
    using Leyp.Model;
    using Leyp.Model.Stock;
    using Leyp.SQLServerDAL;
    using Leyp.SQLServerDAL.Stock;
    using System;
    using System.Collections.Generic;

    public class AppendStockService
    {
        public bool AuditingAppendStockOrder(string AppendID)
        {
            bool result = false;
            try
            {
                VAppendStock bp = new VAppendStock();
                List<VAppendStockDetail> list = new List<VAppendStockDetail>();
                ProductsStockDAL pd = new ProductsStockDAL();
                bp = new AppendStockDAL().getByID(AppendID);
                list = new AppendStockDetailDAL().getListByAppendID(AppendID);
                for (int i = 0; i < list.Count; i++)
                {
                    ProductsStock ps;
                    AppendStockDetail b = list[i];
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

