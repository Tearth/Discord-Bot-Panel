import { GlobalErrorHandler } from './global-error-handler';
import { BotSelectComponent } from './components/bot-select/bot-select.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { ChartsModule, BaseChartDirective } from 'ng2-charts';

import { AppComponent } from './app.component';
import { StatsComponent } from './components/stats/stats.component';
import { AppRoutingModule } from './/app-routing.module';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { NgRedux, NgReduxModule, DevToolsExtension } from '@angular-redux/store';
import { IAppState, initialState, reducer } from './store';
import { composeWithDevTools } from 'redux-devtools-extension';

@NgModule({
  declarations: [
    AppComponent,
    StatsComponent,
    BotSelectComponent
  ],

  imports: [
    BrowserModule,
    ChartsModule,
    AppRoutingModule,
    RouterModule,
    NgReduxModule,
    HttpClientModule
  ],

  providers:
  [
    {
      provide: ErrorHandler,
      useClass: GlobalErrorHandler
    }
  ],

  bootstrap: [AppComponent]
})

export class AppModule {
  constructor (ngRedux: NgRedux<IAppState>, devTools: DevToolsExtension) {
    ngRedux.configureStore(reducer, initialState, null, devTools.isEnabled() ? [ devTools.enhancer() ] : []);
  }
}

// Workaround for chartjs with update method
// https://stackoverflow.com/a/52005147/2066024
BaseChartDirective.prototype.ngOnChanges = function (changes) {
  if (this.initFlag) {
      // Check if the changes are in the data or datasets
      if (changes.hasOwnProperty('data') || changes.hasOwnProperty('datasets')) {
          if (changes['data']) {
              this.updateChartData(changes['data'].currentValue);
          }
          else {
              this.updateChartData(changes['datasets'].currentValue);
          }
          // add label change detection every time
          if (changes['labels']) { 
              if (this.chart && this.chart.data && this.chart.data.labels) {
                  this.chart.data.labels = changes['labels'].currentValue;    
              }
          }
          this.chart.update();
      }
      else {
          // otherwise rebuild the chart
          this.refresh();
      }
  }};
