import { Injectable } from '@angular/core';
import { MyLocalStorageService } from './my.local.storage.service';
import jwt_decode from 'jwt-decode';
@Injectable({
  providedIn: 'root',
})
export class PermissionService {

  constructor(private localStorageService: MyLocalStorageService) { }

  getRoles(): string[] {
    const token = this.localStorageService.get('jwt'); // Retrieve the JWT token
    if (token) {
      const decodedToken: any = jwt_decode(token);
      return decodedToken['role'] || [];
    } else {
      return [];
    }
  }
}