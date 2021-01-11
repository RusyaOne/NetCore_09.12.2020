using Infestation.Models;
using System.Collections.Generic;

namespace Infestation.ViewModels
{
    public class HomeInfoViewModel
    {
        public IEnumerable<Human> Humans { get; set; }
        public IEnumerable<Country> Countries { get; set; }
    }
}