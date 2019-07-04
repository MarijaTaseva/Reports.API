using System.Collections.Generic;
using System.Linq;

namespace RiaRu.API
{
    public class PaginatedResponse<T>
    {
        public PaginatedResponse(IEnumerable<T> data, int i, int len)
        {
            // [1] page, 10 results
            // Skip 0 => ((1-1) * 10) 
            // Then take 10 from there
            Data = data.Skip((i - 1) * len).Take(len).ToList();
            Total = data.Count();
        }

        public int Total { get; set;}
        public IEnumerable<T> Data { get; set; }
    }
}