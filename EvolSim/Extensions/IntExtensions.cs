using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolSim.Extensions
{
    public static class IntExtensions
    {
        public static int Modulo(this int a, int m)
        {
            return (a % m + m) % m;
        }
    }
}
