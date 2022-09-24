import {Injectable} from '@angular/core';
import {JwtHelperService} from '@auth0/angular-jwt';
import { StorageKeys } from 'src/app/storage/storage-keys';

@Injectable()
export class AuthenticationService {
  constructor(public jwtHelper: JwtHelperService) {
  }


  public isAuthenticated(): boolean {
    const token = localStorage.getItem(StorageKeys.AUTH_TOKEN);
    return !this.jwtHelper.isTokenExpired(token?.toString());
  }
}
