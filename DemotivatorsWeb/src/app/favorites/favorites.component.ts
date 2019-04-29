import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';


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


}
