import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Figure } from '../model/figure';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { map } from 'rxjs/operators/map';
import { FilterParams } from '../model/filterParams';
import { HttpHeaders } from '@angular/common/http';


@Injectable()
export class FiguresService {

  protected baseUrl: string;
  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) { this.baseUrl = baseUrl + 'api/v1/figure'; }

  getAll() {
    let httpOptions = this.addAuthHeader();

    return this.httpClient.get<Figure[]>(this.baseUrl, httpOptions).pipe(
      map(response => (<GridDataResult>{
        data: response,
        total: response.length
      }))
    );
  }

  getBy(filter: FilterParams) {
    var url = filter.getRequest();
    let httpOptions = this.addAuthHeader();

    return this.httpClient.get<Figure[]>(this.baseUrl + url, httpOptions).pipe(
      map(response => (<GridDataResult>{
        data: response,
        total: response.length
      }))
    );
  }

  private addAuthHeader() {
    let authToken = localStorage.getItem('auth_token');
    let httpOptions = {
      headers: new HttpHeaders()
    };
    httpOptions.headers = httpOptions.headers.set('Authorization', `Bearer ${authToken}`);
    return httpOptions;
  }


}
