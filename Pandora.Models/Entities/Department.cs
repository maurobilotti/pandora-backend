using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pandora.Models.Entities
{
    [Table("departments")]
    public class Department
    {
        [Key]
        [Column("department_id")]
        public int Id { get; set; }

        [Column("department_name")]
        public string Name { get; set; }

        [ForeignKey("city_id")]
        public City City { get; set; }
    }
}
