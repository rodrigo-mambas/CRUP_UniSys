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

        [Theory]
        [Trait("Services", "Create de Cliente Ok")]
        [InlineData("jose da silva", "30/01/2015", "12345678909", "30/01/2015","Solteiro", "123456789","Feminino","SSP")]
        public async Task CreateCliente_DeveCriarClienteOk(string nome,string dataNascimento, string cpf, string dataExpedicao, string estadoCivil, string rg, string sexo, string orgaoExpedicao)
        {
            // Arrange
            var clienteCommand = new CreateClienteCommand
            {
                Nome = nome,
                DataDeNascimento = Convert.ToDateTime(dataNascimento),
                Cpf = cpf,
                DataExpedicao = Convert.ToDateTime(dataExpedicao),
                EstadoCivil = estadoCivil,
                Rg = rg,
                Sexo = sexo,
                OrgaoExpedicao = orgaoExpedicao
            };

            //act
            var result = await _clienteService.CreateCliente(clienteCommand);

            //assert
            Assert.True(result.Success);
        }

        [Theory]
        [Trait("Services", "Create de Cliente Badrequest")]
        [InlineData("jose da silva", "30/01/2015", "123", "30/01/2015", "Solteiro", "123456789", "Feminino", "SSP","PE")]
        [InlineData("", "30/01/2015", "12345678909", "30/01/2015", "Solteiro", "123456789", "Feminino", "SSP", "PE")]
        [InlineData("jose Gomez", "30/01/2015", "12345678909", "30/01/2015", "Solteiro", "123456789", "", "SSP", "PE")]
        public async Task GetAllClientes_DeveRetornarListaDeClientes1(string nome, string dataNascimento, string cpf, string dataExpedicao, string estadoCivil, string rg, string sexo, string orgaoExpedicao, string uf)
        {
            // Arrange
            var clienteCommand = new CreateClienteCommand
            {
                Nome = nome,
                DataDeNascimento = Convert.ToDateTime(dataNascimento),
                Cpf = cpf,
                DataExpedicao = Convert.ToDateTime(dataExpedicao),
                EstadoCivil = estadoCivil,
                Rg = rg,
                Sexo = sexo,
                OrgaoExpedicao = orgaoExpedicao,
                Uf =uf
            };

            //act
            var result = await _clienteService.CreateCliente(clienteCommand);

            //assert
            Assert.False(result.Success);
        }
        [Theory]
        [Trait("Services", "Create de Cliente Ok")]
        [InlineData("jose da silva", "30/01/2015", "12345678909", "30/01/2015", "Solteiro", "123456789", "Feminino", "SSP","AM", "Maria da Graca", "15/01/1983", "98765432109", "30/01/2015", "Casada", "123456789", "Masculino", "SSP","RJ")]
        public async Task GetAllClientes_DeveListarCliente1_OK(string nome, string dataNascimento, string cpf, string dataExpedicao, string estadoCivil, string rg, string sexo, string orgaoExpedicao,string uf,
                                                                string nome1, string dataNascimento1, string cpf1, string dataExpedicao1, string estadoCivil1, string rg1, string sexo1, string orgaoExpedicao1,string uf1)
        {
            // Arrange
            var clientes = new List<Cliente> {
                 new Cliente( cpf,nome,rg,Convert.ToDateTime(dataExpedicao),orgaoExpedicao,uf,Convert.ToDateTime(dataNascimento),sexo,estadoCivil),
                 new Cliente( cpf1,nome1,rg1,Convert.ToDateTime(dataExpedicao1),orgaoExpedicao1,uf1,Convert.ToDateTime(dataNascimento1),sexo1,estadoCivil1),
                 }.AsQueryable();
            _readRepositoryMock.Setup(x => x.FindAll()).Returns(clientes);

            //act
            var result = await _clienteService.GetAllClientes();

            //assert
            Assert.True(result.Success);
        }

        [Fact]
        [Trait("Services", "Busca Todos os Cliente BadRequest")]
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

        [Theory]
        [Trait("Services", "Busca por ID o Cliente Ok")]
        [InlineData("jose da silva", "30/01/2015", "12345678909", "30/01/2015", "Solteiro", "123456789", "Feminino", "SSP", "PE")]
        public async Task GetByIdCliente_DeveListarCliente1_OK(string nome, string dataNascimento, string cpf, string dataExpedicao, string estadoCivil, string rg, string sexo, string orgaoExpedicao, string uf)
        {
            // Arrange
            var id = new Guid();
            var clientes = new List<Cliente> {new Cliente(cpf, nome, rg, Convert.ToDateTime(dataExpedicao), orgaoExpedicao, uf, Convert.ToDateTime(dataNascimento), sexo, estadoCivil) }.AsQueryable();
            _readRepositoryMock.Setup(x => x.FindByCondition(x => x.Id == id)).Returns(clientes);

            //act
            var result = await _clienteService.GetByIdCliente(id);

            //assert
            Assert.True(result.Success);
        }

        [Fact]
        [Trait("Services", "Busca por ID o Cliente BadRequest")]
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

        [Theory]
        [Trait("Services", "Delete Cliente por Id BadRequest")]
        [InlineData("jose da silva", "30/01/2015", "12345678909", "30/01/2015", "Solteiro", "123456789", "Feminino", "SSP", "PE")]
        public async Task DeleteCliente_DeveDeletarCliente1_Erro(string nome, string dataNascimento, string cpf, string dataExpedicao, string estadoCivil, string rg, string sexo, string orgaoExpedicao, string uf)
        {
            // Arrange
            var id = new Guid();
            var clientes = new List<Cliente>().AsQueryable();
            var cliente = new Cliente(cpf, nome, rg, Convert.ToDateTime(dataExpedicao), orgaoExpedicao, uf, Convert.ToDateTime(dataNascimento), sexo, estadoCivil);
            _readRepositoryMock.Setup(x => x.FindByCondition(x => x.Id == cliente.Id)).Returns(clientes);
            _writeRepositoryMock.Setup(x => x.Delete(cliente));

            //act
            var result = await _clienteService.DeleteCliente(id);

            //assert
            Assert.False(result.Success);
        }

        [Theory]
        [Trait("Services", "Delete Cliente por Id Ok")]
        [InlineData("jose da silva", "30/01/2015", "12345678909", "30/01/2015", "Solteiro", "123456789", "Feminino", "SSP", "PE")]
        public async Task DeleteCliente_DeveDeletarCliente1_Ok(string nome, string dataNascimento, string cpf, string dataExpedicao, string estadoCivil, string rg, string sexo, string orgaoExpedicao, string uf)
        {
            // Arrange
            var id = new Guid();
            var clientes = new List<Cliente> {new Cliente(cpf, nome, rg, Convert.ToDateTime(dataExpedicao), orgaoExpedicao, uf, Convert.ToDateTime(dataNascimento), sexo, estadoCivil),}.AsQueryable();
            var cliente =new Cliente(cpf, nome, rg, Convert.ToDateTime(dataExpedicao), orgaoExpedicao, uf, Convert.ToDateTime(dataNascimento), sexo, estadoCivil);
            _readRepositoryMock.Setup(x => x.FindByCondition(x => x.Id == id)).Returns(clientes);
            _writeRepositoryMock.Setup(x => x.Delete(cliente));

            //act
            var result = await _clienteService.DeleteCliente(id);

            //assert
            Assert.True(result.Success);
        }

        [Theory]
        [Trait("Services", "Update Cliente por Id Erro")]
        [InlineData("jose da silva", "30/01/2015", "1234", "30/01/2015", "Solteiro", "123456789", "Feminino", "SSP", "PE", "20682e30-60ed-4f9d-a086-3e483de3325d")]
        public async Task UpdateCliente_DeveUpdateCliente1_ErroValidacao(string nome, string dataNascimento, string cpf, string dataExpedicao, string estadoCivil, string rg, string sexo, string orgaoExpedicao, string uf, string idEntrada)
        {
            // Arrange
            var id = new Guid();
            id = System.Guid.Parse(idEntrada);
            var clientes = new List<Cliente> {
                 new Cliente( cpf, nome, rg, Convert.ToDateTime(dataExpedicao), orgaoExpedicao, uf, Convert.ToDateTime(dataNascimento), sexo, estadoCivil),
                 }.AsQueryable();
            var updateCommand = new UpdateClienteCommand
            {
                Nome = nome,
                DataDeNascimento = Convert.ToDateTime(dataNascimento),
                Cpf = cpf,
                IdClienteExistente = id,
                EstadoCivil = estadoCivil,
                DataExpedicao = Convert.ToDateTime(dataExpedicao),
                OrgaoExpedicao = orgaoExpedicao,
                Uf = uf,
                Rg = rg,
                Sexo = sexo
            };
            var cliente = new Cliente(cpf, nome, rg, Convert.ToDateTime(dataExpedicao), orgaoExpedicao, uf, Convert.ToDateTime(dataNascimento), sexo, estadoCivil);

            _readRepositoryMock.Setup(x => x.FindByCondition(x => x.Id == updateCommand.IdClienteExistente)).Returns(clientes);

            _writeRepositoryMock.Setup(x => x.Update(cliente));

            //act
            var result = await _clienteService.UpdateCliente(updateCommand);

            //assert
            Assert.False(result.Success);
        }


        [Theory]
        [Trait("Services", "Update Cliente por Id Ok")]
        [InlineData("jose da silva", "30/01/2015", "12345678909", "30/01/2015", "Solteiro", "123456789", "Feminino", "SSP", "PE", "20682e30-60ed-4f9d-a086-3e483de3325d")]
        public async Task UpdateCliente_DeveUpdateCliente1_Ok(string nome, string dataNascimento, string cpf, string dataExpedicao, string estadoCivil, string rg, string sexo, string orgaoExpedicao, string uf,string idEntrada)
        {
            // Arrange
            var id = new Guid();
            id = System.Guid.Parse(idEntrada);
            var clientes = new List<Cliente> {
                 new Cliente( cpf, nome, rg, Convert.ToDateTime(dataExpedicao), orgaoExpedicao, uf, Convert.ToDateTime(dataNascimento), sexo, estadoCivil),
                 }.AsQueryable();
            var updateCommand = new UpdateClienteCommand
            {
                Nome = nome,
                DataDeNascimento = Convert.ToDateTime(dataNascimento),
                Cpf = cpf,
                IdClienteExistente = id,
                EstadoCivil = estadoCivil,
                DataExpedicao = Convert.ToDateTime(dataExpedicao),
                OrgaoExpedicao = orgaoExpedicao,
                Uf = uf,
                Rg = rg,
                Sexo = sexo
            };
            var cliente = new Cliente(cpf, nome, rg, Convert.ToDateTime(dataExpedicao), orgaoExpedicao, uf, Convert.ToDateTime(dataNascimento), sexo, estadoCivil);

            _readRepositoryMock.Setup(x => x.FindByCondition(x => x.Id == updateCommand.IdClienteExistente)).Returns(clientes);

            _writeRepositoryMock.Setup(x => x.Update(cliente));

            //act
            var result = await _clienteService.UpdateCliente(updateCommand);

            //assert
            Assert.True(result.Success);
        }

        [Theory]
        [Trait("Services", "Update Cliente por Id Ok")]
        [InlineData("jose da silva", "30/01/2015", "12345678909", "30/01/2015", "Solteiro", "123456789", "Feminino", "SSP", "PE", "20682e30-60ed-4f9d-a086-3e483de3325d")]
        public async Task UpdateCliente_DeveUpdateCliente1_Erro(string nome, string dataNascimento, string cpf, string dataExpedicao, string estadoCivil, string rg, string sexo, string orgaoExpedicao, string uf, string idEntrada)
        {
            // Arrange
            var id = new Guid();
            id = System.Guid.Parse(idEntrada);
            var clientes = new List<Cliente>().AsQueryable();
            var updateCommand = new UpdateClienteCommand
            {
                Nome = nome,
                DataDeNascimento = Convert.ToDateTime(dataNascimento),
                Cpf = cpf,
                IdClienteExistente = id,
                EstadoCivil = estadoCivil,
                DataExpedicao = Convert.ToDateTime(dataExpedicao),
                OrgaoExpedicao = orgaoExpedicao,
                Uf = uf,
                Rg = rg,
                Sexo = sexo
            };
            var cliente = new Cliente(cpf, nome, rg, Convert.ToDateTime(dataExpedicao), orgaoExpedicao, uf, Convert.ToDateTime(dataNascimento), sexo, estadoCivil);

            _readRepositoryMock.Setup(x => x.FindByCondition(x => x.Id == updateCommand.IdClienteExistente)).Returns(clientes);

            _writeRepositoryMock.Setup(x => x.Update(cliente));

            //act
            var result = await _clienteService.UpdateCliente(updateCommand);

            //assert
            Assert.False(result.Success);
        }

        [Theory]
        [Trait("Services", "Update Cliente por Id Ok")]
        [InlineData("jose da silva", "30/01/2015", "12345678909", "30/01/2015", "Solteiro", "123456789", "Feminino", "SSP", "PE", "20682e30-60ed-4f9d-a086-3e483de3325d")]

        public async Task UpdateCliente_DeveUpdateCliente1_Fail(string nome, string dataNascimento, string cpf, string dataExpedicao, string estadoCivil, string rg, string sexo, string orgaoExpedicao, string uf, string idEntrada)
        {
            // Arrange
            var id = new Guid();
            //id = System.Guid.Parse(idEntrada);
            var clientes = new List<Cliente>().AsQueryable();
            var updateCommand = new UpdateClienteCommand
            {
                Nome = nome,
                DataDeNascimento = Convert.ToDateTime(dataNascimento),
                Cpf = cpf,
                IdClienteExistente = id,
                EstadoCivil = estadoCivil,
                DataExpedicao = Convert.ToDateTime(dataExpedicao),
                OrgaoExpedicao = orgaoExpedicao,
                Uf = uf,
                Rg = rg,
                Sexo = sexo
            };
            var cliente = new Cliente(cpf, nome, rg, Convert.ToDateTime(dataExpedicao), orgaoExpedicao, uf, Convert.ToDateTime(dataNascimento), sexo, estadoCivil);
            _readRepositoryMock.Setup(x => x.FindByCondition(x => x.Id == updateCommand.IdClienteExistente)).Returns(clientes);
            _writeRepositoryMock.Setup(x => x.Update(cliente));

            //act
            var result = await _clienteService.UpdateCliente(updateCommand);

            //assert
            Assert.False(result.Success);
        }
    }
}

