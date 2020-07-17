﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ponto.Api.Dto
{
    public class LoginDto
    {
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage ="O campo {0} está em formato inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [StringLength(150, ErrorMessage ="O campo {0} precisa ter entre {2} e {1} caracteres",MinimumLength =3)]
        public string Password { get; set; }
    }
}
