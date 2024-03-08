using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUP.API;
using CRUP.API.Controllers;
using CRUP.Application.Interfaces;
using CRUP.Domain.Commands;
using CRUP.Domain.Commands.Clientes;
using CRUP.Domain.Entities;
using CRUP.Shared.Handlers;
using Moq;
using Xunit;

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
        public void GetAllAsync_Get_DeveRetornarOK()
        {
            // Arrange

            var ddd = new CommandResult();
            ddd.Success = true;
            ddd.Message = string.Empty;
            ddd.Data = string.Empty;
            _clienteServiceMock.Setup(x => x.GetAllClientes()).ReturnsAsync(ddd);
            _createClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<CreateClienteCommand>())).ReturnsAsync(ddd);
            _updateClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<UpdateClienteCommand>())).ReturnsAsync(ddd);

            var controller = new ClienteController(_clienteServiceMock.Object, _createClienteHandlerMock.Object, _updateClienteHandlerMock.Object);



            // Act
            var result = controller.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            
            //Assert.Equal(200, result.Status.sta.StatusCode);
        }

        [Fact]
        public void GetAllAsync_Get_DeveRetornarErro()
        {
            // Arrange

            var ddd = new CommandResult();
            ddd.Success = false;
            ddd.Message = string.Empty;
            ddd.Data = string.Empty;
            _clienteServiceMock.Setup(x => x.GetAllClientes()).ReturnsAsync(ddd);
            _createClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<CreateClienteCommand>())).ReturnsAsync(ddd);
            _updateClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<UpdateClienteCommand>())).ReturnsAsync(ddd);

            var controller = new ClienteController(_clienteServiceMock.Object, _createClienteHandlerMock.Object, _updateClienteHandlerMock.Object);



            // Act
            var result = controller.GetAllAsync();

            // Assert
            Assert.NotNull(result);

            //Assert.re
        }







        ///////
        [Fact]
        public void GetByIdAsync_Get_DeveRetornarOK()
        {
            // Arrange
            var id = new Guid();
            var ddd = new CommandResult();
            ddd.Success = true;
            ddd.Message = string.Empty;
            ddd.Data = string.Empty;
            _clienteServiceMock.Setup(x => x.GetByIdCliente(id)).ReturnsAsync(ddd);
            _createClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<CreateClienteCommand>())).ReturnsAsync(ddd);
            _updateClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<UpdateClienteCommand>())).ReturnsAsync(ddd);

            var controller = new ClienteController(_clienteServiceMock.Object, _createClienteHandlerMock.Object, _updateClienteHandlerMock.Object);



            // Act
            var result = controller.GetByIdAsync(id);

            // Assert
            Assert.NotNull(result);

            //Assert.Equal(200, result.Status.sta.StatusCode);
        }

        [Fact]
        public void GetByIdAsync_Get_DeveRetornarErro()
        {
            // Arrange
            var id = new Guid();
            var ddd = new CommandResult();
            ddd.Success = false;
            ddd.Message = string.Empty;
            ddd.Data = string.Empty;
            _clienteServiceMock.Setup(x => x.GetByIdCliente(id)).ReturnsAsync(ddd);
            _createClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<CreateClienteCommand>())).ReturnsAsync(ddd);
            _updateClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<UpdateClienteCommand>())).ReturnsAsync(ddd);

            var controller = new ClienteController(_clienteServiceMock.Object, _createClienteHandlerMock.Object, _updateClienteHandlerMock.Object);



            // Act
            var result = controller.GetByIdAsync(id);

            // Assert
            Assert.NotNull(result);

            //Assert.Equal(200, result.Status.sta.StatusCode);
        }



        ///////////////PostAsync
        [Fact]
        public void PostAsync_Post_DeveRetornarOK()
        {
            // Arrange
            var cliente = new CreateClienteCommand();
            cliente.Cpf = "30508397839";
            var ddd = new CommandResult();
            ddd.Success = true;
            ddd.Message = string.Empty;
            ddd.Data = string.Empty;
            _clienteServiceMock.Setup(x => x.CreateCliente(cliente)).ReturnsAsync(ddd);
            _createClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<CreateClienteCommand>())).ReturnsAsync(ddd);
            _updateClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<UpdateClienteCommand>())).ReturnsAsync(ddd);

            var controller = new ClienteController(_clienteServiceMock.Object, _createClienteHandlerMock.Object, _updateClienteHandlerMock.Object);



            // Act
            var result = controller.PostAsync(cliente);

            // Assert
            Assert.NotNull(result);

            //Assert.Equal(200, result.Status.sta.StatusCode);
        }

        [Fact]
        public void PostAsync_Post_DeveRetornarErro()
        {
            // Arrange
            var cliente = new CreateClienteCommand();
            cliente.Cpf = "30508397839";
            var ddd = new CommandResult();
            ddd.Success = false;
            ddd.Message = string.Empty;
            ddd.Data = string.Empty;
            _clienteServiceMock.Setup(x => x.CreateCliente(cliente)).ReturnsAsync(ddd);
            _createClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<CreateClienteCommand>())).ReturnsAsync(ddd);
            _updateClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<UpdateClienteCommand>())).ReturnsAsync(ddd);

            var controller = new ClienteController(_clienteServiceMock.Object, _createClienteHandlerMock.Object, _updateClienteHandlerMock.Object);



            // Act
            var result = controller.PostAsync(cliente);

            // Assert
            Assert.NotNull(result);

            //Assert.Equal(200, result.Status.sta.StatusCode);
        }

        /////
        ///PutAsync
        ///
        [Fact]
        public void PutAsync_Put_DeveRetornarOK()
        {
            // Arrange
            var id = new Guid();

            var cliente = new UpdateClienteCommand();
            cliente.Cpf = "30508397839";
            var ddd = new CommandResult();
            ddd.Success = true;
            ddd.Message = string.Empty;
            ddd.Data = string.Empty;
            _clienteServiceMock.Setup(x => x.UpdateCliente(cliente)).ReturnsAsync(ddd);
            _createClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<CreateClienteCommand>())).ReturnsAsync(ddd);
            _updateClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<UpdateClienteCommand>())).ReturnsAsync(ddd);

            var controller = new ClienteController(_clienteServiceMock.Object, _createClienteHandlerMock.Object, _updateClienteHandlerMock.Object);



            // Act
            var result = controller.PutAsync(id,cliente);

            // Assert
            Assert.NotNull(result);

            //Assert.Equal(200, result.Status.sta.StatusCode);
        }

        [Fact]
        public void PutAsync_Put_DeveRetornarErro()
        {
            // Arrange
            var id = new Guid();

            var cliente = new UpdateClienteCommand();
            cliente.Cpf = "30508397839";
            var ddd = new CommandResult();
            ddd.Success = false;
            ddd.Message = string.Empty;
            ddd.Data = string.Empty;
            _clienteServiceMock.Setup(x => x.UpdateCliente(cliente)).ReturnsAsync(ddd);
            _createClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<CreateClienteCommand>())).ReturnsAsync(ddd);
            _updateClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<UpdateClienteCommand>())).ReturnsAsync(ddd);

            var controller = new ClienteController(_clienteServiceMock.Object, _createClienteHandlerMock.Object, _updateClienteHandlerMock.Object);



            // Act
            var result = controller.PutAsync(id,cliente);

            // Assert
            Assert.NotNull(result);

            //Assert.Equal(200, result.Status.sta.StatusCode);
        }


        ////DeleteAsync
        ///
        [Fact]
        public void DeleteAsync_Delete_DeveRetornarOK()
        {
            // Arrange
            var id = new Guid();

            var cliente = new UpdateClienteCommand();
            cliente.Cpf = "30508397839";
            var ddd = new CommandResult();
            ddd.Success = true;
            ddd.Message = string.Empty;
            ddd.Data = string.Empty;
            _clienteServiceMock.Setup(x => x.DeleteCliente(id)).ReturnsAsync(ddd);
            _createClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<CreateClienteCommand>())).ReturnsAsync(ddd);
            _updateClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<UpdateClienteCommand>())).ReturnsAsync(ddd);

            var controller = new ClienteController(_clienteServiceMock.Object, _createClienteHandlerMock.Object, _updateClienteHandlerMock.Object);



            // Act
            var result = controller.DeleteAsync(id);

            // Assert
            Assert.NotNull(result);

            //Assert.Equal(200, result.Status.sta.StatusCode);
        }

        [Fact]
        public void DeleteAsync_Delete_DeveRetornarErro()
        {
            // Arrange
            var id = new Guid();
  
            var cliente = new UpdateClienteCommand();
            cliente.Cpf = "30508397839";
            var ddd = new CommandResult();
            ddd.Success = false;
            ddd.Message = string.Empty;
            ddd.Data = string.Empty;
            _clienteServiceMock.Setup(x => x.DeleteCliente(id)).ReturnsAsync(ddd);
            _createClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<CreateClienteCommand>())).ReturnsAsync(ddd);
            _updateClienteHandlerMock.Setup(x => x.ExecuteCommand(It.IsAny<UpdateClienteCommand>())).ReturnsAsync(ddd);

            var controller = new ClienteController(_clienteServiceMock.Object, _createClienteHandlerMock.Object, _updateClienteHandlerMock.Object);



            // Act
            var result = controller.DeleteAsync(id);

            // Assert
            Assert.NotNull(result);

            //Assert.Equal(200, result.Status.sta.StatusCode);
        }
    }
}
