import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-grid-players',
  templateUrl: './grid-players.component.html',
  styleUrls: ['./grid-players.component.css']
})
export class GridPlayersComponent implements OnInit {
  @Input()
  playerData: Array<any>;

  constructor() { }

  ngOnInit() {
  }

}
