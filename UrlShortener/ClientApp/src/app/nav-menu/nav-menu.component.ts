import { Component, OnInit } from '@angular/core';
import { NgxPermissionsService } from 'ngx-permissions';
import { PermissionService } from '../services/permission.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  
  constructor(
    public permissionsService: NgxPermissionsService,
    private myPermissionsService: PermissionService
    ) {}

  ngOnInit(): void {
    const roles = this.myPermissionsService.getRoles();
    this.permissionsService.loadPermissions(roles)
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
