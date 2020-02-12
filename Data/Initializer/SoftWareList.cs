using PcRepaire.Models;
namespace PcRepaire.Data.Initializer
{
    public class SoftWareList
    {
        public static SoftWare[] CreateSoftWares()
        {
            return new SoftWare[]
                                {
                new SoftWare { Id = 1, Name = "Windows 7"},
                new SoftWare { Id = 2, Name = "Windows 10"},
                new SoftWare { Id = 3, Name = "IOs"},
                new SoftWare { Id = 4, Name = "Linux Ubuntu"},
                new SoftWare { Id = 5, Name = "Linux Mint"},
                new SoftWare { Id = 6, Name = "Android"}
            };
        }
    }
}
