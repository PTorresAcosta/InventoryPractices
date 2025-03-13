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
    public class SaleProductDAO : ISaleProductDAO
    {

        private readonly ApplicationDbContext _context;

        public SaleProductDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SaleProductDTO> GetSaleProducts()
        {

            IEnumerable<SaleProductDTO> saleProducts = null;

            try
            {
                saleProducts = from sa in _context.Sales
                               join pr in _context.Products
                               on sa.ProductId equals pr.ProductId
                               select new SaleProductDTO
                               {
                                   Products = pr,
                                   Sales = sa
                               };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Data Layer: " + ex.Message);
            }

            return saleProducts;

        }

    }
}
