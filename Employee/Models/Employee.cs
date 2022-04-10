using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Employee.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [DisplayName("Employee Name")]
        public string Name { get; set; }

        
        [DisplayName("Employee Age")]
        [Required]
        [Range(1,int.MaxValue, ErrorMessage = "Age must be greater than 0")]
        public int Age { get; set; }

    }
}
