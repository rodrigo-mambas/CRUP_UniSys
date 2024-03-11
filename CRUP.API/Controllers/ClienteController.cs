using CRUP.Application.Interfaces;
using CRUP.Domain.Commands;
using CRUP.Domain.Commands.Clientes;
using CRUP.Shared.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IHandler<CreateClienteCommand> _createClienteHandler;
        private readonly IHandler<UpdateClienteCommand> _updateClienteHandler;

        public ClienteController(IClienteService clienteService, IHandler<CreateClienteCommand> createClienteHandler, IHandler<UpdateClienteCommand> updateClienteHandler)
        {
            _clienteService = clienteService;
            _createClienteHandler = createClienteHandler;
            _updateClienteHandler = updateClienteHandler;
        }

        [HttpGet]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _clienteService.GetAllClientes();

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _clienteService.GetByIdCliente(id);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync(CreateClienteCommand command)
        {
            var result = await _createClienteHandler.ExecuteCommand(command);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutAsync(Guid id, UpdateClienteCommand command)
        {
            command.InserirIdClienteExistenteNoCommand(id);
            var result = await _updateClienteHandler.ExecuteCommand(command);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _clienteService.DeleteCliente(id);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
