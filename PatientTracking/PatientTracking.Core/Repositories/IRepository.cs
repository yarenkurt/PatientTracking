using PatientTracking.Core.Results;
using PatientTracking.Core.Signatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PatientTracking.Core.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : class, IBaseEntity, new()
    {
        /// <summary>
        /// To Table
        /// </summary>
        IQueryable<TEntity> Table { get; }

        /// <summary>
        /// To Table no tracking
        /// </summary>
        IQueryable<TEntity> TableNoTracking { get; }

        /// <summary>
        /// Get Entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(int id);

        /// <summary>
        /// Get Entity by predicate
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(Expression<Func<TEntity,bool>> filter);

        /// <summary>
        /// Insert Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<DataResult<TEntity>> InsertAsync(TEntity entity);

        /// <summary>
        /// Update Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<Result> UpdateAsync(TEntity entity);

        /// <summary>
        /// Delete Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<Result> DeleteAsync(TEntity entity);
    }
}
