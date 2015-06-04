using System;
using System.Threading.Tasks;
using Services;

namespace DependencyInjection
{
    public class LazyBerekening
    {
        readonly Lazy<IBerekening> _berekening;

        public LazyBerekening(Lazy<IBerekening> berekening)
        {
            _berekening = berekening;
        }

        public async Task ShowBerekening()
        {
            var b = _berekening.Value;
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

