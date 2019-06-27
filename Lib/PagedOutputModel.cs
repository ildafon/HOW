using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoustonOnWire.Lib
{
    public class PagedOutputModel<T>
    {
        public PagingHeader Paging { get; set; }
        public List<LinkInfo> Links { get; set; }
        public List<T> Items { get; set; }
    }
}