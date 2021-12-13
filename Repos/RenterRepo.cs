using BuildNRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildNRent.Repos
{
    public interface IRenterRepo
    {
        bool SaveChanges();

        Renter GetRenterById(int id);
        IEnumerable<Renter> GetAllRenters();
        void CreateRenter(Renter renter);
        void UpdateRenter(Renter renter);
        void DeleteRenter(Renter renter);
    }
    public class RenterRepo : IRenterRepo
    {

        private readonly BnRContext _context;

        public RenterRepo(BnRContext context)
        {
            _context = context;
        }
        public void CreateRenter(Renter renter)
        {
            if (renter == null)
            {
                throw new ArgumentNullException(nameof(renter));
            }

            _context.Renters.Add(renter);
        }

        public void DeleteRenter(Renter renter)
        {
            if (renter == null)
            {
                throw new ArgumentNullException(nameof(renter));
            }

            _context.Renters.Remove(renter);
        }

        public IEnumerable<Renter> GetAllRenters()
        {
            return _context.Renters.ToList();
        }

        public Renter GetRenterById(int id)
        {
            return _context.Renters.FirstOrDefault(i => i.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateRenter(Renter renter) {  }
    }
}
