import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../models/user';




@Injectable({
  providedIn: 'root'
})
export class AuthenticationServiceService {
  //private url = "api/v1//login";
  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;
  public apiUrl = "http://localhost:4200/api";
  constructor(private http: HttpClient) {
    this.currentUserSubject = new BehaviorSubject<User>(sessionStorage.getItem('currentUser') == null ? '' : JSON.parse(sessionStorage.getItem('currentUser') || ''));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): User {
    return this.currentUserSubject.value;
  }

  login(username: any, password: any): Observable<any> {
    // let users = JSON.parse(localStorage.getItem('users') || '');
    // const user = users.find(x => x.username === username && x.password === password);

    //     localStorage.setItem('currentUser', JSON.stringify(user));
    //    this.currentUserSubject.next(user);
    //     return user;
    let url = this.apiUrl + '/login';
    
    const headers = new HttpHeaders()
      .set('Access-Control-Allow-Origin', '*');
    headers.set("Access-Control-Allow-Methods", "GET , PUT , POST , DELETE");
    headers.set("Access-Control-Allow-Headers", "Content-Type, x-requested-with");
    headers.set('Content-Type', 'application/json');
    let data = { 'username': username, 'password':password };
    return this.http.post<any>(url,data, {
      headers: headers
    })
      .pipe(map(user => {
        // store user details and jwt token in local storage to keep user logged in between page refreshes
        sessionStorage.setItem('currentUser', JSON.stringify(user));
        this.currentUserSubject.next(user);
        return user;
      }));
  }

  logout() {
    // remove user from local storage and set current user to null
    sessionStorage.removeItem('currentUser');
    const userJson = sessionStorage.getItem('currentUser');
    this.currentUserSubject.next(userJson !== null ? JSON.parse(userJson) : new User());
    //this.currentUserSubject.next(null);
  }
}
