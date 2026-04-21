using System.ComponentModel.DataAnnotations;

namespace EnergyMonitoringAPI.ViewModels
{
    public class CreateEnergyReadingViewModel
    {
        [Required(ErrorMessage = "DeviceId é obrigatório")]
        public string DeviceId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Location é obrigatório")]
        public string Location { get; set; } = string.Empty;

        [Range(0, double.MaxValue, ErrorMessage = "Consumo deve ser positivo")]
        public decimal EnergyConsumption { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Demanda deve ser positiva")]
        public decimal PowerDemand { get; set; }

        public string EnergySource { get; set; } = "Grid";

        [Range(0, double.MaxValue, ErrorMessage = "Custo deve ser positivo")]
        public decimal CostPerKWh { get; set; }
    }

    public class EnergyReadingResponseViewModel
    {
        public int Id { get; set; }
        public string DeviceId { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public decimal EnergyConsumption { get; set; }
        public decimal PowerDemand { get; set; }
        public DateTime ReadingDate { get; set; }
        public string EnergySource { get; set; } = string.Empty;
        public decimal TotalCost { get; set; }
    }
}