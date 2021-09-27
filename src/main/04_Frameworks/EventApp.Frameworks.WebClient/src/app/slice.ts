import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import axios from 'axios';
import { addParticipant, createCampaign, createHobby, signUp, signIn, fetchCampaignMessages, fetchCampaigns, fetchHobbies, sendMessage } from './api';
import { AppThunk, RootState } from './store';
import CryptoJs from "crypto-js";

export interface AppState {
  authentication: {
    isAuthenticated: boolean;
    userId?: string;
  }
  campaigns: any;
  hobbies: any;
  campaignMessages: any;
}

const initialState: AppState = {
  authentication: {
    isAuthenticated: false
  },
  campaigns: [],
  hobbies: [],
  campaignMessages: [],
};

export const loadCampaignsAsync = (): AppThunk => async (
  dispatch,
  getState
) => {
  const response = await fetchCampaigns();
  console.log(response.data);

  dispatch(setCampaigns(response.data))
}

export const loadHobbiesAsync = (): AppThunk => async (
  dispatch,
  getState
) => {
  const response = await fetchHobbies();
  console.log(response.data);

  dispatch(setHobbies(response.data))
}

export const loadCampaignMessagesAsync = (campaignId: string): AppThunk => async (
  dispatch,
  getState
) => {
  const response = await fetchCampaignMessages(campaignId);
  console.log(response.data);

  dispatch(setCampaignMessages(response.data))
}

export const sendMessageAsync = (userId: string, campaignId: string, text: string): AppThunk => async (
  dispatch,
  getState
) => {
  const response = await sendMessage(userId, campaignId, text);
  console.log(response.data);
}

export const signUpAsync = (login: string, password: string): AppThunk => async (
  dispatch,
  getState
) => {
  const response = await signUp(login, password);
  console.log(response.data);
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
    dispatch(setAuthentication({ 
      isAuthenticated: false, 
      userId: null
    }));

    delete axios.defaults.headers.common["Authorization"];
  } catch (e) {
    throw e;
  }
}

export const createHobbyAsync = (name: string): AppThunk => async (
  dispatch,
  getState
) => {
  const response = await createHobby(name);
  console.log(response.data);
}

export const addParticipantAsync = (userId: string, campaignId: string): AppThunk => async (
  dispatch,
  getState
) => {
  const response = await addParticipant(userId, campaignId);
  console.log(response.data);
}

export const createCampaignAsync = (name: string, administratorId: string, hobbyIds: Array<string>): AppThunk => async (
  dispatch,
  getState
) => {
  const response = await createCampaign(name, administratorId, hobbyIds);
  console.log(response.data);
}

export const campaignSlice = createSlice({
  name: 'main',
  initialState,
  reducers: {
    setCampaigns: (state, action: PayloadAction<any>) => {
      state.campaigns = action.payload;
    },
    setHobbies: (state, action: PayloadAction<any>) => {
      state.hobbies = action.payload;
    },
    setCampaignMessages: (state, action: PayloadAction<any>) => {
      state.campaignMessages = action.payload;
    },
    setAuthentication: (state, action: PayloadAction<any>) => {
      state.authentication.isAuthenticated = action.payload.isAuthenticated;
      state.authentication.userId = action.payload.userId;
    }
  },
});

export const { setCampaigns, setHobbies, setCampaignMessages, setAuthentication } = campaignSlice.actions;

export const selectCampaigns = (state: RootState) => state.main.campaigns;
export const selectCampaignMessages = (state: RootState) => state.main.campaignMessages;
export const selectHobbies = (state: RootState) => state.main.hobbies;
export const selectAuthentication = (state: RootState) => state.main.authentication;

export default campaignSlice.reducer;
