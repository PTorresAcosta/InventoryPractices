using Practice5Model.DTO;

namespace Practice5Bussiness.Interfaces
{
    public interface IPurchaseProductBLL
    {
        IEnumerable<PurchaseProductDTO> getPurchaseProduct();
    }
}
