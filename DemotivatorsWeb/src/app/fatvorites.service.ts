import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IFavorites } from './favorites/favorites.component';

@Injectable({
  providedIn: 'root'
})
export class FatvoritesService {
  private apiRootUrl = 'http://www.demotivatorapi.hostingasp.pl/api/favourite/';

  constructor(private http: HttpClient) { }

  getFavorites(userName: string): Observable<IFavorites[]> {
    return this.http.get<IFavorites[]>(this.apiRootUrl  + userName);
  }

  deleteUserFavorite(userName: string, id: number) {
    console.log(id);
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Access-Control-Allow-Origin': 'http://localhost:4200' }),
      body: {
        Id: id,
        UserName: userName
      }
  };

    this.http.delete(this.apiRootUrl, httpOptions).subscribe(
      res => {
        console.log(res);
      },
      error => {
        console.log(error);
      }
    );
  }

  addFavorites(imgUrl: string) {
    console.log(imgUrl);

    const currentUser = localStorage.getItem('userName');

    if (currentUser == null ) {
      return;
    }

    let model = {
      userName: localStorage.getItem('userName'),
      FavouriteModel: {
        Url: imgUrl,
        Title: 'Test Title'
      }
    };

    this.http
      .post(this.apiRootUrl, model)
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
