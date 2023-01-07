using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PL04.Models;

namespace PL04.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} lenght must be between {2} and {1}")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required field")]
        [StringLength(256, MinimumLength = 3, ErrorMessage = "lenght cannot excceed {1} characters")]
        public string Description { get; set; }
        public int Credits { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public Decimal Cost { get; set; }
        public Boolean State { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
