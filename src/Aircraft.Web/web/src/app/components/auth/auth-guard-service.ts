import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { AuthenticationService } from "./authentication-service";

@Injectable()
export class AuthGuardService implements CanActivate {
  constructor(public auth: AuthenticationService, public router: Router) {
  }

  canActivate(): boolean {

    if (!this.auth.isAuthenticated()) {
      this.router.navigate(['/auth']);

      return false;
    }

    return true;
  }
}
