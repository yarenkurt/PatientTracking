using Microsoft.EntityFrameworkCore;
using PatientTracking.Core.Results;
using PatientTracking.Core.Signatures;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PatientTracking.Core.Repositories.EF
{
    public class EfRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IBaseEntity, new()
        where TContext : DbContext
    {

        private readonly TContext _context;
        public DbSet<TEntity> _entities;
        public EfRepository(TContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }
        protected virtual DbSet<TEntity> Entities => _entities ??= _context.Set<TEntity>();

        public IQueryable<TEntity> Table => Entities;

        public IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();



        public async Task<TEntity> GetAsync(int id)
        {
            var entity = await Entities.FindAsync(id);
            if (entity != null) _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter) => await TableNoTracking.FirstOrDefaultAsync(filter);



        public async Task<DataResult<TEntity>> InsertAsync(TEntity entity)
        {
            if (entity == null) return new ErrorDataResult<TEntity>("Data is not found.");

            try
            {
                await Entities.AddAsync(entity);
                await _context.SaveChangesAsync();
                return new SuccessDataResult<TEntity>(entity);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<TEntity>($"{ex.Message}\n{ex.InnerException}");
            }
        }

        public async Task<Result> UpdateAsync(TEntity entity)
        {
            if (entity == null) return new ErrorResult("Data is not found.");
            try
            {
                Entities.Update(entity);
                await _context.SaveChangesAsync();
                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ErrorResult($"{ex.Message}\n{ex.InnerException}");
            }
        }

        public async Task<Result> DeleteAsync(TEntity entity)
        {
            if (entity == null) return new ErrorResult("Data is not found.");
            try
            {
                Entities.Remove(entity);
                await _context.SaveChangesAsync();
                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ErrorResult($"{ex.Message}\n{ex.InnerException}");
            }
        }
    }
}
