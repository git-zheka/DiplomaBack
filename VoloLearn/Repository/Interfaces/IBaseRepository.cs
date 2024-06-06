using VoloLearn.Models.Entities;

namespace VoloLearn.Repository.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(Guid id);
    Task<Guid> CreateAsync(TEntity entity);
    Task DaleteAsync(Guid id);
    Task UpdateAsync(TEntity entity);
    Task SaveAsync();
}