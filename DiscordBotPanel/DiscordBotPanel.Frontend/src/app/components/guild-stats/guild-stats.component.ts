import { IAppState } from './../../store';
import { Component, OnInit } from '@angular/core';
import { NgRedux } from '@angular-redux/store';
import { tassign } from 'tassign';
import { TrendService } from '../../services/trend.service';

@Component({
  selector: 'app-guild-stats',
  templateUrl: './guild-stats.component.html',
  styleUrls: ['./guild-stats.component.css']
})
export class GuildStatsComponent implements OnInit {
  public dataReady: boolean;
  public chartOptions;
  public chartData;
  public chartLabels: string[];

  constructor(private ngRedux: NgRedux<IAppState>, private trendService: TrendService) {
    this.dataReady = false;
  }

  ngOnInit() {
    this.chartOptions = {
      responsive: true
    };

    var stats = this.ngRedux.getState().stats;
    this.chartData = [
      {
      data: stats.map(p => p.guildsCount), label: "Guilds count"
      },
      {
        data: this.trendService.getTrendLineValues(stats.map(p => p.guildsCount)), label: "Trend line"
      }];
    this.chartLabels = stats.map(p => new Date(p.createTime).toLocaleDateString());

    this.dataReady = true;
  }
}
