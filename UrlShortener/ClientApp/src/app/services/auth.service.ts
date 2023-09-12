import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiConfig } from '../config/api.config';
import { LoginResponse } from '../models/login.response.model';
import { LoginModel } from '../models/login.model';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private http: HttpClient) { }

  login(body: LoginModel): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(ApiConfig.AUTH_API + 'login', body);
  }
}