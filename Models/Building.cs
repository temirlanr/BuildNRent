using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildNRent.Models
{
    public class Building
    {
        public int Id { get; set; }
        public string BuildingName { get; set; }
        public decimal Area { get; set; }
        public bool IsBusiness { get; set; }
        public decimal SalePrice
        {
            get
            {
                return Area * 1000;
            }
        }
        public IList BelongsTo { get; set; }
    }
}
