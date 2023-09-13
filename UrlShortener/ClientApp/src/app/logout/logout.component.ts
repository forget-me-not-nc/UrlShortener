import { Component, OnInit } from '@angular/core';
import { MyLocalStorageService } from '../services/my.local.storage.service';
import { Router } from '@angular/router';
import { NgxPermissionsService } from 'ngx-permissions';
import { MyRoleService } from '../services/role.service';
import { LocalStorageConfig } from '../config/local.storage.config';

@Component({
  selector: 'app-logout-component',
  templateUrl: './logout.component.html'
})
export class LogoutComponent implements OnInit{

  constructor(private localStorageService: MyLocalStorageService,
              private roleService: MyRoleService,
              private router: Router) {}

  ngOnInit(): void {
    this.roleService.flushRoles();
    this.localStorageService.clear(LocalStorageConfig.USER_ID);
    this.localStorageService.clear(LocalStorageConfig.USERNAME);
    this.localStorageService.clear(LocalStorageConfig.JWT);
    this.router.navigate(['']);
  }
}