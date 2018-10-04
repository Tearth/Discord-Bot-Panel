import { IAppState, LOAD_BOTS, SELECT_BOT } from './../../store';
import { BotModel } from './../../models/bot.model';
import { BotsService } from './../../services/bots.service';
import { Component, OnInit } from '@angular/core';
import { NgRedux } from '@angular-redux/store';

@Component({
  selector: 'app-bot-select',
  templateUrl: './bot-select.component.html',
  styleUrls: ['./bot-select.component.css']
})
export class BotSelectComponent implements OnInit {
  public bots: BotModel[];

  constructor(private ngRedux: NgRedux<IAppState>, private botsService: BotsService) {

  }

  ngOnInit() {
    this.botsService.getBots().subscribe((receivedBots: BotModel[]) => {
      this.bots = receivedBots;
      this.ngRedux.dispatch({ type: LOAD_BOTS, payload: receivedBots })

      if(this.bots.length > 0) {
        this.ngRedux.dispatch({ type: SELECT_BOT, payload: this.bots[0].id });
      }
    });
  }
}
