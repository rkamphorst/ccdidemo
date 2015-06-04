using System;
using System.Threading.Tasks;

namespace Services
{
    public interface IBerekening
    {
        string Naam { get; }
        int[] Parameters { get; set; }
        Task BerekenAsync();
        decimal Resultaat { get; }
    }
}

