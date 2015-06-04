using System;
using Services;
using System.Threading.Tasks;
using System.Linq;

namespace ServiceImplementations
{
    public class BerekeningGemiddelde : IBerekening
    {
        public async Task BerekenAsync()
        {
            Resultaat = await Task.Run(() => (decimal) Parameters.Average());
        }

        public string Naam { get { return "Gemiddelde"; } }

        public int[] Parameters { get; set; }

        public decimal Resultaat { get; private set; }

    }


}

