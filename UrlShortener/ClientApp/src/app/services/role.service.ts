import { Injectable } from '@angular/core';
import { MyLocalStorageService } from './my.local.storage.service';
import jwt_decode from 'jwt-decode';
import { NgxRolesService } from 'ngx-permissions';
import { LocalStorageConfig } from '../config/local.storage.config';
import { Roles } from '../models/roles';


@Injectable({
  providedIn: 'root',
})
export class MyRoleService {

  constructor(private localStorageService: MyLocalStorageService,
              private ngxRoleService: NgxRolesService) { }

  private getRolesFromJwt(): string[] {
    const token = this.localStorageService.get(LocalStorageConfig.JWT); 
    if (token) {
      const decodedToken: any = jwt_decode(token);
      let roles = decodedToken['role'];
      if (!Array.isArray(roles)) {
        roles = [roles];
      }
      return roles;
    } else {
      return [];
    }
  }

  hasRole(role: Roles): boolean {
    return this.ngxRoleService.getRole(role) !== undefined;
  }

  setRoles() {
    this.getRolesFromJwt().forEach(
      el => this.ngxRoleService.addRole(el, [])
    );
  }

  isAuthenticated(): boolean {
    return Object.keys(this.ngxRoleService.getRoles()).length !== 0;;
  }

  flushRoles() {
    this.ngxRoleService.flushRoles();
  }
}