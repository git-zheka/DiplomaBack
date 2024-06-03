using VoloLearn.Models.Service;

namespace VoloLearn.Services.Interfaces
{
    public interface IUserService
    {
        Task<Guid> CreateNewUserAsync(CreateUserModel model);
        Task LoginAsync(LoginModel model);
    }
}
