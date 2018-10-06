import { StatsModel } from './../models/stats.model';
import { Observable } from 'rxjs';
import { BotModel } from './../models/bot.model';
import { ApiService } from './api.service';
import { Injectable } from '@angular/core';
import { HttpClient } from 'selenium-webdriver/http';

@Injectable({
  providedIn: 'root'
})
export class TrendService {
  getTrendLineValues(stats: number[]): number[] {
    var domain = this.createRangedArray(1, stats.length);
    var xAverage = this.calculateAverage(domain);
    var yAverage = this.calculateAverage(stats);

    var xDeviation = this.calculateDeviation(xAverage, domain, 1);
    var xPowDeviation = this.calculateDeviation(xAverage, domain, 2);
    var yDeviation = this.calculateDeviation(yAverage, stats, 1);

    var sumOfDeviations = 0;
    for(var i = 0; i < stats.length; i++) {
      sumOfDeviations += (domain[i] - xAverage) * (stats[i] - yAverage);
    }

    var a = sumOfDeviations / xPowDeviation;
    var b = yAverage - (a * xAverage);

    var trendLineValues = [];
    for(var x of domain) {
      trendLineValues.push(Math.max(0, (a * x) + b));
    }

    return trendLineValues;
  }

  calculateAverage(values: number[]){
    var average = 0;
    for(var number of values) {
      average += number;
    }

    return average / values.length;
  }

  calculateDeviation(average: number, values: number[], power: number) {
    var sum = 0;
    for(var number of values) {
      sum += Math.pow(number - average, power);
    }

    return sum;
  }

  createRangedArray(start: number, end: number) {
    var array = [];
    for (var i = start; i <= end; i++) {
      array.push(i);
    }
    return array;
  }
}
