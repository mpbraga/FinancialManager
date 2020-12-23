using FinancialManager.Data.Interfaces;

namespace FinancialManager.Data.Configuration
{
    public class FinancialManagerRepositoryConfig : IRepositoryConfig
    {
        public string ConnectionString { get; set; }
    }
}
