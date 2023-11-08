using Microsoft.AspNetCore.Mvc;
using Szkola.BLL.Interfaces.Student;
using Szkola.DAL.Entities;

namespace Szkola.API.Controllers.Student
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentEntity>>> GetStudents()
        {
            var students = await _studentService.GetStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentEntity>> GetStudent(Guid id)
        {
            var student = await _studentService.GetStudent(id);
            if (student == null)
            {
                return NotFound("Student not found");
            }
            return Ok(student);
        }
        [HttpGet("byFirstName/{firstName}")]
        public async Task<ActionResult<List<StudentEntity>>> GetStudentsByFirstName(string firstName)
        {
            var students = await _studentService.GetStudentsByFirstName(firstName);

            if (students == null || !students.Any())
            {
                return NotFound("No students found");
            }

            return Ok(students);
        }

        [HttpPost]
        public async Task<ActionResult<StudentEntity>> CreateStudent(StudentEntity student)
        {
            try
            {
                var createdStudent = await _studentService.CreateStudent(student);
                return CreatedAtAction("GetStudent", new { id = createdStudent.StudentId }, createdStudent);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateStudent(Guid id, StudentEntity student)
        {
            try
            {
                await _studentService.UpdateStudent(id, student);
                return Ok("Student updated successfully");
            }
            catch (ArgumentException)
            {
                return BadRequest("Invalid student ID");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating student: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteStudent(Guid id)
        {
            try
            {
                await _studentService.DeleteStudent(id);
                return Ok("Student deleted successfully");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Student not found");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting student: {ex.Message}");
            }
        }
    }
}
