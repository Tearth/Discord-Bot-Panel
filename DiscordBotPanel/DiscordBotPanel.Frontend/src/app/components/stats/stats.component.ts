import { IAppState } from './../../store';
import { Component, OnInit, ViewChild, SimpleChanges } from '@angular/core';
import { NgRedux } from '@angular-redux/store';
import { tassign } from 'tassign';
import { TrendService } from '../../services/trend.service';
import { ActivatedRoute } from '@angular/router';
import { BaseChartDirective } from 'ng2-charts';

@Component({
  selector: 'app-stats',
  templateUrl: './stats.component.html',
  styleUrls: ['./stats.component.css']
})
export class StatsComponent implements OnInit {
  @ViewChild(BaseChartDirective)
  public chart: BaseChartDirective;

  public chartOptions;
  public chartData;
  public chartLabels: string[];

  constructor(private activeRoute: ActivatedRoute, private ngRedux: NgRedux<IAppState>, private trendService: TrendService) {
    
  }

  ngOnInit() {
    this.chartOptions = {
      responsive: true
    };

    this.activeRoute.params.subscribe(fragment => {
      this.updateChart();
    });
  }

  updateChart() {
    var stats = this.ngRedux.getState().stats;

    this.chartLabels = null;
    this.chartData = null;

    this.chartLabels = stats.map(p => new Date(p.createTime).toLocaleDateString());
    this.chartData = [
      {
        data: stats.map(p => p.guildsCount), label: "Guilds count"
      },
      {
        data: this.trendService.getTrendLineValues(stats.map(p => p.guildsCount)), label: "Trend line"
      }];
  }
}