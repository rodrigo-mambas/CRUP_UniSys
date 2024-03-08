using CRUP.Domain.Commands;
using CRUP.Domain.Commands.Clientes;

namespace CRUP.Application.Interfaces
{
    public interface IClienteService
    {
        Task<CommandResult> GetAllClientes();
        Task<CommandResult> GetByIdCliente(Guid id);
        Task<CommandResult> CreateCliente(CreateClienteCommand command);
        Task<CommandResult> UpdateCliente(UpdateClienteCommand command);
        Task<CommandResult> DeleteCliente(Guid id);
    }
}
