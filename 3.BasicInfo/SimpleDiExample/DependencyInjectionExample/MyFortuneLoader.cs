using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDiExample.DependencyInjectionExample
{
    public class MyFortuneLoader : IFortuneLoader
    {
        private string  _fortune { get; }

        public MyFortuneLoader(string fortune)
        {
            _fortune = fortune;
        }

        public string LoadFortune()
        {
            return _fortune;
        }
    }
}
