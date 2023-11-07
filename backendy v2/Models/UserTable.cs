using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backendy.Models
{
    [Table("users")]
    public class UserTable
    {
        [Key]
        [Column("userID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [Column("Username", TypeName = "VARCHAR(255)")]
        public string Username { get; set; }

        [Required]
        [Column("Password", TypeName = "VARCHAR(255)")]
        public string Password { get; set; }

        [Column("User_icon", TypeName = "VARCHAR(255)")]
        public string UserIcon { get; set; }

        [Required]
        [Column("Email", TypeName = "VARCHAR(255)")]
        public string Email { get; set; }

    }
}
