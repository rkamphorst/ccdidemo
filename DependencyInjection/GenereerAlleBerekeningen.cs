using System;
using Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DependencyInjection
{
    public class GenereerAlleBerekeningen
    {
        readonly IEnumerable<Func<IBerekening>> _berekeningen;

        public GenereerAlleBerekeningen(IEnumerable<Func<IBerekening>> berekeningen)
        {
            _berekeningen = berekeningen;
        }

        public async Task ShowBerekening()
        {
            foreach (var berekeningFactory in _berekeningen) {
                {
                    var b = berekeningFactory();
                    b.Parameters = new int[] { 10, 20, 30, 40 };
                    await b.BerekenAsync();
                    Console.WriteLine("Resultaat van berekening {0} op {1}: {2}", 
                        b.Naam,
                        string.Join(", ", b.Parameters), 
                        b.Resultaat
                    );
                }
                {
                    var b = berekeningFactory();
                    b.Parameters = new int[] { 40, 50, 60, 70 };
                    await b.BerekenAsync();
                    Console.WriteLine("Resultaat van berekening {0} op {1}: {2}", 
                        b.Naam,
                        string.Join(", ", b.Parameters), 
                        b.Resultaat
                    );
                }
                {
                    var b = berekeningFactory();
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
}
