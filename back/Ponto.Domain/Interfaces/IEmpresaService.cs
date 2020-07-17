using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ponto.Domain.Models;

namespace Ponto.Domain.Interfaces
{
    public interface IEmpresaService : IDisposable
    {
        Task<bool> Adicionar(Empresa empresa);
        Task<bool> Atualizar(Empresa empresa);
        Task<bool> Remover(Guid Id);
    }
}
