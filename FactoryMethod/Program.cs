using System;
using ServiceImplementations;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Start();
            ShowBerekening().Wait();
        }

        static void Start() 
        {
            ServiceFactory.CreateEurosPerDollar = () => new LocalEurosPerDollar();
            ServiceFactory.CreateBerekening = () => new BerekeningDollarSomInEuros();
        }

        static async Task ShowBerekening() {
            var b = ServiceFactory.CreateBerekening();
            b.Parameters = new int[] { 10, 20, 30, 40 };
            await b.BerekenAsync();
            Console.WriteLine("Resultaat van berekening {0} op {1}: {2}", 
                b.Naam,
                string.Join(", ", b.Parameters), 
                b.Resultaat
            );
        }
    }
}
