import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DTOBattle } from '../models/DTOBattle';
import { DTOPlayers } from '../models/DTOPlayers';
import { IBattle } from '../models/IBattle';
import { IGame } from '../models/IGame';
import { IMove } from '../models/IMove';
import { DataService } from './data.service';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  appUrl = 'https://rockpaperservice.azurewebsites.net/';
  games = 'api/Games/';
  battles = 'api/Battles';
  moves = 'api/Moves';

  constructor(private http: HttpClient, private dataService: DataService) {  }

  newGame(DTO: DTOPlayers)
  {
    return this.http.post<IGame>(this.appUrl+this.games, DTO, {responseType: "json"}).subscribe(data => {
      this.dataService.setGame(data);
    });
  }

  async getGame(id: number)
  {
    let response: IGame = await
     this.http.get<IGame>(this.appUrl+this.games + id, {responseType: "json"}).toPromise();

    return response;
  }

  newBattle(DTO: DTOBattle)
  {
    return this.http.post<DTOBattle>(this.appUrl+this.battles, DTO, {responseType: "json"}).subscribe(data => {
      this.getBattles(data.gameId);
    });
  }

  async getBattles(gameId: number)
  {
    let response: IBattle [] = await
     this.http.get<IBattle[]>(this.appUrl+this.battles+'/'+gameId).toPromise();

    return response;
  }

  getMoves()
  {
    return this.http.get<IMove[]>(this.appUrl+this.moves).toPromise().then(data =>{this.dataService.setMoves(data);});
  }
}
