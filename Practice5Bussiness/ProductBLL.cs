using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice5DataAccess;
using Practice5Model.Models;

namespace Practice5Bussiness
{

    public interface IProductBLL
    {
        IEnumerable<Product> GetProducts();
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }

    public class ProductBLL : IProductBLL
    {

        private readonly IProductDAO _productDAO;
        public ProductBLL(IProductDAO productDAO)
        {
            _productDAO = productDAO;
        }

        public IEnumerable<Product> GetProducts()
        {
            IEnumerable<Product> result = null;

            //var dao = new ProductDAO();

            try
            {
                result = _productDAO.GetProducts();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in business layer: " + ex.Message);
            }

            return result;
        }

        public void AddProduct(Product product)
        {
            //var result = new Product();

            //return result;
            //var dao = new ProductDAO();

            try
            {
                _productDAO.AddProduct(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void UpdateProduct(Product product)
        {

            try
            {
                _productDAO.AddProduct(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in business Layer: " + ex.Message);
            }

        }

        public void DeleteProduct(Product product)
        {

            try
            {
                _productDAO.UpdateProduct(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Business layer: " + ex.Message);
            }

        }
    }
}
