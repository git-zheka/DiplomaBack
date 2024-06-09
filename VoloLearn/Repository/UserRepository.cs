using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using VoloLearn.Constants;
using VoloLearn.DataBase;
using VoloLearn.Models.Entities;
using VoloLearn.Repository.Interfaces;

namespace VoloLearn.Repository;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly IConfiguration _configuration;
    private readonly IRoleRepository _roleRepository;

    public UserRepository(VoloLearnDbContext context, IConfiguration configuration, IRoleRepository roleRepository) :
        base(context)
    {
        _configuration = configuration;
        _roleRepository = roleRepository;
    }

    public async Task<Guid> CreateUserAsync(User user, string password)
    {
        user.PasswordHash = await CreatePasswordHash(password);
        var role = await _roleRepository.GetByNameAsync(DefaultRoleName.VolonteerName);
        user.RoleId = role.Id;
        var result = await CreateAsync(user);
        await SaveAsync();

        return result;
    }


    public async Task SetUserRoleAsync(Guid id, string roleName)
    {
        var foundeduser = await _context.Users.FirstOrDefaultAsync(item => item.Id == id);
        if (foundeduser is null) throw new Exception("User not founded");
        foundeduser.Role = await _roleRepository.GetByNameAsync(roleName);
        foundeduser.RoleId = foundeduser.Role.Id;

        await UpdateAsync(foundeduser);
        await SaveAsync();
    }

    public async Task<bool> IsUserExistsByEmailAsync(string email)
    {
        return await _context.Users.AnyAsync(x => x.Email == email);
    }

    public async Task<bool> CheckUserPasswordAsync(string email, string password)
    {
        var foundedUser = await _context.Users.FirstOrDefaultAsync(user => user.Email == email);
        if (foundedUser is null) throw new Exception("Email is not founded");

        var passwordHash = await CreatePasswordHash(password);

        return passwordHash == foundedUser.PasswordHash;
    }

    public async Task ProcessPasswordAsync(string password, User user)
    {
        user.PasswordHash = await CreatePasswordHash(password);

        await UpdateAsync(user);
        await SaveAsync();
    }

    private async Task<string> CreatePasswordHash(string password)
    {
        var secret = _configuration.GetValue<string>("SecretString");

        var secretes = new UTF8Encoding().GetBytes(secret);
        var sha256 = new HMACSHA256(secretes);

        var passwordBytes = new UTF8Encoding().GetBytes(password);

        var hashBytes = sha256.ComputeHash(passwordBytes);

        return hashBytes.Aggregate(string.Empty, (current, t) => current + t.ToString("X2"));
    }
}