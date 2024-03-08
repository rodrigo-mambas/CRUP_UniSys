using CRUP.Application.Interfaces;
using CRUP.Infra.Data.Interfaces;
using CRUP.Domain.Entities;
using CRUP.Domain.Commands;
using Microsoft.EntityFrameworkCore;
using CRUP.Domain.Commands.Clientes;

namespace CRUP.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IReadRepository<Cliente> _readRepository;
        private readonly IWriteRepository<Cliente> _writeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ClienteService(IReadRepository<Cliente> readRepository, IWriteRepository<Cliente> writeRepository, IUnitOfWork unitOfWork )
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CommandResult> GetAllClientes()
        {
            var listaClientes = await _readRepository.FindAll().ToListAsync();

            if (listaClientes is null || listaClientes.Count == 0)
                return new CommandResult(false, "Falha ao consultar clientes");

            return new CommandResult(true, "Clientes consultados com sucesso", listaClientes);
        }

        public async Task<CommandResult> GetByIdCliente(Guid id)
        {
            var cliente = await _readRepository.FindByCondition(x => x.Id == id).ToListAsync();

            if (cliente is null || cliente.Count == 0)
                return new CommandResult(false, "Falha ao consultar cliente");

            return new CommandResult(true, "Cliente consultado com sucesso", cliente);
        }

        public async Task<CommandResult> CreateCliente(CreateClienteCommand command)
        {
            command.Validate();


            

            if (!command.IsValid )
                return new CommandResult(false, "Falha ao registrar cliente", command.Notifications);

            Cliente cliente = new Cliente(command.Cpf, command.Nome, command.Rg, command.DataExpedicao, command.OrgaoExpedicao,
                command.Uf, command.DataDeNascimento, command.Sexo, command.EstadoCivil);


            await _writeRepository.AddAsync(cliente);
            await _unitOfWork.CommitAsync();

            return new CommandResult(true, "Cliente registrado com sucesso", cliente);
        }

        public async Task<CommandResult> UpdateCliente(UpdateClienteCommand command)
        {
            command.Validate();


            if (!command.IsValid )
                return new CommandResult(false, "Falha ao alterar cliente", command.Notifications);

            var cliente = await _readRepository.FindByCondition(x => x.Id == command.IdClienteExistente).FirstOrDefaultAsync();
            if (cliente is null)
                return new CommandResult(false, "Falha ao recuperar cliente");


            cliente.Alterar(command);

            _writeRepository.Update(cliente);
            await _unitOfWork.CommitAsync();

            return new CommandResult(true, "Cliente alterado com sucesso", cliente);
        }

        public async Task<CommandResult> DeleteCliente(Guid id)
        {
            var cliente = await _readRepository.FindByCondition(x => x.Id == id).FirstOrDefaultAsync();
            if (cliente is null)
                return new CommandResult(false, "Falha ao recuperar cliente");

            
            _writeRepository.Delete(cliente);
            
            await _unitOfWork.CommitAsync();

            return new CommandResult(true, "Cliente deletado com sucesso", cliente);
        }
    }

}
