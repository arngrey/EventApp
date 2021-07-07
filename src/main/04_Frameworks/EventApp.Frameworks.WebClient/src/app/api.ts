import axios from "axios";

export async function fetchCampaigns() {
  return await axios.get("/api/campaigns")
}
