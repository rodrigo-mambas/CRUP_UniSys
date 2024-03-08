

using System;
using CRUP.Domain.Commands.Clientes;
using CRUP.Domain.Contracts.Clientes;
using FluentAssertions;
using Xunit;

namespace CRUP.API.Test
{
    public class CreateClienteContractTests
    {
        [Fact]
        public void Deve_ValidarCreateClienteCommand_CpfNaoPodeSerNuloOuVazio()
        {
            // Arrange
            var command = new CreateClienteCommand { Cpf = "" };

            // Act
            var contract = new CreateClienteContract(command);

            // Assert
            contract.IsValid.Should().BeFalse();
            //contract.Notifications.Should().ContainSingle(n => n.Key == "Cpf");
        }

        // Outros métodos de teste para as outras validações podem ser escritos da mesma forma
    }
}
