using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice5DataAccess.DAOs.Interfaces;
using Practice5DataAccess.Data;
using Practice5Model.DTO;

namespace Practice5DataAccess.DAOs.Implementations
{

    public class PurchaseProductDAO : IPurchaseProductDAO
    {

        private readonly ApplicationDbContext _context;

        public PurchaseProductDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<PurchaseProductDTO> getPurchaseProduct()
        {
            IEnumerable<PurchaseProductDTO> purchaseProducts = null;

            try
            {
                purchaseProducts = from pu in _context.Purchases
                                   join pr in _context.Products
                                   on pu.ProductId equals pr.ProductId
                                   select new PurchaseProductDTO
                                   {
                                       Product = pr,
                                       Purchase = pu
                                   };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Data Layer: " + ex.Message);
            }

            return purchaseProducts;
        }

    }
}
