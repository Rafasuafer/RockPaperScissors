import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DTOBattle } from '../models/DTOBattle';
import { DTOPlayers } from '../models/DTOPlayers';
import { IBattle } from '../models/IBattle';
import { IGame } from '../models/IGame';
import { DataService } from './data.service';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  appUrl = 'https://localhost:44394/';
  games = 'api/Games/';
  battles = 'api/Battles';

  constructor(private http: HttpClient, private dataService: DataService) {  }

  newGame(DTO: DTOPlayers)
  {
    return this.http.post<IGame>(this.appUrl+this.games, DTO, {responseType: "json"}).subscribe(data => {
      this.dataService.setGame(data);
    });
  }

  newBattle(DTO: DTOBattle)
  {
    return this.http.post<string>(this.appUrl+this.battles, DTO, {responseType: "json"}).subscribe(data => {
      console.log(data);
    });
  }

  getBattles(gameId: number)
  {
    this.http.get<IBattle[]>(this.appUrl+this.battles+'/'+gameId).toPromise()
      .then( data => this.dataService.setBattles(data));
  }
}
