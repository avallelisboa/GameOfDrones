import { Injectable } from '@angular/core';
import global from './global';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  private _url;
  constructor() {
    this._url = global.apiURL + "game/";
  }

  async NewGameService(playerOneName:string, playerTwoName:string):Promise<any>{
    let url = this._url + "newgame";
    try{
      const response = await fetch(url + `?playerOneName="${playerOneName}"&playerTwoName="${playerTwoName}"`);
      return response.json();
    }catch(error){
      console.log(error);
    }
  }
  async MakeMoveService(gameId:string, playerNumber:number, playerMove:number):Promise<any>{
    let url = this._url + "makemove";
    try{
      const response = await fetch(url + `?gameId=${gameId}&playerNumber=${playerNumber}&playerMove=${playerMove}`)
      return response.json();
    }catch(error){
      console.log(error);
    }
  }
}
