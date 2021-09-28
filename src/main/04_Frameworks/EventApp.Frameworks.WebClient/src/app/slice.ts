import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { addParticipant, createCampaign, createHobby, fetchCampaignMessages, fetchCampaigns, fetchHobbies, sendMessage } from './api';
import { AppThunk } from './store';
import { CampaignDto } from './models/campaign';
import { HobbyDto } from './models/hobby';
import { MessageDto } from './models/message';


export interface AppState {
  campaigns: CampaignDto[];
  hobbies: HobbyDto[];
}

const initialState: AppState = {
  campaigns: [],
  hobbies: [],
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
  dispatch(setCampaignMessages({
    campaignId: campaignId,
    campaignMessages: campaignMessages
  }))
}

export const sendMessageAsync = (userId: string, campaignId: string, text: string): AppThunk => async (
  dispatch,
  getState
) => {
  await sendMessage(userId, campaignId, text);
}

export const createHobbyAsync = (name: string): AppThunk => async (
  dispatch,
  getState
) => {
  await createHobby(name);
}

export const addParticipantAsync = (userId: string, campaignId: string): AppThunk => async (
  dispatch,
  getState
) => {
  await addParticipant(userId, campaignId);
}

export const createCampaignAsync = (name: string, administratorId: string, hobbyIds: Array<string>): AppThunk => async (
  dispatch,
  getState
) => {
  await createCampaign(name, administratorId, hobbyIds);
}

export interface ISetCampaignMessages {
  campaignId: string;
  campaignMessages: MessageDto[];
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
    setCampaignMessages: (state, action: PayloadAction<ISetCampaignMessages>) => {
      let campaign = state.campaigns.find(campaign => campaign.id === action.payload.campaignId);

      if (campaign === undefined) {
        throw "При сохранении сообщений кампании не найдена кампания по идентификатору.";
      }

      action.payload.campaignMessages.sort((a, b) => a.created < b.created ? 1 : -1);

      campaign.messages = action.payload.campaignMessages;
    }
  },
});

export const { setCampaigns, setHobbies, setCampaignMessages } = campaignSlice.actions;

export default campaignSlice.reducer;
