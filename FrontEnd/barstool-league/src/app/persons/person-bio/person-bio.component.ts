import { Component, OnInit, Input } from '@angular/core';
import { Person } from '../../shared/models/person.model';
import { isNullOrUndefined } from 'util';

@Component({
  selector: 'app-person-bio',
  templateUrl: './person-bio.component.html',
  styleUrls: ['./person-bio.component.css']
})
export class PersonBioComponent implements OnInit {
  @Input() person: Person;
  @Input() isDetail = false;

  constructor() { }

  ngOnInit() {
  }

  get deathDate(): string {
    let result = '';
    if (this.person !== undefined) {
      result = (this.person.deathYear != null) ?
      new Date(this.person.deathYear, this.person.deathMonth, this.person.deathDay).toDateString() :
      '';
    }
    return result;
  }

  get birthDate(): string {
    let result = '';
    if (this.person !== undefined) {
      result = (this.person.birthYear != null) ?
      new Date(this.person.birthYear, this.person.birthMonth, this.person.birthDay).toDateString() :
      '';
    }
    return result;
  }

  get isPlayer(): boolean {
    return this.person.appearances.length > 0;
  }

  get isManager(): boolean {
    return this.person.managers.length > 0;
  }

  // TODO: create control for POB and POD to demonstrate varying country display practices
  get placeOfBirth(): string {
    return (this.person.birthCity != null) ?
      `${this.person.birthCity} ${this.person.birthState}, ${this.person.birthCountry}` :
      '';
  }

  // TODO: create control for POB and POD to demonstrate varying country display practices
  get placeOfDeath(): string {
    return (this.person.deathCity != null) ?
      `${this.person.deathCity} ${this.person.deathState}, ${this.person.deathCountry}` :
      '';
  }

  get displayHeight(): string {
    return `${Math.floor(this.person.height / 12)}' ${this.person.height % 12}"`;
  }
}
