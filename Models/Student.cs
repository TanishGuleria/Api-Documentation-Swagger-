using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WEBapi.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required]
        [MaxLength(20)]
        public string StudentName { get; set; }
        [Required]
        [Range(0,10)]
        public int Cgpa { get; set; }
    }
}
