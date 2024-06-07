using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VoloLearn.Repository.Interfaces;

namespace VoloLearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolCourseController : ControllerBase
    {
        private readonly ISchoolCourseRepository _schoolCourseRepository;

        public SchoolCourseController(ISchoolCourseRepository schoolCourseRepository)
        {
            _schoolCourseRepository = schoolCourseRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("getallCourse")]
        public async Task<IActionResult> GetAllCourse()
        {
            return Ok(await _schoolCourseRepository.GetAllAsync());
        }

    }


}
