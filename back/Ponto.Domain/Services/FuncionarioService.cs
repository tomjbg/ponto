using Ponto.Domain.Interfaces;
using Ponto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ponto.Domain.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly INotificador _notificador;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository, INotificador notificador)
        {
            _funcionarioRepository = funcionarioRepository;
            _notificador = notificador;
        }

        public async Task<bool> Adicionar(Funcionario funcionario)
        {
            if (funcionario.Invalid)
            {
                funcionario.Notifications.ToList().ForEach(n =>
                            _notificador.AddNotificacao(new Notificacoes.Notificacao(n.Message)));

                return false;
            }

            await _funcionarioRepository.Adicionar(funcionario);
            return true;
        }

        public async Task<bool> Atualizar(Funcionario funcionario)
        {
            if (funcionario.Invalid) return false;
            await _funcionarioRepository.Atualizar(funcionario);
            return true;
        }

        public async Task<bool> Deletar(Guid Id)
        {
            await _funcionarioRepository.Remover(Id);
            return true;
        }
    }
}
