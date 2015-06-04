using System;
using Services;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class GenereerBerekeningen
    {
        readonly Func<IBerekening> _berekening;

        public GenereerBerekeningen(Func<IBerekening> berekening)
        {
            _berekening = berekening;
        }

        public async Task ShowBerekening()
        {
            {
                var b = _berekening();
                b.Parameters = new int[] { 10, 20, 30, 40 };
                await b.BerekenAsync();
                Console.WriteLine("Resultaat van berekening {0} op {1}: {2}", 
                    b.Naam,
                    string.Join(", ", b.Parameters), 
                    b.Resultaat
                );
            }
            {
                var b = _berekening();
                b.Parameters = new int[] { 40, 50, 60, 70 };
                await b.BerekenAsync();
                Console.WriteLine("Resultaat van berekening {0} op {1}: {2}", 
                    b.Naam,
                    string.Join(", ", b.Parameters), 
                    b.Resultaat
                );
            }
            {
                var b = _berekening();
                b.Parameters = new int[] { 70, 80, 90, 100 };
                await b.BerekenAsync();
                Console.WriteLine("Resultaat van berekening {0} op {1}: {2}", 
                    b.Naam,
                    string.Join(", ", b.Parameters), 
                    b.Resultaat
                );
            }
        }
    }
}

