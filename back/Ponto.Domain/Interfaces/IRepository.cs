using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ponto.Domain.Interfaces
{
    public interface IRepository<T> : IDisposable where T : Models.Entity
    {
        Task Adicionar(T entity);
        Task<T> ObterPorId(Guid id);
        Task<IList<T>> ObterTodos();
        Task Atualizar(T entity);
        Task Remover(Guid id);
        Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate);
        Task<int> SaveChanges();
    }
}
