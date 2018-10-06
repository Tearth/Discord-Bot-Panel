import { StatsModel } from './../../models/stats.model';
import { IAppState, LOAD_BOTS, SELECT_BOT, LOAD_STATS } from './../../store';
import { BotModel } from './../../models/bot.model';
import { BotsService } from './../../services/bots.service';
import { Component, OnInit } from '@angular/core';
import { NgRedux } from '@angular-redux/store';
import { StatsService } from '../../services/stats.service';

@Component({
  selector: 'app-bot-select',
  templateUrl: './bot-select.component.html',
  styleUrls: ['./bot-select.component.css']
})
export class BotSelectComponent implements OnInit {
  public bots: BotModel[];

  constructor(private ngRedux: NgRedux<IAppState>,
              private botsService: BotsService,
              private statsService: StatsService) {

  }

  ngOnInit() {
    this.botsService.getBots().subscribe((receivedBots: BotModel[]) => {
      this.bots = receivedBots;
      this.ngRedux.dispatch({ type: LOAD_BOTS, payload: receivedBots })

      if(this.bots.length > 0) {
        this.selectBot(this.bots[0].id);
      }
    });
  }

  private selectBot(botId: string) {
    this.ngRedux.dispatch({ type: SELECT_BOT, payload: botId });
    this.statsService.getStatsForBot(botId).subscribe((stats: StatsModel[]) => {
      this.ngRedux.dispatch({ type: LOAD_STATS, payload: stats })
    });
  }
}
