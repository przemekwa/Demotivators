import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class FatvoritesService {

  constructor(private http: HttpClient) { }

  addFavorites(imgUrl: string) {

    var currentUser = localStorage.getItem('userName');

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
