using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyMonitoringAPI.Models
{
    [Table("USERS")]
    public class User
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [Column("USERNAME")]
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [Column("EMAIL")]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Column("PASSWORD_HASH")]
        [MaxLength(255)]
        public string PasswordHash { get; set; } = string.Empty;

        [Column("ROLE")]
        [MaxLength(20)]
        public string Role { get; set; } = "User";

        [Column("CREATED_AT")]
        public DateTime CreatedAt { get; set; }
    }
}