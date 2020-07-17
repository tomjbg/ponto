using Ponto.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ponto.Api.Dto
{
    public class UserDto : IUser
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [StringLength(150,ErrorMessage ="O campo {0} deve ter entre {2} e {1} caracteres",MinimumLength =3)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(150, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Password { get; set; }
    }
}
