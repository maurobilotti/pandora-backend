using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pandora.Models.Entities
{
    [Table("employees")]
    public class Employee
    {
        [Key]
        [Column("employee_id")]
        public int Id { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [Column("salary")]
        public decimal Salary { get; set; }

        [Column("role")]
        public string Role { get; set; }

        [ForeignKey("department_id")]
        public Department Department { get; set; }
    }
}
