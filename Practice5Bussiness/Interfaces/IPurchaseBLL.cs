using Practice5Model.Models;

namespace Practice5Bussiness.Interfaces
{
    public interface IPurchaseBLL
    {
        IEnumerable<Purchase> GetPurchases();
        void AddPurchase(Purchase purchase);
        void UpdatePurchase(Purchase purchase);
        void DeletePurchase(Purchase purchase);
    }
}
