import { Injectable } from '@angular/core';
import { IGame } from '../models/IGame';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  gameState: string = "START";
  game: IGame = {
    id: null,
    pOne:null,
    pTwo:null,
    scoreOne: 0,
    scoreTwo: 0,
    winner: null
  };;

  getState():string
  {
    return this.gameState;
  }
  setState(state: string)
  {
    this.gameState = state;
  }
  resetState()
  {
    this.gameState = "START";
  }

  getGame():IGame
  {
    return this.game;
  }
  setGame(newGame: IGame)
  {
    this.game = newGame;
  }
  resetGame()
  {
    this.game = 
    {
      id: null,
      pOne:null,
      pTwo:null,
      scoreOne: 0,
      scoreTwo: 0,
      winner: null
    };
  }

  

  constructor() { }
}
