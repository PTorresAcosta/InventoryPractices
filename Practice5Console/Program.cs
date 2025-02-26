using Practice5Bussiness;

namespace Practice5Console
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ProductBLL productBll = new ProductBLL();

            productBll.AddProduct(new Practice5Model.Models.Product { 
                Name = "Producto Prueba C#",
                PurchasePrice = 100m,
                SellPrice = 200m
            });

            var productList = productBll.GetProducts();


        }
    }
}
