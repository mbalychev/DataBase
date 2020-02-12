using PcRepaire.Models;
namespace PcRepaire.Data.Initializer
{
    public class RepaireManList
    {
        public static RepaireMan[] CreateRepaireMen()
        {
            return new RepaireMan[]
            {
                new RepaireMan { Id = 10, FirstName = "Mikhail", LastName = "Fikstin"},
                new RepaireMan { Id = 11, FirstName = "Konstantin", LastName = "Lysin"},
                new RepaireMan { Id = 12, FirstName = "Igor", LastName = "Noskov"},
                new RepaireMan { Id = 13, FirstName = "Fedor", LastName = "Lepechev"},
                new RepaireMan { Id = 14, FirstName = "Ivan", LastName = "Kastrichenko"},
                new RepaireMan { Id = 15, FirstName = "Igor", LastName = "Lapushev"}
            };
        }
    }
}
