using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HoustonOnWire.Lib;

namespace HoustonOnWire.Lib
{
    public class PagedList<T>
    {
        public PagedList(IQueryable<T> source, int pageNumber, int pageSize, string term)
        {
            
            this.TotalItems = source.Count();
            this.PageNumber = pageNumber;
            this.PageSize = pageSize == 0 ? this.TotalItems : pageSize ;
            this.Term = term;
            this.List = source.Count() > 0 ? source
                .Skip((pageNumber - 1) * pageSize)
                .Take(this.PageSize)
                .ToList() : new List<T>();
        }

        public int TotalItems { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public List<T> List { get; }
        public string Term { get; }


        public int TotalPages => this.TotalItems > 0 ? (int)Math.Ceiling(this.TotalItems /(double)this.PageSize): 0;
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
                this.TotalPages,
                this.Term
            );
        }

        public List<LinkInfo> GetLinkInfos<T>(IUrlHelper urlHelper)
        {
            var links = new List<LinkInfo>();

            if (this.HasPreviousPage)
                links.Add(CreateLink(urlHelper, this.PreviousPageNumber, this.PageSize, "previousPage", "GET"));

            links.Add(CreateLink(urlHelper, this.PageNumber, this.PageSize, "self", "GET"));

            if (this.HasNextPage)
                links.Add(CreateLink(urlHelper, this.NextPageNumber, this.PageSize, "nextPage", "GET"));
            return links;
        }

        private LinkInfo CreateLink(IUrlHelper urlHelper, int pageNumber, int pageSize,
            string rel, string method)
        {
            
            return new LinkInfo
            {
                Href = urlHelper.Link("Get"+ typeof(T).Name + "s", new { PageNumber = pageNumber, PageSize = pageSize }),
                Rel = rel,
                Method = method
            };
        }
    }
}
