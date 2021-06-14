import { Component, OnInit } from '@angular/core';
import { IBattle } from 'src/app/models/IBattle';
import { IGame } from 'src/app/models/IGame';
import { ApiService } from 'src/app/services/api.service';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-score',
  templateUrl: './score.component.html',
  styleUrls: ['./score.component.css']
})
export class ScoreComponent implements OnInit {
  contador: number;
  constructor(private apiService: ApiService, public dataService: DataService) 
  {
    this.contador = 0;
  }

  ngOnInit(){}
  getGame()
  {
    return this.dataService.getGame();
  }


}
