using Microsoft.AspNetCore.Mvc;
using Szkola.BLL.Interfaces.Class;
using Szkola.DAL.Entities;

namespace Szkola.API.Controllers.Class
{
    [Route("api/classes")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassesController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClassEntity>>> GetClasses()
        {
            var classes = await _classService.GetClasses();
            return Ok(classes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClassEntity>> GetClass(Guid id)
        {
            var @class = await _classService.GetClass(id);
            if (@class == null)
            {
                return NotFound("Class not found");
            }
            return Ok(@class);
        }

        [HttpPost]
        public async Task<ActionResult<ClassEntity>> CreateClass(ClassEntity @class)
        {
            try
            {
                var createdClass = await _classService.CreateClass(@class);
                return CreatedAtAction("GetClass", new { id = createdClass.ClassId }, createdClass);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateClass(Guid id, ClassEntity @class)
        {
            try
            {
                await _classService.UpdateClass(id, @class);
                return Ok("Class updated successfully");
            }
            catch (ArgumentException)
            {
                return BadRequest("Invalid class ID");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating class: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteClass(Guid id)
        {
            try
            {
                await _classService.DeleteClass(id);
                return Ok("Class deleted successfully");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Class not found");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting class: {ex.Message}");
            }
        }
    }

}
