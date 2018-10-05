import { BotModel } from './models/bot.model';
import { Action, Reducer, Store, createStore } from 'redux';
import { toBase64String } from '@angular/compiler/src/output/source_map';
import { tassign } from "tassign/"
import { StatsModel } from './models/stats.model';

export const LOAD_BOTS = 'LOAD_BOTS';
export const SELECT_BOT = 'SELECT_BOT';
export const LOAD_STATS = 'LOAD_STATS'

export interface IAppState {
    bots: BotModel[];
    selectedBotId: string;
    stats: StatsModel[];
};

export const initialState: IAppState = { 
    bots: [],
    selectedBotId: "",
    stats: []
};
 
export const reducer: Reducer<IAppState> = (state: IAppState = initialState, action): IAppState => {
  switch (action.type) {
    case LOAD_BOTS: return tassign(state, { bots: action.payload });
    case SELECT_BOT: return tassign(state, { selectedBotId: action.payload });
    case LOAD_STATS: return tassign(state, { stats: action.payload });
  }

  return state;
};