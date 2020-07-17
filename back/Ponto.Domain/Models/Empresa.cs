using System;
using System.Collections.Generic;
using System.Text;
using FluentValidator;
using FluentValidator.Validation;

namespace Ponto.Domain.Models
{
    public class Empresa : Entity
    {
        public Empresa()
        {
        }
        public Empresa(string razaoSocial, string nomeFantasia, string cNPJ, string iE, string iM, string ramoAtividade)
        {
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            CNPJ = cNPJ;
            IE = iE;
            IM = iM;
            RamoAtividade = ramoAtividade;

        }

        public void AdicionarEndereco(EnderecoEmpresa endereco)
        {
            EnderecoEmpresa = endereco;
        }

        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }
        public string CNPJ { get; private set; }
        public string IE { get; private set; }
        public string IM { get; private set; }
        public string RamoAtividade { get; private set; }

        public virtual EnderecoEmpresa EnderecoEmpresa { get; private set; }
        public virtual ICollection<Funcionario> Funcionarios { get; private set; }

        //public bool validar()
        //{
        //    AddNotifications(new ValidationContract()
        //        .IsNotNullOrEmpty(RazaoSocial,"RazaoSocial","O campo Razão social é obrigatório")
        //        .HasMinLen(RazaoSocial,3,"RazaoSocial", " O campo Razão social deve ter no mínimo 3 caracteres")
        //        .HasMaxLen(RazaoSocial,100,"RazaoSocial"," O campo Razão social deve ter no máximo 100 caracteres")
        //        .HasMinLen(NomeFantasia, 3, "NomeFantasia", "O campo Nome Fantasia deve ter no mínimo 3 caracteres")
        //        .HasMaxLen(NomeFantasia, 100, "NomeFantasia", " O campo Nome Fantasia deve ter no máximo 100 caracteres")
        //        .IsNotNullOrEmpty(CNPJ, "CNPJ", "O campo CNPJ é obrigatório")

        //    );

        //    return false;
        //}

    }
}
