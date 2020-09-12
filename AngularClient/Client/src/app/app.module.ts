import {BrowserModule} from '@angular/platform-browser';
import {APP_INITIALIZER, NgModule} from '@angular/core';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {AuthModule, LogLevel, OidcConfigService} from "angular-auth-oidc-client";
import {HttpClientModule} from "@angular/common/http";


export function configureAuth(odicConfigService :   OidcConfigService) : Function
{
  return () => odicConfigService.withConfig(
    {
      stsServer: "https://localhost:5000",
      redirectUrl: window.location.origin,
      postLogoutRedirectUri: window.location.origin,
      responseType: "code",
      clientId: "angular_client",
      scope: "openid emailService profile",
      logLevel: LogLevel.Debug,
    }
  )
}



@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AuthModule.forRoot(),
    HttpClientModule
  ],
  providers: [
    OidcConfigService,
    {
      provide: APP_INITIALIZER,
      useFactory: configureAuth,
      deps: [OidcConfigService],
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
