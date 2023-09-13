import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiConfig } from '../config/api.config';

@Injectable({
  providedIn: 'root',
})
export class RedirectService {
  generateRedirectUrl(slug: string): string {
    return ApiConfig.REDIRECT_API + slug;
  }
}