using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Practice5Bussiness.Interfaces;
using Practice5DataAccess.DAOs.Interfaces;
using Practice5DataAccess.Migrations;
using Practice5Model.DTO;
using Practice5Model.Models;

namespace Practice5Bussiness.Implementations
{
    public class InventoryBLL : IInventoryBLL
    {
        private readonly IInventoryDAO _inventoryDAO;
        public InventoryBLL(IInventoryDAO inventoryDAO)
        {
            _inventoryDAO = inventoryDAO;//design patterns (repositorypattern)
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
        public IEnumerable<InventoryDTO> GetFullInventory()
        {
            IEnumerable<InventoryDTO> inventory = null;

            try
            {
                inventory = _inventoryDAO.GetFullInventory();
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

        public int GetCountOfProduct(int productId)
        {
            int result = -1;
            try
            {
                result = _inventoryDAO.GetCountOfProduct(productId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Business Layer: " + ex.Message);
            }
            return result;
        }
    }
}
