using System.Threading.Tasks;

namespace IDT.Boss.FeeService.SeedTool.Interfaces
{
    public interface ISeedService
    {
        Task InitializeDatabaseAsync();
    }
}
