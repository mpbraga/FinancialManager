using FinancialManager.Data.Repositories.Interfaces;
using FinancialManager.Models;
using FinancialManager.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace FinancialManager.Services
{
    public class BillService : IBillService
    {
        private IBillRepository _billRepository;

        public BillService(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        public void Add(Bill bill)
        {
            _billRepository.Add(bill);
        }

        public void AddRange(IEnumerable<Bill> bills)
        {
            _billRepository.AddRange(bills);
        }

        public void Update(Bill bill)
        {
            _billRepository.Update(bill);
        }

        public void Delete(Bill bill)
        {
            _billRepository.Delete(bill);
        }

        public IEnumerable<Bill> GetSupplierBillsFromPeriod(int supplierId, DateTime startDate, DateTime endDate)
            => _billRepository.GetSupplierBillsFromPeriod(supplierId, startDate, endDate);
    }
}
