using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice5Bussiness.Interfaces;
using Practice5DataAccess.DAOs.Interfaces;
using Practice5DataAccess.Migrations;
using Practice5Model.DTO;

namespace Practice5Bussiness.Implementations
{
    public class SaleProductBLL : ISaleProductBLL
    {

        private readonly ISaleProductDAO _saleProductDAO;

        public SaleProductBLL(ISaleProductDAO saleProductDAO)
        {
            _saleProductDAO = saleProductDAO;
        }

        public IEnumerable<SaleProductDTO> GetSaleProducts()
        {
            IEnumerable<SaleProductDTO> saleProducts = null;


            try
            {
                saleProducts = _saleProductDAO.GetSaleProducts();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in business layer: " + ex.Message);
            }


            return saleProducts;
        }
    }
}
