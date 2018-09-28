import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ChartsModule } from 'ng2-charts';

import { AppComponent } from './app.component';
import { GuildStatsComponent } from './guild-stats/guild-stats.component';
import { MemberStatsComponent } from './member-stats/member-stats.component';
import { CommandStatsComponent } from './command-stats/command-stats.component';

@NgModule({
  declarations: [
    AppComponent,
    GuildStatsComponent,
    MemberStatsComponent,
    CommandStatsComponent
  ],
  imports: [
    BrowserModule,
    ChartsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
