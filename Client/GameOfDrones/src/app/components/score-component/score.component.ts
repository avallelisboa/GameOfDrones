import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import RoundWinner from '../../models/RoundWinner';

@Component({
  selector: 'app-score',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './score.component.html',
  styleUrl: './score.component.scss'
})
export class Score {
  @Input() RoundsWinners:Array<RoundWinner> = [ ]
}
