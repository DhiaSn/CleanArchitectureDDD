using CleanArchitectureDDD.Core.Common;
using CleanArchitectureDDD.Core.Interfaces;
using CleanArchitectureDDD.Core.Specifications;
using CleanArchitectureDDD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureDDD.Infrastructure.Repositories
{
    public class GenericRepository<T>(AppDbContext dbContext) : IGenericRepository<T> where T : BaseEntity
    {
        #region Local Variables 
        private readonly AppDbContext _dbContext = dbContext;
        #endregion

        #region CRUD

        #region GetAsync

        #region GetAllAsync
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
        public async Task<IReadOnlyList<T>> GetAllAsync(ISpecifications<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }
        #endregion

        #region GetByIdAsync
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByIdAsync(ISpecifications<T> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }
        #endregion

        #endregion

        #region AddAsync
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        #endregion

        #region UpdateAsync
        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        #endregion

        #region DeleteAsync
        public virtual async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity); 
            await _dbContext.SaveChangesAsync();
        }
        #endregion

        #region CountAsync
        public async Task<int> CountAsync(ISpecifications<T> specifications)
        {
            return await ApplySpecification(specifications).CountAsync();
        }
        #endregion

        #endregion

        #region ApplySpecification
        private IQueryable<T> ApplySpecification(ISpecifications<T> specifications)
        {
            return SpecificationEvaluatOr<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), specifications);
        }
        #endregion
    }
}
