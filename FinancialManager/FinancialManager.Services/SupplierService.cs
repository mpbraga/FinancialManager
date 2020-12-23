using FinancialManager.Data.Repositories.Interfaces;
using FinancialManager.Models;
using FinancialManager.Services.Interfaces;

namespace FinancialManager.Services
{
    public class SupplierService : ISupplierService
    {
        private ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public void Add(Supplier supplier)
        {
            _supplierRepository.Add(supplier);
        }

        public void Add(SupplierDTO sup)
        {
            var supplier = new Supplier()
            {
                Name = sup.Name,
                Document = sup.Document
            };

            _supplierRepository.Add(supplier);
        }

        public void Update(int id, SupplierDTO sup)
        {
            var supplier = _supplierRepository.Find(id);
            if (supplier == null) return;

            supplier.Name = sup.Name;
            supplier.Document = sup.Document;

            _supplierRepository.Update(supplier);
        }

        public void Delete(Supplier supplier)
        {
            _supplierRepository.Delete(supplier);
        }

        public Supplier Find(int id)
            => _supplierRepository.Find(id);

        public Supplier FindByDocument(string document)
            => _supplierRepository.FindByDocument(document);
    }
}
