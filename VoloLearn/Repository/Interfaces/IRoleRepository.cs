using VoloLearn.Models.Entities;

namespace VoloLearn.Repository.Interfaces;

public interface IRoleRepository : IBaseRepository<Role>
{
    Task<Role> GetByNameAsync(string name);
}