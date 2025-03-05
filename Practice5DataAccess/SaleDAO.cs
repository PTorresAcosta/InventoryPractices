using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice5DataAccess.Data;
using Practice5Model.Models;

namespace Practice5DataAccess
{
    public interface ISaleDAO
    {
        IEnumerable<Sale> GetSales();
        void AddSale(Sale product);
        void UpdateSale(Sale product);
        void DeleteSale(Sale product);
    }
    public class SaleDAO : ISaleDAO
    {
        
        private readonly ApplicationDbContext _context;

        public SaleDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Sale> GetSales()
        {
            IEnumerable<Sale> sales = null;

            try
            {
                sales = _context.Sales;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Data Layer: " + ex.Message);
            }

            return sales;
        }
        public void AddSale(Sale sale)
        {
            try
            {
                _context.Sales.Add(sale);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Data Layer: " + ex.Message);
            }

        }
        public void UpdateSale(Sale sale)
        {
            try
            {

                var sales = _context.Sales.Where(s => s.SaleId == sale.SaleId);

                foreach (var s in sales)
                {
                    s.ProductId = sale.ProductId;
                    s.SaleDate = sale.SaleDate;
                }
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Data Layer: " + ex.Message);
            }
        }
        public void DeleteSale(Sale sale)
        {
            try
            {
                var deletedSale = _context.Sales.Find(sale.SaleId);
                _context.Sales.Remove(deletedSale);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Data Layer: " + ex.Message);
            }

        }
    }
}
