using CRUP.API.Controllers;
using CRUP.Application.Interfaces;
using CRUP.Domain.Commands;
using CRUP.Domain.Commands.Clientes;
using CRUP.Shared.Handlers;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace CRUP.API.Test
{
    public class ClienteControllerTest
    {
        private readonly Mock<IClienteService> _clienteServiceMock;
        private readonly Mock<IHandler<CreateClienteCommand>> _createClienteHandlerMock;
        private readonly Mock<IHandler<UpdateClienteCommand>> _updateClienteHandlerMock;

        public ClienteControllerTest()
        {
            _clienteServiceMock = new Mock<IClienteService>();
            _createClienteHandlerMock = new Mock<IHandler<CreateClienteCommand>>();
            _updateClienteHandlerMock = new Mock<IHandler<UpdateClienteCommand>>();
        }
        [Fact]
        [Trait("Controller", "Busca Todos os Cliente Ok")]
        public void GetAllAsync_Get_DeveRetornarOK()
        {
            // Arrange
            var commandResult = new CommandResult();
            commandResult.Success = true;
            commandResult.Message = string.Empty;
            commandResult.Data = string.Empty;
            _clienteServiceMock.Setup(x => x.GetAllClientes()).ReturnsAsync(commandResult);
            _createClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<CreateClienteCommand>())).ReturnsAsync(commandResult);
            _updateClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<UpdateClienteCommand>())).ReturnsAsync(commandResult);

            var controller = new ClienteController(_clienteServiceMock.Object, _createClienteHandlerMock.Object, _updateClienteHandlerMock.Object);

            // Act
            var result = controller.GetAllAsync();

            // Assert 
            Assert.NotNull(result);
            Assert.Equal(200, ((ObjectResult)result.Result).StatusCode);
        }

        [Fact]
        [Trait("Controller", "Busca Todos os Cliente BadRequest")]
        public void GetAllAsync_Get_DeveRetornarErro()
        {
            // Arrange

            var commandResult = new CommandResult();
            commandResult.Success = false;
            commandResult.Message = string.Empty;
            commandResult.Data = string.Empty;
            _clienteServiceMock.Setup(x => x.GetAllClientes()).ReturnsAsync(commandResult);
            _createClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<CreateClienteCommand>())).ReturnsAsync(commandResult);
            _updateClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<UpdateClienteCommand>())).ReturnsAsync(commandResult);

            var controller = new ClienteController(_clienteServiceMock.Object, _createClienteHandlerMock.Object, _updateClienteHandlerMock.Object);

            // Act
            var result = controller.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, ((ObjectResult)result.Result).StatusCode);
        }

        [Fact]
        [Trait("Controller", "Busca por Id de Cliente Ok")]
        public void GetByIdAsync_Get_DeveRetornarOK()
        {
            // Arrange
            var id = new Guid();
            var commandResult = new CommandResult();
            commandResult.Success = true;
            commandResult.Message = string.Empty;
            commandResult.Data = string.Empty;
            _clienteServiceMock.Setup(x => x.GetByIdCliente(id)).ReturnsAsync(commandResult);
            _createClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<CreateClienteCommand>())).ReturnsAsync(commandResult);
            _updateClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<UpdateClienteCommand>())).ReturnsAsync(commandResult);

            var controller = new ClienteController(_clienteServiceMock.Object, _createClienteHandlerMock.Object, _updateClienteHandlerMock.Object);

            // Act
            var result = controller.GetByIdAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((ObjectResult)result.Result).StatusCode);
        }

        [Fact]
        [Trait("Controller", "Busca por Id de Cliente BadRequest")]
        public void GetByIdAsync_Get_DeveRetornarErro()
        {
            // Arrange
            var id = new Guid();
            var commandResult = new CommandResult();
            commandResult.Success = false;
            commandResult.Message = string.Empty;
            commandResult.Data = string.Empty;
            _clienteServiceMock.Setup(x => x.GetByIdCliente(id)).ReturnsAsync(commandResult);
            _createClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<CreateClienteCommand>())).ReturnsAsync(commandResult);
            _updateClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<UpdateClienteCommand>())).ReturnsAsync(commandResult);

            var controller = new ClienteController(_clienteServiceMock.Object, _createClienteHandlerMock.Object, _updateClienteHandlerMock.Object);

            // Act
            var result = controller.GetByIdAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, ((ObjectResult)result.Result).StatusCode);
        }

        [Theory]
        [Trait("Controller", "Create de Cliente Ok")]
        [InlineData("30508397839")]
        public void PostAsync_Post_DeveRetornarOK(string cpf)
        {
            // Arrange
            var cliente = new CreateClienteCommand();
            cliente.Cpf = cpf;
            var commandResult = new CommandResult();
            commandResult.Success = true;
            commandResult.Message = string.Empty;
            commandResult.Data = string.Empty;
            _clienteServiceMock.Setup(x => x.CreateCliente(cliente)).ReturnsAsync(commandResult);
            _createClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<CreateClienteCommand>())).ReturnsAsync(commandResult);
            _updateClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<UpdateClienteCommand>())).ReturnsAsync(commandResult);

            var controller = new ClienteController(_clienteServiceMock.Object, _createClienteHandlerMock.Object, _updateClienteHandlerMock.Object);

            // Act
            var result = controller.PostAsync(cliente);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((ObjectResult)result.Result).StatusCode);
        }

        [Theory]
        [Trait("Controller", "Create de Cliente BadRequest")]
        [InlineData("30508397839")]
        public void PostAsync_Post_DeveRetornarErro(string cpf)
        {
            // Arrange
            var cliente = new CreateClienteCommand();
            cliente.Cpf = cpf;
            var commandResult = new CommandResult();
            commandResult.Success = false;
            commandResult.Message = string.Empty;
            commandResult.Data = string.Empty;
            _clienteServiceMock.Setup(x => x.CreateCliente(cliente)).ReturnsAsync(commandResult);
            _createClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<CreateClienteCommand>())).ReturnsAsync(commandResult);
            _updateClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<UpdateClienteCommand>())).ReturnsAsync(commandResult);

            var controller = new ClienteController(_clienteServiceMock.Object, _createClienteHandlerMock.Object, _updateClienteHandlerMock.Object);

            // Act
            var result = controller.PostAsync(cliente);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, ((ObjectResult)result.Result).StatusCode);
        }

        [Theory]
        [Trait("Controller","Update de Cliente Ok")]
        [InlineData("30508397839")]
        public void PutAsync_Put_DeveRetornarOK(string cpf)
        {
            // Arrange
            var id = new Guid();

            var cliente = new UpdateClienteCommand();
            cliente.Cpf = cpf;
            var commandResult = new CommandResult();
            commandResult.Success = true;
            commandResult.Message = string.Empty;
            commandResult.Data = string.Empty;
            _clienteServiceMock.Setup(x => x.UpdateCliente(cliente)).ReturnsAsync(commandResult);
            _createClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<CreateClienteCommand>())).ReturnsAsync(commandResult);
            _updateClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<UpdateClienteCommand>())).ReturnsAsync(commandResult);

            var controller = new ClienteController(_clienteServiceMock.Object, _createClienteHandlerMock.Object, _updateClienteHandlerMock.Object);

            // Act
            var result = controller.PutAsync(id,cliente);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((ObjectResult)result.Result).StatusCode);
        }

        [Theory]
        [Trait("Controller", "Update de Cliente BadRequest")]
        [InlineData("30508397839")]
        public void PutAsync_Put_DeveRetornarErro(string cpf)
        {
            // Arrange
            var id = new Guid();
            var cliente = new UpdateClienteCommand();
            cliente.Cpf = cpf;
            var commandResult = new CommandResult();
            commandResult.Success = false;
            commandResult.Message = string.Empty;
            commandResult.Data = string.Empty;
            _clienteServiceMock.Setup(x => x.UpdateCliente(cliente)).ReturnsAsync(commandResult);
            _createClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<CreateClienteCommand>())).ReturnsAsync(commandResult);
            _updateClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<UpdateClienteCommand>())).ReturnsAsync(commandResult);
            var controller = new ClienteController(_clienteServiceMock.Object, _createClienteHandlerMock.Object, _updateClienteHandlerMock.Object);

            // Act
            var result = controller.PutAsync(id,cliente);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, ((ObjectResult)result.Result).StatusCode);
        }

        [Theory]
        [Trait("Controller", "Delete de Cliente Ok")]
        [InlineData("30508397839")]
        public void DeleteAsync_Delete_DeveRetornarOK(string cpf)
        {
            // Arrange
            var id = new Guid();

            var cliente = new UpdateClienteCommand();
            cliente.Cpf = cpf;
            var commandResult = new CommandResult();
            commandResult.Success = true;
            commandResult.Message = string.Empty;
            commandResult.Data = string.Empty;
            _clienteServiceMock.Setup(x => x.DeleteCliente(id)).ReturnsAsync(commandResult);
            _createClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<CreateClienteCommand>())).ReturnsAsync(commandResult);
            _updateClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<UpdateClienteCommand>())).ReturnsAsync(commandResult);

            var controller = new ClienteController(_clienteServiceMock.Object, _createClienteHandlerMock.Object, _updateClienteHandlerMock.Object);



            // Act
            var result = controller.DeleteAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, ((ObjectResult)result.Result).StatusCode);
        }

        [Theory]
        [Trait("Controller", "Delete de Cliente BadRequest")]
        [InlineData("30508397839")]
        public void DeleteAsync_Delete_DeveRetornarErro(string cpf)
        {
            // Arrange
            var id = new Guid();
  
            var cliente = new UpdateClienteCommand();
            cliente.Cpf = cpf;
            var commandResult = new CommandResult();
            commandResult.Success = false;
            commandResult.Message = string.Empty;
            commandResult.Data = string.Empty;
            _clienteServiceMock.Setup(x => x.DeleteCliente(id)).ReturnsAsync(commandResult);
            _createClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<CreateClienteCommand>())).ReturnsAsync(commandResult);
            _updateClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<UpdateClienteCommand>())).ReturnsAsync(commandResult);

            var controller = new ClienteController(_clienteServiceMock.Object, _createClienteHandlerMock.Object, _updateClienteHandlerMock.Object);



            // Act
            var result = controller.DeleteAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, ((ObjectResult)result.Result).StatusCode);
        }
    }
}
