using VoloLearn.Models.Entities;

namespace VoloLearn.Repository.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<bool> IsUserExistsByEmailAsync(string email);
    Task<Guid> CreateUserAsync(User user, string password, string roleName);
    Task SetUserRoleAsync(Guid id, string roleName);
    Task<bool> CheckUserPasswordAsync(string email, string password);
    Task<User> GetUserByEmail(string email);
}