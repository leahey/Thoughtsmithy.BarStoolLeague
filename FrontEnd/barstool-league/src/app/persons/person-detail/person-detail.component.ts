import { switchMap, map } from 'rxjs/operators';
import { Component, Input, OnInit } from '@angular/core';
import { Observable, from } from 'rxjs';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { PersonService } from '../person.service';
import { Person } from '../../shared/models/person.model';
import { BattingModule } from 'src/app/batting/batting.module';

@Component({
  selector: 'app-person-detail',
  templateUrl: './person-detail.component.html',
  styleUrls: ['./person-detail.component.css']
})
export class PersonDetailComponent implements OnInit {
  person: Person;

  constructor(
    private route: ActivatedRoute,
    private service: PersonService
  ) { }

  ngOnInit() {
      const playerId = this.route.snapshot.paramMap.get('id');
      const obsPerson = this.service.getPersonById(playerId);

      obsPerson.subscribe((data: Person) => {
        this.person = data;
      });

      console.log(this.person);
  }
}
