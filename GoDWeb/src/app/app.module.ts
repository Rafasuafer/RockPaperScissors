import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from  '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ScoreComponent } from './components/score/score.component';
import { StartComponent } from './components/start/start.component';
import { RoundComponent } from './components/round/round.component';
import { WinnerComponent } from './components/winner/winner.component';
import { GameComponent } from './components/game/game.component';
import { SystemComponent } from './components/system/system.component';

@NgModule({
  declarations: [
    AppComponent,
    ScoreComponent,
    StartComponent,
    RoundComponent,
    WinnerComponent,
    GameComponent,
    SystemComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
