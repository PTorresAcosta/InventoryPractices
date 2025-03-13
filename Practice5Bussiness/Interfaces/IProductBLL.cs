using Practice5Model.Models;

namespace Practice5Bussiness.Interfaces
{
    public interface IProductBLL
    {
        IEnumerable<Product> GetProducts();
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        IEnumerable<Product> GetProductsToSell();
    }
}
