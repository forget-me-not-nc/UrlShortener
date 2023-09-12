import { Injectable } from "@angular/core";
import { LocalStorageService } from "ngx-webstorage";

@Injectable({
  providedIn: 'root',
})
export class MyLocalStorageService {

  constructor(private storage: LocalStorageService) {}

  setPair(key: any, value: any): void {
    this.storage.store(key, value);
  }

  get(key: any): any {
    return this.storage.retrieve(key);
  }

  clear(key: any): any {
    this.storage.clear(key);
  }
}
 

  