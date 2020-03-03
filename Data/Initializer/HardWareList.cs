using PcRepaire.Models;
namespace PcRepaire.Data.Initializer
{
    public class HardWareList
    {
        public static HardWare[] CreateHardWares()
        {
            return new HardWare[]
                          {
                new HardWare { Id = 1, HardType = "h1", SpeedEthernetI = 0.5, SpeedProcessorI = 0.6, SpeedSsdI = 0.5},
                new HardWare { Id = 2, HardType = "h2", SpeedEthernetI = 0.8, SpeedProcessorI = 0.7, SpeedSsdI = 0.4},
                new HardWare { Id = 3, HardType = "h3", SpeedEthernetI = 0.8, SpeedProcessorI = 0.5, SpeedSsdI = 0.4},
                new HardWare { Id = 4, HardType = "h4", SpeedEthernetI = 0.6, SpeedProcessorI = 0.4, SpeedSsdI = 0.5},
                new HardWare { Id = 5, HardType = "h5", SpeedEthernetI = 0.5, SpeedProcessorI = 0.3, SpeedSsdI = 0.5}
                          };
        }
    }
}
