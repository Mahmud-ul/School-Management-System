using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace schoolApp.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Provide Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Provide Address*")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Select Department*")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Provide Id*")]
        public int Roll { get; set; }

        [Required(ErrorMessage = "Provide Email*")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Provide Batch*")]
        public string Batch { get; set; }

        public Department Department { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
