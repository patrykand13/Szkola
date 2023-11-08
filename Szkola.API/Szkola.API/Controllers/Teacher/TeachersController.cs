using Microsoft.AspNetCore.Mvc;
using Szkola.BLL.Interfaces.Teacher;
using Szkola.DAL.Entities;

namespace Szkola.API.Controllers.Teacher
{
    [Route("api/teachers")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TeacherEntity>>> GetTeachers()
        {
            var teachers = await _teacherService.GetTeachers();
            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherEntity>> GetTeacher(Guid id)
        {
            var teacher = await _teacherService.GetTeacher(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }
        [HttpGet("byMinYearsOfWork/{minYearsOfWork}")]
        public async Task<ActionResult<List<TeacherEntity>>> GetTeachersByMinYearsOfWork(int minYearsOfWork)
        {
            var teachers = await _teacherService.GetTeachersByMinYearsOfWork(minYearsOfWork);
            return Ok(teachers);
        }

        [HttpPost]
        public async Task<ActionResult<TeacherEntity>> CreateTeacher(TeacherEntity teacher)
        {
            var createdTeacher = await _teacherService.CreateTeacher(teacher);
            return CreatedAtAction("GetTeacher", new { id = createdTeacher.TeacherId }, createdTeacher);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(Guid id, TeacherEntity teacher)
        {
            try
            {
                await _teacherService.UpdateTeacher(id, teacher);
                return Ok("Teacher updated successfully");
            }
            catch (ArgumentException)
            {
                return BadRequest("Invalid teacher ID");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating teacher: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(Guid id)
        {
            try
            {
                await _teacherService.DeleteTeacher(id);
                return Ok("Teacher deleted successfully");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Teacher not found");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting teacher: {ex.Message}");
            }
        }

    }
}
