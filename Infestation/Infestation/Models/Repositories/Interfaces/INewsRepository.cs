using System.Collections.Generic;

namespace Infestation.Models.Repositories.Interfaces
{
    public interface INewsRepository
    {
        IEnumerable<News> GetNews();
    }
}