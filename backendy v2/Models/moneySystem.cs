using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backendy.Models
{
    [Table("money_system")]
    public class moneySystem
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("Balance", TypeName = "DECIMAL(10,2)")]
        public decimal MoneyBalance { get; set; }

        [ForeignKey("UserId")] 
        public virtual required UserTable User { get; set; }
    }
}