using System.ComponentModel.DataAnnotations;

namespace EnergyMonitoringAPI.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username é obrigatório")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password é obrigatório")]
        public string Password { get; set; } = string.Empty;
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Username é obrigatório")]
        [MinLength(3, ErrorMessage = "Username deve ter ao menos 3 caracteres")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password é obrigatório")]
        [MinLength(6, ErrorMessage = "Password deve ter ao menos 6 caracteres")]
        public string Password { get; set; } = string.Empty;
    }

    public class TokenResponseViewModel
    {
        public string Token { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}