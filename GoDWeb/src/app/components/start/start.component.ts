import { Component, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DTOPlayers } from 'src/app/models/DTOPlayers';
import { ApiService } from 'src/app/services/api.service';
@Component({
  selector: 'app-start',
  templateUrl: './start.component.html',
  styleUrls: ['./start.component.css']
})
export class StartComponent {
  
  startForm: FormGroup;

  @Output() messageEvent = new EventEmitter();
  @Output() gameMessage = new EventEmitter();
  
  message: string;

  constructor(private formBuilder: FormBuilder, private apiService: ApiService) 
  {
    this.startForm = this.formBuilder.group({
      id: 0,
      pOne: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      pTwo: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]]
    })
  }

  newGame(){
    this.createGame();
    this.message = "GAME";
    this.sendMessage();
  }
  sendMessage()
  {
    this.messageEvent.emit(this.message);
  }
  createGame()
  {
    const DTO: DTOPlayers =
    {
      p1: this.startForm.get("pOne").value,
      p2: this.startForm.get("pTwo").value,
    }

    this.apiService.newGame(DTO).subscribe(data => {
      console.log(data);
    });
    this.startForm.reset();
  }
}
