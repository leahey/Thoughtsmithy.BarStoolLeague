import { Component, OnInit, Input } from '@angular/core';
import { Appearance } from '../../shared/models/appearance.model';

@Component({
  selector: 'app-appearances-list',
  templateUrl: './appearances-list.component.html',
  styleUrls: ['./appearances-list.component.css']
})
export class AppearancesListComponent implements OnInit {
  @Input() appearanceData: Array<Appearance>;
  constructor() { }

  ngOnInit() {
  }

}
