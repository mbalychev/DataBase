using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcRepaire.Models
{
    public class ThinkClient : Pc
    {
        private double SpeedIndexCulculate()
        {
            HardWare.SpeedEthernetI += HardWare.SpeedEthernetI * 20 / 100;
            return Math.Round(((HardWare.SpeedEthernetI + HardWare.SpeedProcessorI + HardWare.SpeedSsdI) / 3), 2);
        }
    }
}
