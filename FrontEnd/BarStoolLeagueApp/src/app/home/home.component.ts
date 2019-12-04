import { Component, OnInit } from '@angular/core';
import { PlayerService } from '../player.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public playerData: Array<any>;

  constructor(private playerService: PlayerService) {
    playerService.get().subscribe((data: any) => this.playerData = data);
   }

  ngOnInit() {
  }

}
