using Microsoft.EntityFrameworkCore;
using VoloLearn.DataBase;
using VoloLearn.Models.Entities;
using VoloLearn.Repository.Interfaces;

namespace VoloLearn.Repository
{
    public abstract class BaseRepository <TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntiti 
    {
        protected readonly VoloLearnDbContext _context;

        public BaseRepository(VoloLearnDbContext context)
        {
            _context = context;

        }

        public async virtual Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async virtual Task<TEntity> GetByIdAsync(Guid id)
        {
            var result = await _context.Set<TEntity>().FirstOrDefaultAsync(item => item.Id.Equals(id));

            if (result is null)
            {
                throw new Exception("Object not found");
            }
            return result;
        }

        public async virtual Task<Guid> CreateAsync(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedDate = DateTime.Now;

            var createdEntity = await _context.Set<TEntity>().AddAsync(entity);

            return createdEntity.Entity.Id;
        }

        public async virtual Task DaleteAsync(Guid id)
        {
            var result = await _context.Set<TEntity>().FirstOrDefaultAsync(item => item.Id.Equals(id));

            if (result is null)
            {
                return ;
            }

            _context.Set<TEntity>().Remove(result);
        }

        public async virtual Task UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async virtual Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
