import { Component, Input } from '@angular/core';
import { IGame } from 'src/app/models/IGame';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-system',
  templateUrl: './system.component.html',
  styleUrls: ['./system.component.css']
})
export class SystemComponent{

  constructor(private dataService: DataService)
  {
      this.dataService;
  };

  public setState(state:string)
    {
      this.dataService.setState(state);
    }

  public getState():string
  {
    return this.dataService.getState();
  }

  public getGame(): IGame
  {
    return this.dataService.getGame();
  }

}
