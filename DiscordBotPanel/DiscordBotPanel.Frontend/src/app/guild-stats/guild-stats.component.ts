import { Component, OnInit } from '@angular/core';
import { IAppState } from '../store';
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
    this.ngRedux.dispatch({ type: 'ADD_MESSAGE'});
    alert(this.ngRedux.getState().counter);
  }
}
