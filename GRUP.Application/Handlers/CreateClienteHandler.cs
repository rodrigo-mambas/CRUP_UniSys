using CRUP.Application.Interfaces;
using CRUP.Domain.Commands.Clientes;
using CRUP.Shared.Commands.Interfaces;
using CRUP.Shared.Handlers;

namespace CRUP.Application.Handlers
{
    public class CreateClienteHandler : IHandler<CreateClienteCommand>
    {
        private readonly IClienteService _clienteService;

        public CreateClienteHandler(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task<ICommandResult> ExecuteCommand(CreateClienteCommand command)
        {
            return await _clienteService.CreateCliente(command);
        }
    }
}
