import { Component, OnInit, Input } from '@angular/core';
import { Page } from './Jbzdy';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { FatvoritesService } from '../fatvorites.service';
import { AppComponent } from '../app.component';

@Component({
  selector: 'app-jbzdy',
  templateUrl: './jbzdy.component.html',
  styleUrls: ['./jbzdy.component.css']
})
export class JbzdyComponent implements OnInit {
  public loading = false;
  public loadingScroll = false;
  @Input() MainPage$: Page = new Page();
  @Input() nsfw: boolean;
  CurrentPage: number;


  constructor(private http: HttpClient, route: ActivatedRoute, private favoritesService: FatvoritesService, private appC: AppComponent) {
    route.params.subscribe(params => {
      if (params['pageNumber'] !== undefined) {
        this.CurrentPage = params['pageNumber'];
        this.MainPage$.jbzdyModels = [];
        this.getMainPage();
     } else {
       this.CurrentPage = 1;
     }
   });
    this.getMainPage();
  }

  ngOnInit() {

  }

  getMainPage() {
    this.loading = true;

    const dataFromApi = this.appC.nsfw ? this.getNsfwPageFromApi() : this.getMainPageFromApi();

    dataFromApi.subscribe(res => {
      this.MainPage$ = res;
      this.loading = false;
    });
  }

  onScroll() {
    console.log(this.appC.nsfw);
    this.loadingScroll = true;
    window.history.replaceState({}, '', `/jbzdy/${this.CurrentPage}`);
    this.CurrentPage++;
    const dataFromApi = this.appC.nsfw ? this.getNsfwPageFromApi() : this.getMainPageFromApi();

    dataFromApi.subscribe(res => {
        res.jbzdyModels.forEach(element => {
          this.MainPage$.jbzdyModels.push(element);
        });
        this.loadingScroll = false;
      });
  }

  getNextPage() {
    console.log(this.appC.nsfw);
    this.CurrentPage++;
    this.loading = true;
    const dataFromApi = this.appC.nsfw ? this.getNsfwPageFromApi() : this.getMainPageFromApi();

    dataFromApi.subscribe(res => {
      res.jbzdyModels.forEach(element => {
        this.MainPage$.jbzdyModels.unshift(element);
        this.loading = false;
      });
    });
  }


  getMainPageFromApi(): Observable<Page> {
    return this.http.get<Page>('http://www.demotivatorapi.hostingasp.pl/api/jbzdy/' + this.CurrentPage);
  }

  getNsfwPageFromApi(): Observable<Page> {
    return this.http.get<Page>('http://www.demotivatorapi.hostingasp.pl/api/jbzdy/login/' + this.CurrentPage);
  }


  addFavorites(imgUrl: string) {
    this.favoritesService.addFavorites(imgUrl);
  }

}
