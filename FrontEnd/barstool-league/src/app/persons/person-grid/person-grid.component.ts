import { Component, Input, OnInit } from '@angular/core';
import { Person } from '../../shared/models/person.model';
import { NgbPaginationConfig } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-person-grid',
  templateUrl: './person-grid.component.html',
  styleUrls: ['./person-grid.component.css']
})
export class PersonGridComponent implements OnInit {
  @Input() personsData: Array<Person>;
  page = 1;

  // TODO: store currently expanded personId for re-expansion after reload.
  public selectedPersonId: string;

  constructor(config: NgbPaginationConfig) {
    config.size = 'sm';
    config.boundaryLinks = true;
    config.ellipses = true;
    config.pageSize = 50;
    config.rotate = true;
    config.maxSize = 15;
  }

  ngOnInit() {
  }
}
