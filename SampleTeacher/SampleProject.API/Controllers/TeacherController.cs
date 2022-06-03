using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Business.Service;
using SampleProject.Entity.Entity;

namespace SampleProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        TeacherService _teacherService;

        public TeacherController(TeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet("fetchteacher")]
        public IActionResult fetchTeachers()
        {
            return Ok(_teacherService.fetchTeachers());
        }

        [HttpPost("addteacher")]
        public IActionResult AddTeacher(TeacherModel teacherModel)
        {
            return Ok(_teacherService.AddTeacher(teacherModel));
        }
    }
}
