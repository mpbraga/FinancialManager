using FinancialManager.Models;
using FinancialManager.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialManager.Data.Repositories.Interfaces
{
    public interface ISupplierFilePatternRepository : IRepository<SupplierFilePattern>
    {
        SupplierFilePattern FindBySupplierIdAndFileExtension(int supplierId, FileExtension fileExtension);
    }
}
