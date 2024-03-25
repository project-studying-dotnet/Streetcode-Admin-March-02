using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Streetcode.DAL.Entities.Locations
{
    [Table("locations", Schema = "locations")]
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string? Streetname { get; set; }
        [Required]
        public int TableNumber { get; set; }
    }
}
