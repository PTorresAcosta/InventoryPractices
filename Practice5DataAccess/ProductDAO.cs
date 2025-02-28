using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Practice5DataAccess.Data;
using Practice5Model.Models;

namespace Practice5DataAccess
{
    public class ProductDAO
    {
        public List<Product> GetProducts()
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

        public async void AddProduct(Product productToAdd)
        {


            using var context = new ApplicationDbContext();

            try
            {
                var result = context.Products.Add(productToAdd);
                await context.SaveChangesAsync();
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public async void UpdateProduct(Product productToUpdate)
        {

            using var context = new ApplicationDbContext();

            try
            {
                var product = context.Products.Find(productToUpdate.ProductId);
                product = productToUpdate;
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public async void DeleteProduct(Product productToDelete)
        {
            using var context = new ApplicationDbContext();

            try
            {
                var product = await context.Products.FindAsync(productToDelete.ProductId);
                context.Products.Remove(product);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
 