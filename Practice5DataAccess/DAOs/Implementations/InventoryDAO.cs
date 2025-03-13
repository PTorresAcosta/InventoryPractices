using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice5DataAccess.DAOs.Interfaces;
using Practice5DataAccess.Data;
using Practice5Model.DTO;
using Practice5Model.Models;

namespace Practice5DataAccess.DAOs.Implementations
{
    public class InventoryDAO : IInventoryDAO
    {
        private readonly ApplicationDbContext _context;

        public InventoryDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Inventory> GetInventory()
        {
            IEnumerable<Inventory> inventory = null;

            try
            {
                inventory = _context.Inventory;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Data Layer: " + ex.Message);
            }

            return inventory;
        }

        public IEnumerable<InventoryDTO> GetFullInventory()
        {
            IEnumerable<InventoryDTO> inventory = null;

            try
            {
                inventory = from pro in _context.Products
                            join inv in _context.Inventory
                            on pro.ProductId equals inv.ProductId
                            group pro by pro.ProductId into g
                            select new InventoryDTO
                            {
                                Product = new Product
                                {
                                    ProductId = g.Select(g => g.ProductId).FirstOrDefault(),
                                    Name = g.Select(g => g.Name).FirstOrDefault(),
                                    PurchasePrice = g.Select(g => g.PurchasePrice).FirstOrDefault(),
                                    SellPrice = g.Select(g => g.SellPrice).FirstOrDefault()
                                },
                                Count = g.Count()
                            };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Data Layer: " + ex.Message);
            }

            return inventory;
        }

        public void AddInventory(Inventory item)
        {
            try
            {
                _context.Inventory.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Data Layer: " + ex.Message);
            }
        }

        public void DeleteInventory(Inventory item)
        {

            try
            {
                var itemToDelete = _context.Inventory.Find(item.InventoryId);
                _context.Inventory.Remove(itemToDelete);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Data layer: " + ex.Message);
            }

        }

        public int GetCountOfProduct(int productId)
        {

            try
            {
                var countOfProduct = _context.Inventory
                    .Where(inv => inv.ProductId == productId)
                    .GroupBy(inv => inv.ProductId)
                    .Select(prod => prod.Count()).FirstOrDefault();

                return countOfProduct;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Data layer: " + ex.Message);
            }
            return -1;

        }
    }
}
