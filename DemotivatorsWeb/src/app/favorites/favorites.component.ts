import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';


interface IFavorites {
  Id: number;
  Url: string;
  Title: string;
  UpdateDate: string;
  IsDeleted: boolean;
}

@Component({
  selector: 'app-favorites',
  templateUrl: './favorites.component.html',
  styleUrls: ['./favorites.component.css']
})



export class FavoritesComponent implements OnInit {


  @Input() public Favorites: IFavorites[] = [];

  constructor(private http: HttpClient) {
    this.getUserFavorites(localStorage.getItem('userName')).subscribe(res => {
      this.Favorites = res;
    });
   }

  ngOnInit() {
  }

  getUserFavorites(userName: string): Observable<IFavorites[]> {
    return this.http.get<IFavorites[]>('http://www.demotivatorapi.hostingasp.pl/api/favourite/' + userName);
  }

  removeFavorites(favorite: IFavorites) {

    this.deleteUserFavorite(localStorage.getItem('userName'), favorite.Id);
  }

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


}
