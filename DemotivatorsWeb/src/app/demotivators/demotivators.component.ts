import { Page, Demotivator } from './Demotivator';
import { Component, OnInit, Input } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';



@Component({
  selector: 'app-demotivators',
  templateUrl: './demotivators.component.html',
  styleUrls: ['./demotivators.component.css']
})
export class DemotivatorsComponent implements OnInit {

  Title2: any;
  @Input() MainPage$: Page;
  CurrentPage : number;

  constructor(private http: HttpClient) {
    this.Title2 = "dsds";
    this.MainPage$ = new Page();
    this.CurrentPage = 1;
  }

  ngOnInit() {
    this.getMainPage();
  }

  getMainPage() {
    this.getMainPageFromApi().subscribe(res => {
      this.MainPage$ = res
    })
  }

  getNextPage(){
    this.CurrentPage++;
    
    this.getMainPageFromApi().subscribe(res => {

      
      res.demotivatorCollection.forEach(element => {
        this.MainPage$.demotivatorCollection.unshift(element)
      });


  
      
    })
  }

  getMainPageFromApi(): Observable<Page> {
    return this.http.get<Page>('https://demotivatorwebapi.azurewebsites.net/api/demotivators/'+this.CurrentPage);
  }
}
