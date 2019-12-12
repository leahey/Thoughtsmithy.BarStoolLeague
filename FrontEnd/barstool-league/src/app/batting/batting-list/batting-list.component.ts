import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { BattingStint } from '../../shared/models/batting-stint.model';

@Component({
  selector: 'app-batting-list',
  templateUrl: './batting-list.component.html',
  styleUrls: ['./batting-list.component.css']
})
export class BattingListComponent implements OnInit {
  @Input() battingData: Observable<Array<BattingStint>>;

  constructor() { }

  ngOnInit() {
  }

}
