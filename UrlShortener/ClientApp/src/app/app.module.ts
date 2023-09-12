import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { DialogModule } from 'primeng/dialog';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { UrlsTableComponent } from './main-page/urls-table.component';
import { LoginComponent } from './login/login.component';
import { NgxWebstorageModule } from 'ngx-webstorage';
import { JwtInterceptor, JwtModule } from '@auth0/angular-jwt';
import { NgxPermissionsModule } from 'ngx-permissions';
import { LogoutComponent } from './logout/logout.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    UrlsTableComponent,
    LoginComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    DialogModule,
    JwtModule,
    NgxPermissionsModule.forRoot(),
    NgxWebstorageModule.forRoot(),
    RouterModule.forRoot([
      { path: '', component: UrlsTableComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'logout', component: LogoutComponent },
    ])
  ],
  providers: [
  //   {
  //     provide: HTTP_INTERCEPTORS,
  //     useClass: JwtInterceptor,
  //     multi: true,
  //   },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
