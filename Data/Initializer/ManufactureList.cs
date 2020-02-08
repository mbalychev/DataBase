using PcRepaire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcRepaire.Data.Initializer
{
    public class ManufactureList
    {
        public static Manufacture[] CreateManufactures()
        {
            return new Manufacture[]
            {
                new Manufacture { Id = 1, Name = "Lenovo"},
                new Manufacture { Id = 2, Name = "Hewlett Packard"},
                new Manufacture { Id = 3, Name = "Apple"},
                new Manufacture { Id = 4, Name = "Microsoft"},
                new Manufacture { Id = 5, Name = "Samsung"}
            };
        }
    }
}
