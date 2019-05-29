using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoustonOnWire.Lib
{
    public class FilterParams
    {
        public bool Related { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public string Term { get; set; } = "";

    }
}
