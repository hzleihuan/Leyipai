namespace Leyp.SQLServerDAL.Service
{
    using Leyp.Model;
    using Leyp.Model.Stock;
    using Leyp.SQLServerDAL;
    using Leyp.SQLServerDAL.Stock;
    using System;

    public class InventoryService
    {
        public bool AuditingInventoryOrder(string InventoryID)
        {
            bool result = false;
            try
            {
                ProductsStock ps;
                VInventory bp = new VInventory();
                ProductsStockDAL pd = new ProductsStockDAL();
                bp = new InventoryDAL().getByID(InventoryID);
                if (pd.isHaveEitity(bp.HouseDetailID, bp.ProductsID))
                {
                    ps = new ProductsStock {
                        HouseDetailID = bp.HouseDetailID,
                        ProductsID = bp.ProductsID,
                        Num = bp.AdjustNum
                    };
                    pd.updateEitityNum(ps);
                }
                else
                {
                    ps = new ProductsStock {
                        HouseDetailID = bp.HouseDetailID,
                        ProductsID = bp.ProductsID,
                        Num = bp.AdjustNum
                    };
                    pd.insertNewEitity(ps);
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

