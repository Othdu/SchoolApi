using Microsoft.AspNetCore.Mvc;
using SchoolAPI.DTOs;
using SchoolAPI.Services;

namespace SchoolAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly StudentService _service;

        public StudentsController(StudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<StudentResponseDto>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<StudentResponseDto> GetById(int id)
        {
            var student = _service.GetById(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public ActionResult<StudentResponseDto> Create(StudentDto dto)
        {
            var created = _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.id }, created);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, StudentDto dto)
        {
            if (!_service.Update(id, dto)) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (!_service.Delete(id)) return NotFound();
            return NoContent();
        }
    }
}