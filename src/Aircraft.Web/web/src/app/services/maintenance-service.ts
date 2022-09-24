import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Maintenance } from '../models/maintenance';

@Injectable()
export class MaintenanceService {

    httpOptions = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        })
      }

    constructor(private httpClient : HttpClient)
    {
    }

    get(userId : string): Observable<Maintenance[]>
    {
        return this.httpClient.get<Maintenance[]>(`${environment.baseURL}Maintenance?userId=${userId}`);
    }

    post(request : Maintenance) {
        return this.httpClient.post<Maintenance>(`${environment.baseURL}Maintenance`, JSON.stringify(request), this.httpOptions)
    }
}