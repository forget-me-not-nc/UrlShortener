import { Component, OnInit } from '@angular/core';
import { MyLocalStorageService } from '../services/my.local.storage.service';
import { Router } from '@angular/router';
import { NgxPermissionsService } from 'ngx-permissions';

@Component({
  selector: 'app-logout-component',
  templateUrl: './logout.component.html'
})
export class LogoutComponent implements OnInit{

  constructor(private localStorageService: MyLocalStorageService,
              private permissionsService: NgxPermissionsService,
              private router: Router) {}

  ngOnInit(): void {
    this.permissionsService.flushPermissions();
    this.localStorageService.clear("jwt");
    this.router.navigate(['']);
  }
}