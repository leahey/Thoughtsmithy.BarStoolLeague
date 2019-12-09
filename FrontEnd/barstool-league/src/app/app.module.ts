import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { PersonGridComponent } from './persons/person-grid/person-grid.component';
import { PersonDetailComponent } from './persons/person-detail/person-detail.component';
import { PersonBioComponent } from './persons/person-bio/person-bio.component';
import { HomeComponent } from './core/home/home.component';
import { PersonRowComponent } from './persons/person-row/person-row.component';

import { PersonService } from './persons/person.service';
import { HttpClientModule } from '@angular/common/http';

const appRoutes: Routes = [
  { path: '', component: HomeComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    PersonGridComponent,
    PersonDetailComponent,
    PersonBioComponent,
    HomeComponent,
    PersonRowComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule
  ],
  providers: [
    PersonService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
