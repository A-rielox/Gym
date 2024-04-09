import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { SharedModule } from './_shared/shared.module';
import { PrimeModule } from './_prime/prime.module';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { ClasesModule } from './sections/clases/clases.module';
import { HomeModule } from './sections/home/home.module';

@NgModule({
   declarations: [AppComponent],
   imports: [
      BrowserModule,
      AppRoutingModule,
      BrowserAnimationsModule,
      HttpClientModule,
      SharedModule,
      PrimeModule,
      //
      ClasesModule,
      HomeModule,
   ],
   providers: [
      { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
   ],
   bootstrap: [AppComponent],
})
export class AppModule {}
