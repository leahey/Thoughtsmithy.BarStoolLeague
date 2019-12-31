import { Component, OnInit, Input } from '@angular/core';
import { BattingStint } from 'src/app/shared/models/batting-stint.model';

@Component({
  selector: 'app-batting-stint-row',
  templateUrl: './batting-stint-row.component.html',
  styleUrls: ['./batting-stint-row.component.css']
})
export class BattingStintRowComponent implements OnInit {
  @Input() battingStint: BattingStint;
  constructor() { }

  ngOnInit() {
  }

}
