using BuildNRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildNRent.Repos
{
    public interface IInteractionRepo
    {
        bool SaveChanges();

        Interaction GetInteractionById(int id);
        IEnumerable<Interaction> GetAllInteractions();
        void CreateInteraction(Interaction interaction);
        void UpdateInteraction(Interaction interaction);
        void DeleteInteraction(Interaction interaction);
    }
    public class InteractionRepo : IInteractionRepo
    {

        private readonly BnRContext _context;

        public InteractionRepo(BnRContext context)
        {
            _context = context;
        }
        public void CreateInteraction(Interaction interaction)
        {
            if (interaction == null)
            {
                throw new ArgumentNullException(nameof(interaction));
            }

            _context.Interactions.Add(interaction);
        }

        public void DeleteInteraction(Interaction interaction)
        {
            if (interaction == null)
            {
                throw new ArgumentNullException(nameof(interaction));
            }

            _context.Interactions.Remove(interaction);
        }

        public IEnumerable<Interaction> GetAllInteractions()
        {
            return _context.Interactions.ToList();
        }

        public Interaction GetInteractionById(int id)
        {
            return _context.Interactions.FirstOrDefault(i => i.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateInteraction(Interaction interaction) { }
    }
}
