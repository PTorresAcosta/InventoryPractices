﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice5Model.Models;

namespace Practice5DataAccess
{
    public interface ISaleBLL
    {
        IEnumerable<Sale> GetSales();
        void AddSale(Sale sale);
        void UpdateSale(Sale sale);
        void DeleteSale(Sale sale);
    }
    public class SaleBLL : ISaleBLL
    {

        private readonly ISaleDAO _saleDAO;

        public SaleBLL(ISaleDAO saleDAO)
        {
            _saleDAO = saleDAO;
        }

        public IEnumerable<Sale> GetSales()
        {
            IEnumerable<Sale> sales = null;

            try
            {
                sales = _saleDAO.GetSales();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Business Layer" + ex.Message);
            }

            return sales;
        }

        public void AddSale(Sale sale)
        {
            try
            {
                _saleDAO.AddSale(sale);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Business Layer" + ex.Message);
            }
        }

        public void UpdateSale(Sale sale)
        {
            try
            {
                _saleDAO.UpdateSale(sale);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Business Layer" + ex.Message);
            }
        }

        public void DeleteSale(Sale sale)
        {
            try
            {
                _saleDAO.DeleteSale(sale);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Business Layer" + ex.Message);
            }
        }
    }
}
