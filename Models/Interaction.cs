using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuildNRent.Models
{
    public class Interaction
    {
        [Key]
        public int Id { get; set; }
        public int RenterId { get; set; }
        public int BuildingId { get; set; }
        public decimal RentingArea { get; set; }
        public decimal Cost { get; set; }
    }
}
