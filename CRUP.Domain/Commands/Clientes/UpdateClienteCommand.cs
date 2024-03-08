﻿using CRUP.Domain.Contracts.Clientes;
using CRUP.Shared.Commands;

namespace CRUP.Domain.Commands.Clientes
{
    public class UpdateClienteCommand : BaseCommand
    {
        public Guid IdClienteExistente { get; private set; }

        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string? Rg { get; set; }
        public DateTime? DataExpedicao { get; set; }
        public string? OrgaoExpedicao { get; set; }
        public string? Uf { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }


        public override void Validate()
        {
            AddNotifications(new UpdateClienteContract(this));
        }

        public void InserirIdClienteExistenteNoCommand(Guid id)
        {
            IdClienteExistente = id;
        }
    }
}
