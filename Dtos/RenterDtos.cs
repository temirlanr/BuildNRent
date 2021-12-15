using BuildNRent.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuildNRent.Dtos
{
    public class RenterReadDto
    {
        [Key]
        public int RenterId { get; set; }
        [Required]
        public string RenterName { get; set; }
        [Required]
        public bool IsEntity { get; set; }
    }


    public class RenterCreateDto
    {
        [Required]
        public string RenterName { get; set; }
        [Required]
        public bool IsEntity { get; set; }
    }
        
    public class RenterUpdateDto
    {
        [Key]
        public int RenterId { get; set; }
        [Required]
        public string RenterName { get; set; }
        [Required]
        public bool IsEntity { get; set; }
    }
}
