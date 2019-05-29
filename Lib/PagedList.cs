using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoustonOnWire.Lib;

namespace HoustonOnWire.Lib
{
    public class PagedList<T>
    {
        public PagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            System.Console.WriteLine($"pageNumber in constractor of  class PagedList = {pageNumber}");
            this.TotalItems = source.Count();
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.List = source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int TotalItems { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public List<T> List { get; }

        public int TotalPages => (int)Math.Ceiling(this.TotalItems /(double)this.PageSize);
        public bool HasPreviousPage => this.PageNumber > 1;
        public bool HasNextPage => this.PageNumber < this.TotalPages;
        public int NextPageNumber => this.HasNextPage ? this.PageNumber + 1 : this.TotalPages;
        public int PreviousPageNumber => this.HasPreviousPage ? this.PageNumber - 1 : 1;

        public PagingHeader GetHeader() {
            return new PagingHeader
            (
                this.TotalItems,
                this.PageNumber,
                this.PageSize,
                this.TotalPages
            );
        }
    }
}
