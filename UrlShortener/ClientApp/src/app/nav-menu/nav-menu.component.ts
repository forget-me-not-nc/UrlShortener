import { Component } from '@angular/core';
import { MyRoleService } from '../services/role.service';
import { MyLocalStorageService } from '../services/my.local.storage.service';
import { LocalStorageConfig } from '../config/local.storage.config';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent{
  isExpanded = false;
  
  constructor(private roleService: MyRoleService,
              private localStorageService: MyLocalStorageService) {}

  isAuthenticated(): boolean {
    return this.roleService.isAuthenticated();
  }

  getUsername(): string {
    return this.localStorageService.get(LocalStorageConfig.USERNAME);
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
