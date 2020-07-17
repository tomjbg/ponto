using Ponto.Data.Context;
using Ponto.Domain.Interfaces;
using Ponto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ponto.Data.Repository
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(PontoDBContext db) : base(db)
        {
        }

               
    }
}
