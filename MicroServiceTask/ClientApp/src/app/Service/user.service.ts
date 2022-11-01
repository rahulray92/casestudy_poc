import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user';



@Injectable({ providedIn: 'root' })
export class UserService {
  constructor(private http: HttpClient) { }

  getAll() {
    //     let JSONDatas = [
    //         {"id": 0,"username":"Rahul","password":"Rahul123","firstName":"Rahul","lastname":"Ray","token":""},
    //         {"id": 1,"username":"Raja","password":"Rahul124","firstName":"Raja","lastname":"Rai","token":""},
    //         {"id": 2,"username":"Ravi","password":"Rahul125","firstName":"Ravi","lastname":"Thakur","token":""},

    //     ]

    //     localStorage.clear();
    //     localStorage.setItem("users", JSON.stringify(JSONDatas));
    //    return JSON.stringify(JSONDatas);
    let apiUrl = "http://localhost:4200";
    return this.http.get<User[]>(`${apiUrl}/users`);
  }



  delete(id: number) {
    //return null;
    let apiUrl = "http://localhost:4200";
    return this.http.delete(`${apiUrl}/users/${id}`);
  }
}
