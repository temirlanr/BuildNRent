using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuildNRent.Dtos
{
    public class InteractionReadDto
    {
        [Key]
        public int Id { get; set; }
        public int RenterId { get; set; }
        public int BuildingId { get; set; }
        public decimal RentingArea { get; set; }
        public decimal Cost { get; set; }
    }

    public class InteractionCreateDto
    {
        public int RenterId { get; set; }
        public int BuildingId { get; set; }
        public decimal RentingArea { get; set; }
    }

    public class InteractionUpdateDto
    {
        [Key]
        public int Id { get; set; }
        public int RenterId { get; set; }
        public int BuildingId { get; set; }
        public decimal RentingArea { get; set; }
        public decimal Cost { get; set; }
    }
}
