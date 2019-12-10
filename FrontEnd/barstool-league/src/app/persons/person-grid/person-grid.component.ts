import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Person } from '../person';

@Component({
  selector: 'app-person-grid',
  templateUrl: './person-grid.component.html',
  styleUrls: ['./person-grid.component.css']
})
export class PersonGridComponent implements OnInit {
  @Input() personData: Observable<Array<Person>>;

  constructor() { }

  ngOnInit() {
  }

}
