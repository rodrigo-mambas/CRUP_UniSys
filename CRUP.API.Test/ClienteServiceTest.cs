



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUP.Application.Services;
using CRUP.Domain.Commands;
using CRUP.Domain.Entities;
using CRUP.Domain.Commands.Clientes;
using CRUP.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using static System.Runtime.InteropServices.JavaScript.JSType;
using CRUP.API.Controllers;
using CRUP.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRUP.API.Test
{
    public class ClienteServiceTest
    {
        private readonly ClienteService _clienteService;
        private readonly Mock<IReadRepository<Cliente>> _readRepositoryMock;
        private readonly Mock<IWriteRepository<Cliente>> _writeRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public ClienteServiceTest()
        {
            _readRepositoryMock = new Mock<IReadRepository<Cliente>>();
            _writeRepositoryMock = new Mock<IWriteRepository<Cliente>>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();

            _clienteService = new ClienteService(_readRepositoryMock.Object, _writeRepositoryMock.Object, _unitOfWorkMock.Object);
        }

        [Fact]
        public async Task CreateCliente_DeveCriarCliente()
        {
            // Arrange
            var clienteCommand = new CreateClienteCommand();
            clienteCommand.Nome = "1";
            clienteCommand.DataDeNascimento = Convert.ToDateTime("30/01/2015");
            clienteCommand.Cpf = "12345678909";
            clienteCommand.DataExpedicao = Convert.ToDateTime("30/01/2015"); 
            clienteCommand.EstadoCivil = "1";
            clienteCommand.Rg = "1";
            clienteCommand.Sexo = "1";
            clienteCommand.OrgaoExpedicao = "1";

            //act
            var result = await _clienteService.CreateCliente(clienteCommand);

            //assert
            Assert.True(result.Success);
        }

        [Fact]
        public async Task GetAllClientes_DeveRetornarListaDeClientes1()
        {
            // Arrange
            var clienteCommand = new CreateClienteCommand();
            clienteCommand.Nome = "1";
            clienteCommand.DataDeNascimento = Convert.ToDateTime("30/01/2015");
            clienteCommand.Cpf = "1";
            clienteCommand.DataExpedicao = Convert.ToDateTime("30/01/2015");
            clienteCommand.EstadoCivil = "1";
            clienteCommand.Rg = "1";
            clienteCommand.Sexo = "1";
            clienteCommand.OrgaoExpedicao = "1";

            //act
            var result = await _clienteService.CreateCliente(clienteCommand);

            //assert
            Assert.False(result.Success);
        }
    }
}

