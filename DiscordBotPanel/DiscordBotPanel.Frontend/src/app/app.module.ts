import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ChartsModule } from 'ng2-charts';

import { AppComponent } from './app.component';
import { GuildStatsComponent } from './guild-stats/guild-stats.component';
import { MemberStatsComponent } from './member-stats/member-stats.component';
import { CommandStatsComponent } from './command-stats/command-stats.component';
import { AppRoutingModule } from './/app-routing.module';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
    GuildStatsComponent,
    MemberStatsComponent,
    CommandStatsComponent
  ],
  imports: [
    BrowserModule,
    ChartsModule,
    AppRoutingModule,
    RouterModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
