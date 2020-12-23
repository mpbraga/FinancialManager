using FinancialManager.Data.Interfaces;
using FinancialManager.Data.Repositories.Interfaces;
using FinancialManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinancialManager.Data.Repositories
{
    public class BillRepository : IBillRepository
    {
        private IDbContext _db;
        private IContextFactory _contextFactory;
        private IRepositoryConfig _repositoryConfig;

        public BillRepository(IRepositoryConfig repositoryConfig, IContextFactory contextFactory)
        {
            _repositoryConfig = repositoryConfig;
            _contextFactory = contextFactory;
        }

        private IDbContext Db => _db ?? (_db = _contextFactory.Write);

        public void Add(Bill bill)
        {

            bill.CreatedAt = DateTime.Now;
            bill.LastUpdatedAt = DateTime.Now;

            Db.Set<Bill>().Add(bill);
            Db.SaveChanges();
        }

        public void AddRange(IEnumerable<Bill> bills)
        {
            var date = DateTime.Now;

            foreach (var bill in bills)
            {
                bill.CreatedAt = date;
                bill.LastUpdatedAt = date;
            }

            Db.Set<Bill>().AddRange(bills);
            Db.SaveChanges();
        }

        public void Update(Bill bill)
        {
            bill.LastUpdatedAt = DateTime.Now;

            Db.Entry(bill).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Delete(Bill bill)
        {
            Db.Entry(bill).State = EntityState.Deleted;
            Db.SaveChanges();
        }

        public Bill Find(int id)
            => Db.Set<Bill>().Where(b => b.Id == id).FirstOrDefault();

        public IEnumerable<Bill> GetSupplierBillsFromPeriod(int supplierId, DateTime startDate, DateTime endDate)
            => Db.Set<Bill>().Where(
                b => b.SupplierId == supplierId &&
                b.PaymentDate >= startDate &&
                b.PaymentDate <= endDate);
    }
}
