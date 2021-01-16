using System.Collections.Generic;

namespace Infestation.Models.Repositories.Interfaces
{
    public interface IHumanRepository
    {
        IEnumerable<Human> GetAllHumans();

        void AddHuman(Human human);

        void RemoveHuman(int humanId);
    }
}