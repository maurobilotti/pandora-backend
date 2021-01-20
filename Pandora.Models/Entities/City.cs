using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pandora.Models.Entities
{
    [Table("cities")]
    public class City
    {
        [Key]
        [Column("city_id")]
        public int Id { get; set; }

        [Column("city_name")]
        public string Name { get; set; }
    }
}
