using Practice5Model.Models;

namespace Practice5DataAccess.DAOs.Interfaces
{
    public interface IPurchaseDAO
    {
        IEnumerable<Purchase> GetPurchases();
        void AddPurchase(Purchase purchase);
        void UpdatePurchase(Purchase purchase);
        void DeletePurchase(Purchase purchase);
    }
}
