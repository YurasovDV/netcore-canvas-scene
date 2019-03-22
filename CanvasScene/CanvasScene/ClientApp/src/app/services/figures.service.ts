import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Figure } from '../model/figure';
import { Observable } from 'rxjs';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { map } from 'rxjs/operators/map';

@Injectable()
export class FiguresService {

  protected baseUrl: string;
  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) { this.baseUrl = baseUrl; }

  getAll() {
    return this.httpClient.get<Figure[]>(this.baseUrl + 'api/v1/figure').pipe(
      map(response => (<GridDataResult>{
        data: response,
        total: response.length
      }))
    );
  }
}
