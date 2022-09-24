import { environment } from './../../environments/environment';
import { HttpClient } from "@angular/common/http";
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
  })
export class AuthService {
    public readonly httpClient: HttpClient;
  
    constructor(httpClient: HttpClient) {
        this.httpClient = httpClient;
    }
  
    public signIn(args?: any): Promise<any> {
      return this.httpClient.post(`${environment.baseURL}Authentication`, args).toPromise();
    }

}
