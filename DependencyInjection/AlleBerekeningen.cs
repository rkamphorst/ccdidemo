using System;
using System.Collections.Generic;
using Services;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class AlleBerekeningen
    {
        readonly List<IBerekening> _berekeningen;

        public AlleBerekeningen(IEnumerable<IBerekening> berekeningen)
        {
            _berekeningen = berekeningen.ToList();
        }

        public async Task ShowBerekeningen() 
        {
            foreach (var b in _berekeningen) {
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
}

