using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace employeeTask.Models
{
    public class Address
    {

        public int Id { get; set; }
        [Required]
       
        public string Description { get; set; }

      
        public int EmployeeId { get; set; }


        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee Employee { get; set; }
    }
}
