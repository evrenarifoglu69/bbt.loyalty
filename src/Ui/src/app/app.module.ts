import {NgModule, LOCALE_ID} from '@angular/core';
import {registerLocaleData} from '@angular/common';
import localeTR from '@angular/common/locales/tr';
import {BrowserModule} from '@angular/platform-browser';
import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {LoginComponent} from "./screens/login/login.component";
import {DefaultLayoutComponent} from "./layouts/default-layout/default-layout.component";
import {HeaderComponent} from "./components/header/header.component";

registerLocaleData(localeTR);

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    DefaultLayoutComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [{ provide: LOCALE_ID, useValue: 'tr-TR'}],
  exports: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
