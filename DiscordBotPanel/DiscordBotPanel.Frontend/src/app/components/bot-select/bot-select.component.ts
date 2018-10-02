import { BotModel } from './../../models/bot.model';
import { BotsService } from './../../services/bots.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-bot-select',
  templateUrl: './bot-select.component.html',
  styleUrls: ['./bot-select.component.css']
})
export class BotSelectComponent implements OnInit {
  public bots: BotModel[];

  constructor(private botsService: BotsService) {

  }

  ngOnInit() {
    this.botsService.getBots().subscribe((receivedBots: BotModel[]) => {
      this.bots = receivedBots;
    });
  }
}
