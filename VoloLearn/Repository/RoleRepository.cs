using Microsoft.EntityFrameworkCore;
using VoloLearn.DataBase;
using VoloLearn.Models.Entities;
using VoloLearn.Repository.Interfaces;

namespace VoloLearn.Repository;

public class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    public RoleRepository(VoloLearnDbContext context) : base(context)
    {
    }

    public async Task<Role> GetByNameAsync(string name)
    {
        var result = await _context.Set<Role>().FirstOrDefaultAsync(item => item.Name.Equals(name));
        if (result is null) throw new Exception("Role not found");
        return result;
    }
}