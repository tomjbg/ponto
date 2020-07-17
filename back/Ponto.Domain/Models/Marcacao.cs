using System;
using System.Collections.Generic;
using System.Text;

namespace Ponto.Domain.Models
{
    public class Marcacao : Entity
    {
        public Marcacao(DateTime entrada, DateTime saidaAlmoco, DateTime retornoAlmoco, DateTime saida)
        {
            Entrada = entrada;
            SaidaAlmoco = saidaAlmoco;
            RetornoAlmoco = retornoAlmoco;
            Saida = saida;
        }

        public DateTime Entrada { get; private set; }
        public DateTime SaidaAlmoco { get; private set; }
        public DateTime RetornoAlmoco { get; private set; }
        public DateTime Saida { get; private set; }
    }
}
