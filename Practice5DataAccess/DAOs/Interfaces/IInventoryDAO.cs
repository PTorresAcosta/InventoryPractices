using Practice5Model.DTO;
using Practice5Model.Models;

namespace Practice5DataAccess.DAOs.Interfaces
{
    public interface IInventoryDAO
    {
        IEnumerable<Inventory> GetInventory();
        void AddInventory(Inventory item);
        void DeleteInventory(Inventory item);
        int GetCountOfProduct(int productId);
        IEnumerable<InventoryDTO> GetFullInventory();
    }
}
