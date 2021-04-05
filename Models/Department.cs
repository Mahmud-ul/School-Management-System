using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace schoolApp.Models
{
    public class Department
    {
        public Department()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }

        [Required (ErrorMessage ="Provide Department Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Provide Department Detail")]
        [StringLength(100, MinimumLength = 2)]
        [DataType(DataType.MultilineText)]
        public string Detail { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
