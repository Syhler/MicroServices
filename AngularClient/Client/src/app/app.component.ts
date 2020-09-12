import {Component} from '@angular/core';
import {OidcSecurityService} from "angular-auth-oidc-client";
import {HttpClient, HttpHeaders} from "@angular/common/http";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Client';

  constructor(public oidcSecurityService: OidcSecurityService, public http: HttpClient) {
    this.oidcSecurityService.checkAuth().subscribe((auth) => {
      console.log("Is Authenticated " + auth)
    })
  }

  signIn(): void {
    this.oidcSecurityService.authorize()
  }



  sendEmail(): void {
    const token = this.oidcSecurityService.getToken();

    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + token
      })
    };


    const body = new FormData();
    body.append('Email', 'morten.syhler@gmail.com');
    body.append('Message', 'Hey med dig');

    this.http.post(
      "https://localhost:5050/email/send",
      body, httpOptions).subscribe(x => console.log(x))

  }


}


