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

  private modeLabels: any[];

  constructor(private activeRoute: ActivatedRoute, private ngRedux: NgRedux<IAppState>, private trendService: TrendService) {
    this.modeLabels = [
      { name: "guilds", label: "Guilds count" },
      { name: "members", label: "Members count" },
      { name: "commands", label: "Commands count" }
    ]
  }

  ngOnInit() {
    this.chartOptions = {
      responsive: true
    };

    this.activeRoute.params.subscribe(params => {
      this.updateChart(params.mode);
    });
  }

  updateChart(mode: string) {
    var stats = this.ngRedux.getState().stats;

    this.chartLabels = null;
    this.chartData = null;

    this.chartLabels = stats.map(p => new Date(p.createTime).toLocaleDateString());
    this.chartData = [
      {
        data: this.getDataForMode(mode, stats), label: this.modeLabels.find(p => p.name == mode).label
      },
      {
        data: this.trendService.getTrendLineValues(this.getDataForMode(mode, stats)), label: "Trend line"
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