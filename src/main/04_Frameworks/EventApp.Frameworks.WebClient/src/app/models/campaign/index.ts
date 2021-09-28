import { HobbyFlatDto } from "../hobby";
import { MessageDto } from "../message";
import { UserFlatDto } from "../user";

export interface CampaignDto {
    id: string;
    name: string;
    administrator: UserFlatDto,
    hobbies: Array<HobbyFlatDto>,
    participants: Array<UserFlatDto>,
    messages?: Array<MessageDto>
}

export interface CampaignFlatDto {
    id: string;
    name: string;
    administratorId: string,
    hobbyIds: Array<string>,
    participantIds: Array<string>,
    messageIds: Array<string>
}