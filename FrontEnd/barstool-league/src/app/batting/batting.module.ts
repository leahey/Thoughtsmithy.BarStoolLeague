import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BattingListComponent } from './batting-list/batting-list.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BattingStintRowComponent } from './batting-stint-row/batting-stint-row.component';



@NgModule({
  declarations: [
    BattingListComponent,
    BattingStintRowComponent
  ],
  imports: [
    CommonModule, NgbModule
  ],
  exports: [
    BattingListComponent
  ]
})
export class BattingModule { }
