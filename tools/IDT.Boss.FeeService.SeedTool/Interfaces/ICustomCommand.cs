using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;

namespace IDT.Boss.FeeService.SeedTool.Interfaces
{
    public interface ICustomCommand
    {
        Task OnExecuteAsync(CommandLineApplication command, IConsole console);
    }
}
