import { configureStore, ThunkAction, Action } from '@reduxjs/toolkit';

// import thunk from 'redux-thunk';
// import logger from 'redux-logger'

import authReducer from './authSlice';
import cartReducer from './cartSlice';
import counterReducer from '../features/counter/counterSlice';

export const store = configureStore({
  reducer: {
    auth: authReducer,
    cart: cartReducer,
    counter: counterReducer,
  }
});

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
export type AppThunk<ReturnType = void> = ThunkAction<
  ReturnType,
  RootState,
  unknown,
  Action<string>
>;
