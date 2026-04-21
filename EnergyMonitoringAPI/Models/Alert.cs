using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyMonitoringAPI.Models
{
    [Table("ALERTS")]
    public class Alert
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [Column("DEVICE_ID")]
        [MaxLength(50)]
        public string DeviceId { get; set; } = string.Empty;

        [Required]
        [Column("ALERT_TYPE")]
        [MaxLength(100)]
        public string AlertType { get; set; } = string.Empty;

        [Required]
        [Column("MESSAGE")]
        [MaxLength(500)]
        public string Message { get; set; } = string.Empty;

        [Column("SEVERITY")]
        [MaxLength(20)]
        public string Severity { get; set; } = "Medium";

        [Column("CREATED_AT")]
        public DateTime CreatedAt { get; set; }

        [Column("IS_RESOLVED")]
        public int IsResolved { get; set; }  // ← MUDOU DE bool PARA int (0 = false, 1 = true)
    }
}