using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backendy.Models
{
    [Table("comments")]
    public class CommentTable
    {
        [Key]
        [Column("CommentID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }

        [Required]
        [Column("text", TypeName = "VARCHAR(255)")]
        public required string Text { get; set; }

        [Column("creation_date")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreationDate { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual required UserTable User { get; set; }
    }

}
