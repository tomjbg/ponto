using System;
using System.Collections.Generic;
using System.Text;
using Ponto.Domain.Models;
using Ponto.Domain.Interfaces;
using System.Threading.Tasks;
using Ponto.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Ponto.Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : Entity, new()
    {
        protected readonly PontoDBContext Db;
        protected readonly DbSet<T> DbSet;

        protected Repository(PontoDBContext db)
        {
            Db = db;
            DbSet = db.Set<T>();
        }

        public async Task Adicionar(T entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public async Task Atualizar(T entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public async Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        

        public async Task<T> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }


        public async Task Remover(Guid id)
        {
            DbSet.Remove(new T { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }

        public async Task<IList<T>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }
    }
}
