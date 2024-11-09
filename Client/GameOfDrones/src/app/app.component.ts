import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewGameForm } from "./components/new-game-form/new-game-form.component";
import { Game } from "./components/game/game.component";
import NewGame from './models/NewGame';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, NewGameForm, Game],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'GameOfDrones';
  
  public hasGameStarted = false;
  public playerOneName = "";
  public playerTwoName = "";
  public gameId = "";

  getHasGameStarted(value:boolean){
    this.hasGameStarted = value;
  }
  getPlayerNames(value:NewGame){
    this.playerOneName = value.playerOneName;
    this.playerTwoName = value.playerTwoName;
  }
  getGameId(value:string){
    this.gameId = value;
  }

}
