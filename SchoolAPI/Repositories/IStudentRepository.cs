using SchoolAPI.models;

namespace SchoolAPI.Repositories
{
    public interface IStudentRepository
    {
        List<Student> GetAll();
        Student? GetById(int id);

        void Add(Student student);
        void Update(Student student);
        void Delete(Student student);
        void Save();
    }
}
