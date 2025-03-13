using Practice5Model.Models;

namespace Practice5DataAccess.DAOs.Interfaces
{
    public interface IProductDAO
    {
        IEnumerable<Product> GetProducts();
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        IEnumerable<Product> GetProductsToSell();
    }
}
 