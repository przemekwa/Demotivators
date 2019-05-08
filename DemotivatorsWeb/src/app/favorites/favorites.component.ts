import { UserService } from './../user.service';
import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FatvoritesService } from '../fatvorites.service';


export interface IFavorites {
  id: number;
  url: string;
  title: string;
  updateDate: string;
  isDeleted: boolean;
}

@Component({
  selector: 'app-favorites',
  templateUrl: './favorites.component.html',
  styleUrls: ['./favorites.component.css']
})



export class FavoritesComponent implements OnInit {
  @Input() public Favorites: IFavorites[] = [];

  constructor(private http: HttpClient, private fatvoritesService: FatvoritesService, private userService: UserService) {
    this.fatvoritesService.getFavorites(this.userService.UserName).subscribe(res => {
      this.Favorites = res;
    });
   }

  ngOnInit() {
  }

  removeFavorites(favorite: IFavorites) {
    favorite.isDeleted = true;
    this.fatvoritesService.deleteUserFavorite(this.userService.UserName, favorite.id);
  }




}
