import { Component, Input, OnInit } from '@angular/core';
import { Url } from '../models/url.model';
import { Roles } from '../models/roles'
import { RedirectService } from '../services/redirect.service';
import { MyRoleService } from '../services/role.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-urls-table',
  templateUrl: './urls-table.component.html',
  styleUrls:['./urls-table.component.css'],
})
export class UrlsTableComponent {
  @Input() urls: Url[] = [];
  @Input() showActions: boolean;

  public Roles = Roles;

  constructor(private redirectService: RedirectService,
              public roleService: MyRoleService,
              private router: Router) { }

  generateRedirect(slug: string) {
    return this.redirectService.generateRedirectUrl(slug);
  }

  navigateToUrlInfo(id: number) {
    this.router.navigate(['/info', id]);
  }
}
