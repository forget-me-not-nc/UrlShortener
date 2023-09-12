import { Component, OnInit } from '@angular/core';
import { Url } from '../models/url.model';
import { UrlService } from '../services/url.service';
//import { RedirectService } from '../services/redirect.service';
import { RedirectModel } from '../models/redirct.model';
import { NgxPermissionsService } from 'ngx-permissions';
import { PermissionService } from '../services/permission.service';

@Component({
  selector: 'app-urls-table',
  templateUrl: './urls-table.component.html',
  styleUrls:['./urls-table.component.css'],
})
export class UrlsTableComponent implements OnInit {
  urls: Url[] = [];

  constructor(private urlService: UrlService,
              //private redirectService: RedirectService,
              private permissionsService: NgxPermissionsService,
              private myPermissionsService: PermissionService) { }
  
  ngOnInit(): void {
    this.urlService.getAll().subscribe((resp) => {
     this.urls = resp;
    });

    const roles = this.myPermissionsService.getRoles();
    this.permissionsService.loadPermissions(roles);
    console.log(this.permissionsService.getPermissions());
  }

  redirect(slug: string, aliasSLug: string) {
    // const redirectModel = new RedirectModel();
    // redirectModel.aliasSlug = aliasSLug;
    // redirectModel.slug = slug;
    // this.redirectService.redirect(redirectModel).subscribe();
  }
}
