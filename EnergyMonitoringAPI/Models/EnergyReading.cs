using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EnergyMonitoringAPI.Models
{
    [Table("ENERGY_READINGS")]
    public class EnergyReading
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }  // SQLite vai gerar automaticamente

        [Required]
        [Column("DEVICE_ID")]
        [MaxLength(50)]
        public string DeviceId { get; set; } = string.Empty;

        [Required]
        [Column("LOCATION")]
        [MaxLength(200)]
        public string Location { get; set; } = string.Empty;

        [Column("ENERGY_CONSUMPTION")]
        [Precision(18, 2)]
        public decimal EnergyConsumption { get; set; }

        [Column("POWER_DEMAND")]
        [Precision(18, 2)]
        public decimal PowerDemand { get; set; }

        [Column("READING_DATE")]
        public DateTime ReadingDate { get; set; }

        [Column("ENERGY_SOURCE")]
        [MaxLength(50)]
        public string EnergySource { get; set; } = "Grid";

        [Column("COST_PER_KWH")]
        [Precision(18, 2)]
        public decimal CostPerKWh { get; set; }

        [Column("TOTAL_COST")]
        [Precision(18, 2)]
        public decimal TotalCost { get; set; }
    }
}