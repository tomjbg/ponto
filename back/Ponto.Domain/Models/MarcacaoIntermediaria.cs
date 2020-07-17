using System;
using System.Collections.Generic;
using System.Text;

namespace Ponto.Domain.Models
{
    public class MarcacaoIntermediaria : Entity
    {
        public MarcacaoIntermediaria(DateTime saida, DateTime retorno)
        {
            Saida = saida;
            Retorno = retorno;
        }

        public DateTime Saida { get; private set; }
        public DateTime Retorno { get; private set; }
        

    }
}
