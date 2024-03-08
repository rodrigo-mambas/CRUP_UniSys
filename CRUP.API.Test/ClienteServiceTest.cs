﻿



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
        public async Task GetAllClientes_DeveRetornarListaDeClientes()
        {
            // Arrange

            var ddd = new CommandResult();
            ddd.Success = true;
            ddd.Message = string.Empty;
            ddd.Data = new List<Cliente>
            {
                new Cliente( "12345678909","asdfgh1","sdddd",Convert.ToDateTime("30/01/2015"),"asd","df",Convert.ToDateTime("30/01/2015"),"wer","sdf"),
                new Cliente( "12345678909","asdfgh2","sdddd",Convert.ToDateTime("30/01/2015"),"asd","df",Convert.ToDateTime("30/01/2015"),"wer","sdf"),
                new Cliente( "12345678909","asdfgh3","sdddd",Convert.ToDateTime("30/01/2015"),"asd","df",Convert.ToDateTime("30/01/2015"),"wer","sdf"),
            };
            

        }


    }
}
