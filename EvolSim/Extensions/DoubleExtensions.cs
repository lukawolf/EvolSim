using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolSim.Extensions
{
    public static class DoubleExtensions
    {
        public static double Modulo(this double a, double m)
        {
            return (a % m + m) % m;
        }
    }
}
