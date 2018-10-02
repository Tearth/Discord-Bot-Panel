import { Observable } from 'rxjs';
import { BotModel } from './../models/bot.model';
import { ApiService } from './api.service';
import { Injectable } from '@angular/core';
import { HttpClient } from 'selenium-webdriver/http';

@Injectable({
  providedIn: 'root'
})
export class BotsService {
  constructor(private api: ApiService) {

  }

  public getBots() : Observable<BotModel[]> {
    return this.api.get<BotModel[]>("bots");
  }
}
