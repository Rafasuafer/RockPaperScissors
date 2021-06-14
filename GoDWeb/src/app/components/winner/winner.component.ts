import { Component, Output, EventEmitter } from '@angular/core';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-winner',
  templateUrl: './winner.component.html',
  styleUrls: ['./winner.component.css']
})
export class WinnerComponent{
  constructor(public dataService: DataService) { }

  public replay()
  {
    this.dataService.resetGame();
    this.dataService.resetBattles();
    this.dataService.resetMoves();
    this.dataService.resetState();
  }
}
