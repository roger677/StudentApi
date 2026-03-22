using System.ComponentModel.DataAnnotations;

namespace StudentApi.Service.Dtos
{
    public class CreateStudentDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Range(1, 120, ErrorMessage = "Edad inválida")]
        public int Age { get; set; }
    }
}