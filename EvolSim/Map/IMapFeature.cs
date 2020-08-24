using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolSim.Map
{
    interface IMapFeature
    {
        IMapFeature CreateSelf(World world);
        void Effect();
    }
}
