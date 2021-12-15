using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildNRent.Repos;

namespace BuildNRent.Models
{
    public class Renter
    {
        [Key]
        public int RenterId { get; set; }
        [Required]
        public string RenterName { get; set; }
        [Required]
        public bool IsEntity { get; set; }
    }
}
