using System;

namespace SimpleDiExample.DependencyInjectionExample
{
    public class FortuneTeller : IFortuneTeller
    {
        private IFortuneLoader _fortuneLoader;

        public FortuneTeller(IFortuneLoader fortuneLoader)
        {
            _fortuneLoader = fortuneLoader;
        }

        public void TellFortune()
        {
            var fortune = _fortuneLoader.LoadFortune();
            Console.Write(fortune);
        }
    }
}
