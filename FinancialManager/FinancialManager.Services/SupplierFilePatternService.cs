using FinancialManager.Data.Repositories.Interfaces;
using FinancialManager.Models;
using FinancialManager.Models.Enums;
using FinancialManager.Services.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FinancialManager.Services
{
    public class SupplierFilePatternService : ISupplierFilePatternService
    {
        private ISupplierFilePatternRepository _supplierFilePatternRepository;

        public SupplierFilePatternService(ISupplierFilePatternRepository supplierFilePatternRepository)
        {
            _supplierFilePatternRepository = supplierFilePatternRepository;
        }

        public void Add(SupplierFilePattern supplierFilePattern)
        {
            _supplierFilePatternRepository.Add(supplierFilePattern);
        }

        public void Update(SupplierFilePattern supplierFilePattern)
        {
            _supplierFilePatternRepository.Update(supplierFilePattern);
        }

        public void Delete(SupplierFilePattern supplierFilePattern)
        {
            _supplierFilePatternRepository.Delete(supplierFilePattern);
        }

        public SupplierFilePattern Find(int id)
            => _supplierFilePatternRepository.Find(id);

        public Dictionary<string, int> GetSupplierFilePattern(int supplierId, FileExtension fileExtension)
        {
            var filePattern = _supplierFilePatternRepository.FindBySupplierIdAndFileExtension(supplierId, fileExtension);
            if (filePattern == null) return null;

            return JsonConvert.DeserializeObject<Dictionary<string, int>>(filePattern.FieldsPattern);
        }
    }
}
