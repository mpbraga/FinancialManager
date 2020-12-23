using FinancialManager.Data.Interfaces;
using FinancialManager.Data.Repositories.Interfaces;
using FinancialManager.Models;
using FinancialManager.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FinancialManager.Data.Repositories
{
    public class SupplierFilePatternRepository : ISupplierFilePatternRepository
    {
        private IDbContext _db;
        private IContextFactory _contextFactory;
        private IRepositoryConfig _repositoryConfig;

        public SupplierFilePatternRepository(IRepositoryConfig repositoryConfig, IContextFactory contextFactory)
        {
            _repositoryConfig = repositoryConfig;
            _contextFactory = contextFactory;
        }

        private IDbContext Db => _db ?? (_db = _contextFactory.Write);

        public void Add(SupplierFilePattern supplierFilePattern)
        {

            supplierFilePattern.CreatedAt = DateTime.Now;
            supplierFilePattern.LastUpdatedAt = DateTime.Now;

            Db.Set<SupplierFilePattern>().Add(supplierFilePattern);
            Db.SaveChanges();
        }

        public void Update(SupplierFilePattern supplierFilePattern)
        {
            supplierFilePattern.LastUpdatedAt = DateTime.Now;

            Db.Entry(supplierFilePattern).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Delete(SupplierFilePattern supplierFilePattern)
        {
            Db.Entry(supplierFilePattern).State = EntityState.Deleted;
            Db.SaveChanges();
        }

        public SupplierFilePattern Find(int id)
            => Db.Set<SupplierFilePattern>().Where(s => s.Id == id).FirstOrDefault();

        public SupplierFilePattern FindBySupplierIdAndFileExtension(int supplierId, FileExtension fileExtension)
            => Db.Set<SupplierFilePattern>().Where(s => s.SupplierId == supplierId && s.FileExtension == fileExtension).FirstOrDefault();
    }
}
