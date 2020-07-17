using Microsoft.EntityFrameworkCore;
using Ponto.Data.Context;
using Ponto.Domain.Interfaces;
using Ponto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ponto.Data.Repository
{
    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(PontoDBContext db): base(db)
        {

        }

        public async Task<Empresa> ObterEmpresaEndereco(Guid Id)
        {
            return await Db.Empresas.AsNoTracking()
                .Include(m => m.EnderecoEmpresa)
                .FirstOrDefaultAsync(m => m.Id == Id);
        }

    }
}
