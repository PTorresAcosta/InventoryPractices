using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice5DataAccess.Data;
using Practice5Model.Models;

namespace Practice5DataAccess
{
    public interface IInventoryDAO
    {
        IEnumerable<Inventory> GetInventory();
        void AddInventory(Inventory item);
        void DeleteInventory(Inventory item);
    }
    public class InventoryDAO : IInventoryDAO
    {
        private readonly ApplicationDbContext _context;

        public InventoryDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Inventory> GetInventory()
        {
            IEnumerable<Inventory> inventory = null;

            try
            {
                inventory = _context.Inventory;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Data Layer: " + ex.Message);
            }

            return inventory;
        }
        public void AddInventory(Inventory item)
        {
            try
            {
                _context.Inventory.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Data Layer: " + ex.Message);
            }
        }

        public void DeleteInventory(Inventory item)
        {

            try
            {
                var itemToDelete = _context.Inventory.Find(item.InventoryId);
                _context.Inventory.Remove(itemToDelete);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Data layer: " + ex.Message);
            }

        }
    }
}
