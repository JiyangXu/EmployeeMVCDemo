using System;
using System.ComponentModel.DataAnnotations;

namespace Employee.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

    }
}
