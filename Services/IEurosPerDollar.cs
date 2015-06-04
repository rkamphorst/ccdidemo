using System;
using System.Threading.Tasks;

namespace Services
{
    public interface IEurosPerDollar
    {
        Task<decimal> Get();
    }
}

