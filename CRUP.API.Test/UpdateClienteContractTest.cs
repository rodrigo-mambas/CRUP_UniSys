
using System;
using CRUP.Domain.Commands.Clientes;
using CRUP.Domain.Contracts.Clientes;
using FluentAssertions;
using Xunit;

namespace CRUP.API.Test
{
    public class UpdateClienteContractTests
    {
        [Fact]
        public void Deve_ValidarUpdateClienteCommand_CpfNaoPodeSerNuloOuVazio()
        {
            // Arrange
            var command = new UpdateClienteCommand { Cpf = "" };

            // Act
            var contract = new UpdateClienteContract(command);

            // Assert
            contract.IsValid.Should().BeFalse();
            //contract.Notifications.Should().ContainSingle(n => n.Message with("%Cpf%"));
        }


    }
}
