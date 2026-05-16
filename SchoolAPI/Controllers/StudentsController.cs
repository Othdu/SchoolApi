using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.DTOs;
using SchoolAPI.models;


namespace SchoolAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public StudentsController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<StudentResponseDto>> GetAll()
        {
            var students = _db.Students.ToList();
            return Ok(_mapper.Map<List<StudentResponseDto>>(students));
        }

        [HttpGet("{id}")]
        public ActionResult<StudentResponseDto> GetById(int id)
        {
            var student = _db.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            return Ok(_mapper.Map<StudentResponseDto>(student));
        }

        [HttpPost]
        public ActionResult<StudentResponseDto> Create(StudentDto dto)
        {
            var student = _mapper.Map<Student>(dto);
            _db.Students.Add(student);
            _db.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, _mapper.Map<StudentResponseDto>(student));
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, StudentDto dto)
        {
            var student = _db.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            _mapper.Map(dto, student);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var student = _db.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            _db.Students.Remove(student);
            _db.SaveChanges();
            return NoContent();
        }
    }
}