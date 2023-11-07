using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Column("Username", TypeName = "VARCHAR(255)")]
        public string Username { get; set; }

        [Required]
        [Column("text", TypeName = "VARCHAR(255)")]
        public string Text { get; set; }

        //[Column("creation_date")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public DataType CreationDate { get; set; }

        //[Column("user_icon", TypeName = "VARCHAR(255)")]
        //public string UserIcon { get; set; }
    }

}
