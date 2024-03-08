using CRUP.Application.Interfaces;
using CRUP.Domain.Commands.Clientes;
using CRUP.Shared.Commands.Interfaces;
using CRUP.Shared.Handlers;

namespace CRUP.Application.Handlers
{
    public class UpdateClienteHandler : IHandler<UpdateClienteCommand>
    {
        private readonly IClienteService _clienteService;

        public UpdateClienteHandler(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task<ICommandResult> ExecuteCommand(UpdateClienteCommand command)
        {
            return await _clienteService.UpdateCliente(command);
        }
    }
}
