import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {

  session = this.uppercase(window.sessionStorage.getItem('currentUser'));


  constructor(
    private authService: AuthService
  ) { }

  Logout() {
    this.authService.logout();
  }

  uppercase(user){
    return user?.toUpperCase();
  }

}
