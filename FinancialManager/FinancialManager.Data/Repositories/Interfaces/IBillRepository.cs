using FinancialManager.Models;
using System;
using System.Collections.Generic;

namespace FinancialManager.Data.Repositories.Interfaces
{
    public interface IBillRepository : IRepository<Bill>
    {
        void AddRange(IEnumerable<Bill> bills);
        IEnumerable<Bill> GetSupplierBillsFromPeriod(int supplierId, DateTime startDate, DateTime endDate);
    }
}
