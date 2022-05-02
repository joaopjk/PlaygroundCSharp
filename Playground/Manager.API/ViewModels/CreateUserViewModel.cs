using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "O nome não pode ser nula!")]
        [MinLength(3, ErrorMessage = "O nome deve conter ao menos 3 caracteres.")]
        [MaxLength(80, ErrorMessage = "O nome deve conter ao máximo 80 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O email não pode ser nulo!")]
        [EmailAddress(ErrorMessage = "O campo email é inválido!")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            ErrorMessage = "O campo email é inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo password não pode ser nulo!")]
        [MinLength(3, ErrorMessage = "O password deve conter ao menos 3 caracteres.")]
        [MaxLength(80, ErrorMessage = "O password deve conter ao máximo 80 caracteres.")]
        public string Password { get; set; }
    }
}
