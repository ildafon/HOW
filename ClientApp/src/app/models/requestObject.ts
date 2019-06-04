
export interface IRequestObject {
  pageNumber: number;
  pageSize: number;
  pageTotal?: number;
  term?: string;
  related: boolean;
  visitedId?: number;
}

export class RequestObject implements IRequestObject {
  constructor(
    public pageNumber: number = 1,
    public pageSize: number = 5,
    public pageTotal?: number,
    public term: string = '',
    public related: boolean = true,
    public visitedId?: number,
  ) { }
  
}
