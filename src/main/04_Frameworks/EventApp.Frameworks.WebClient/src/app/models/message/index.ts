import { CampaignFlatDto } from "../campaign";
import { UserFlatDto } from "../user";

export interface MessageDto {
    id: string;
    sender: UserFlatDto;
    campaign: CampaignFlatDto;
    text: string;
    created: Date;
}

export interface MessageFlatDto {
    id: string;
    senderId: string;
    campaignId: string;
    text: string;
    created: Date;
}