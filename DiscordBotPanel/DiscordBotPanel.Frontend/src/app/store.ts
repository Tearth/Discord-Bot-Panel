import { BotModel } from './models/bot.model';
import { Action, Reducer, Store, createStore } from 'redux';
import { toBase64String } from '@angular/compiler/src/output/source_map';
import { tassign } from "tassign/"

export const LOAD_BOTS = 'LOAD_BOTS';
export const SELECT_BOT = 'SELECT_BOT';

export interface IAppState {
    bots: BotModel[];
    selectedBotId: number;
};

export const initialState: IAppState = { 
    bots: [],
    selectedBotId: 0
};
 
export const reducer: Reducer<IAppState> = (state: IAppState = initialState, action): IAppState => {
  switch (action.type) {
    case LOAD_BOTS: return tassign(state, { bots: action.payload });
    case SELECT_BOT: return tassign(state, { selectedBotId: action.payload });
  }

  return state;
};