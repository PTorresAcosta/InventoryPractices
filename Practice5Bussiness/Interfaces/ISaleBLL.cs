using Practice5Model.Models;

namespace Practice5Bussiness.Interfaces
{
    public interface ISaleBLL
    {
        IEnumerable<Sale> GetSales();
        void AddSale(Sale sale);
        void UpdateSale(Sale sale);
        void DeleteSale(Sale sale);
    }
}
