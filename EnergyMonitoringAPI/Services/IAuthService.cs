using EnergyMonitoringAPI.Models;
using EnergyMonitoringAPI.ViewModels;

namespace EnergyMonitoringAPI.Services
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(RegisterViewModel model);
        Task<string> LoginAsync(LoginViewModel model);
        Task<User?> GetUserByUsernameAsync(string username);
    }
}