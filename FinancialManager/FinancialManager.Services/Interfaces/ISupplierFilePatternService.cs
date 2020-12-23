using FinancialManager.Models;
using FinancialManager.Models.Enums;
using System.Collections.Generic;

namespace FinancialManager.Services.Interfaces
{
    public interface ISupplierFilePatternService
    {
        void Add(SupplierFilePattern supplierFilePattern);
        void Update(SupplierFilePattern supplierFilePattern);
        void Delete(SupplierFilePattern supplierFilePattern);
        SupplierFilePattern Find(int id);
        Dictionary<string, int> GetSupplierFilePattern(int supplierId, FileExtension fileExtension);
    }
}
