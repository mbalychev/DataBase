using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PcRepaire.Models.ViewModels
{
    public class StatWorkers : RepaireMan
    {
        public int CountRepaires { get; set; }
        public int CountSoft { get; set; }
        public int CountHard { get; set; }

        public static IQueryable<StatWorkers> Create(IQueryable<RepaireMan> workers)
        {
            IQueryable<StatWorkers> statWorkers = workers.Select(s => new StatWorkers
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                RepairList = s.RepairList,
                CountRepaires = s.RepairList.Count(),
                CountSoft = s.RepairList.Where(soft => soft.SoftWare == true).Count(),
                CountHard = s.RepairList.Where(h => h.HardWare == true).Count()
            });

            return statWorkers;
        }
    }
}
