using System.IO;

namespace SimpleDiExample.DependencyInjectionExample
{
    public class FromFileFortuneLoader : IFortuneLoader
    {
        public string LoadFortune() 
        {
            return File.ReadAllText(@"..\..\..\res\Fortune.txt");
        }
    }
}
