import { BotsService } from './../../services/bots.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-bot-select',
  templateUrl: './bot-select.component.html',
  styleUrls: ['./bot-select.component.css']
})
export class BotSelectComponent implements OnInit {

  constructor(private botsService: BotsService) { }

  ngOnInit() {
  }

}
