import { Injectable } from '@angular/core';
import { 
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
} from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { MyLocalStorageService } from './my.local.storage.service';
import { LocalStorageConfig } from '../config/local.storage.config';
import { MyRoleService } from './role.service';
import { Router } from '@angular/router';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor(private localStorageService: MyLocalStorageService,
              private roleService: MyRoleService,
              private router: Router) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const token = this.localStorageService.get(LocalStorageConfig.JWT);
    if (token) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`,
        },
      });
    }
    return next.handle(request).pipe(tap(() => {}, (error) => {
      if (error.status === 401) {  
        this.roleService.flushRoles();
        this.router.navigate(['/login']);
      };
    }));
  }
}