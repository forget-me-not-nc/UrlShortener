import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Url } from '../models/url.model'  
import { ApiConfig } from '../config/api.config';
import { CreateUrlModel } from '../models/create.url.model';
import { UpdateUrlModel } from '../models/update.url.model';

@Injectable({
  providedIn: 'root',
})
export class UrlService {
  constructor(private http: HttpClient) { }

  getAll(): Observable<Url[]> {
    return this.http.get<Url[]>(ApiConfig.URL_API);
  }

  get(id: number): Observable<Url> {
    return this.http.get<Url>(ApiConfig.URL_API + '' + id);
  }

  getAllByUserId(id: number): Observable<Url[]> {
    return this.http.get<Url[]>(ApiConfig.URL_API + 'user/' + id);
  }

  create(obj: CreateUrlModel): Observable<Url> {
    return this.http.post<Url>(ApiConfig.URL_API, obj);
  }

  update(obj: UpdateUrlModel): Observable<Url> {
    return this.http.put<Url>(ApiConfig.URL_API, obj);
  }

  delete(id: number): Observable<HttpResponse<any>> {
    return this.http.delete<HttpResponse<any>>(
      ApiConfig.URL_API + id.toString(),
      { observe: 'response' }
    );
  }
}
