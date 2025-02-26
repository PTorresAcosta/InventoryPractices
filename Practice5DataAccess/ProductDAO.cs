using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice5DataAccess.Data;
using Practice5Model.Models;

namespace Practice5DataAccess
{
    public class ProductDAO
    {
        public List<Product> getProducts()
        {
            var result = new List<Product>();

            using var context = new ApplicationDbContext();

            try
            {
                result = context.Products.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return result;
        }
    }
}
