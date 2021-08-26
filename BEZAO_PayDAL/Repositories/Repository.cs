using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BEZAO_PayDAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BEZAO_PayDAL.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private DbSet<TEntity> _entity;
        public Repository(DbContext context)
        {
            _context = context;
            this._entity = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
          return _entity.AsQueryable();
        }


        public TEntity Get(int id)
        {
            return _entity.Find(id);
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _entity.FindAsync(id);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entity.Where(predicate).AsQueryable();
        }

        public void Add(TEntity entity)
        {
            _entity.Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
             await _entity.AddAsync(entity);
        }

        public void AddRange(IList<TEntity> entities)
        {
            _entity.AddRange(entities);
        }

        public async Task AddRangeAsync(IList<TEntity> entities)
        {
            await _entity.AddRangeAsync(entities);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _entity.Remove(entity);
        }

        public void DeleteRange(IList<TEntity> entities)
        {
            _entity.RemoveRange(entities);
        }
    }
}
