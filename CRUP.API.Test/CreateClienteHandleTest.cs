

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
        [Theory]
        [Trait("Services", "Create de Cliente Ok")]
        [InlineData("jose da silva", "30/01/2015", "12345678909", "30/01/2015", "Solteiro", "123456789", "Feminino", "SSP","SP")]
        public async Task ExecuteCommand_DeveChamarMetodoCreateClienteDoClienteService(string nome, string dataNascimento, string cpf, string dataExpedicao, string estadoCivil, string rg, string sexo, string orgaoExpedicao, string uf)
        {
            // Arrange
            var mockClienteService = new Mock<IClienteService>();
            var handler = new CreateClienteHandler(mockClienteService.Object);
            var command = new CreateClienteCommand
            {
                Cpf = cpf,
                Nome = nome,
                Rg = rg,
                DataExpedicao = DateTime.Parse(dataExpedicao),
                OrgaoExpedicao = orgaoExpedicao,
                Uf = uf,
                DataDeNascimento = DateTime.Parse(dataNascimento),
                Sexo = sexo,
                EstadoCivil = estadoCivil
            };

            // Act
            await handler.ExecuteCommand(command);

            // Assert
            mockClienteService.Verify(x => x.CreateCliente(command), Times.Once);
        }
    }
}
