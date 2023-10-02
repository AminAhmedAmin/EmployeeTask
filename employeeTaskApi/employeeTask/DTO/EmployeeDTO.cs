using employeeTask.Models;
using NSwag.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace employeeTask.DTO
{
    public class EmployeeDTO
    {

    
        public int Id { get; set; }

       
        public string Name { get; set; }

        
        public int Age { get; set; }

      
        public virtual List<AddressDTo> Addresses { get; set; }
    }


    public class AddressDTo
    {


        [Required]

        public string Description { get; set; }

    }
}
