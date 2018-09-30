import { IAppState } from './../../store';
import { Component, OnInit } from '@angular/core';
import { NgRedux } from '@angular-redux/store';

@Component({
  selector: 'app-guild-stats',
  templateUrl: './guild-stats.component.html',
  styleUrls: ['./guild-stats.component.css']
})
export class GuildStatsComponent implements OnInit {

  constructor(private ngRedux: NgRedux<IAppState>) {
  }

  ngOnInit() {
  }
}
