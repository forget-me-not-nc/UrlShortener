import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
// import { Injectable } from '@angular/core';
// import { Observable } from 'rxjs';
// import { ApiConfig } from '../config/api.config';
// import { RedirectModel } from '../models/redirct.model';

// @Injectable({
//   providedIn: 'root',
// })
// export class RedirectService {
//   constructor(private http: HttpClient) { }

//   redirect(body: RedirectModel): Observable<void> {
//     const params = new HttpParams()
//       .set('aliasSlug', body.aliasSlug)
//       .set('slug', body.slug);
  
//     return this.http.get<void>(ApiConfig.REDIRECT_API, { params });
//   }
// }