import { Action, Reducer, Store, createStore } from 'redux';

export interface IAppState {
    counter: number;
};

export const initialState: IAppState = { 
    counter: 123
};
 
export const reducer: Reducer<IAppState> =
  (state: IAppState, action: Action): IAppState => {
  switch (action.type) {
  case 'ADD_MESSAGE':
    return {
      counter: 999
    };
  }};