import { configureStore, ThunkAction, Action } from '@reduxjs/toolkit';
import mainReducer from './slice';
import authenticationReducer from './modules/authentication/slice';

export const store = configureStore({
  reducer: {
    main: mainReducer,
    authentication: authenticationReducer
  },
});

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
export type AppThunk<ReturnType = void> = ThunkAction<
  ReturnType,
  RootState,
  unknown,
  Action<string>
>;
