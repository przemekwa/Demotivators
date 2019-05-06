import { UserService } from './../user.service';
import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FatvoritesService } from '../fatvorites.service';


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

  constructor(private http: HttpClient, private fatvoritesService: FatvoritesService, private userService: UserService) {
    this.getUserFavorites(this.userService.UserName).subscribe(res => {
      this.Favorites = res;
    });
   }

  ngOnInit() {
  }

  getUserFavorites(userName: string): Observable<IFavorites[]> {
    return this.http.get<IFavorites[]>('http://www.demotivatorapi.hostingasp.pl/api/favourite/' + userName);
  }

  removeFavorites(favorite: IFavorites) {
    this.fatvoritesService.deleteUserFavorite(this.userService.UserName, favorite.Id);
  }




}
