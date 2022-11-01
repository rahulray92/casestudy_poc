import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../models/user';

  @Injectable({
    providedIn: 'root'
  })
  export class TaskService {
    //private url = "api/v1//login";

    private url = "/projectmgmt/api/v1/member/list";
    private updateAlloctionurl = "/projectmgmts/api/v1/manager/update";
    public apiUrl = "http://localhost:4200";
    constructor(private http: HttpClient) {

    }



    taskview(deliverables: any, taskName: any, taskstartDate: any, taskendDate: any, memberId: any): Observable<any> {
      let url = this.apiUrl + this.url;
      if (memberId != null)
        this.url.replace('{memberId}', memberId)
      const headers = new HttpHeaders()
        .set('Access-Control-Allow-Origin', '*');
      headers.set("Access-Control-Allow-Methods", "GET , PUT , POST , DELETE");
      headers.set("Access-Control-Allow-Headers", "Content-Type, x-requested-with");
      headers.set('Content-Type', 'application/json');
      let data = {
        'Deliverables': deliverables,
        'TaskName': taskName,
        'TaskstartDate': taskstartDate,
        'TaskendDate': taskendDate
      };



      return this.http.post<any>(url, data, {
        headers: headers
      })
        .pipe(map(user => {
          // store user details and jwt token in local storage to keep user logged in between page refreshes

          return user;
        }));
    }

    updateAllocation(allocationpercentage: number,memberId: number): Observable<any> {
      let url = this.apiUrl + this.updateAlloctionurl;
      //if (allocationpercentage != null)
      //  this.url.replace('{allocationpercentage}', allocationpercentage)
      const headers = new HttpHeaders()
        .set('Access-Control-Allow-Origin', '*');
      headers.set("Access-Control-Allow-Methods", "GET , PUT , POST , DELETE");
      headers.set("Access-Control-Allow-Headers", "Content-Type, x-requested-with");
      headers.set('Content-Type', 'application/json');
      let data = {
        'memberId': memberId,
        'allocationPercentage': allocationpercentage     
      };

      return this.http.post<any>(url,data, {
        headers: headers
      })
        .pipe(map(user => {
          // store user details and jwt token in local storage to keep user logged in between page refreshes

          return user;
        }));
    }


  }

