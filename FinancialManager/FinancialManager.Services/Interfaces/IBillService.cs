using FinancialManager.Models;
using System;
using System.Collections.Generic;

namespace FinancialManager.Services.Interfaces
{
    public interface IBillService
    {
        void Add(Bill bill);
        void AddRange(IEnumerable<Bill> bills);
        void Update(Bill bill);
        void Delete(Bill bill);
        IEnumerable<Bill> GetSupplierBillsFromPeriod(int supplierId, DateTime startDate, DateTime endDate);
    }
}
