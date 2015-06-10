using System;
using Autofac;
using System.Threading.Tasks;
using ServiceImplementations;
using Services;
using Autofac.Features.ResolveAnything;

namespace DependencyInjection
{
    class MainClass
    {
        public static IContainer Container { get; private set; }

        public static void Main(string[] args)
        {
            Start();
            ShowBerekening();
            // ShowAlleBerekeningen();
            // ShowLazyBerekening();
            // ShowGenereerBerekeningen();
        }

        static void Start() 
        {
            var builder = new ContainerBuilder();
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            builder.RegisterType<BerekeningGemiddelde>().As<IBerekening>();
            builder.RegisterType<BerekeningSom>().As<IBerekening>();
            builder.RegisterType<BerekeningDollarSomInEuros>().As<IBerekening>();
            builder.RegisterType<LocalEurosPerDollar>().As<IEurosPerDollar>();
            Container = builder.Build();
        }

        static void ShowBerekening() 
        {
            var b = Container.Resolve<IBerekening>();
            b.Parameters = new int[] { 10, 20, 30, 40 };
            b.BerekenAsync().Wait();
            Console.WriteLine("Resultaat van berekening {0} op {1}: {2}", 
                b.Naam,
                string.Join(", ", b.Parameters), 
                b.Resultaat
            );
        }





        static void ShowBerekening2() 
        {
            Container.Resolve<Berekenaar>().ShowBerekening().Wait();
        }

        static void ShowAlleBerekeningen() 
        {
            Container.Resolve<AlleBerekeningen>().ShowBerekeningen().Wait();
        }

        static void ShowLazyBerekening() 
        {
            Container.Resolve<LazyBerekening>().ShowBerekening().Wait();
        }

        static void ShowGenereerBerekeningen() 
        {
            Container.Resolve<GenereerBerekeningen>().ShowBerekening().Wait();
        }
    }


}
