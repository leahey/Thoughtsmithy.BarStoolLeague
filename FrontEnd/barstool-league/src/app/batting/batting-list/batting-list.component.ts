import { Component, OnInit, Input } from '@angular/core';
import { BattingStint } from '../../shared/models/batting-stint.model';
import { BattingCollection } from 'src/app/shared/types/batting-collection';

@Component({
  selector: 'app-batting-list',
  templateUrl: './batting-list.component.html',
  styleUrls: ['./batting-list.component.css']
})
export class BattingListComponent implements OnInit {
  @Input() battingData: Array<BattingStint>;
  public battingCollection: BattingCollection;

  constructor() { }

  ngOnInit() {
    this.battingCollection = new BattingCollection(this.battingData);
  }

}
