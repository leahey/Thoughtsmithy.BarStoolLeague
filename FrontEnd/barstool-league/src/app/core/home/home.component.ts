import { Component, OnInit } from '@angular/core';
import { PersonService } from 'src/app/persons/person.service';
import { Person } from 'src/app/shared/models/person.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public personsData: Array<Person>;

  constructor(personService: PersonService) {
    const persons = personService.get();

    persons.subscribe((data: Array<Person>) => {
      this.personsData = data;
    });
  }

  ngOnInit() {
  }

}
