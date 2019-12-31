import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BattingStint } from './batting-stint.model';
import { FieldingStint } from './fielding-stint.model';
import { Person } from './person.model';



@NgModule({
  declarations: [
    BattingStint, FieldingStint, Person
  ],
  imports: [
    CommonModule
  ]
})
export class ModelsModule { }
