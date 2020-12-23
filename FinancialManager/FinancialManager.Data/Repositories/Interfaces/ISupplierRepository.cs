using FinancialManager.Models;

namespace FinancialManager.Data.Repositories.Interfaces
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Supplier FindByDocument(string document);
    }
}
