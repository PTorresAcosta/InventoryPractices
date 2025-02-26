using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice5DataAccess;
using Practice5Model.Models;

namespace Practice5Bussiness
{
    public class ProductBLL
    {
        public List<Product> GetProducts()
        {
            var result = new List<Product>();

            var dao = new ProductDAO();

            try
            {
                result = dao.getProducts();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }
    }
}
