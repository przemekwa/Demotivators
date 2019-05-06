import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class FatvoritesService {

  constructor(private http: HttpClient) { }

  deleteUserFavorite(userName: string, id: number) {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
      body: {
        Id: id,
        UserName: userName
      }
  };

    this.http.delete('http://www.demotivatorapi.hostingasp.pl/api/favourite/', httpOptions).subscribe(
      res => {
        console.log(res);
      },
      error => {
        console.log(error);
      }
    );
  }

  addFavorites(imgUrl: string) {

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
      .post('http://www.demotivatorapi.hostingasp.pl/api/favourite', model)
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
