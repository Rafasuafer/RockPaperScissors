import { Component, OnInit } from '@angular/core';
import { DTOBattle } from 'src/app/models/DTOBattle';
import { ApiService } from 'src/app/services/api.service';
import { DataService } from 'src/app/services/data.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-round',
  templateUrl: './round.component.html',
  styleUrls: ['./round.component.css']
})
export class RoundComponent implements OnInit {

  turn: number;
  DTO: DTOBattle;
  roundForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private apiService: ApiService, private dataService: DataService) 
  {
    this.turn = 1;
    this.roundForm = this.formBuilder.group({
      id: 0,
      moveSelect: ['', [Validators.required]]
    });

    this.DTO = {gameId: 0,moveOne: "", moveTwo: ""};
  }

  ngOnInit(): void {
  }

  async updateBattles()
  {
    await this.apiService.getBattles(this.dataService.getGame().id);
    this.dataService.setBattles( await this.apiService.getBattles(this.dataService.getGame().id));
  }

  updateTurn()
  {
    switch (this.turn) {
      case 1:
        this.turn = 2;
        break;
      case 2:
        this.turn = 1;
        this.DTO = {gameId: 0,moveOne: "", moveTwo: ""};
        break;
    }
    this.roundForm.reset();    
  }

  updateDTO()
  {
    this.DTO.gameId = this.dataService.getGame().id;
    if (this.turn === 1) 
    {
      console.log("UPDATING MOVE ONE");
      this.DTO.moveOne = this.roundForm.get("moveSelect").value;
    }
    else
    {
      console.log("UPDATING MOVE TWO");
      this.DTO.moveTwo = this.roundForm.get("moveSelect").value;
    }
  }

  async updateRound()
  {
    this.apiService.getMoves();
    this.updateDTO();
    console.log("ROUND P1: " + this.DTO.moveOne + " | P2 " + this.DTO.moveTwo);
    this.sendDTO();
    await this.updateBattles();
    await this.updateGame();
    this.updateTurn();
  }

  async updateGame()
  {
    console.log("Updating game");
    this.dataService.setGame( await this.apiService.getGame(this.dataService.getGame().id));
    console.log("Game Winner: " + this.dataService.getGame().winner);

    if (this.dataService.getGame().winner != 0) 
    {
      console.log("SHOULD BE HERE");
      this.dataService.setState("END");  
    }
  }

  sendDTO()
  {
    if(this.turn === 2)
    {
      console.log("SENDING DTO")
      this.apiService.newBattle(this.DTO);
    }
  }

  getRoundNum()
  {
    return this.dataService.getBattles().length + 1;
  }

  getTurn()
  {
    return this.turn;
  }

  getMoves()
  {
    return this.dataService.getMoves();
  }

  getName()
  {
    if (this.turn === 1) 
    {
      return this.dataService.getGame().pOne;
    }
    else
    {
      return this.dataService.getGame().pTwo;
    }
  }


}
