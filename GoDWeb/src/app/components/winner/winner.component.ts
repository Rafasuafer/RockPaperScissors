import { Component, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-winner',
  templateUrl: './winner.component.html',
  styleUrls: ['./winner.component.css']
})
export class WinnerComponent{

  @Output() messageEvent = new EventEmitter();
  message: string = "GAME"

  constructor() { }

  sendMessage()
  {
    this.messageEvent.emit(this.message);
  }
}
