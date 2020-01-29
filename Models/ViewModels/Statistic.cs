using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PcRepaire.Models.ViewModels
{
    public class Statistic
    {
        [Key]
        public int Id { get; set; }
        public IQueryable<StatRepaires> StatRepaires { get; set; }
        public IQueryable<StatWorkers> StatWorkers { get; set; }
    }
}
