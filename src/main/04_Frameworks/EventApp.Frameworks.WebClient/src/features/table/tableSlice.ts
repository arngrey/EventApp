import { createAsyncThunk, createSlice, PayloadAction } from '@reduxjs/toolkit';
import { fetchCampaigns } from './campaignAPI';

export interface TableState {
  data: any;
}

const initialState: TableState = {
  data: []
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
      state.data = action.payload;
    },
  },
});

export const { load } = campaignSlice.actions;

export default campaignSlice.reducer;
