import { Component, OnInit } from '@angular/core';
import { PersonService } from 'src/app/persons/person.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public personData: Array<any>;

  constructor(private personService: PersonService) {
    const persons = personService.get();

    persons.subscribe((data: any) => {
      this.personData = data;
    });
  }

  ngOnInit() {
  }

}
