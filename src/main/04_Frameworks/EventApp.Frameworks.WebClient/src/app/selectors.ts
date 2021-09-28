import { CampaignDto } from './models/campaign';
import { HobbyDto } from './models/hobby';
import { RootState } from './store';

export const selectCampaigns: (state: RootState) => CampaignDto[] = state => state.main.campaigns;
export const selectCampaign: (campaignId: string) => (state: RootState) => CampaignDto | undefined = campaignId => state => state.main.campaigns.find((campaign: any) => campaign["id"] === campaignId);
export const selectHobbies: (state: RootState) => HobbyDto[] = state => state.main.hobbies;
