import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PersonService } from '../person.service';
import { Person } from '../../shared/models/person.model';

@Component({
  selector: 'app-person-detail',
  templateUrl: './person-detail.component.html',
  styleUrls: ['./person-detail.component.css']
})
export class PersonDetailComponent implements OnInit {
  buttonsModel = {
    appearances: true,
    batting: true,
    fielding: true
  };

  person: Person;
  public isBattingCollapsed = false;
  public isAppearancesCollapsed = false;
  public isFieldingCollapsed = false;
  public hasAppearances = false;
  public hasBatting = false;
  public hasFielding = false;

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
        this.hasAppearances = this.person.appearances.length > 0;
        this.hasBatting = this.person.batting.length > 0;
        this.hasFielding = this.person.fielding.length > 0;
      });
  }
}
