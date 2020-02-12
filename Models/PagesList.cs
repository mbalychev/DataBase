using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcRepaire.Models
{
    public class PagesList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int PagesTotal { get; set; }

        public PagesList(List<T> items, int count, int pageIndex, int pageSize)
        {

            PageIndex = pageIndex;
            PagesTotal = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }

        public bool Previous => PageIndex > 1;

        public bool Next => PageIndex < PagesTotal;

        public static async Task<PagesList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagesList<T>(items, count, pageIndex, pageSize);
        }


    }
}
