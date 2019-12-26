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
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BattingListComponent } from './batting/batting-list/batting-list.component';
import { FieldingListComponent } from './fielding/fielding-list/fielding-list.component';

const appRoutes: Routes = [
  { path: 'person/:id', component: PersonDetailComponent},
  { path: 'person', component: PersonGridComponent },
  { path: '', component: HomeComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    PersonGridComponent,
    PersonDetailComponent,
    PersonBioComponent,
    HomeComponent,
    PersonRowComponent,
    BattingListComponent,
    FieldingListComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule,
    NgbModule
  ],
  providers: [
    PersonService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
