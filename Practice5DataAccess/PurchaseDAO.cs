using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice5DataAccess.Data;
using Practice5Model.Models;

namespace Practice5DataAccess
{
    public interface IPurchaseDAO
    {
        IEnumerable<Purchase> GetPurchases();
        void AddPurchase(Purchase purchase);
        void UpdatePurchase(Purchase purchase);
        void DeletePurchase(Purchase purchase);
    }
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

            try
            {
                _context.Purchases.Add(purchase);
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
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Data Layer: " + ex.Message);
            }
        }


    }
}
