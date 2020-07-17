using Ponto.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ponto.Domain.Notificacoes
{
    public class Notificador : INotificador
    {
        private List<Notificacao> _notificacoes;

        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }

        public void AddNotificacao(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public void AddNotificacoes(List<Notificacao> notificacoes)
        {
            _notificacoes.AddRange(notificacoes);
        }


        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public bool TemNotificacoes()
        {
            return _notificacoes.Any();
        }
    }
}
