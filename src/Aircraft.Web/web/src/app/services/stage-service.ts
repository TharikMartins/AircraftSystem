import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Maintenance } from '../models/maintenance';
import { Stage } from '../models/stage';

@Injectable()
export class StageService {

    httpOptions = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        })
      }

    constructor(private httpClient : HttpClient)
    {
    }

    post(request : Stage[]) {
        return this.httpClient.post<Stage>(`${environment.baseURL}Stage`, JSON.stringify(request), this.httpOptions)
    }
    
    get(maintenaceId : string): Observable<Stage[]>
    {
        return this.httpClient.get<Stage[]>(`${environment.baseURL}Stage?maintenanceId=${maintenaceId}`);
    }
}