using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildNRent.Models
{
    public class Building
    {
        [Key]
        public int BuildingId { get; set; }
        [Required]
        public string BuildingName { get; set; }
        [Required]
        public bool IsBusiness { get; set; }
        public decimal SalePrice { get; set; } = 1000;
    }
}
