import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-person-bio',
  templateUrl: './person-bio.component.html',
  styleUrls: ['./person-bio.component.css']
})
export class PersonBioComponent implements OnInit {
  @Input() person: any;

  constructor() { }

  ngOnInit() {
  }

}
