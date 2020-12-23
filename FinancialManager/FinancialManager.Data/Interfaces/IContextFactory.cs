namespace FinancialManager.Data.Interfaces
{
    public interface IContextFactory
    {
        IDbContext Read { get; }
        IDbContext Write { get; }
    }
}
