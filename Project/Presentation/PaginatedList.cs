using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Presentation
{
    public class PaginatedList<T> : List<T>
    {
        public PaginatedList(IEnumerable<T> source, int pageIndex, int pageSize,int count)
        {
            PageIndex = pageIndex;
            TotalPage = (int)Math.Ceiling(count / (double)pageSize);
            
            this.AddRange(source);
        }

        public int PageIndex { get; set; }
        public int TotalPage { get; set; }
        public bool HasNext
        {
            get { return PageIndex < TotalPage; }
        }
        public bool HasPrevious
        {
            get { return PageIndex > 1; }
        }

         public static  PaginatedList<T> Create(IEnumerable<T> query, int pageIndex, int pageSize)
        {
            //int count = await query.CountAsync<T>();
            var count =  query.Count<T>();

            var items =  query.Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize).ToList();

            return new PaginatedList<T>(items, pageIndex, pageSize, count);
        }
    }
}