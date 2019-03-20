import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Circle } from '../model/circle';
import { Observable } from 'rxjs';

@Injectable()
export class CirclesService {

  protected baseUrl: string;
  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) { this.baseUrl = baseUrl; }

  getAll(): Observable<Circle[]> {
    return this.httpClient.get<Circle[]>(this.baseUrl + 'api/v1/circle');
  }
}
