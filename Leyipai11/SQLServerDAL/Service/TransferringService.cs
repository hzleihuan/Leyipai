namespace Leyp.SQLServerDAL.Service
{
    using Leyp.Model;
    using Leyp.Model.Stock;
    using Leyp.SQLServerDAL;
    using Leyp.SQLServerDAL.Stock;
    using System;

    public class TransferringService
    {
        public bool AuditingTransferring(string ID)
        {
            bool result = false;
            try
            {
                ProductsStockDAL pd = new ProductsStockDAL();
                VTransferringOrder bp = new TransferringOrderDAL().getByID(ID);
                if (bp == null)
                {
                    return false;
                }
                int OutId = bp.OutHouseID;
                int InId = bp.InHouseID;
                int Pid = bp.ProductsID;
                int Num = bp.Quantity;
                ProductsStock pu = pd.getByProductsIDStockID(Pid, OutId);
                ProductsStock pi = pd.getByProductsIDStockID(Pid, InId);
                if (pu == null)
                {
                    return false;
                }
                if (Num > pu.Num)
                {
                    return false;
                }
                ProductsStock pu0 = new ProductsStock {
                    HouseDetailID = OutId,
                    ProductsID = Pid,
                    Num = Num
                };
                ProductsStock pi0 = new ProductsStock {
                    HouseDetailID = InId,
                    ProductsID = Pid,
                    Num = Num
                };
                if (pd.updateCutNum(pu0))
                {
                    if (pi == null)
                    {
                        pd.insertNewEitity(pi0);
                    }
                    else
                    {
                        pd.updateAddNum(pi0);
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

