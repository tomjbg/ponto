using Ponto.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ponto.Api.Dto
{
    public class EmpresaDto
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(250, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string RazaoSocial { get; set; }
        [MaxLength(250, ErrorMessage ="O campo {0} deve ter no máximo {1} caracteres")]
        public string NomeFantasia { get; set; }
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [MaxLength(14,ErrorMessage ="O campo {0} deve ter no máximo {1} caracteres")]
        public string CNPJ { get; set; }
        [MaxLength(14, ErrorMessage ="O campo {0} deve ter no máximo {1} caracteres")]
        public string IE { get; set; }
        [MaxLength(14, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string IM { get; set; }
        [MaxLength(250, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string RamoAtividade { get; set; }

        public EnderecoEmpresaDto EnderecoEmpresa { get; set; }
        public ICollection<FuncionarioDto> Funcionarios { get; set; }
    }
}
