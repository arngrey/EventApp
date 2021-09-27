import { createSlice, PayloadAction, SliceCaseReducers } from '@reduxjs/toolkit';
import axios from 'axios';
import { signIn, signUp } from './api';
import { AppThunk } from '../../store';
import CryptoJs from "crypto-js";
import { AuthenticationSetState, AuthenticationState, STATE_AUTHENTICATION_CLEARED } from '../../models/authentication';

export const signUpAsync = (login: string, password: string): AppThunk => async (
  dispatch,
  getState
) => {
  try {
    await signUp(login, password);
    await signInAsync(login, password);
  } catch (e) {
    throw e;
  }
}

export const signInAsync = (login: string, password: string): AppThunk => async (
  dispatch,
  getState
) => {
  try {
    const response = await signIn(login, password);

    dispatch(setAuthentication({ 
      isAuthenticated: true, 
      userId: response.data.id 
    }));

    const authWordArray = CryptoJs.enc.Utf8.parse(`${login}:${password}`);
    const authBase64 = CryptoJs.enc.Base64.stringify(authWordArray);
    axios.defaults.headers.common["Authorization"] = "Basic " + authBase64;
  } catch (e) {
    throw e;
  }
}

export const logOutAsync = (): AppThunk => async (
  dispatch,
  getState
) => {
  try {
    dispatch(clearAuthentication);

    delete axios.defaults.headers.common["Authorization"];
  } catch (e) {
    throw e;
  }
}

export const authenticationSlice = createSlice<AuthenticationState, SliceCaseReducers<AuthenticationState>, string>({
  name: 'authentication',
  initialState: STATE_AUTHENTICATION_CLEARED,
  reducers: {
    setAuthentication: (state, action: PayloadAction<AuthenticationSetState>) => {
      state.isAuthenticated = action.payload.isAuthenticated;

      if (state.isAuthenticated) {
        state.userId = action.payload.userId;
      }
    },
    clearAuthentication: (state) => {
      state = STATE_AUTHENTICATION_CLEARED;
    }
  },
});

export const { setAuthentication, clearAuthentication } = authenticationSlice.actions;

export default authenticationSlice.reducer;
