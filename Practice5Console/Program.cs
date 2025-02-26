using Practice5Bussiness;

namespace Practice5Console
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ProductBLL productBll = new ProductBLL();

            var productList = productBll.GetProducts();



        }
    }
}
