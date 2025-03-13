using Practice5Model.DTO;

namespace Practice5DataAccess.DAOs.Interfaces
{
    public interface ISaleProductDAO
    {
        IEnumerable<SaleProductDTO> GetSaleProducts();
    }
}