using System.Collections.Generic;

namespace Infestation.Models.Repositories
{
    public interface IHumanRepository
    {
        IEnumerable<Human> GetAllHumans();

        void RemoveHuman(int humanId);

        void AddHuman(Human human);
    }
}