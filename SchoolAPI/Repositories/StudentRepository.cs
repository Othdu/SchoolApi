using Microsoft.EntityFrameworkCore;
using SchoolAPI.models;


namespace SchoolAPI.Repositories
{
    public class StudentRepository : IStudentRepository
    {

        private readonly AppDbContext _db;
        public StudentRepository(AppDbContext db) { _db = db; }

        public Student? GetById(int id) =>_db.Students.FirstOrDefault( s=> s.Id == id);

        public void Add(Student student)=> _db.Students.Add(student);
        public void Update(Student student)=> _db.Students.Update(student);
        public void Delete(Student student) => _db.Students.Remove(student);
        public void Save() => _db.SaveChanges();
    }
}
