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
  public isThereAWinner = false;
  public winnerName =  "";
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
    const response = this._gameService.MakeMoveService(this.gameId,1,this.moves.playerOneMove);
    response.then(result => {
      console.log(result)
        if(result.isValid){
          this.isPlayerOneTurn = false;
          this.isPlayerTwoTurn = true;
        }  
    });    
    
  }
  EndRound(){
    const response = this._gameService.MakeMoveService(this.gameId,2,this.moves.playerTwoMove);
    response.then(result =>{
      console.log(result)
      if(result.isValid){
        this.moves.playerOneMove = 0;
        this.moves.playerTwoMove = 0;
        let roundWinnerName = result.roundWinner == 0 ? "draw" : result.roundWinner == 1 ? this.playerOneName : this.playerTwoName;
        this.roundsWinners.push(new RoundWinner(this.round,roundWinnerName));
        if(result.gameWinner == 0){
          this.round++;          
          this.isPlayerOneTurn = true;
          this.isPlayerTwoTurn = false;
        }else{
          this.isThereAWinner = true;
          this.winnerName = result.gameWinner == 1 ? this.playerOneName : this.playerTwoName;
          this.isPlayerOneTurn = false;
          this.isPlayerTwoTurn = false;
        }
      }
    });

    
  }
}
