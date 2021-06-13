import { Component, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DTOPlayers } from 'src/app/models/DTOPlayers';
import { IGame } from 'src/app/models/IGame';
import { ApiService } from 'src/app/services/api.service';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-start',
  templateUrl: './start.component.html',
  styleUrls: ['./start.component.css']
})
export class StartComponent {
  
  startForm: FormGroup;
  game: IGame;

  constructor(private formBuilder: FormBuilder, private apiService: ApiService, private dataService: DataService) 
  {
    this.startForm = this.formBuilder.group({
      id: 0,
      pOne: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      pTwo: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]]
    })
  }

  newGame(){
    this.createGame();
    this.dataService.setState("GAME");
  }
 
  createGame()
  {
    const DTO: DTOPlayers =
    {
      p1: this.startForm.get("pOne").value,
      p2: this.startForm.get("pTwo").value,
    }

    this.apiService.newGame(DTO);
    this.startForm.reset();
  }
}
