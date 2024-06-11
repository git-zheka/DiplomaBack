using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VoloLearn.Models.Service;
using VoloLearn.Repository.Interfaces;
using VoloLearn.Services.Interfaces;

namespace VoloLearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolCourseController : ControllerBase
    {
        private readonly ISchoolCourseService _schoolCourseService;
        private readonly ISchoolCourseRepository _schoolCourseRepository;

        public SchoolCourseController(ISchoolCourseService schoolCourseService, ISchoolCourseRepository schoolCourseRepository)
        {
            _schoolCourseService = schoolCourseService;
            _schoolCourseRepository = schoolCourseRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CreateSchoolCourseModel model)
        {
            return Ok(await _schoolCourseService.CreateCourseAsync(model));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourse()
        {
            return Ok(await _schoolCourseRepository.GetAllAsync());
        }

    }


}
