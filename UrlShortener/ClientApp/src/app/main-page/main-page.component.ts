import { Component } from '@angular/core';
import { UrlService } from '../services/url.service';
import { Url } from '../models/url.model';
import { Roles } from '../models/roles';
import { MyRoleService } from '../services/role.service';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.html']
})
export class MainPageComponent {
  list: Url[] = [];
  public Roles = Roles;

  constructor(private urlsService: UrlService,
              public roleService: MyRoleService) 
  {
    this.retrieveUrls();
  }

  retrieveUrls() {
    this.urlsService.getAll().subscribe((resp) => {
      this.list = resp;
    });
  }

  updateList(url: Url) {
    this.list.push(url);
  }
}