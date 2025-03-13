using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice5DataAccess.DAOs.Interfaces;
using Practice5DataAccess.Data;
using Practice5Model.Models;

namespace Practice5DataAccess.DAOs.Implementations
{
    public class PurchaseDAO : IPurchaseDAO
    {
        private readonly ApplicationDbContext _context;

        public PurchaseDAO(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Purchase> GetPurchases()
        {
            IEnumerable<Purchase> purchases = null;

            try
            {
                purchases = _context.Purchases;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Data Layer: " + ex.Message);
            }

            return purchases;
        }

        public void AddPurchase(Purchase purchase)
        {

            var inventory = new Inventory
            {
                ProductId = purchase.ProductId
            };


            try
            {
                _context.Purchases.Add(purchase);
                _context.Inventory.Add(inventory);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Data Layer: " + ex.Message);
            }

        }

        public void UpdatePurchase(Purchase purchase)
        {
            try
            {
                var purchases = _context.Purchases.Where(p => p.PurchaseId == purchase.PurchaseId);

                foreach (var p in purchases)
                {
                    p.ProductId = purchase.ProductId;
                    p.PurchaseDate = purchase.PurchaseDate;
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Data Layer: " + ex.Message);
            }
        }

        public void DeletePurchase(Purchase purchase)
        { 

            try
            {
                var purchaseToDelete = _context.Purchases.Find(purchase.PurchaseId);
                _context.Purchases.Remove(purchaseToDelete);

                var inventoryToDelete = _context.Inventory.FirstOrDefault(inv => inv.ProductId == purchase.ProductId);
                _context.Inventory.Remove(inventoryToDelete);
                
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Data Layer: " + ex.Message);
            }
        }


    }
}
