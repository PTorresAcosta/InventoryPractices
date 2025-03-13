using Practice5Model.DTO;

namespace Practice5Bussiness.Interfaces
{
    public interface ISaleProductBLL
    {
        IEnumerable<SaleProductDTO> GetSaleProducts();
    }
}