namespace SchoolAPI.DTOs
{
    public class StudentDto
    {
        public string? Name { get; set; }
        public double Grade { get; set; }
    }
    public class StudentResponseDto
    {
        public int id {  get; set; }
        public String? Name { get; set; }
        public double Grade { get; set; }
    }

}
