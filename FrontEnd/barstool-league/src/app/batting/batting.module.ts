import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BattingListComponent } from './batting-list/batting-list.component';



@NgModule({
  declarations: [
    BattingListComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    BattingListComponent
  ]
})
export class BattingModule { }
