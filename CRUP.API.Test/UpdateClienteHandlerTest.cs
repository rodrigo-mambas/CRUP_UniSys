

using System.Threading.Tasks;
using CRUP.Application.Handlers;
using CRUP.Application.Interfaces;
using CRUP.Domain.Commands.Clientes;
using Moq;
using Xunit;

namespace CRUP.API.Test
{
    public class UpdateClienteHandlerTests
    {
        [Fact]
        public async Task ExecuteCommand_DeveChamarMetodoUpdateClienteDoClienteService()
        {
            // Arrange
            var mockClienteService = new Mock<IClienteService>();
            var handler = new UpdateClienteHandler(mockClienteService.Object);
            var command = new UpdateClienteCommand
            {
                //IdClienteExistente = "1234567890",
                Cpf = "12345678900",
                Nome = "Fulano",
                Rg = "1234567",
                DataExpedicao = DateTime.Parse("01/01/2000"),
                OrgaoExpedicao = "SSP",
                Uf = "SP",
                DataDeNascimento = DateTime.Parse("01/01/1980"),
                Sexo = "M",
                EstadoCivil = "Solteiro(a)"
            };

            // Act
            await handler.ExecuteCommand(command);

            // Assert
            mockClienteService.Verify(x => x.UpdateCliente(command), Times.Once);
        }
    }
}
