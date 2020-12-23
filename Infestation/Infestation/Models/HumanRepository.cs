using System.Collections.Generic;
using System.Linq;

namespace Infestation.Models
{
    public class HumanRepository : IHumanRepository
    {
        private InfestationDbContext _context { get; }

        public HumanRepository(InfestationDbContext context)
        {
            _context = context;
        }

        public void DeleteHuman(int humanId)
        {
            _context.Humans.Remove(_context.Humans.First(human => human.Id == humanId));
            _context.SaveChanges();
        }

        public IEnumerable<Human> GetAllHumans()
        {
            return _context.Humans;
        }
    }
}