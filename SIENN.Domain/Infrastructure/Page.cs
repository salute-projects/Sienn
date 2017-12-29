using System.Collections.Generic;

namespace SIENN.Domain.Infrastructure
{
    public class Page<T> where T : class
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int FoundItems { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
