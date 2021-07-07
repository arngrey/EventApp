import axios from "axios";

export async function fetchCampaigns() {
  return await axios.get(`/api/campaigns`)
}

export async function fetchHobbies() {
  return await axios.get(`/api/hobbies`)
}

export async function fetchCampaignMessages(campaignId: string) {
  return await axios.get(`/api/campaigns/${campaignId}/messages`);
}

export async function sendMessage(userId: string, campaignId: string, text: string) {
  return await axios.post(`/api/campaigns/${campaignId}/sendmessage`, {
    userId: userId,
    campaignId: campaignId,
    text: text
  });
}

export async function createUser(name: string) {
  return await axios.post(`/api/users/new`, {
    name: name
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


