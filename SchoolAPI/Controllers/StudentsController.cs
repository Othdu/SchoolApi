using Microsoft.AspNetCore.Mvc;
using SchoolAPI.DTOs;
using SchoolAPI.models;

namespace SchoolAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController:ControllerBase

    {
        private readonly AppDbContext _db;
        public StudentsController(AppDbContext db)
        {
            _db = db;
        }
       
        
        [HttpGet]
        public ActionResult<List<Student>> GetAll()
        {
            var students = _db.Students
            .Select(s => new StudentResponseDto
             {
                 id = s.Id,
                 Name=s.Name,
                 Grade = s.Grade

             }).ToList();
            return Ok(students);
        }
        
        
        [HttpGet("{id}")]
        public ActionResult<Student> GetById(int id) { 
        var student = _db.Students.FirstOrDefault(s=> s.Id == id);
            if (student == null) return NotFound();
            
            return Ok(new StudentResponseDto
            {
                id = student.Id,
                Name = student.Name,
                Grade = student.Grade
            });
        
        
        }
        [HttpPost]
        public ActionResult<Student> Create(StudentDto dto) {

            var student = new Student
            {
                Name = dto.Name,
                Grade = dto.Grade
            };
            _db.Students.Add(student);
            _db.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id=student.Id},new StudentResponseDto
            {
                id=student.Id,
                Name=student.Name,
                Grade=student.Grade
            });


        }
        [HttpPut("{id}")]
        public ActionResult Update(int id , StudentDto dto)
        {
            var student = _db.Students.FirstOrDefault(s=> s.Id ==id);
            if (student == null) return NotFound();
            student.Name = dto.Name;
            student.Grade = dto.Grade;
            _db.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        
        public ActionResult Delete(int id) { 
        var student = _db.Students.FirstOrDefault(s => s.Id==id);
            if ( student == null) return NotFound();
            _db.Students.Remove(student);
            _db.SaveChanges();
            return NoContent();
        
        }



    }
}
