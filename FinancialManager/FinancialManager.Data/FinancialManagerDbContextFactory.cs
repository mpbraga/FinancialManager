using FinancialManager.Data.Interfaces;
using System;

namespace FinancialManager.Data
{
    public class FinancialManagerDbContextFactory : IContextFactory
    {
        private Func<IFinancialManagerDbContext> _dbContext;

        public FinancialManagerDbContextFactory(Func<IFinancialManagerDbContext> dbContext)
        {
            _dbContext = dbContext;
        }

        public IDbContext Write => _dbContext();
        public IDbContext Read => _dbContext();
    }
}
