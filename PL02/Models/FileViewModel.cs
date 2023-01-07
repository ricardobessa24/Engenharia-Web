using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace PL02.Models
{
    public class FileViewModel
    {
        [Required]
        [RegularExpression(@"^.+\.([pP][dD][fF])$", ErrorMessage = "Only pdf files")]
        public string Name { get; set; }

        [Display(Name ="Size in bytes")]
        public long Size { get; set; }
    }
}
