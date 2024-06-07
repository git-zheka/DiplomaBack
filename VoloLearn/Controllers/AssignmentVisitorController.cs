using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VoloLearn.Models.Enum;
using VoloLearn.Repository.Interfaces;
using VoloLearn.Services.Interfaces;

namespace VoloLearn.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AssignmentVisitorController : ControllerBase
{

        private readonly IAssignmentVisitorRepository _assignmentvisitorReposetory;
        private readonly IAssignmentVisitorService _assignmentVisitorService;

        public AssignmentVisitorController(IAssignmentVisitorRepository assignmentvisitorReposetory, IAssignmentVisitorService assignmentVisitorService)
        {
            _assignmentvisitorReposetory = assignmentvisitorReposetory;
            _assignmentVisitorService = assignmentVisitorService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("uservisits")]

        public async Task<IActionResult> GetUsersVisits(Guid userId)
        {
           return Ok(await _assignmentvisitorReposetory.GetUsersVisitsAsync(userId));
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("assignmentvisits")]
        public async Task<IActionResult> GetAssignmentVisitors(Guid assignmentid)
        {
            return Ok(await _assignmentvisitorReposetory.GetAssignmentVisitorsAsync(assignmentid));
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("score")]
        public async Task<IActionResult> GetScore(Guid userid)
        {
            return Ok(await _assignmentvisitorReposetory.CalculateUserScoreAsync(userid));
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("changestatus")]
        public async Task<IActionResult> ChangeStatus(Guid assignmentId, Guid userId, AssignmentVisitStatus status)
        {
            await _assignmentvisitorReposetory.ChangeStatusAsync(assignmentId, userId, status);
            return NoContent();
        }
}