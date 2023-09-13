import { Component } from '@angular/core';
import { UrlService } from '../services/url.service';
import { MyLocalStorageService } from '../services/my.local.storage.service';
import { Url } from '../models/url.model';
import { LocalStorageConfig } from '../config/local.storage.config';

@Component({
  selector: 'app-my-urls-page',
  templateUrl: './my-urls-page.component.html',
  styleUrls: ['./my-urls-page.component.css']
})
export class MyUrlsPageComponent{
  list: Url[] = [];

  constructor(
    private urlsService: UrlService,
    private localStorage: MyLocalStorageService) 
  {
    this.retrieveUrls();
  }

  retrieveUrls() {
    this.urlsService.getAllByUserId(this.localStorage.get(LocalStorageConfig.USER_ID)).subscribe((resp) => {
      this.list = resp;
    });
  }
}