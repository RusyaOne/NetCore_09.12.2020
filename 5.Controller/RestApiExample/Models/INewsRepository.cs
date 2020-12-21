using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiExample.Models
{
    public interface INewsRepository
    {
        public IEnumerable<News> GetAllNews();

        void CreateNews(News news);
    }
}
