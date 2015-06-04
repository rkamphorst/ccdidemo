using System;
using System.Threading.Tasks;
using System.Linq;
using Services;

namespace FactoryMethod
{
    public class BerekeningDollarSomInEuros : IBerekening
    {
        readonly IEurosPerDollar _eurosPerDollar;

        public BerekeningDollarSomInEuros()
        {
            _eurosPerDollar = ServiceFactory.CreateEurosPerDollar();
        }

        public async Task BerekenAsync()
        {
            var eurPerDollar = await _eurosPerDollar.Get();
            Resultaat = await Task.Run(() => ((decimal) Parameters.Sum() * eurPerDollar));
        }

        public string Naam { get { return "Som van Dollars in Euro's"; } }

        public int[] Parameters { get; set; }

        public decimal Resultaat { get; private set; }
    }
}

