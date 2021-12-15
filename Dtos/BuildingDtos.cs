using BuildNRent.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuildNRent.Dtos
{
    public class BuildingReadDto
    {
        [Key]
        public int BuildingId { get; set; }
        [Required]
        public string BuildingName { get; set; }
        [Required]
        public bool IsBusiness { get; set; }
        public decimal SalePrice { get; set; } = 1000;
    }

    public class BuildingCreateDto
    {
        [Required]
        public string BuildingName { get; set; }
        [Required]
        public bool IsBusiness { get; set; }
        public decimal SalePrice { get; set; } = 1000;
    }

    public class BuildingUpdateDto
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
