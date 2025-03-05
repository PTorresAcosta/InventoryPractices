using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice5Model.Models;

namespace Practice5DataAccess
{
    public interface IPurchaseBLL
    {
        IEnumerable<Purchase> GetPurchases();
        void AddPurchase(Purchase purchase);
        void UpdatePurchase(Purchase purchase);
        void DeletePurchase(Purchase purchase);
    }
    public class PurchaseBLL : IPurchaseBLL
    {
        private readonly IPurchaseDAO _purchaseDAO;

        public PurchaseBLL(IPurchaseDAO purchaseDAO)
        {
            _purchaseDAO = purchaseDAO;
        }

        public IEnumerable<Purchase> GetPurchases()
        {
            IEnumerable<Purchase> purchases = null;

            try
            {
                purchases = _purchaseDAO.GetPurchases();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Busiess Layer: " + ex.Message);
            }

            return purchases;
        }

        public void AddPurchase(Purchase purchase)
        {
            try
            {
                _purchaseDAO.AddPurchase(purchase);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Busiess Layer: " + ex.Message);
            }
        }

        public void UpdatePurchase(Purchase purchase)
        {
            try
            {
                _purchaseDAO.UpdatePurchase(purchase);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Busiess Layer: " + ex.Message);
            }
        }

        public void DeletePurchase(Purchase purchase)
        {
            try
            {
                _purchaseDAO.DeletePurchase(purchase);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Busiess Layer: " + ex.Message);
            }
        }
    }
}
