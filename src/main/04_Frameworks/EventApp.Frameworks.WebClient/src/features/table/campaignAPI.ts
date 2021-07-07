import axios from "axios";

export async function fetchCampaigns() {
  return await axios.get("http://localhost:5000/api/campaigns")
}
