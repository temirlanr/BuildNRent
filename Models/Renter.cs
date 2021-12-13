using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildNRent.Models
{
    public class Renter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsEntity { get; set; }
        public IList HasBuildings { get; set; }
    }
}
