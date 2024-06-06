using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VoloLearn.Models.Entities;
using VoloLearn.Models.Service;
using VoloLearn.Repository.Interfaces;
using VoloLearn.Services.Interfaces;

namespace VoloLearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssigmmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;
        private readonly IAssignmentRepository _assignmentRepository;

        public AssigmmentController(IAssignmentService assignmentService, IAssignmentRepository assignmentRepository)
        {
            _assignmentService = assignmentService;
            _assignmentRepository = assignmentRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAssignment()
        {
            return Ok(await _assignmentRepository.GetAllAsync());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAssignment([FromBody] CreateAssignmentModel model)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _assignmentService.CreateAssignmentAsync(model);

            return Ok();
        }
    }
}
