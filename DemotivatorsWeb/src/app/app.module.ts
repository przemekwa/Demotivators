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

const appRoutes: Routes = [
  { path: 'd', component: DemotivatorsComponent },
  { path: 'demotivators/:pageNumber',    component: DemotivatorsComponent},
  { path: 'demotivators', component: DemotivatorsComponent },
  { path: 'jbzdy/:pageNumber', component: JbzdyComponent },
  { path: 'jbzdy', component: JbzdyComponent },
];

@NgModule({
  declarations: [
    AppComponent,
    DemotivatorsComponent,
    JbzdyComponent,
  ],
  imports: [
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: true }
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
