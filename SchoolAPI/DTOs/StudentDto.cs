using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.DTOs
{
    public class StudentDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
        public string? Name { get; set; }

        [Range(0, 100, ErrorMessage = "Grade must be between 0 and 100")]
        public double Grade { get; set; }
    }

    public class StudentResponseDto
    {
        public int id {  get; set; }
        public String? Name { get; set; }
        public double Grade { get; set; }
    }

}
