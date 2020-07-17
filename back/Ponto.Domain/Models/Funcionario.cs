using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using FluentValidator.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ponto.Domain.Models
{
    [Table("Funcionario")]
    public class Funcionario : Entity
    {
        public Funcionario()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .IsNotNullOrEmpty(NomeCompleto, "NomeCompleto", $"Campo {NomeCompleto.ToString()} é obrigatório")
                .HasMinLen(NomeCompleto, 3, "NomeCompleto", $"{NomeCompleto.ToString()} deve ter no mínimo 3 caracteres")
                .HasMaxLen(NomeCompleto, 150, "NomeCompleto", $"{NomeCompleto.ToString()} deve ter no máximo 150 caracteres")
                .IsLowerThan(DataNascimento, DateTime.Now, "Data Nascimento", "Nascimento não pode ser maior que a data atual")
                .IsNotNullOrEmpty(HorarioEntrada.ToShortTimeString(), "HorarioEntrada", $"Campo {HorarioEntrada.ToString()} é obrigatório")
                .IsNotNull(HorarioSaida, "HorarioSaida", "Digite um horário de saída")
                );
        }
        public Funcionario(string nomeCompleto, string apelido, DateTime dataNascimento, string funcao, DateTime horarioEntrada, 
                            DateTime horarioSaida, string formaContratacao, byte[] fotoData, string fotoFilename)
        {
            NomeCompleto = nomeCompleto;
            Apelido = apelido;
            DataNascimento = dataNascimento;
            Funcao = funcao;
            HorarioEntrada = horarioEntrada;
            HorarioSaida = horarioSaida;
            FormaContratacao = formaContratacao;
            FotoData = fotoData;
            FotoFilename = fotoFilename;
        }

        public string NomeCompleto { get; private set; }
        public string Apelido { get; private set; }

        public DateTime DataNascimento { get; private set; }

        public string Funcao { get; private set; }

        public DateTime HorarioEntrada { get; private set; }

        public DateTime HorarioSaida { get; private set; }
        public string FormaContratacao { get; private set; }
        public byte[] FotoData { get; private set; }
        public string FotoFilename { get; private set; }
        public Guid EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }




    }
}
