import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { ApiConfig } from "../config/api.config";
import { AboutModel } from "../models/about.model";

@Injectable({
  providedIn: 'root',
})
export class AboutService {
  constructor(private http: HttpClient) {}

  getAboutContent(): Observable<AboutModel> {
    return this.http.get<AboutModel>(ApiConfig.ABOUT_API);
  }

  storeAboutContent(body: AboutModel): Observable<void> {
    return this.http.put<void>(ApiConfig.ABOUT_API, body);
  }
}