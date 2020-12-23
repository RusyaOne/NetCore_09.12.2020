using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicInfo.Models
{
    public interface INewsRepository
    {
        List<News> GetNews();
    }
}
