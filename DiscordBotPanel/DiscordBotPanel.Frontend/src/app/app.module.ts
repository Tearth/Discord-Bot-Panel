import { BotSelectComponent } from './components/bot-select/bot-select.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ChartsModule } from 'ng2-charts';

import { AppComponent } from './app.component';
import { GuildStatsComponent } from './components/guild-stats/guild-stats.component';
import { MemberStatsComponent } from './components/member-stats/member-stats.component';
import { CommandStatsComponent } from './components/command-stats/command-stats.component';
import { AppRoutingModule } from './/app-routing.module';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { NgRedux, NgReduxModule, DevToolsExtension } from '@angular-redux/store';
import { IAppState, initialState, reducer } from './store';
import { composeWithDevTools } from 'redux-devtools-extension';

@NgModule({
  declarations: [
    AppComponent,
    GuildStatsComponent,
    MemberStatsComponent,
    CommandStatsComponent,
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
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule {
  constructor (ngRedux: NgRedux<IAppState>, devTools: DevToolsExtension) {
    ngRedux.configureStore(reducer, initialState, null, devTools.isEnabled() ? [ devTools.enhancer() ] : []);
  }
}
