import { Page } from './Demotivator';
import { Component, OnInit, Input } from '@angular/core';
import {
  HttpClient,
  HttpHeaders,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { FatvoritesService } from '../fatvorites.service';

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
  public CurrentPage: number;

  constructor(private http: HttpClient, route: ActivatedRoute, private favoritesService: FatvoritesService, private router: Router) {
    route.params.subscribe(params => {
      if (params['pageNumber'] !== undefined) {
        this.CurrentPage = params['pageNumber'];
        this.MainPage$.demotivators = [];
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
    this.getMainPageFromApi().subscribe(res => {
      if (this.MainPage$.demotivators === undefined) {
        this.MainPage$.demotivators = [];
      }

      res.demotivatorCollection.forEach(element => {
        this.MainPage$.demotivators.push(element);
      });

      res.demotivatorVideoCollection.forEach(element => {
        this.MainPage$.demotivators.push(element);
      });
      this.loading = false;
    });
  }

  onScroll() {
    this.loadingScroll = true;
    window.history.replaceState({}, '', `/demotivators/${this.CurrentPage}`);
    this.CurrentPage++;



    this.getMainPageFromApi().subscribe(res => {
      res.demotivatorCollection.forEach(element => {
        this.MainPage$.demotivators.push(element);
      });

      res.demotivatorVideoCollection.forEach(element => {
        this.MainPage$.demotivators.push(element);
      });

      this.loadingScroll = false;
    });
  }

  getNextPage() {
    this.CurrentPage++;
    this.loading = true;
    this.getMainPageFromApi().subscribe(res => {
      res.demotivatorCollection.forEach(element => {
        this.MainPage$.demotivatorCollection.unshift(element);
        this.loading = false;
      });
    });
  }

  getMainPageFromApi(): Observable<Page> {
    return this.http.get<Page>(
      'http://www.demotivatorapi.hostingasp.pl/api/demotivators/' +
        this.CurrentPage
    );
  }
  addFavorites(imgUrl: string) {
    this.favoritesService.addFavorites(imgUrl);
  }
}
