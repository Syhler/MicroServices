import {Component} from '@angular/core';
import {OidcSecurityService} from "angular-auth-oidc-client";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Client';

  constructor(public oidcSecurityService: OidcSecurityService)
  {
    this.oidcSecurityService.checkAuth().subscribe((auth) => {console.log("Is Authenticated " + auth)})
  }

  signIn(): void {
    this.oidcSecurityService.authorize()
  }

  sendEmail(): void {

  }


}


