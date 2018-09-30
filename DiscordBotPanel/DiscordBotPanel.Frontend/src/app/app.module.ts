import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ChartsModule } from 'ng2-charts';

import { AppComponent } from './app.component';
import { GuildStatsComponent } from './guild-stats/guild-stats.component';
import { MemberStatsComponent } from './member-stats/member-stats.component';
import { CommandStatsComponent } from './command-stats/command-stats.component';
import { AppRoutingModule } from './/app-routing.module';
import { RouterModule } from '@angular/router';
import { NgRedux, NgReduxModule, DevToolsExtension } from '@angular-redux/store';
import { IAppState, initialState, reducer } from './store';
import { composeWithDevTools } from 'redux-devtools-extension';
import { GuildSelectComponent } from './guild-select/guild-select.component';

@NgModule({
  declarations: [
    AppComponent,
    GuildStatsComponent,
    MemberStatsComponent,
    CommandStatsComponent,
    GuildSelectComponent
  ],
  imports: [
    BrowserModule,
    ChartsModule,
    AppRoutingModule,
    RouterModule,
    NgReduxModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule {
  constructor (ngRedux: NgRedux<IAppState>, devTools: DevToolsExtension) {
    ngRedux.configureStore(reducer, initialState, null, devTools.isEnabled() ? [ devTools.enhancer() ] : []);
  }
}
