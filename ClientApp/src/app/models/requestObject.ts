
export interface IRequestObject {
  pageNumber: number;
  pageSize: number;
  term?: string;
  related: boolean;
}

export class RequestObject implements IRequestObject {
  constructor(
    public pageNumber: number = 1,
    public pageSize: number = 5,
    public term: string = '',
    public related: boolean = true
  ) { }
  
}
