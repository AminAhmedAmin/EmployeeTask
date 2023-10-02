using System.ComponentModel.DataAnnotations;
using System.Net;

namespace employeeTask.Models
{
    public class Employee

    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(21, int.MaxValue, ErrorMessage = "Age should be greater than 20.")]
        public int Age { get; set; }
        [Required]


        public virtual List<Address> Addresses { get; set; } = new List<Address>();
    }
}
