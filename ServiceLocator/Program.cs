using System;
using Autofac;
using ServiceImplementations;
using Services;
using System.Threading.Tasks;

namespace ServiceLocator
{

    class MainClass
    {
        public static IContainer Container { get; private set; }
        
        public static void Main(string[] args)
        {
            Start();
            ShowBerekening().Wait();
        }

        static void Start() 
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<BerekeningDollarSomInEuros>().As<IBerekening>();
            builder.RegisterType<LocalEurosPerDollar>().As<IEurosPerDollar>();
            Container = builder.Build();
        }

        static async Task ShowBerekening() {
            var b = Container.Resolve<IBerekening>();
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
