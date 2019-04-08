using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GreyWilson.Data
{
    public class Claim
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Customer Number")]
        public string CustomerNumber { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Claim Amount")]
        public decimal ClaimAmount { get; set; }
        [Required]
        [Display(Name = "Claim Date")]
        public string CreatedOn {get; set;}

    }
}
