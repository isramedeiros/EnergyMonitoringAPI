using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EnergyMonitoringAPI.Models;
using EnergyMonitoringAPI.Repositories;
using EnergyMonitoringAPI.ViewModels;

namespace EnergyMonitoringAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EnergyReadingsController : ControllerBase
    {
        private readonly IEnergyReadingRepository _repository;

        public EnergyReadingsController(IEnergyReadingRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Lista todas as leituras de energia com paginação
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<PaginatedResultViewModel<EnergyReadingResponseViewModel>>> GetAll(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                if (page < 1) page = 1;
                if (pageSize < 1 || pageSize > 100) pageSize = 10;

                var (items, totalCount) = await _repository.GetAllAsync(page, pageSize);

                var response = new PaginatedResultViewModel<EnergyReadingResponseViewModel>
                {
                    Items = items.Select(e => new EnergyReadingResponseViewModel
                    {
                        Id = e.Id,
                        DeviceId = e.DeviceId,
                        Location = e.Location,
                        EnergyConsumption = e.EnergyConsumption,
                        PowerDemand = e.PowerDemand,
                        ReadingDate = e.ReadingDate,
                        EnergySource = e.EnergySource,
                        TotalCost = e.TotalCost
                    }).ToList(),
                    TotalItems = totalCount,
                    CurrentPage = page,
                    PageSize = pageSize,
                    TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao buscar leituras", error = ex.Message });
            }
        }

        /// <summary>
        /// Cria uma nova leitura de energia
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<EnergyReadingResponseViewModel>> Create(
            [FromBody] CreateEnergyReadingViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var reading = new EnergyReading
                {
                    DeviceId = model.DeviceId,
                    Location = model.Location,
                    EnergyConsumption = model.EnergyConsumption,
                    PowerDemand = model.PowerDemand,
                    ReadingDate = DateTime.UtcNow,
                    EnergySource = model.EnergySource,
                    CostPerKWh = model.CostPerKWh,
                    TotalCost = model.EnergyConsumption * model.CostPerKWh
                };

                var created = await _repository.AddAsync(reading);

                var response = new EnergyReadingResponseViewModel
                {
                    Id = created.Id,
                    DeviceId = created.DeviceId,
                    Location = created.Location,
                    EnergyConsumption = created.EnergyConsumption,
                    PowerDemand = created.PowerDemand,
                    ReadingDate = created.ReadingDate,
                    EnergySource = created.EnergySource,
                    TotalCost = created.TotalCost
                };

                return CreatedAtAction(nameof(GetById), new { id = created.Id }, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao criar leitura", error = ex.Message });
            }
        }

        /// <summary>
        /// Busca uma leitura específica por ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<EnergyReadingResponseViewModel>> GetById(int id)
        {
            try
            {
                var reading = await _repository.GetByIdAsync(id);

                if (reading == null)
                {
                    return NotFound(new { message = "Leitura não encontrada" });
                }

                var response = new EnergyReadingResponseViewModel
                {
                    Id = reading.Id,
                    DeviceId = reading.DeviceId,
                    Location = reading.Location,
                    EnergyConsumption = reading.EnergyConsumption,
                    PowerDemand = reading.PowerDemand,
                    ReadingDate = reading.ReadingDate,
                    EnergySource = reading.EnergySource,
                    TotalCost = reading.TotalCost
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao buscar leitura", error = ex.Message });
            }
        }

        /// <summary>
        /// Busca leituras por dispositivo
        /// </summary>
        [HttpGet("device/{deviceId}")]
        public async Task<ActionResult<List<EnergyReadingResponseViewModel>>> GetByDevice(string deviceId)
        {
            try
            {
                var readings = await _repository.GetByDeviceIdAsync(deviceId);

                var response = readings.Select(e => new EnergyReadingResponseViewModel
                {
                    Id = e.Id,
                    DeviceId = e.DeviceId,
                    Location = e.Location,
                    EnergyConsumption = e.EnergyConsumption,
                    PowerDemand = e.PowerDemand,
                    ReadingDate = e.ReadingDate,
                    EnergySource = e.EnergySource,
                    TotalCost = e.TotalCost
                }).ToList();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao buscar leituras", error = ex.Message });
            }
        }
    }
}