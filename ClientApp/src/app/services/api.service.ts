import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpResponse, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class ApiService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  

   sendRequest<T>(verb: string, url: string, body?: T): Observable<T> {

    let myHeaders = new HttpHeaders();
    myHeaders = myHeaders.set('Content-Type', 'application/json; charset=utf-8');
    myHeaders = myHeaders.set('Accept', 'application/json');

     return this.http.request<T>(verb,`${this.baseUrl}${url}`, {
      body: body,
      headers: myHeaders
    }).pipe(
      catchError(this.handleServerError)
    );
  }

  handleServerError(error: any) {
    console.log(error.error || error.json() || error);
    return Observable.throw(error.error || error.json() || error || `Server error`);
  }
}
