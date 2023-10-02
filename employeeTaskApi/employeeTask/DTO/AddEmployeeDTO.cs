using System.ComponentModel.DataAnnotations;

namespace employeeTask.DTO
{
    public class AddEmployeeDTO
    {

        [Required]
        [RegularExpression(@"^\S+$", ErrorMessage = "Name should not contain spaces.")]
        public string Name { get; set; }

        [Required]
        [Range(21, int.MaxValue, ErrorMessage = "Age should be greater than 20.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Addresses list should not be empty.")]
        public virtual List<string> Addresses { get; set; }
    }
}
