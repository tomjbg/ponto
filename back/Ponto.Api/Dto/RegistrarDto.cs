using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ponto.Api.Dto
{
    public class RegistrarDto
    {
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage ="O campo {0} não está em um formato correto")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(150,ErrorMessage ="O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength =3)]
        public string Password { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(150, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string ConfirmPassword { get; set; }
    }
}
