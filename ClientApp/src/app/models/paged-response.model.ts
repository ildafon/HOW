export interface Paging {
  totalItems: number;
  pageNumber: number;
  pageSize: number;
  totalPages: number;
  term?: string;
}

export interface LinkInfo {
  href: string,
  rel: string,
  method: string
}

export interface PagedResponse<T> {
  paging: Paging,
  links: LinkInfo[],
  items: T[]
}
