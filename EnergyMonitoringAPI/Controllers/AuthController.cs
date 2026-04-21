using Microsoft.AspNetCore.Mvc;
using EnergyMonitoringAPI.Services;
using EnergyMonitoringAPI.ViewModels;

namespace EnergyMonitoringAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Registra um novo usuário
        /// </summary>
        [HttpPost("register")]
        public async Task<ActionResult<TokenResponseViewModel>> Register([FromBody] RegisterViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = await _authService.RegisterAsync(model);
                var token = await _authService.LoginAsync(new LoginViewModel
                {
                    Username = model.Username,
                    Password = model.Password
                });

                var response = new TokenResponseViewModel
                {
                    Token = token,
                    Username = user.Username,
                    Role = user.Role
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Realiza login e retorna token JWT
        /// </summary>
        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseViewModel>> Login([FromBody] LoginViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var token = await _authService.LoginAsync(model);
                var user = await _authService.GetUserByUsernameAsync(model.Username);

                if (user == null)
                {
                    return Unauthorized(new { message = "Erro ao buscar usuário" });
                }

                var response = new TokenResponseViewModel
                {
                    Token = token,
                    Username = user.Username,
                    Role = user.Role
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }
    }
}