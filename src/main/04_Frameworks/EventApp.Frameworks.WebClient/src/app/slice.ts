import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { addParticipant, createCampaign, createHobby, fetchCampaignMessages, fetchCampaigns, fetchHobbies, sendMessage } from './api';
import { AppThunk, RootState } from './store';
import { CampaignDto } from './models/campaign';
import { HobbyDto } from './models/hobby';
import { MessageDto } from './models/message';


export interface AppState {
  campaigns: CampaignDto[];
  hobbies: HobbyDto[];
  campaignMessages: MessageDto[];
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
  const campaigns = await fetchCampaigns();
  dispatch(setCampaigns(campaigns))
}

export const loadHobbiesAsync = (): AppThunk => async (
  dispatch,
  getState
) => {
  const hobbies = await fetchHobbies();
  dispatch(setHobbies(hobbies))
}

export const loadCampaignMessagesAsync = (campaignId: string): AppThunk => async (
  dispatch,
  getState
) => {
  const campaignMessages = await fetchCampaignMessages(campaignId);
  dispatch(setCampaignMessages(campaignMessages))
}

export const sendMessageAsync = (userId: string, campaignId: string, text: string): AppThunk => async (
  dispatch,
  getState
) => {
  const response = await sendMessage(userId, campaignId, text);
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
    setCampaigns: (state, action: PayloadAction<CampaignDto[]>) => {
      state.campaigns = action.payload;
    },
    setHobbies: (state, action: PayloadAction<HobbyDto[]>) => {
      state.hobbies = action.payload;
    },
    setCampaignMessages: (state, action: PayloadAction<MessageDto[]>) => {
      state.campaignMessages = action.payload;
    }
  },
});

export const { setCampaigns, setHobbies, setCampaignMessages } = campaignSlice.actions;

export const selectCampaigns: (state: RootState) => CampaignDto[] = state => state.main.campaigns;
export const selectCampaign: (campaignId: string) => (state: RootState) => CampaignDto | undefined = campaignId => state => state.main.campaigns.find((campaign: any) => campaign["id"] === campaignId);
export const selectCampaignMessages: (state: RootState) => MessageDto[] = state => state.main.campaignMessages;
export const selectHobbies: (state: RootState) => HobbyDto[] = state => state.main.hobbies;

export default campaignSlice.reducer;
