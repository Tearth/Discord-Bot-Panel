import { StatsModel } from './../models/stats.model';
import { Observable } from 'rxjs';
import { BotModel } from './../models/bot.model';
import { ApiService } from './api.service';
import { Injectable } from '@angular/core';
import { HttpClient } from 'selenium-webdriver/http';

@Injectable({
  providedIn: 'root'
})
export class StatsService {
  constructor(private api: ApiService) {

  }

  public getStatsForBot(botId: string) : Observable<StatsModel[]> {
    return this.api.get<StatsModel[]>("stats/" + botId);
  }
}
