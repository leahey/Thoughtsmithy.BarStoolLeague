import { switchMap, map } from 'rxjs/operators';
import { Component, Input, OnInit } from '@angular/core';
import { Observable, from } from 'rxjs';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { PersonService } from '../person.service';
import { Person } from '../person';

@Component({
  selector: 'app-person-detail',
  templateUrl: './person-detail.component.html',
  styleUrls: ['./person-detail.component.css']
})
export class PersonDetailComponent implements OnInit {
  person: Person;
  playerId: string;

  constructor(
    private route: ActivatedRoute,
    private service: PersonService
  ) { }

  ngOnInit() {
      this.playerId = this.route.snapshot.paramMap.get('id');
      const person = this.service.getPersonById(this.playerId);

      person.subscribe((data: Person) => {
        this.person = data;
      });

      // this.person.subscribe((data: any) => {
      //   this.person = data;
      // });
      //  = this.service.getPersonById(this.playerId);
      console.log(this.person);

  }

}
