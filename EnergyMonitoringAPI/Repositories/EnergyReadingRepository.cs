using Microsoft.EntityFrameworkCore;
using EnergyMonitoringAPI.Data;
using EnergyMonitoringAPI.Models;

namespace EnergyMonitoringAPI.Repositories
{
    public class EnergyReadingRepository : IEnergyReadingRepository
    {
        private readonly AppDbContext _context;

        public EnergyReadingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EnergyReading> AddAsync(EnergyReading reading)
        {
            _context.EnergyReadings.Add(reading);
            await _context.SaveChangesAsync();
            return reading;
        }

        public async Task<EnergyReading?> GetByIdAsync(int id)
        {
            return await _context.EnergyReadings.FindAsync(id);
        }

        public async Task<(List<EnergyReading> items, int totalCount)> GetAllAsync(int page, int pageSize)
        {
            var totalCount = await _context.EnergyReadings.CountAsync();
            
            var items = await _context.EnergyReadings
                .OrderByDescending(e => e.ReadingDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<List<EnergyReading>> GetByDeviceIdAsync(string deviceId)
        {
            return await _context.EnergyReadings
                .Where(e => e.DeviceId == deviceId)
                .OrderByDescending(e => e.ReadingDate)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalConsumptionAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.EnergyReadings
                .Where(e => e.ReadingDate >= startDate && e.ReadingDate <= endDate)
                .SumAsync(e => e.EnergyConsumption);
        }
    }
}