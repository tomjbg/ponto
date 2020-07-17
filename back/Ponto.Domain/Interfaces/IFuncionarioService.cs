using Ponto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ponto.Domain.Interfaces
{
    public interface IFuncionarioService
    {
        Task<bool> Adicionar(Funcionario funcionario);
        Task<bool> Atualizar(Funcionario funcionario);
        Task<bool> Deletar(Guid Id);
    }
}
