using FinancialManager.Data.Interfaces;
using FinancialManager.Data.Repositories.Interfaces;
using FinancialManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FinancialManager.Data.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private IDbContext _db;
        private IContextFactory _contextFactory;
        private IRepositoryConfig _repositoryConfig;

        public SupplierRepository(IRepositoryConfig repositoryConfig, IContextFactory contextFactory)
        {
            _repositoryConfig = repositoryConfig;
            _contextFactory = contextFactory;
        }

        private IDbContext Db => _db ?? (_db = _contextFactory.Write);

        public void Add(Supplier supplier)
        {
            
            supplier.CreatedAt = DateTime.Now;
            supplier.LastUpdatedAt = DateTime.Now;

            Db.Set<Supplier>().Add(supplier);
            Db.SaveChanges();
        }

        public void Update(Supplier supplier)
        {
            supplier.LastUpdatedAt = DateTime.Now;

            Db.Entry(supplier).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Delete(Supplier supplier)
        {
            Db.Entry(supplier).State = EntityState.Deleted;
            Db.SaveChanges();
        }

        public Supplier Find(int id)
            => Db.Set<Supplier>().Where(s => s.Id == id).FirstOrDefault();

        public Supplier FindByDocument(string document)
            => Db.Set<Supplier>().Where(s => s.Document == document).FirstOrDefault();
    }
}
