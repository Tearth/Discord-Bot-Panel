import { BotModel } from './models/bot.model';
import { Action, Reducer, Store, createStore } from 'redux';

export const LOAD_BOTS = 'LOAD_BOTS';

export interface IAppState {
    bots: BotModel[];
};

export const initialState: IAppState = { 
    bots: []
};
 
export const reducer: Reducer<IAppState> =
  (state: IAppState, action): IAppState => {
  switch (action.type) {
    case LOAD_BOTS:
      return { bots: action.payload };
  }};