import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { DialogModule } from 'primeng/dialog';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { UrlsTableComponent } from './urls-table/urls-table.component';
import { LoginComponent } from './login/login.component';
import { NgxWebstorageModule } from 'ngx-webstorage';
import { NgxPermissionsModule } from 'ngx-permissions';
import { LogoutComponent } from './logout/logout.component';
import { MainPageComponent } from './main-page/main-page.component';
import { MyUrlsPageComponent } from './my-urls-page/my-urls-page.component';
import { JwtInterceptor } from './services/jwt.interceptor';
import { JwtModule } from '@auth0/angular-jwt';
import { DynamicDialogModule } from 'primeng/dynamicdialog';
import { ConfirmPopupModule } from 'primeng/confirmpopup';
import { ConfirmationService } from 'primeng/api';
import { CreateDialogComponent } from './upsert-dialog/create-dialog.component';
import { UrlInfoPageComponent } from './url-info-page/url-info-page.component';
import { FormsModule } from '@angular/forms';
import { AboutPageComponent } from './about-page/about-page.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    UrlsTableComponent,
    LoginComponent,
    MainPageComponent,
    MyUrlsPageComponent,
    CreateDialogComponent,
    UrlInfoPageComponent,
    AboutPageComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    DialogModule,
    JwtModule,
    HttpClientModule,
    ConfirmPopupModule,
    DynamicDialogModule,
    NgxPermissionsModule.forRoot(),
    NgxWebstorageModule.forRoot(),
    RouterModule.forRoot([
      { path: '', component: MainPageComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'logout', component: LogoutComponent },
      { path: 'my', component: MyUrlsPageComponent },
      { path: 'info/:id', component: UrlInfoPageComponent },
      { path: 'about', component: AboutPageComponent }
    ])
  ],
  providers: [
    ConfirmationService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true,
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
