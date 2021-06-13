import { Component, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
@Component({
  selector: 'app-start',
  templateUrl: './start.component.html',
  styleUrls: ['./start.component.css']
})
export class StartComponent {
  
  startForm: FormGroup;

  @Output() messageEvent = new EventEmitter();
  message: string = "GAME"

  constructor(private formBuilder: FormBuilder) 
  {
    this.startForm = this.formBuilder.group({
      id: 0,
      pOne: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      pTwo: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]]
    })
  }

  newGame(){
    console.log(this.startForm);
    this.message = "GAME";
    this.sendMessage();
  }
  sendMessage()
  {
    this.messageEvent.emit(this.message);
  }
}
