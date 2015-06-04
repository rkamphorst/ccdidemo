using System;
using Services;
using System.Threading.Tasks;
using System.Linq;

namespace ServiceImplementations
{
    public class BerekeningSom : IBerekening
    {
        public async Task BerekenAsync()
        {
            Resultaat = await Task.Run(() => (decimal) Parameters.Sum());
        }

        public string Naam { get { return "Som"; } }

        public int[] Parameters { get; set; }

        public decimal Resultaat { get; private set; }

    }

}
