import { Component, Output, EventEmitter } from '@angular/core';
import { FormsModule } from '@angular/forms';
import NewGame from '../../models/NewGame';
import { GameService } from '../../services/game.service';

@Component({
  selector: 'app-new-game-form',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './new-game-form.component.html',
  styleUrl: './new-game-form.component.scss'
})
export class NewGameForm {
  @Output() hasGameStarted = new EventEmitter<boolean>();
  @Output() playerNames = new EventEmitter<NewGame>();
  @Output() gameId = new EventEmitter<string>();
  public aNewGame = new NewGame('','');
  
  constructor(
    private _gameService:GameService
  ){}

  onSubmit(){    
    const result = this._gameService.NewGameService(this.aNewGame.playerOneName, this.aNewGame.playerTwoName);
    result.then((res)=>{
      this.gameId.emit(res.gameId.toString()); 
      this.playerNames.emit(this.aNewGame);
      this.hasGameStarted.emit(true);
    });
      
  }
}
