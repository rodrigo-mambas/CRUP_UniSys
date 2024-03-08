using CRUP.Shared.Commands.Interfaces;

namespace CRUP.Shared.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommandResult> ExecuteCommand(T command);
    }
}
