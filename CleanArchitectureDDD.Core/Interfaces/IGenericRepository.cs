using CleanArchitectureDDD.Core.Common;
using CleanArchitectureDDD.Core.Specifications;
using System;

namespace CleanArchitectureDDD.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(ISpecifications<T> specification);
        Task<IReadOnlyList<T>> GetAllAsync(ISpecifications<T> specification);
        Task<int> CountAsync(ISpecifications<T> specifications);

        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
