import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { FiguresService } from './services/figures.service';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { GridModule } from '@progress/kendo-angular-grid';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { KonvaModule } from 'ng2-konva';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './authGuard';
import { AuthService } from './services/auth.service';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, canActivate: [AuthGuard] },
      { path: 'login', component: LoginComponent },
    ]),
    GridModule,
    BrowserAnimationsModule,
    KonvaModule
  ],
  providers: [FiguresService, AuthService, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
