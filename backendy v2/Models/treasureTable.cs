using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backendy_v2.Models
{
    [Table("treasures")]
    public class treasureTable
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name", TypeName = "VARCHAR(255)")]
        public required string Name { get; set; }

        [Required]
        [Column("type", TypeName = "VARCHAR(255)")]
        public required string Type { get; set; }

        [Required]
        [Column("image_url", TypeName = "VARCHAR(255)")]
        public required string ImageUrl { get; set; }

        [Required]
        [Column("price", TypeName = "DECIMAL(10,2)")]
        public required decimal Price { get; set; }
    }
}
