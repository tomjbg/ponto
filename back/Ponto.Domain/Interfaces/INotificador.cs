using Ponto.Domain.Notificacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ponto.Domain.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacoes();
        List<Notificacao> ObterNotificacoes();
        void AddNotificacao(Notificacao notificacao);
        void AddNotificacoes(List<Notificacao> notificacoes);
    }
}
