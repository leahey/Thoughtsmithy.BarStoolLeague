import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-person-row',
  templateUrl: './person-row.component.html',
  styleUrls: ['./person-row.component.css']
})
export class PersonRowComponent implements OnInit {
  @Input() person: any;

  constructor() { }

  ngOnInit() {
  }

}
