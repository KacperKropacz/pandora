using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backendy.Models
{
    [Table("money_system")]
    public class moneySystem
    {
        // dorob zwykly id
        [Key]
        [Column("id")]
        public int id { get; set; }
        //[ForeignKey("id")] //nie dziala foreignKey z jakeijs przyczyny, to samo w CommentTable
        //public virtual UserTable UserId { get; set; }
        [Required]
        [Column("Balance", TypeName = "DECIMAL(10,2)")]
        public decimal MoneyBalance { get; set; }

        
        
    }
}