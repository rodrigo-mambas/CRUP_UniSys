

using System.Threading.Tasks;
using CRUP.Application.Handlers;
using CRUP.Application.Interfaces;
using CRUP.Domain.Commands.Clientes;
using CRUP.Domain.Entities;
using Moq;
using Xunit;

namespace CRUP.API.Test
{
    public class CreateClienteHandlerTest
    {
        [Fact]
        public async Task ExecuteCommand_DeveChamarMetodoCreateClienteDoClienteService()
        {
            // Arrange
            var mockClienteService = new Mock<IClienteService>();
            var handler = new CreateClienteHandler(mockClienteService.Object);
            var command = new CreateClienteCommand
            {
                Cpf = "12345678900",
                Nome = "Fulano",
                Rg = "1234567",
                DataExpedicao = DateTime.Parse("30/01/2015"),
                OrgaoExpedicao = "SSP",
                Uf = "SP",
                DataDeNascimento = DateTime.Parse("30/01/2015"),
                Sexo = "M",
                EstadoCivil = "Solteiro(a)"
            };

            // Act
            await handler.ExecuteCommand(command);

            // Assert
            mockClienteService.Verify(x => x.CreateCliente(command), Times.Once);
        }
    }
}
