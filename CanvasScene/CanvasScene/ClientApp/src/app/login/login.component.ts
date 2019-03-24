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

  constructor(private authService: AuthService, private router: Router) {
    this.user = new User('', '');
  }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.user).subscribe(
      result => {
        if (result) {
          this.router.navigate(['/']);
        }
      });
  }

  register() {
    this.authService.register(this.user).subscribe(
        result => {         
          if (result) {
            this.router.navigate(['/login']);             
          }
        });
  }
}
