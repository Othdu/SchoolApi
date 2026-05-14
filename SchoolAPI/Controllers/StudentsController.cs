using Microsoft.AspNetCore.Mvc;
using SchoolAPI.models;
using SchoolAPI.models;

namespace SchoolAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController:ControllerBase

    {
        private static List<Student> _students = new List<Student>
        {new Student {Id=1,Name="mohamed",Grade=99.3},
        new Student {Id=2 , Name="Nada",Grade= 98.9}
        };
       
        
        [HttpGet]
        public ActionResult<List<Student>> GetAll()
        {
            return Ok(_students);
        }
        
        
        [HttpGet("{id}")]
        public ActionResult<Student> GetById(int id) { 
        var student = _students.FirstOrDefault(s=> s.Id == id);
            if (student == null) return NotFound();
            
            return Ok(student);
        
        
        }
        [HttpPost]
        public ActionResult<Student> Create(Student student) {
            student.Id = _students.Count + 1;
            _students.Add(student);
            return CreatedAtAction(nameof(GetById), new {id=student.Id},student);


        }
        [HttpPut("{id}")]
        public ActionResult Update(int id , Student updated)
        {
            var student = _students.FirstOrDefault(s=> s.Id ==id);
            if (student == null) return NotFound();
            student.Name = updated.Name;
            student.Grade = updated.Grade;
            return NoContent();
        }
        [HttpDelete("{id}")]
        
        public ActionResult Delete(int id) { 
        var student = _students.FirstOrDefault(s => s.Id==id);
            if ( student == null) return NotFound();
            _students.Remove(student);  
            return NoContent();
        
        }



    }
}
