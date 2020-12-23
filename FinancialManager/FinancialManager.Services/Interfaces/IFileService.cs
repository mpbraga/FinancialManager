using System.Threading.Tasks;

namespace FinancialManager.Services.Interfaces
{
    public interface IFileService
    {
        Task ProcessFile(string path);
    }
}
