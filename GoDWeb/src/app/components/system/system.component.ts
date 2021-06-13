import { Component, Input } from '@angular/core';
import { system } from 'src/app/models/system';

@Component({
  selector: 'app-system',
  templateUrl: './system.component.html',
  styleUrls: ['./system.component.css']
})
export class SystemComponent implements system{
  private static instance: SystemComponent;
  public gameState: string;
  public winner: number;

  public START: string = "START";
  public GAME: string = "GAME";
  public END: string = "END";

  constructor()
  {
      this.gameState = this.START;
      this.winner = 0;
  };

  public static getInstance(): SystemComponent 
  {
      if (!SystemComponent.instance) {
        SystemComponent.instance = new SystemComponent();
      }
      return SystemComponent.instance;
  }


  ngOnInit(): void {
  }

  public setState(state:string)
    {
        this.gameState = state;
    }

  public receiveMessage($event: string)
  {
    this.gameState = $event
  }
}
