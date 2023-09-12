import { Component } from '@angular/core';
import { LoginModel } from '../models/login.model';
import { AuthService } from '../services/auth.service';
import { MyLocalStorageService } from '../services/my.local.storage.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-component',
  templateUrl: './login.component.html'
})
export class LoginComponent {
  loginModel = new LoginModel();

  constructor(private authService: AuthService,
              private localStorageService: MyLocalStorageService,
              private router: Router) {}

  submit() {
    this.authService.login(this.loginModel).subscribe(
      (resp) => {
        this.localStorageService.clear("jwt");
        this.localStorageService.setPair("jwt", resp.jwtToken)
        this.router.navigate(['']);
      }
    );
  }
}
