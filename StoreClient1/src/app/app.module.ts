import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HeaderComponent} from './shared/components/header/header.component';
import { Interceptor } from './shared/Interceptors/interceptor';
import { CookieService } from 'ngx-cookie-service';
import { AuthenticationService } from './shared/services/AuthenticationService';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: Interceptor,
      multi: true
    },
    CookieService,
    AuthenticationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
