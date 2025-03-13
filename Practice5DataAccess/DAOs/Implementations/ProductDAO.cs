using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Practice5DataAccess.DAOs.Interfaces;
using Practice5DataAccess.Data;
using Practice5Model.Models;

namespace Practice5DataAccess.DAOs.Implementations
{

    public class ProductDAO : IProductDAO
    {

        private readonly ApplicationDbContext _context;

        public ProductDAO(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetProducts()
        {
            IEnumerable<Product> result = null;

            try
            {
                result = _context.Products;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Data layer: " + ex.Message);
            }

            return result;
        }

        public IEnumerable<Product> GetProductsToSell()
        {
            IEnumerable<Product> result = null;

            try
            {
                result = from pro in _context.Products
                         join inv in _context.Inventory
                         on pro.ProductId equals inv.ProductId
                         group pro by pro.ProductId into g
                         select new Product
                         {
                             ProductId = g.Select(g => g.ProductId).FirstOrDefault(),
                             Name = g.Select(g => g.Name).FirstOrDefault(),
                             PurchasePrice = g.Select(g => g.PurchasePrice).FirstOrDefault(),
                             SellPrice = g.Select(g => g.SellPrice).FirstOrDefault()
                         };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Data layer: " + ex.Message);
            }

            return result;
        }

        public void AddProduct(Product productToAdd)
        {
            try
            {
                var result = _context.Products.Add(productToAdd);
                _context.SaveChanges();
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Data layer: " + ex.Message);
            }
        }

        public void UpdateProduct(Product productToUpdate)
        {

            //using var context = new ApplicationDbContext();

            try
            {
                var products = _context.Products.Where(p => p.ProductId == productToUpdate.ProductId);
                
                foreach(var product in products)
                {
                    product.ProductId = productToUpdate.ProductId;
                    product.Name = productToUpdate.Name;
                    product.SellPrice = productToUpdate.SellPrice;
                    product.PurchasePrice = productToUpdate.PurchasePrice;
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Data layer: " + ex.Message);
            }

        }

        public void DeleteProduct(Product productToDelete)
        {
            //using var context = new ApplicationDbContext();

            try
            {
                var product = _context.Products.Find(productToDelete.ProductId);
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Data layer: " + ex.Message);
            }
        }

        
    }
}
 