import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Url } from '../models/url.model'  
import { ApiConfig } from '../config/api.config';

@Injectable({
  providedIn: 'root',
})
export class UrlService {
  constructor(private http: HttpClient) { }

  getAll(): Observable<Url[]> {
    return this.http.get<Url[]>(ApiConfig.URL_API);
  }

  get(id: number): Observable<Url> {
    return this.http.get<Url>(ApiConfig.URL_API + id.toString());
  }

  delete(id: number): Observable<HttpResponse<any>> {
    return this.http.delete<HttpResponse<any>>(
      ApiConfig.URL_API + id.toString(),
      { observe: 'response' }
    );
  }
}
