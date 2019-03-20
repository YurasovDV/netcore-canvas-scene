import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Circle } from '../model/circle';
import { Observable } from 'rxjs';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { map } from 'rxjs/operators/map';

@Injectable()
export class CirclesService {

  protected baseUrl: string;
  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) { this.baseUrl = baseUrl; }

  getAll() {
    return this.httpClient.get<Circle[]>(this.baseUrl + 'api/v1/circle').pipe(
      map(response => (<GridDataResult>{
        data: response,
        total: response.length
      }))
    );
  }
}
