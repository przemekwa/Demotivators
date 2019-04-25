import { Component, OnInit, Input } from '@angular/core';
import { Page } from './Jbzdy';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-jbzdy',
  templateUrl: './jbzdy.component.html',
  styleUrls: ['./jbzdy.component.css']
})
export class JbzdyComponent implements OnInit {
  public loading = false;
  public loadingScroll = false;
  @Input() MainPage$: Page = new Page();
  CurrentPage : number;


  constructor(private http: HttpClient, route: ActivatedRoute) {
    route.params.subscribe(params => {
      this.CurrentPage = params['pageNumber'] === undefined ? 1 : params['pageNumber'];
   });
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
        res.jbzdyModels.forEach(element => {
          this.MainPage$.jbzdyModels.push(element)
        });
        this.loadingScroll = false;
      })
  }

  getNextPage(){
    this.CurrentPage++;
    this.loading = true;
    this.getMainPageFromApi().subscribe(res => {
      res.jbzdyModels.forEach(element => {
        this.MainPage$.jbzdyModels.unshift(element)
        this.loading = false;
      });
    })
  }


  getMainPageFromApi(): Observable<Page> {
    return this.http.get<Page>('http://www.demotivatorapi.hostingasp.pl/api/jbzdy/'+this.CurrentPage);
  }

}
