﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ponto.Api.Dto
{
    public class EnderecoEmpresaDto
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
    }
}
