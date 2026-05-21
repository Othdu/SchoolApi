using AutoMapper;
using SchoolAPI.DTOs;
using SchoolAPI.models;
using SchoolAPI.Repositories;

namespace SchoolAPI.Services
{
    public class StudentService
    {
        private readonly IStudentRepository _repo;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository repo, IMapper mapper)
        {
            _repo = repo;
         
            _mapper = mapper;
        }

        public List<StudentResponseDto> GetAll()
        {
            var students = _repo.GetAll();
            return _mapper.Map<List<StudentResponseDto>>(students);
        }

        public StudentResponseDto? GetById(int id)
        {
            var student = _repo.GetById(id);
            if (student == null) return null;
            return _mapper.Map<StudentResponseDto>(student);

        }

        public StudentResponseDto Create(StudentDto dto)
        {
            var student = _mapper.Map<Student>(dto);
            _repo.Add(student);
            _repo.Save();
            return _mapper.Map<StudentResponseDto>(student);
        }
        public bool Update(int id, StudentDto dto)
        {
            var student = _repo.GetById(id);  // find existing student
            if (student == null) return false; // not found — return false
            _mapper.Map(dto, student);         // copy new values into existing student
            _repo.Save();                      // save changes
            return true;                       // success
        }

        public bool Delete(int id)
        {
            var student = _repo.GetById(id);   // find it
            if (student == null) return false; // not found
            _repo.Delete(student);             // tell repo to remove it
            _repo.Save();                      // save
            return true;
        }
    }
}
