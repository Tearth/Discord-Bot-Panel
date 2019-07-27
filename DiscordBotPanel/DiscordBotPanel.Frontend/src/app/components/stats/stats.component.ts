import { IAppState } from './../../store';
import { Component, OnInit, ViewChild, SimpleChanges } from '@angular/core';
import { NgRedux } from '@angular-redux/store';
import { tassign } from 'tassign';
import { TrendService } from '../../services/trend.service';
import { ActivatedRoute } from '@angular/router';
import { BaseChartDirective } from 'ng2-charts';
import { StatsModel } from '../../models/stats.model';

@Component({
  selector: 'app-stats',
  templateUrl: './stats.component.html',
  styleUrls: ['./stats.component.css']
})
export class StatsComponent implements OnInit {
  public chartOptions;
  public chartData;
  public chartLabels: string[];

  public guildsCount: number;
  public membersCount: number;
  public commandsCount: number;

  public guildsCountChangeFromLastMonth: number;
  public guildsCountChangeFromLastMonthPercent: number;

  public membersCountChangeFromLastMonth: number;
  public membersCountChangeFromLastMonthPercent: number;

  public commandsCountChangeFromLastMonth: number;
  public commandsCountChangeFromLastMonthPercent: number;

  private modeLabels: any[];

  constructor(private activeRoute: ActivatedRoute, private ngRedux: NgRedux<IAppState>, private trendService: TrendService) {
    this.modeLabels = [
      { name: "guilds", label: "Guilds count" },
      { name: "members", label: "Members count" },
      { name: "commands", label: "Commands count" }
    ];

    this.chartData = [{ data: [] }, { data: [] }];

    this.guildsCount = 0;
    this.membersCount = 0;
    this.commandsCount = 0;

    this.guildsCountChangeFromLastMonth = 0;
    this.guildsCountChangeFromLastMonthPercent = 0;

    this.membersCountChangeFromLastMonth = 0;
    this.membersCountChangeFromLastMonthPercent = 0;

    this.commandsCountChangeFromLastMonth = 0;
    this.commandsCountChangeFromLastMonthPercent = 0;
  }

  ngOnInit() {
    this.chartOptions = {
      responsive: true
    };

    this.activeRoute.fragment.subscribe(params => {
      this.updateChart(params);
    });
  }

  updateChart(mode: string) {
    var stats = this.ngRedux.getState().stats;
    
    if(stats.length == 0) {
      setTimeout(() => { this.updateChart(mode); }, 50);
      return;
    }
    
    this.chartLabels = null;
    this.chartData = null;

    if(stats.length > 0) {
      var last = stats[stats.length - 1];
      var monthAgo = stats[stats.length - 30 - 1]; 

      this.guildsCount = last.guildsCount;
      this.membersCount = last.membersCount;
      this.commandsCount = last.executedCommandsCount;

      this.guildsCountChangeFromLastMonth = this.guildsCount - monthAgo.guildsCount;
      this.guildsCountChangeFromLastMonthPercent = (this.guildsCount * 100 / monthAgo.guildsCount) - 100;

      this.membersCountChangeFromLastMonth = this.membersCount - monthAgo.membersCount;
      this.membersCountChangeFromLastMonthPercent = (this.membersCount * 100 / monthAgo.membersCount) - 100;

      this.commandsCountChangeFromLastMonth = this.commandsCount - monthAgo.executedCommandsCount;
      this.commandsCountChangeFromLastMonthPercent = (this.commandsCount * 100 / monthAgo.executedCommandsCount) - 100;
    }

    var count = 100;
    var nth = stats.length / count;
    var reducedStats = [];

    for(var i = 0; i < count + 1; i++) {
      reducedStats.push(stats[Math.min(stats.length - 1, Math.round(i * nth))]);
    }

    this.chartLabels = reducedStats.map(p => new Date(p.createTime).toLocaleDateString());
    this.chartData = [
      {
        label: this.modeLabels.find(p => p.name == mode).label,
        data: this.getDataForMode(mode, reducedStats),
      },
      {
        label: "Trend line",
        data: this.trendService.getTrendLineValues(this.getDataForMode(mode, reducedStats)),
      }];
  }

  getDataForMode(mode: string, stats: StatsModel[]) {
    switch(mode) {
      case 'guilds': return stats.map(p => p.guildsCount);
      case 'members': return stats.map(p => p.membersCount);
      case 'commands': return stats.map(p => p.executedCommandsCount);
    }

    return [];
  }
}