using SimpleDiExample.DependencyInjectionExample;
using System;
using Unity;

namespace SimpleDiExample
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IFortuneLoader, FromFileFortuneLoader>();
            container.RegisterType<IFortuneTeller, FortuneTeller>();
            var fortuneTeller = container.Resolve<IFortuneTeller>();
            fortuneTeller.TellFortune();

            //var fortuneTeller = new FortuneTeller(new FromFileFortuneLoader());
            //fortuneTeller.TellFortune();

            Console.Read();
        }
    }
}
