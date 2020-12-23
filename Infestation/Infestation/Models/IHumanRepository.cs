using System.Collections.Generic;

namespace Infestation.Models
{
    public interface IHumanRepository
    {
        IEnumerable<Human> GetAllHumans();

        void DeleteHuman(int humanId);
    }
}