import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DemotivatorsComponent } from './demotivators/demotivators.component';
import { RouterModule, Routes } from '@angular/router';
import { NgxLoadingModule } from 'ngx-loading';
import { HttpClientModule } from '@angular/common/http';
import { JbzdyComponent } from './jbzdy/jbzdy.component';
import { FormsModule } from '@angular/forms';
import { FavoritesComponent } from './favorites/favorites.component';
import { ModalComponent } from './modal/modal.component';

const appRoutes: Routes = [
  { path: 'd', component: DemotivatorsComponent },
  { path: 'demotivators/:pageNumber',    component: DemotivatorsComponent},
  { path: 'demotivators', component: DemotivatorsComponent },
  { path: 'jbzdy/:pageNumber', component: JbzdyComponent },
  { path: 'jbzdy', component: JbzdyComponent },
  { path: 'favorites/:userName', component: FavoritesComponent },
  { path: 'favorites', component: FavoritesComponent },
];

@NgModule({
  declarations: [
    AppComponent,
    DemotivatorsComponent,
    JbzdyComponent,
    FavoritesComponent,
    ModalComponent,
  ],
  imports: [
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: false }
    ),
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    InfiniteScrollModule,
    RouterModule,
    NgxLoadingModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
