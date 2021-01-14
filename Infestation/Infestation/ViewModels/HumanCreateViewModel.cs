using Infestation.Models;
using System.Collections.Generic;

namespace Infestation.ViewModels
{
    public class HumanCreateViewModel
    {
        public IEnumerable<Country> Countries { get; set; }
        public Human Human { get; set; }
    }
}