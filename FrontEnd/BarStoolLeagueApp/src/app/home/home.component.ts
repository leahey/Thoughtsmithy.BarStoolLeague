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
    const players = playerService.get();

    players.subscribe((data: any) => {
      this.playerData = data;
      console.log(this.playerData);
    });
   }

  ngOnInit() {
  }

}
