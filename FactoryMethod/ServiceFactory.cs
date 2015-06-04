using System;
using Services;

namespace FactoryMethod
{
    public static class ServiceFactory
    {
        public static Func<IEurosPerDollar> CreateEurosPerDollar { get; set; }

        public static Func<IBerekening> CreateBerekening { get; set; }
    }

}

