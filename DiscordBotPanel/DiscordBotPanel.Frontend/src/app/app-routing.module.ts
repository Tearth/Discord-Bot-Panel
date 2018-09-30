import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { GuildStatsComponent } from './guild-stats/guild-stats.component';
import { MemberStatsComponent } from './member-stats/member-stats.component';
import { CommandStatsComponent } from './command-stats/command-stats.component';

const routes: Routes = [
  { path: 'guilds', component: GuildStatsComponent },
  { path: 'members', component: MemberStatsComponent },
  { path: 'commands', component: CommandStatsComponent }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  declarations: []
})
export class AppRoutingModule { }