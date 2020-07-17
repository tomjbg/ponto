using System;
using System.Collections.Generic;
using System.Text;

namespace Ponto.Domain.Models
{
    public class EnderecoEmpresa: Endereco
    {
        public Guid EmpresaId { get; private set; }
        public virtual Empresa Empresa { get; private set; }
    }
}
