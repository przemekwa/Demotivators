import { Page, Demotivator } from './Demotivator';
import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';


@Component({
  selector: 'app-demotivators',
  templateUrl: './demotivators.component.html',
  styleUrls: ['./demotivators.component.css']
})
export class DemotivatorsComponent implements OnInit {

  Title2:any;

  constructor(private http: Http) { 
this.Title2 = "dsds";

  }

  ngOnInit() {
  }




}
