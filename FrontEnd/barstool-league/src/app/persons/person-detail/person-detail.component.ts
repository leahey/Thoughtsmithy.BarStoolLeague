import { switchMap, map } from 'rxjs/operators';
import { Component, Input, OnInit } from '@angular/core';
import { Observable, from } from 'rxjs';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { PersonService } from '../person.service';
import { Person } from '../../shared/models/person.model';

@Component({
  selector: 'app-person-detail',
  templateUrl: './person-detail.component.html',
  styleUrls: ['./person-detail.component.css']
})
export class PersonDetailComponent implements OnInit {
  person: Person;
  public isBattingCollapsed = false;

  constructor(
    private route: ActivatedRoute,
    private service: PersonService
  ) { }

  ngOnInit() {
      // we're here via route; get playerId from route params.
      const playerId = this.route.snapshot.paramMap.get('id');
      const obsPerson = this.service.getPersonById(playerId);

      obsPerson.subscribe((data: Person) => {
        this.person = new Person().deserialize(data);
      });

      console.log(this.person);
  }
}
