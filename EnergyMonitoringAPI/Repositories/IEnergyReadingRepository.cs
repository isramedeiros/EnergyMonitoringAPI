using EnergyMonitoringAPI.Models;

namespace EnergyMonitoringAPI.Repositories
{
    public interface IEnergyReadingRepository
    {
        Task<EnergyReading> AddAsync(EnergyReading reading);
        Task<EnergyReading?> GetByIdAsync(int id);
        Task<(List<EnergyReading> items, int totalCount)> GetAllAsync(int page, int pageSize);
        Task<List<EnergyReading>> GetByDeviceIdAsync(string deviceId);
        Task<decimal> GetTotalConsumptionAsync(DateTime startDate, DateTime endDate);
    }
}