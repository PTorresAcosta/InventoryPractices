using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice5DataAccess.Migrations;
using Practice5Model.Models;

namespace Practice5DataAccess
{
    public interface IInventoryBLL
    {
        IEnumerable<Inventory> GetInventory();
        void AddInventory(Inventory item);
        void DeleteInventory(Inventory item);
    }
    public class InventoryBLL : IInventoryBLL
    {
        private readonly IInventoryDAO _inventoryDAO;
        public InventoryBLL(IInventoryDAO inventoryDAO)
        {
            _inventoryDAO = inventoryDAO;
        }

        public IEnumerable<Inventory> GetInventory()
        {
            IEnumerable<Inventory> inventory = null;

            try
            {
                inventory = _inventoryDAO.GetInventory();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Business Layer: " + ex.Message);
            }

            return inventory;
        }

        public void AddInventory(Inventory item)
        {
            try
            {
                _inventoryDAO.AddInventory(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Business Layer: " + ex.Message);
            }
        }

        public void DeleteInventory(Inventory item)
        {
            try
            {
                _inventoryDAO.DeleteInventory(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Business Layer: " + ex.Message);
            }
        }
    }
}
