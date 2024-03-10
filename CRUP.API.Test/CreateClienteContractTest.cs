

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
        [Trait("Contrato", "CPF nao pode ser null ou vazio")]
        public void Deve_ValidarCreateClienteCommand_CpfNaoPodeSerNuloOuVazio()
        {
            // Arrange
            var command = new CreateClienteCommand { Cpf = "" };

            // Act
            var contract = new CreateClienteContract(command);

            // Assert
            contract.IsValid.Should().BeFalse();
        }

        [Fact]
        [Trait("Contrato", "CPF menor que 11 posicoes")]
        public void Deve_ValidarCreateClienteCommand_CpfMenorQue11Posicoes()
        {
            // Arrange
            var command = new CreateClienteCommand { Cpf = "123456789" };

            // Act
            var contract = new CreateClienteContract(command);

            // Assert
            contract.IsValid.Should().BeFalse();
        }
    }
}
