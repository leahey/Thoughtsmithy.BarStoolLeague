import { Component, OnInit, Input } from '@angular/core';
import { Person } from '../../shared/models/person.model';

@Component({
  selector: 'app-person-bio',
  templateUrl: './person-bio.component.html',
  styleUrls: ['./person-bio.component.css']
})
export class PersonBioComponent implements OnInit {
  @Input() person: Person;

  constructor() { }

  ngOnInit() {
  }

  get deathDate(): string {
    return (this.person.deathYear != null) ?
    new Date(this.person.deathYear, this.person.deathMonth, this.person.deathDay).toDateString() :
    '';
  }

  get birthDate(): string {
    return (this.person.birthYear != null) ?
    new Date(this.person.birthYear, this.person.birthMonth, this.person.birthDay).toDateString() :
    '';
  }

  get isPlayer(): boolean {
    return this.person.appearances.length > 0;
  }

  get isManager(): boolean {
    return this.person.managers.length > 0;
  }

  get placeOfBirth(): string {
    return (this.person.birthCity != null) ?
      `${this.person.birthCity} ${this.person.birthState}, ${this.person.birthCountry}` :
      '';
  }

  get placeOfDeath(): string {
    return (this.person.deathCity != null) ?
      `${this.person.deathCity} ${this.person.deathState}, ${this.person.deathCountry}` :
      '';
  }

  get displayHeight(): string {
    return `${Math.floor(this.person.height / 12)}' ${this.person.height % 12}"`;
  }
}
