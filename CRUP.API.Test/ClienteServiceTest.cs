using CRUP.Application.Services;
using CRUP.Domain.Entities;
using CRUP.Domain.Commands.Clientes;
using CRUP.Infra.Data.Interfaces;
using Moq;

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
        public async Task CreateCliente_DeveCriarCliente()
        {
            // Arrange
            var clienteCommand = new CreateClienteCommand
            {
                Nome = "1",
                DataDeNascimento = Convert.ToDateTime("30/01/2015"),
                Cpf = "12345678909",
                DataExpedicao = Convert.ToDateTime("30/01/2015"),
                EstadoCivil = "1",
                Rg = "1",
                Sexo = "1",
                OrgaoExpedicao = "1"
            };

            //act
            var result = await _clienteService.CreateCliente(clienteCommand);

            //assert
            Assert.True(result.Success);
        }

        [Fact]
        public async Task GetAllClientes_DeveRetornarListaDeClientes1()
        {
            // Arrange
            var clienteCommand = new CreateClienteCommand
            {
                Nome = "1",
                DataDeNascimento = Convert.ToDateTime("30/01/2015"),
                Cpf = "1",
                DataExpedicao = Convert.ToDateTime("30/01/2015"),
                EstadoCivil = "1",
                Rg = "1",
                Sexo = "1",
                OrgaoExpedicao = "1"
            };

            //act
            var result = await _clienteService.CreateCliente(clienteCommand);

            //assert
            Assert.False(result.Success);
        }
        [Fact]
        public async Task GetAllClientes_DeveListarCliente1_OK()
        {
            // Arrange
            var clientes = new List<Cliente> {
                 new Cliente( "12345678909","asdfgh1","sdddd",Convert.ToDateTime("30/01/2015"),"asd","df",Convert.ToDateTime("30/01/2015"),"wer","sdf"),
                 new Cliente( "12345678909","asdfgh1","sdddd",Convert.ToDateTime("30/01/2015"),"asd","df",Convert.ToDateTime("30/01/2015"),"wer","sdf"),
                 new Cliente( "12345678909","asdfgh1","sdddd",Convert.ToDateTime("30/01/2015"),"asd","df",Convert.ToDateTime("30/01/2015"),"wer","sdf"),
                 }.AsQueryable();
            _readRepositoryMock.Setup(x => x.FindAll()).Returns(clientes);

            //act
            var result = await _clienteService.GetAllClientes();

            //assert
            Assert.True(result.Success);
        }

        [Fact]
        public async Task GetAllClientes_DeveListarCliente1_Fail()
        {
            // Arrange
            var clientes = new List<Cliente>().AsQueryable();
            _readRepositoryMock.Setup(x => x.FindAll()).Returns(clientes);

            //act
            var result = await _clienteService.GetAllClientes();

            //assert
            Assert.False(result.Success);
        }

        [Fact]
        public async Task GetByIdCliente_DeveListarCliente1_OK()
        {
            // Arrange
            var id = new Guid();
            var clientes = new List<Cliente> {new Cliente( "12345678909","asdfgh1","sdddd",Convert.ToDateTime("30/01/2015"),"asd","df",Convert.ToDateTime("30/01/2015"),"wer","sdf")}.AsQueryable();
            _readRepositoryMock.Setup(x => x.FindByCondition(x => x.Id == id)).Returns(clientes);

            //act
            var result = await _clienteService.GetByIdCliente(id);

            //assert
            Assert.True(result.Success);
        }

        [Fact]
        public async Task GetByIdCliente_DeveListarCliente1_Fail()
        {
            // Arrange
            var id = new Guid();
            var clientes = new List<Cliente>().AsQueryable();
            _readRepositoryMock.Setup(x => x.FindByCondition(x => x.Id == id)).Returns(clientes);

            //act
            var result = await _clienteService.GetByIdCliente(id);

            //assert
            Assert.False(result.Success);
        }

        [Fact]
        public async Task DeleteCliente_DeveDeletarCliente1_Erro()
        {
            // Arrange
            var id = new Guid();
            var clientes = new List<Cliente>().AsQueryable();
            var cliente = new Cliente( "12345678909","asdfgh1","sdddd",Convert.ToDateTime("30/01/2015"),"asd","df",Convert.ToDateTime("30/01/2015"),"wer","sdf");
            _readRepositoryMock.Setup(x => x.FindByCondition(x => x.Id == cliente.Id)).Returns(clientes);
            _writeRepositoryMock.Setup(x => x.Delete(cliente));

            //act
            var result = await _clienteService.DeleteCliente(id);

            //assert
            Assert.False(result.Success);
        }
        [Fact]
        public async Task DeleteCliente_DeveDeletarCliente1_Ok()
        {
            // Arrange
            var id = new Guid();
            var clientes = new List<Cliente> {new Cliente( "12345678909","asdfgh1","sdddd",Convert.ToDateTime("30/01/2015"),"asd","df",Convert.ToDateTime("30/01/2015"),"wer","sdf"),}.AsQueryable();
            var cliente =new Cliente("12345678909", "asdfgh1", "sdddd", Convert.ToDateTime("30/01/2015"), "asd", "df", Convert.ToDateTime("30/01/2015"), "wer", "sdf");
            _readRepositoryMock.Setup(x => x.FindByCondition(x => x.Id == id)).Returns(clientes);
            _writeRepositoryMock.Setup(x => x.Delete(cliente));

            //act
            var result = await _clienteService.DeleteCliente(id);

            //assert
            Assert.True(result.Success);
        }

        [Fact]
        public async Task UpdateCliente_DeveUpdateCliente1_Ok()
        {
            // Arrange
            var id = new Guid();
            id = System.Guid.Parse("20682e30-60ed-4f9d-a086-3e483de3325d");
            var clientes = new List<Cliente> {
                 new Cliente( "12345678909","asdfgh1","sdddd",Convert.ToDateTime("30/01/2015"),"asd","df",Convert.ToDateTime("30/01/2015"),"wer","sdf"),
                 }.AsQueryable();
            var updateCommand = new UpdateClienteCommand();
            updateCommand.Nome = "1";
            updateCommand.DataDeNascimento = Convert.ToDateTime("30/01/2015");
            updateCommand.Cpf = "12345678909";
            updateCommand.IdClienteExistente = id;
            updateCommand.EstadoCivil = "aa";
            updateCommand.DataExpedicao = Convert.ToDateTime("30/01/2015");
            updateCommand.OrgaoExpedicao = "asdf";
            updateCommand.Uf = "as";
            updateCommand.Rg = "12";
            updateCommand.Sexo = "dfg";
            var cliente = new Cliente("12345678909", "asdfgh1", "sdddd", Convert.ToDateTime("30/01/2015"), "asd", "df", Convert.ToDateTime("30/01/2015"), "wer", "sdf");

            _readRepositoryMock.Setup(x => x.FindByCondition(x => x.Id == updateCommand.IdClienteExistente)).Returns(clientes);

            _writeRepositoryMock.Setup(x => x.Update(cliente));

            //act
            var result = await _clienteService.UpdateCliente(updateCommand);

            //assert
            Assert.True(result.Success);
        }

        [Fact]
        public async Task UpdateCliente_DeveUpdateCliente1_Erro()
        {
            // Arrange
            var id = new Guid();
            id = System.Guid.Parse("20682e30-60ed-4f9d-a086-3e483de3325d");
            var clientes = new List<Cliente>().AsQueryable();
            var updateCommand = new UpdateClienteCommand();
            updateCommand.Nome = "1";
            updateCommand.DataDeNascimento = Convert.ToDateTime("30/01/2015");
            updateCommand.Cpf = "12345678909";
            updateCommand.IdClienteExistente = id;
            updateCommand.EstadoCivil = "aa";
            updateCommand.DataExpedicao = Convert.ToDateTime("30/01/2015");
            updateCommand.OrgaoExpedicao = "asdf";
            updateCommand.Uf = "as";
            updateCommand.Rg = "12";
            updateCommand.Sexo = "dfg";
            var cliente = new Cliente("12345678909", "asdfgh1", "sdddd", Convert.ToDateTime("30/01/2015"), "asd", "df", Convert.ToDateTime("30/01/2015"), "wer", "sdf");

            _readRepositoryMock.Setup(x => x.FindByCondition(x => x.Id == updateCommand.IdClienteExistente)).Returns(clientes);

            _writeRepositoryMock.Setup(x => x.Update(cliente));

            //act
            var result = await _clienteService.UpdateCliente(updateCommand);

            //assert
            Assert.False(result.Success);
        }

        [Fact]
        public async Task UpdateCliente_DeveUpdateCliente1_Fail()
        {
            // Arrange
            var id = new Guid();
            //id = System.Guid.Parse("20682e30-60ed-4f9d-a086-3e483de3325d");
            var clientes = new List<Cliente>().AsQueryable();
            var updateCommand = new UpdateClienteCommand
            {
                Nome = "1",
                DataDeNascimento = Convert.ToDateTime("30/01/2015"),
                Cpf = "1",
                IdClienteExistente = id,
                EstadoCivil = "aa",
                DataExpedicao = Convert.ToDateTime("30/01/2015"),
                OrgaoExpedicao = "asdf",
                Uf = "as",
                Rg = "12",
                Sexo = "dfg"
            };
            var cliente = new Cliente("12345678909", "asdfgh1", "sdddd", Convert.ToDateTime("30/01/2015"), "asd", "df", Convert.ToDateTime("30/01/2015"), "wer", "sdf");

            //var clientesQueryable = clientes.AsQueryable();
            _readRepositoryMock.Setup(x => x.FindByCondition(x => x.Id == updateCommand.IdClienteExistente)).Returns(clientes);
            _writeRepositoryMock.Setup(x => x.Update(cliente));

            //act
            var result = await _clienteService.UpdateCliente(updateCommand);

            //assert
            Assert.False(result.Success);
        }
    }
}

