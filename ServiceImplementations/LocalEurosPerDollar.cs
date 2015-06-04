using System;
using Services;
using System.Threading.Tasks;

namespace ServiceImplementations
{
    public class LocalEurosPerDollar : IEurosPerDollar
    {
        public Task<decimal> Get()
        {
            return Task.FromResult(0.89m);
        }
    }
}

