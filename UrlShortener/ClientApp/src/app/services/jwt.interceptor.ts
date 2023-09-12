import { Injectable } from '@angular/core';
import { 
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { MyLocalStorageService } from './my.local.storage.service';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor(private localStorageService: MyLocalStorageService) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const token = this.localStorageService.get('jwt');
    if (token) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`,
        },
      });
    }
    return next.handle(request);
  }
}