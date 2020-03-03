using System;
using System.ComponentModel;

namespace PcRepaire.Models
{
    public class Pc : EqupmentUsing
    {

        public int HardWareId { get; set; }
        [DisplayName("Hard ware")]
        public HardWare HardWare { get; set; }
        
        [DisplayName("Speed index")]
        public double SpeedI => SpeedIndexCulculate();

        private double SpeedIndexCulculate()
        {
            return  Math.Round(((HardWare.SpeedEthernetI + HardWare.SpeedProcessorI + HardWare.SpeedSsdI) / 3), 2);
        }
    }
}
