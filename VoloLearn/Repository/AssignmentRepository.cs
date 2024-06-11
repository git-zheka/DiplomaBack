using VoloLearn.Constants;
using VoloLearn.DataBase;
using VoloLearn.Models.Entities;
using VoloLearn.Repository.Interfaces;

namespace VoloLearn.Repository;

public class AssignmentRepository : BaseRepository<Assignment>, IAssignmentRepository
{
    private readonly IRoleRepository _roleRepository;

    private readonly IUserRepository _userRepository;

    public AssignmentRepository(VoloLearnDbContext context, IUserRepository userRepository,
        IRoleRepository roleRepository) : base(context)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }

    public async Task<Guid> CreateAssignmentAsync(Guid userid, Assignment assignment)
    {
        var founded = await _userRepository.GetByIdAsync(userid);
        var organisationRole = await _roleRepository.GetByNameAsync(DefaultRoleName.OrganisationName);

        if (founded.RoleId != organisationRole.Id) throw new Exception("You can't create Assigment");

        assignment.CreatedById = founded.Id;
        var result = await CreateAsync(assignment);
        await SaveAsync();

        return result;
    }
}