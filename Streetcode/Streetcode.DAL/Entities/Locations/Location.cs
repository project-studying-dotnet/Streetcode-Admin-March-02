using System.ComponentModel.DataAnnotations.Schema;

namespace Streetcode.DAL.Entities.Locations
{
    [Table("locations", Schema = "locations")]
    public class Location
    {
        public int Id { get; set; }
        public string? Streetname { get; set; }
        public int TableNumber { get; set; }
    }
}
