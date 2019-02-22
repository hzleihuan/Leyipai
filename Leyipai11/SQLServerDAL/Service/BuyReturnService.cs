namespace Leyp.SQLServerDAL.Service
{
    using Leyp.Model;
    using Leyp.Model.Buy;
    using Leyp.SQLServerDAL;
    using Leyp.SQLServerDAL.Buy;
    using System;
    using System.Collections.Generic;

    public class BuyReturnService
    {
        public bool AuditingBuyReturnOrder(string BuyReturnID)
        {
            bool result = false;
            try
            {
                List<VBuyReturnDetail> list = new List<VBuyReturnDetail>();
                ProductsStockDAL pd = new ProductsStockDAL();
                BuyReturn bp = new BuyReturnDAL().getByID(BuyReturnID);
                if (bp == null)
                {
                    return false;
                }
                list = new BuyReturnDetailDAL().getBuyReturnDetailByBuyReturnID(BuyReturnID);
                for (int i = 0; i < list.Count; i++)
                {
                    ProductsStock ps;
                    BuyReturnDetail b = list[i];
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

