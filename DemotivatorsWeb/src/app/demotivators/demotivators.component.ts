import { Page, Demotivator } from './Demotivator';
import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';



@Component({
  selector: 'app-demotivators',
  templateUrl: './demotivators.component.html',
  styleUrls: ['./demotivators.component.css']
})
export class DemotivatorsComponent implements OnInit {

  Title2:any;
  MainPage$: Page;

  constructor(private http: HttpClient) { 
this.Title2 = "dsds";
this.MainPage$ = new Page();

  }

  ngOnInit() {
    this.getMainPage();


  }

  getMainPage() {
    this.getMainPageFromApi().subscribe(res=>{

      this.MainPage$ = res

    })
  }


  getMainPageFromApi():Observable<Page> {
    return this.http.get<Page>('https://demotivatorwebapi.azurewebsites.net/api/demotivators/2');
  }




}
