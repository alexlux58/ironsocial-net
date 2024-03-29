using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Core
{
    public class PagedList<T> : List<T>
    {

        public PagedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize); // 10 / 5 = 2
            PageSize = pageSize;
            TotalCount = count;
            AddRange(items);
        }
       
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; } // TotalPages = TotalCount / PageSize
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync(); // 10
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(); // 5
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}