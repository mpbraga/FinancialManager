using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Data;

namespace FinancialManager.Data.Interfaces
{
    public interface IDbContext : IDisposable
    {
        int SaveChanges();
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        string DataSource { get; }
        string DatabaseName { get; }
        DatabaseFacade Database { get; }
        IDbConnection DbConnection { get; }
    }
}
