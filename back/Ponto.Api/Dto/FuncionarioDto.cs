using System;
using System.Collections.Generic;
using System.Text;
using FluentValidator;
using FluentValidator.Validation;

namespace Ponto.Api.Dto
{
    public class FuncionarioDto : Notifiable
    {
        public string NomeCompleto { get; set; }
        public string Apelido { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Funcao { get; set; }

        public DateTime HorarioEntrada { get; set; }

        public DateTime HorarioSaida { get; set; }
        public string FormaContratacao { get; set; }
        public byte[] FotoData { get; set; }
        public string FotoFilename { get; set; }


        public bool isValid()
        {
            AddNotifications(new ValidationContract()
                .IsNotNullOrEmpty(NomeCompleto, "Nome", "Nome não pode ser nulo ou em branco")
                .HasMinLen(NomeCompleto, 2, "Nome", "Nome deve ter no mínimo 2 caracteres")
                .HasMaxLen(NomeCompleto, 150, "Nome", "Nome deve conter no máximo 150 caracteres")

                );

            return Valid;
        }

    }
}
