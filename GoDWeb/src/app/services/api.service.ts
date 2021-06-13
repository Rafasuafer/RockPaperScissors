import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DTOPlayers } from '../models/DTOPlayers';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  appUrl = 'https://localhost:44394/';
  games = 'api/Games/';
  constructor(private http: HttpClient) {  }

  newGame(DTO: DTOPlayers)
  {
    return this.http.post<string>(this.appUrl+this.games, DTO, {responseType: "json"});
  }
}
