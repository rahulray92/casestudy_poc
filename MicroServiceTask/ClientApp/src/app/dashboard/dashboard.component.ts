import { Component, OnInit } from '@angular/core';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { first } from 'rxjs';
import { User } from '../models/user';
import { AuthenticationServiceService } from '../Service/authentication-service.service';
import { UserService } from '../Service/user.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  currentUser: User;
  users: any = [];
  search: string = '';
  isprofile: boolean = false;
  htmlTrustUrl: SafeUrl; currentRoute: string;
  isAccessRole: boolean = false;
  constructor(
    private authenticationService: AuthenticationServiceService,
    private userService: UserService,
    private sanitizer: DomSanitizer,
    private router: Router
  ) {
    this.currentRoute = router.url;
    this.currentUser = this.authenticationService.currentUserValue;
    this.htmlTrustUrl = this.sanitizer.bypassSecurityTrustResourceUrl("#");
    if (this.currentUser != undefined && this.currentUser.role == 'admin')
      this.isAccessRole = true;
  }

  ngOnInit() {
    this.loadAllUsers();
  }

  deleteUser(id: number) {
    this.userService.delete(id)
      .pipe(first())
      .subscribe(() => this.loadAllUsers());
  }

  private loadAllUsers() {
    this.userService.getAll()
      .pipe(first())
      .subscribe(users => this.users = users);
  }
  onProfile() {
    if (!this.isprofile)
      this.isprofile = true;
    else
      this.isprofile = false;
  }

}
