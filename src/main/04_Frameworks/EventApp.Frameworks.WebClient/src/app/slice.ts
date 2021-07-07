import { createAsyncThunk, createSlice, PayloadAction } from '@reduxjs/toolkit';
import { fetchCampaigns } from './api';
import { RootState } from './store';

export interface AppState {
  campaigns: any;
}

const initialState: AppState = {
  campaigns: []
};

export const loadCampaignsAsync = createAsyncThunk(
  'campaign',
  async () => {
    const response = await fetchCampaigns();
    console.log(response.data);
    load({
      payload: response.data
    })
  }
);

export const campaignSlice = createSlice({
  name: 'campaign',
  initialState,
  reducers: {
    load: (state, action: PayloadAction<any>) => {
      state.campaigns = action.payload;
    },
  },
});

export const { load } = campaignSlice.actions;

export const selectCampaigns = (state: RootState) => state.main.campaigns;

export default campaignSlice.reducer;
