import { Page } from './Demotivator';
import { Component, OnInit, Input } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';



@Component({
  selector: 'app-demotivators',
  templateUrl: './demotivators.component.html',
  styleUrls: ['./demotivators.component.css']
})
export class DemotivatorsComponent implements OnInit {
  public loading = false;
  public loadingScroll = false;
  Title2: any;
  @Input() MainPage$: Page = new Page();
  public CurrentPage : number;

  constructor(private http: HttpClient) {
    this.loading = true;
    this.CurrentPage = 1;
    this.loading = true;
    this.getMainPage();
  }

  ngOnInit() {
  
  }

  getMainPage() {
    this.loading = true;
    this.getMainPageFromApi().subscribe(res => {
      this.MainPage$ = res
      this.loading = false;
    })
  }



  onScroll() {
    this.loadingScroll = true;
    this.CurrentPage++;
    this.getMainPageFromApi().subscribe(res => {
        res.demotivatorCollection.forEach(element => {
          this.MainPage$.demotivatorCollection.push(element)
        });
        this.loadingScroll = false;   
      })
  }

  getNextPage(){
    this.CurrentPage++;
    this.loading = true;
    this.getMainPageFromApi().subscribe(res => {
      res.demotivatorCollection.forEach(element => {
        this.MainPage$.demotivatorCollection.unshift(element)
        this.loading = false;
      });
    })
  }

  getMainPageFromApi(): Observable<Page> {
    return this.http.get<Page>('https://demotivatorwebapi.azurewebsites.net/api/demotivators/'+this.CurrentPage);
  }
}
