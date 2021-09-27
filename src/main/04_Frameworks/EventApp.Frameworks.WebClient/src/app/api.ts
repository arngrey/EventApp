import axios from "axios";
import { CampaignDto } from "./models/campaign";
import { HobbyDto } from "./models/hobby";
import { MessageDto } from "./models/message";

export async function fetchCampaigns(): Promise<CampaignDto[]> {
  const response = await axios.get(`/api/campaigns`);
  return response.data;
}

export async function fetchHobbies(): Promise<HobbyDto[]> {
  const response = await axios.get(`/api/hobbies`)
  return response.data;
}

export async function fetchCampaignMessages(campaignId: string): Promise<MessageDto[]> {
  const response = await axios.get(`/api/campaigns/${campaignId}/messages`);
  return response.data;
}

export async function sendMessage(userId: string, campaignId: string, text: string) {
  return await axios.post(`/api/campaigns/${campaignId}/sendmessage`, {
    userId: userId,
    campaignId: campaignId,
    text: text
  });
}

export async function createHobby(name: string) {
  return await axios.post(`/api/hobbies/new`, {
    name: name
  });
}

export async function addParticipant(userId: string, campaignId: string) {
  return await axios.post(`/api/campaigns/${campaignId}/addparticipant`, {
    userId: userId,
    campaignId: campaignId
  });
}

export async function createCampaign(name: string, administratorId: string, hobbyIds: Array<string>) {
  return await axios.post(`/api/campaigns/new`, {
    name: name,
    administratorId: administratorId,
    hobbyIds: hobbyIds
  });
}


