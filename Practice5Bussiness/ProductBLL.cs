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
                result = dao.GetProducts();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public void AddProduct(Product productToAdd)
        {
            //var result = new Product();

            //return result;
            var dao = new ProductDAO();

            try
            {
                dao.AddProduct(productToAdd);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
