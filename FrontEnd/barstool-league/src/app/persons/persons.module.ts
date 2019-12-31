import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonGridComponent } from './person-grid/person-grid.component';
import { PersonRowComponent } from './person-row/person-row.component';
import { PersonBioComponent } from './person-bio/person-bio.component';
import { PersonDetailComponent } from './person-detail/person-detail.component';
import { PersonService } from './person.service';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BattingModule } from '../batting/batting.module';
import { AppearancesListComponent } from './appearances-list/appearances-list.component';


@NgModule({
  declarations: [
    PersonGridComponent, PersonRowComponent, PersonBioComponent, PersonDetailComponent, AppearancesListComponent
  ],
  imports: [
    CommonModule, RouterModule, NgbModule, BattingModule
  ],
  providers: [PersonService],
})
export class PersonsModule { }
