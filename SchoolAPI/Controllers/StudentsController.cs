using Microsoft.AspNetCore.Mvc;
using SchoolAPI.models;
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
            return Ok(_db.Students.ToList());
        }
        
        
        [HttpGet("{id}")]
        public ActionResult<Student> GetById(int id) { 
        var student = _db.Students.FirstOrDefault(s=> s.Id == id);
            if (student == null) return NotFound();
            
            return Ok(student);
        
        
        }
        [HttpPost]
        public ActionResult<Student> Create(Student student) {
           
            _db.Students.Add(student);
            _db.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id=student.Id},student);


        }
        [HttpPut("{id}")]
        public ActionResult Update(int id , Student updated)
        {
            var student = _db.Students.FirstOrDefault(s=> s.Id ==id);
            if (student == null) return NotFound();
            student.Name = updated.Name;
            student.Grade = updated.Grade;
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
