using PcRepaire.Models;
namespace PcRepaire.Data.Initializer
{
    public class HardWareList
    {
        public static HardWare[] CreateHardWares()
        {
            return new HardWare[]
                          {
                new HardWare { Id = 1, HardType = "h1"},
                new HardWare { Id = 2, HardType = "h2"},
                new HardWare { Id = 3, HardType = "h3"},
                new HardWare { Id = 4, HardType = "h4"},
                new HardWare { Id = 5, HardType = "h5"}
                          };
        }
    }
}
