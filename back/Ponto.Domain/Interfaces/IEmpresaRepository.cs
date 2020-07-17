using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ponto.Domain.Models;

namespace Ponto.Domain.Interfaces
{
    public interface IEmpresaRepository : IRepository<Empresa>
    {
        Task<Empresa> ObterEmpresaEndereco(Guid Id);

    }
}
