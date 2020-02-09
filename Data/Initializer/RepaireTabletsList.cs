using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PcRepaire.Models;

namespace PcRepaire.Data.Initializer
{
    public class RepaireTabletsList 
    {
        public static RepaireTablet[] CreateRepaireTablets()
        {
            return new RepaireTablet[]
            {
                new RepaireTablet { Id = 11, DateRepaire = Convert.ToDateTime("02.01.2020"), RepaireManId = 10, SoftWare = true, TabletId = 9 },
                new RepaireTablet { Id = 12, DateRepaire = Convert.ToDateTime("06.01.2020"), RepaireManId = 13, SoftWare = true, TabletId = 11 },
                new RepaireTablet { Id = 13, DateRepaire = Convert.ToDateTime("09.01.2020"), RepaireManId = 11, SoftWare = true, TabletId = 16 },
                new RepaireTablet { Id = 14, DateRepaire = Convert.ToDateTime("12.01.2020"), RepaireManId = 11, SoftWare = true, TabletId = 14 },
                new RepaireTablet { Id = 15, DateRepaire = Convert.ToDateTime("13.01.2020"), RepaireManId = 14, SoftWare = true, TabletId = 11 },
                new RepaireTablet { Id = 16, DateRepaire = Convert.ToDateTime("13.01.2020"), RepaireManId = 15, SoftWare = true, TabletId = 13 }
            };
        }
    }
}
