using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookBazar.Models
{
    public class CoverType
    {

        [Key]
        public int CoverId { get; set; }
        [Required]
        [Display(Name="Cover Type ")]
        public string Name { get; set; }
    }
}
