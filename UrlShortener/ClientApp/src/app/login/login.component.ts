import { Component } from '@angular/core';
import { LoginModel } from '../models/login.model';
import { AuthService } from '../services/auth.service';
import { MyLocalStorageService } from '../services/my.local.storage.service';
import { Router } from '@angular/router';
import { MyRoleService } from '../services/role.service';
import { LocalStorageConfig } from '../config/local.storage.config';

@Component({
  selector: 'app-login-component',
  templateUrl: './login.component.html'
})
export class LoginComponent {
  loginModel = new LoginModel();

  constructor(private authService: AuthService,
              private localStorageService: MyLocalStorageService,
              private roleService: MyRoleService,
              private router: Router) {}

  submit() {
    this.authService.login(this.loginModel).subscribe(
      (resp) => {
        this.localStorageService.setPair(LocalStorageConfig.JWT, resp.jwtToken);
        this.localStorageService.setPair(LocalStorageConfig.USERNAME, resp.username);
        this.localStorageService.setPair(LocalStorageConfig.USER_ID, resp.userId);
        this.roleService.setRoles();
        this.router.navigate(['/my']);
      }
    );
  }
}
