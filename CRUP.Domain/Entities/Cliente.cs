﻿using CRUP.Domain.Commands.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUP.Shared.Entities;

namespace CRUP.Domain.Entities
{
    public class Cliente : Entity
    {
        public Cliente(string cpf, string nome, string? rg, DateTime? dataExpedicao, string? orgaoExpedicao, string? uf, DateTime dataDeNascimento, string sexo, string estadoCivil)
        {
            Cpf = cpf;
            Nome = nome;
            Rg = rg;
            DataExpedicao = dataExpedicao;
            OrgaoExpedicao = orgaoExpedicao;
            Uf = uf;
            DataDeNascimento = dataDeNascimento;
            Sexo = sexo;
            EstadoCivil = estadoCivil;
 
        }

        protected Cliente() { }

        public string Cpf { get; private set; }
        public string Nome { get; private set; }
        public string? Rg { get; private set; }
        public DateTime? DataExpedicao { get; private set; }
        public string? OrgaoExpedicao { get; private set; }
        public string? Uf { get; private set; }
        public DateTime DataDeNascimento { get; private set; }
        public string Sexo { get; private set; }
        public string EstadoCivil { get; private set; }


        public void Alterar(UpdateClienteCommand command)
        {
            Cpf = command.Cpf;
            Nome = command.Nome;
            Rg = command.Rg;
            DataExpedicao = command.DataExpedicao;
            OrgaoExpedicao = command.OrgaoExpedicao;
            Uf = command.Uf;
            DataDeNascimento = command.DataDeNascimento;
            Sexo = command.Sexo;
            EstadoCivil = command.EstadoCivil;
        }
    }
}
