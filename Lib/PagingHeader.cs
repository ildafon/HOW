using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HoustonOnWire.Lib
{
    public class PagingHeader
    {
        public PagingHeader(int totalItems, int pageNumber, int pageSize, int totalPages, string term)
        {
            this.TotalItems = totalItems;
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.TotalPages = totalPages;
            this.Term = term;
        }

        public int TotalItems { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public int TotalPages { get; }
        public string Term { get; }

        public string ToJson() => JsonConvert.SerializeObject(this,
            new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver() });
       
    }
}
