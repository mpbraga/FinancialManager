using FinancialManager.Models;

namespace FinancialManager.Services.Interfaces
{
    public interface ISupplierService
    {
        void Add(Supplier supplier);
        void Add(SupplierDTO supplier);
        void Update(int id, SupplierDTO supplier);
        void Delete(Supplier supplier);
        Supplier Find(int id);
        Supplier FindByDocument(string document);
    }
}
