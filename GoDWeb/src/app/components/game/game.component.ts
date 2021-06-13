import { Component, Output, EventEmitter } from '@angular/core';


@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent{

  @Output() messageEvent = new EventEmitter();
  message: string = "GAME";

  sendMessage()
  {
    this.messageEvent.emit(this.message);
  }
  constructor() { }
}
