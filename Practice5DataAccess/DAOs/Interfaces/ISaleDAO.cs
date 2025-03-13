using Practice5Model.Models;

namespace Practice5DataAccess.DAOs.Interfaces
{
    public interface ISaleDAO
    {
        IEnumerable<Sale> GetSales();
        void AddSale(Sale product);
        void UpdateSale(Sale product);
        void DeleteSale(Sale product);
    }
}
