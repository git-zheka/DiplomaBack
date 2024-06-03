using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using VoloLearn.Constants;
using VoloLearn.DataBase;
using VoloLearn.Models.Entities;
using VoloLearn.Repository.Interfaces;

namespace VoloLearn.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IRoleRepository _roleRepository;
        
        public UserRepository(VoloLearnDbContext context, IConfiguration configuration, IRoleRepository roleRepository) : base(context)
        {
            _configuration = configuration;
            _roleRepository = roleRepository;
        }

        public async Task ProcessPaswordAsync (string password, User user)
        {
            user.PasswordHash = await CreatePasswordHash(password);

            await UpdateAsync (user);
            await SaveAsync();
        }

        public async Task<Guid> CreateUserAsync(User user, string password)
        {
            user.PasswordHash = await CreatePasswordHash(password);
            user.Role = await _roleRepository.GetByNameAsync(DefaultRoleName.VolonteerName);
            return await CreateAsync (user);
        }

        private async Task<string> CreatePasswordHash(string password)
        {
            var secret = _configuration.GetValue<string>("SecretString");

            byte[] secretbytes = new System.Text.UTF8Encoding().GetBytes(secret);
            var sha256 = new HMACSHA256(secretbytes);

            byte[] passwortBytes = new System.Text.UTF8Encoding().GetBytes(password);

            var hashBytes = sha256.ComputeHash(passwortBytes);

            var passwordHash = string.Empty;

            for (int i = 0; i < hashBytes.Length; i++)
            {
                passwordHash += hashBytes[i].ToString("X2");
            }

            return passwordHash;
        }


        public async Task SetUserRoleAsync(Guid id, string roleName)
        {
            var foundeduser = await _context.Users.FindAsync(id);
            if (foundeduser is null) 
            {
                throw new Exception("User not founded");
            }
            foundeduser.Role = await _roleRepository.GetByNameAsync(roleName);
            await SaveAsync();
        } 

        public async Task<bool> IsUserExistsByEmailAsync(string email)
        {
            return await _context.Users.AnyAsync(x => x.Email == email);
        }

        public async Task<bool> CheckUserPasswordAsync(string email, string password)
        {
            var foundedUser = await _context.Users.FirstOrDefaultAsync(user=> user.Email == email);
            if (foundedUser is null)
            {
                throw new Exception("Email is not founded");
            }

            var passwordHash = await CreatePasswordHash(password);

            return passwordHash == foundedUser.PasswordHash;
        }
    }
}
