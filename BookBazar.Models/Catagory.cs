using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookBazar.Models
{
    public class Catagory
    {
        [Key]
        public int CatagoryId { get; set; }
        [Required]
        [Display(Name="Catagory Name")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
