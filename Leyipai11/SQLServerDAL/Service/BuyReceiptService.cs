namespace Leyp.SQLServerDAL.Service
{
    using Leyp.Model;
    using Leyp.Model.Buy;
    using Leyp.SQLServerDAL;
    using Leyp.SQLServerDAL.Buy;
    using System;
    using System.Collections.Generic;

    public class BuyReceiptService
    {
        public bool AuditingBuyReceiptOrder(string ReceiptOrderID)
        {
            bool result = false;
            try
            {
                BuyReceipt bp = new BuyReceipt();
                List<VBuyReceiptDetail> list = new List<VBuyReceiptDetail>();
                ProductsStockDAL pd = new ProductsStockDAL();
                bp = new BuyReceiptDAL().getByID(ReceiptOrderID);
                list = new BuyReceiptDetailDAL().getBuyReceiptDetailByReceiptOrderID(ReceiptOrderID);
                for (int i = 0; i < list.Count; i++)
                {
                    ProductsStock ps;
                    BuyReceiptDetail b = list[i];
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

