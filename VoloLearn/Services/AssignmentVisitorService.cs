using VoloLearn.Models.Entities;
using VoloLearn.Repository.Interfaces;
using VoloLearn.Services.Interfaces;

namespace VoloLearn.Services
{
    public class AssignmentVisitorService : IAssignmentVisitorService
    {

        private readonly IAssignmentVisitorReposetory _assignmentVisitorReposetory;
        public AssignmentVisitorService(IAssignmentVisitorReposetory assignmentVisitorReposetory) 
        {
            _assignmentVisitorReposetory = assignmentVisitorReposetory;
        }

        
    }
}
