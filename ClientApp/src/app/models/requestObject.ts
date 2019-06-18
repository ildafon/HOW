
export interface IRequestObject {
  pageNumber: number;
  pageSize: number;
  related: boolean;
  pageTotal?: number;
  term?: string;
  visitedId?: number;
}

export class RequestObject implements IRequestObject {
  constructor(
    public pageNumber: number = 1,
    public pageSize: number = 5,
    public related: boolean = true,
    public pageTotal?: number,
    public term: string = '',
    public visitedId?: number,
  ) { }
  
}
