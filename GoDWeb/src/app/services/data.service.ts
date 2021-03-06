import { Injectable } from '@angular/core';
import { IBattle } from '../models/IBattle';
import { IGame } from '../models/IGame';
import { IMove } from '../models/IMove';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private gameState: string = "START";
  private game: IGame = {
    id: 0,
    pOne:null,
    pTwo:null,
    scoreOne: 0,
    scoreTwo: 0,
    winner: null
  };
  private battles: IBattle[] = [];
  private moves: IMove[] = [];

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

  getBattles()
  {
    return this.battles;
  }
  setBattles(bList: IBattle[])
  {
    this.battles = bList;
  }
  resetBattles()
  {
    this.battles = []
  }
  
  getMoves()
  {
    return this.moves;
  }
  setMoves(mList: IMove[])
  {
    this.moves = mList;
  }
  resetMoves()
  {
    this.moves = [];
  }

  constructor() { }
}
