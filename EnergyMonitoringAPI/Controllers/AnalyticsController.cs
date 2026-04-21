using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EnergyMonitoringAPI.Repositories;

namespace EnergyMonitoringAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AnalyticsController : ControllerBase
    {
        private readonly IEnergyReadingRepository _repository;

        public AnalyticsController(IEnergyReadingRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retorna análise de consumo total em um período
        /// </summary>
        [HttpGet("consumption")]
        public async Task<ActionResult> GetConsumptionAnalysis(
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate)
        {
            try
            {
                var start = startDate ?? DateTime.UtcNow.AddMonths(-1);
                var end = endDate ?? DateTime.UtcNow;

                if (start > end)
                {
                    return BadRequest(new { message = "Data inicial não pode ser maior que data final" });
                }

                var totalConsumption = await _repository.GetTotalConsumptionAsync(start, end);

                var response = new
                {
                    startDate = start,
                    endDate = end,
                    totalConsumptionKWh = totalConsumption,
                    averageDailyConsumption = totalConsumption / (decimal)(end - start).TotalDays,
                    periodDays = (end - start).TotalDays
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao gerar análise", error = ex.Message });
            }
        }
    }
}