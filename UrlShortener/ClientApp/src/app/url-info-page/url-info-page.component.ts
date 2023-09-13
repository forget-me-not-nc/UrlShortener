import { Component } from '@angular/core';
import { ActivatedRoute, ParamMap, Route, Router } from '@angular/router';
import { Url } from '../models/url.model';
import { UrlService } from '../services/url.service';
import { Roles } from '../models/roles';
import { MyRoleService } from '../services/role.service';
import { MyLocalStorageService } from '../services/my.local.storage.service';
import { LocalStorageConfig } from '../config/local.storage.config';
import { UpdateUrlModel } from '../models/update.url.model';

@Component({
  selector: 'app-url-info-page',
  templateUrl: './url-info-page.component.html',
  styleUrls: ['./url-info-page.component.css']
})
export class UrlInfoPageComponent
{
  url: Url = {
    id: 0,
    userId: 0,
    userName: "",
    baseUrl: "",
    slug: "",
    createdAt: new Date(),
    modifiedAt: new Date(),
    description: "",
    domain: "",
  }

  areChangesMade: boolean = false;
  Roles = Roles;

  constructor(private activeRoute: ActivatedRoute,
              private router: Router,
              private urlService: UrlService,
              private roleService: MyRoleService,
              private localStorageService: MyLocalStorageService) { }

  ngOnInit(): void {
    this.activeRoute.paramMap.subscribe((params: ParamMap) => {
      const id = params.get('id');
      if (id !== null) {
        const idParam = +id; 
        this.urlService.get(idParam).subscribe((resp) => {
          this.url = resp;
        });
      }
    });
  }

  isAdmin(): boolean {
    return this.roleService.hasRole(Roles.ADMIN);
  }

  isUrlCreator(): boolean {
    return this.localStorageService.get(LocalStorageConfig.USER_ID) === this.url.userId;
  }

  onInputChange() {
    this.areChangesMade = true;
  }

  saveChanges() {
    const updateModel: UpdateUrlModel = {
      id: this.url.id,
      description: this.url.description,
      baseUrl: this.url.baseUrl,
    };
    this.urlService.update(updateModel).subscribe((resp) => {
      this.url = resp;
    });
  }

  delete() {
    this.urlService.delete(this.url.id).subscribe((resp) => {
      this.router.navigate(['/my']);
    });
  }
}