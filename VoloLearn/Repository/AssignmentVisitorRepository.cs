using Microsoft.EntityFrameworkCore;
using VoloLearn.DataBase;
using VoloLearn.Models.Entities;
using VoloLearn.Models.Enum;
using VoloLearn.Repository.Interfaces;

namespace VoloLearn.Repository;
public class AssignmentVisitorRepository : BaseRepository<AssignmentVisitor>, IAssignmentVisitorRepository
{
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly IUserRepository _userRepository;

    public AssignmentVisitorRepository(VoloLearnDbContext context, IAssignmentRepository assignmentRepository,
        IUserRepository userRepository) : base(context)
    {
        _assignmentRepository = assignmentRepository;
        _userRepository = userRepository;
    }

    public async Task ChangeStatusAsync(Guid assignmentId, Guid userId, AssignmentVisitStatus status)
    {
        var founded =
            await _context.AssignmentVisitors
                .Include(assignmentVisitor => assignmentVisitor.User)
                .Include(assignmentVisitor => assignmentVisitor.Assignment)
                .FirstOrDefaultAsync(x =>
                x.Assignment.Id == assignmentId && x.User.Id == userId);
        if (founded == null) throw new Exception("Visit not founded");
        founded.Status = status;
        await UpdateAsync(founded);
       await SaveAsync();
    }

    public async Task<List<Assignment>> GetUsersVisitsAsync(Guid userId)
    {
        var foundedFisits = await _context.AssignmentVisitors
            .Include(assignmentVisitor => assignmentVisitor.Assignment)
            .Include(assignmentVisitor => assignmentVisitor.User)
            .Where(x => x.User.Id == userId)
            .Select(x => x.Assignment).ToListAsync();

        return foundedFisits;
    }

    public async Task<List<User>> GetAssignmentVisitorsAsync(Guid assignmentId)
    {
        var foundedFisits = await _context.AssignmentVisitors
            .Include(assignmentVisitor => assignmentVisitor.Assignment)
            .Include(assignmentVisitor => assignmentVisitor.User)
            .Where(x => x.Assignment.Id == assignmentId)
            .Select(x => x.User).ToListAsync();
        return foundedFisits;
    }

    public async Task<int> CalculateUserScoreAsync(Guid userId)
    {
        var founded = await _userRepository.GetByIdAsync(userId);
        var visits = await _context.AssignmentVisitors
            .Include(assignmentVisitor => assignmentVisitor.Assignment)
            .Include(assignmentVisitor => assignmentVisitor.User)
            .Where(x => x.User.Id == userId && x.Status == AssignmentVisitStatus.Visited)
            .ToListAsync();

        var result = visits.Sum(x => x.Assignment.Reward);

        return result;
    }

    public async Task<Guid> CreateVisitAsync(Guid assignmentId, Guid userId)
    {
        var checkUser = await _userRepository.GetByIdAsync(userId);
        var checkAssinment = await _assignmentRepository.GetByIdAsync(assignmentId);
        var assignmentVisitor = new AssignmentVisitor { AssignmentId = checkAssinment.Id, UserId = checkUser.Id, VisitDate = DateTime.Now };
        
        var result = await CreateAsync(assignmentVisitor);
        await SaveAsync();
        return result;
    }
}