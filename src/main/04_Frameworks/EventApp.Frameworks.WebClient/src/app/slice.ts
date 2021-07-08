import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { addParticipant, createCampaign, createHobby, createUser, fetchCampaignMessages, fetchCampaigns, fetchHobbies, sendMessage } from './api';
import { AppThunk, RootState } from './store';

export interface AppState {
  campaigns: any;
  hobbies: any;
  campaignMessages: any;
}

const initialState: AppState = {
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

export const createUserAsync = (name: string): AppThunk => async (
  dispatch,
  getState
) => {
  const response = await createUser(name);
  console.log(response.data);
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
  },
});

export const { setCampaigns, setHobbies, setCampaignMessages } = campaignSlice.actions;

export const selectCampaigns = (state: RootState) => state.main.campaigns;
export const selectCampaignMessages = (state: RootState) => state.main.campaignMessages;
export const selectHobbies = (state: RootState) => state.main.hobbies;

export default campaignSlice.reducer;
