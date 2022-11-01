import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, NavigationEnd, ActivatedRoute, Params } from '@angular/router';
import { Subscription } from 'rxjs';
import { User } from '../models/user';
import { AuthenticationServiceService } from '../Service/authentication-service.service';
import { ToastrService } from 'ngx-toastr';
import { TaskService } from '../Service/taskservice';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements OnInit, OnDestroy {

  search: string = '';
  searchDetails: any;
  taskData:any;
  isPopup: boolean = false; editTaskForm: FormGroup; submitted = false; taskList: Array<any> = [];
  message: string = ''; currentRoute: string; currentUser: User; isAccessRole: boolean = false;
  paramSubscription: Subscription;
  deliverables: string = '';
  taskstartDate = '';
  taskendDate = '';
  taskName = ''; memberId: any;

  constructor(private router: Router, private route: ActivatedRoute,
    private authenticationService: AuthenticationServiceService,private taskService:TaskService, private formBuilder: FormBuilder, private toastr: ToastrService) {
    console.log(router.url);
    this.currentRoute = router.url;
    this.currentUser = this.authenticationService.currentUserValue;
    this.currentUser.role = 'manager';
    if (this.currentUser != undefined && this.currentUser.role == 'manager')
      this.isAccessRole = true;

  }

  ngOnInit(): void {
    this.TaskView();
    this.paramSubscription = this.route.params.subscribe((params: Params) => {
      console.log(params);
    })
    this.taskData = sessionStorage.getItem('taskList') == null ? null : JSON.parse(sessionStorage.getItem('taskList') || '');

    
  }

  // convenience getter for easy access to form fields
  get f() { return this.editTaskForm.controls; }

  searchloan() {
    this.message = '';
    //this.searchDetails=this.loanData.find(x=>x.loanId==this.search);
    if (this.searchDetails == undefined)
      this.message = "Records not found";
  }
  onChange(event:any) {
    this.message = '';
    this.searchDetails = undefined;
    if (event.key.length > 0 && event.key != 'Backspace') {
      this.searchDetails = event.key;
    }
    else {
      if (this.searchDetails == undefined) {
        if (event.key == 'Backspace')

          this.message = "Records not found";
      }

    }
    console.log(event);
    console.log(event.target);
    // if ((event.target as HTMLInputElement).files && (event.target as HTMLInputElement).files.length) {
    //   const [file] = event.target.files;
    // }
  }
  edit(memberId: any) {

    let taskDetails = this.taskList.find(x => x.memberId == memberId);
    this.editTaskForm = this.formBuilder.group({
      allocationPercentage: [taskDetails.allocationPercentage, Validators.required],
      memberId: [taskDetails.memberId]
    });
    if (!this.isPopup)
      this.isPopup = true;
    else
      this.isPopup = false;

  }
  onUpdate() {
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();
    let datetoday = mm + '/' + dd + '/' + yyyy;
   
   
    this.taskService.updateAllocation(this.f['allocationPercentage'].value, this.f['memberId'].value)
      .subscribe(data => {
        console.log(data);
      });
   
    this.submitted = true;
    this.isPopup = false;
    this.toastr.success('Updated succesfully!');
    this.search = '';
    this.searchDetails = undefined;
    this.TaskView();
  }
  close() {
    this.isPopup = false;
  }
  ngOnDestroy(): void {
    this.paramSubscription.unsubscribe();
  }
  TaskView() {
    this.message = '';
    this.taskService.taskview(this.deliverables, this.taskName, this.taskstartDate, this.taskendDate, this.memberId)
      .subscribe(data => {
        if (data.data != null)
          this.taskList = data.data;
        if (data.data.length==0)
          this.message = "There are no any record exists."
      })
  }

}
