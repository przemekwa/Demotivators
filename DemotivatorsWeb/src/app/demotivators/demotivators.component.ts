import { Page } from "./Demotivator";
import { Component, OnInit, Input } from "@angular/core";
import {
  HttpClient,
  HttpHeaders,
  HttpErrorResponse
} from "@angular/common/http";
import { Observable } from "rxjs";
import { stringify } from "@angular/core/src/util";
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: "app-demotivators",
  templateUrl: "./demotivators.component.html",
  styleUrls: ["./demotivators.component.css"]
})
export class DemotivatorsComponent implements OnInit {
  public loading = false;
  public loadingScroll = false;
  Title2: any;
  @Input() MainPage$: Page = new Page();
  public CurrentPage: number;
  public PageNumber: number;

  constructor(private http: HttpClient, route: ActivatedRoute) {
     route.params.subscribe(params => {
      this.CurrentPage = params['pageNumber'] === undefined ? 1 : params['pageNumber'];
   });

    this.loading = true;
    this.loading = true;
    this.getMainPage();
  }

  ngOnInit() {}

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
      "http://www.demotivatorapi.hostingasp.pl/api/demotivators/" +
        this.CurrentPage
    );
  }

  addFavorites() {
    let model = {
      userName: "Przemek",
      FavouriteModel: {
        Url: "Link2",
        Title: "ette2"
      }
    };

    //this.http.post('https://localhost:44300/api/favourite', model).
    this.http
      .post("http://www.demotivatorapi.hostingasp.pl/api/favourite", model)
      .subscribe(
        res => {
          console.log(res);
        },
        error => {
          console.log(error);
        }
      );
  }
}
