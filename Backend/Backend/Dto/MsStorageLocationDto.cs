using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Dto
{
    public class MsStorageLocationDto
    {
        [Key]
        [Column("location_id")]
        public string LocationId { get; set; }

        [Column("location_name")]
        public string LocationName { get; set; }
    }
}
