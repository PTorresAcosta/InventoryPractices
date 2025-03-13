using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice5Bussiness.Interfaces;
using Practice5DataAccess.DAOs.Interfaces;
using Practice5Model.DTO;

namespace Practice5Bussiness.Implementations
{

    public class PurchaseProductBLL : IPurchaseProductBLL
    {

        private readonly IPurchaseProductDAO _purchaseProductDAO;
        public PurchaseProductBLL(IPurchaseProductDAO purchaseProductDAO)
        {
            _purchaseProductDAO = purchaseProductDAO;
        }

        public IEnumerable<PurchaseProductDTO> getPurchaseProduct()
        {
            IEnumerable<PurchaseProductDTO> purchaseProducts = null;

            try
            {
                purchaseProducts = _purchaseProductDAO.getPurchaseProduct();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Business Layer: " + ex.Message);
            }

            return purchaseProducts;
        }
    }
}
