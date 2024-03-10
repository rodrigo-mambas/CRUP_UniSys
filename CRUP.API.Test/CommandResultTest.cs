
using CRUP.Shared.Commands.Interfaces;
using CRUP.Domain.Commands;
using Xunit;

namespace CRUP.API.Test
{
    public class CommandResultTests
    {
        [Fact]
        [Trait("CommandResult", "Com Sucesso e mensagem")]
        public void Deve_InicializarCommandResult_ComSucessoEMensagem()
        {
            // Arrange
            var success = true;
            var message = "Mensagem de sucesso";

            // Act
            var commandResult = new CommandResult(success, message);

            // Assert
            Assert.Equal(success, commandResult.Success);
            Assert.Equal(message, commandResult.Message);
            Assert.Null(commandResult.Data);
        }

        [Fact]
        [Trait("CommandResult", "Com Sucesso, mensagem e dados")]
        public void Deve_InicializarCommandResult_ComSucessoMensagemEDados()
        {
            // Arrange
            var success = true;
            var message = "Mensagem de sucesso";
            var data = new object();

            // Act
            var commandResult = new CommandResult(success, message, data);

            // Assert
            Assert.Equal(success, commandResult.Success);
            Assert.Equal(message, commandResult.Message);
            Assert.Equal(data, commandResult.Data);
        }
    }
}
