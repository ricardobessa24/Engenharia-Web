using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using PL04.Models;

namespace PL04.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        [Required (ErrorMessage ="Required field")]
        [StringLength(50, MinimumLength =3, ErrorMessage ="{0} lenght must be between {2} and {1}")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Required field")]
        [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} lenght cannot excceed {1} characters")]
        public string description { get; set; }
        public Boolean state { get; set; }
        [Display(Name = "Creation Date")]
        public DateTime Date { get; set; } = DateTime.Now;
        public ICollection<Course> Courses { get; set; }
    }
}
