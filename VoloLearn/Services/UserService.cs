using VoloLearn.Models.Entities;
using VoloLearn.Models.Service;
using VoloLearn.Repository.Interfaces;
using VoloLearn.Services.Interfaces;

namespace VoloLearn.Services;

public class UserService : IUserService
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }

    public async Task<Guid> CreateNewUserAsync(CreateUserModel model)
    {
        if (await _userRepository.IsUserExistsByEmailAsync(model.Email)) throw new Exception("Email already exists");

        var user = new User();

        user.FullName = model.FullName;
        user.Email = model.Email;
        user.Phone = model.Phone;

        var resulId = await _userRepository.CreateUserAsync(user, model.Password);

        await _roleRepository.GetByNameAsync(model.RoleName);

        await _userRepository.SetUserRoleAsync(resulId, model.RoleName);

        return resulId;
    }

    public async Task LoginAsync(LoginModel model)
    {
        if (!await _userRepository.IsUserExistsByEmailAsync(model.Email)) throw new Exception("Email not founded");

        if (!await _userRepository.CheckUserPasswordAsync(model.Email, model.Password))
            throw new Exception("Password is not walid");
    }
}