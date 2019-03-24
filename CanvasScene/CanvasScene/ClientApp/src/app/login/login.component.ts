import { Component, OnInit } from '@angular/core';
import { User } from '../model/user';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  private user: User;

  private registered: boolean = false;

  private error: string = '';

  constructor(private authService: AuthService, private router: Router) {
    this.user = new User('', '');
  }

  ngOnInit() {
  }

  login() {
    this.error = '';
    this.authService.login(this.user).subscribe(
      result => {
        if (result) {
          this.router.navigate(['/']);
        }
      },
      err => this.handleError(err));
  }

  register() {
    this.error = '';
    this.authService.register(this.user).subscribe(
        result => {         
          if (result) {
            this.registered = true;
            this.router.navigate(['/login']);             
        }
      }, err => this.handleError(err));
  }

  private handleError(err) {
    console.log(err); this.error = 'Произошла ошибка'; 
  }
}
