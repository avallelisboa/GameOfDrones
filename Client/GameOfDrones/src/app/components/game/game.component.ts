import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Score } from '../score-component/score.component';
import { CommonModule } from '@angular/common';
import { GameService } from '../../services/game.service';
import RoundWinner from '../../models/RoundWinner';
import PlayersMoves from '../../models/PlayersMoves';

@Component({
  selector: 'app-game',
  standalone: true,
  imports: [Score, CommonModule, FormsModule],
  templateUrl: './game.component.html',
  styleUrl: './game.component.scss'
})
export class Game {
  @Input() playerOneName = "";
  @Input() playerTwoName = "";
  @Input() gameId = "";

  constructor(
    private _gameService:GameService
  ){}
  public roundsWinners:Array<RoundWinner> = [];

  public isPlayerOneTurn = true;
  public isPlayerTwoTurn = false;
  public round = 1;
  public posibleMove = [
    { 
      name:"Rock",
      value:0
    },
    { 
      name:"Paper", 
      value:1
    },
    { 
      name:"Scissors", 
      value:2
    }
  ];
  public moves:PlayersMoves = new PlayersMoves(0, 0);

  NextPlayer(){
    const result = this._gameService.MakeMoveService(this.gameId,1,this.moves.playerOneMove);
    result.then(result => console.log(result));
    
    this.isPlayerOneTurn = false;
    this.isPlayerTwoTurn = true;
  }
  EndRound(){
    const result = this._gameService.MakeMoveService(this.gameId,2,this.moves.playerTwoMove);
    result.then(result => console.log(result));

    this.moves.playerOneMove = 0;
    this.moves.playerTwoMove = 0;

    this.round++;

    this.isPlayerOneTurn = true;
    this.isPlayerTwoTurn = false;
  }
}
